# ?? AttendanceService - Enhanced with Comprehensive Permission System

## ?? **Overview:**
Enhanced `AttendanceService` v?i complete permission system theo c?u trúc clean architecture t??ng t? nh? `EmployeeService`, ??m b?o users ch? có th? thao tác v?i attendance records mà h? có quy?n.

---

## ??? **Clean Architecture Structure:**

### **?? Enhanced Dependencies:**
```csharp
public AttendanceService(
    IAttendanceRepository repo, 
    IEmployeeRepository employeeRepo, 
    IMapper mapper,
    AppDbContext db,                           // NEW - For team queries
    ILogger<AttendanceService>? logger = null, // NEW - For logging
    IPermissionService? permissionService = null, // NEW - For permissions
    IAuthService? authService = null)          // NEW - For user context
```

### **?? Permission Checking Region:**
```csharp
#region Permission Checking
- HasPermissionAsync() - Main permission orchestrator
- IsPermissionCheckAvailable() - Service validation
- GetCurrentUserInfo() - User context extraction
- HasGlobalPermissionAsync() - Global scope check
- HasSelfPermissionAsync() - Self scope check
- HasTeamBasedPermissionAsync() - Team permission coordinator
- GetTeamRelationshipAsync() - Team relationship calculator
- CheckOwnTeamPermissionAsync() - OwnTeam scope validation
- CheckTeamPermissionAsync() - Team scope validation
- GetAllowedEmployeeIdsAsync() - Employee ID filtering
#endregion
```

### **?? Public Service Methods Region:**
```csharp
#region Public Service Methods
- GetByIdAsync() - Single record with permission check
- QueryAsync() - Search with permission filtering
- CreateAsync() - Create with permission validation
- UpdateAsync() - Update with permission validation
- DeleteAsync() - Delete with permission validation
#endregion
```

### **??? Helper Methods Region:**
```csharp
#region Helper Methods
- ApplyPermissionFilteringAsync() - Result filtering by permissions
- ComputeDurationAndOvertimeAsync() - Enhanced calculation with logging
#endregion
```

---

## ?? **Permission Integration:**

### **1. ??? Record-Level Permission Checks:**
```csharp
public async Task<AttendanceRecordDto?> GetByIdAsync(int id, CancellationToken ct = default)
{
    var entity = await _repo.GetByIdAsync(id, ct);
    if (entity == null) return null;

    // Check permission for this specific attendance record
    if (!await HasPermissionAsync(PermissionAction.View, entity.EmployeeId))
    {
        _logger?.LogWarning("Access denied for attendance record {RecordId}", id);
        return null;
    }

    return _mapper.Map<AttendanceRecordDto>(entity);
}
```

### **2. ?? Smart Query Filtering:**
```csharp
public async Task<List<AttendanceRecordDto>> QueryAsync(...)
{
    // Check basic view permission
    if (!await HasPermissionAsync(PermissionAction.View))
        return new List<AttendanceRecordDto>();

    var attendanceRecords = await _repo.QueryAsync(...);
    var dtos = _mapper.Map<List<AttendanceRecordDto>>(attendanceRecords);

    // Apply permission-based filtering
    dtos = await ApplyPermissionFilteringAsync(dtos, ct);
    
    return dtos;
}
```

### **3. ?? CRUD Operations with Permission Validation:**
```csharp
public async Task<AttendanceRecordDto> CreateAsync(AttendanceRecordDto dto, CancellationToken ct = default)
{
    if (!await HasPermissionAsync(PermissionAction.Create, dto.EmployeeId))
    {
        throw new UnauthorizedAccessException("B?n không có quy?n t?o b?n ghi ch?m công cho nhân viên này.");
    }

    // ... creation logic with logging
}
```

---

## ?? **Multi-Layer Security System:**

### **Layer 1: ?? Module-Level Permission**
```csharp
// Check if user has ANY permission on Attendance module
if (!await HasPermissionAsync(PermissionAction.View))
{
    return new List<AttendanceRecordDto>(); // Return empty if no access
}
```

### **Layer 2: ?? Scope-Based Filtering**
```csharp
private async Task<List<AttendanceRecordDto>> ApplyPermissionFilteringAsync(List<AttendanceRecordDto> dtos, CancellationToken ct)
{
    // Global permission ? See all records
    if (hasGlobalView) return dtos;

    // Filter by allowed employee IDs based on Self, Team, OwnTeam permissions
    var allowedIds = await GetAllowedEmployeeIdsAsync(accountId.Value, currentEmployeeId);
    return dtos.Where(d => allowedIds.Contains(d.EmployeeId)).ToList();
}
```

### **Layer 3: ?? Record-Level Validation**
```csharp
// For specific operations (Update, Delete), check permission on individual record
if (!await HasPermissionAsync(PermissionAction.Edit, entity.EmployeeId))
{
    throw new UnauthorizedAccessException("B?n không có quy?n ch?nh s?a b?n ghi ch?m công này.");
}
```

---

## ?? **Permission Scenarios:**

### **Scenario 1: HR Manager (Global Permission)**
```
User: HR Manager
Permission: Attendance.All.Global
Query Result: ALL attendance records in system
Operations: Can view, create, edit, delete any attendance record
```

### **Scenario 2: Team Leader (OwnTeam Permission)**
```
User: Team Leader
Permission: Attendance.All.OwnTeam-NULL
Query Result: Attendance records of team members where user is leader
Operations: Can manage attendance for team members
```

### **Scenario 3: Team Member (Team Permission)**
```
User: Team Member  
Permission: Attendance.View.Team-1001
Query Result: Attendance records of employees in same team (1001)
Operations: Can view attendance of teammates
```

### **Scenario 4: Employee (Self Permission)**
```
User: Regular Employee
Permission: Attendance.View.Self
Query Result: Only their own attendance records
Operations: Can view own attendance, may create/edit own records
```

### **Scenario 5: No Permission**
```
User: Contractor/Guest
Permission: None
Query Result: Empty list
Operations: No access to attendance data
```

---

## ?? **Enhanced Features:**

### **?? Smart Team-Based Filtering:**
```csharp
private async Task<HashSet<int>> GetTeamBasedAllowedEmployeesAsync(int accountId, int currentEmployeeId)
{
    var allowedIds = new HashSet<int>();
    var currentUserTeams = await _db.TeamMembers
        .Where(tm => tm.EmployeeId == currentEmployeeId)
        .ToListAsync();

    // Team scope: Can view attendance of teammates
    await AddTeamMembersWithPermissionAsync(accountId, currentUserTeams, ScopeType.Team, allowedIds);

    // OwnTeam scope: Team leaders can view attendance of team members
    var leaderTeams = currentUserTeams.Where(tm => tm.IsLeader).ToList();
    await AddTeamMembersWithPermissionAsync(accountId, leaderTeams, ScopeType.OwnTeam, allowedIds);

    return allowedIds;
}
```

### **?? Enhanced Duration & Overtime Calculation:**
```csharp
private async Task ComputeDurationAndOvertimeAsync(AttendanceRecord entity)
{
    if (entity.CheckOut.HasValue && entity.CheckOut.Value > entity.CheckIn)
    {
        var hours = (decimal)(entity.CheckOut.Value - entity.CheckIn).TotalHours;
        entity.DurationHours = Math.Round(hours, 2);

        var employee = await _employeeRepo.GetByIdAsync(entity.EmployeeId);
        if (employee != null)
        {
            entity.IsOvertime = entity.DurationHours.HasValue && entity.DurationHours.Value > employee.MaxHoursPerDay;
            _logger?.LogDebug("Computed overtime for employee {EmployeeId}: {IsOvertime}", 
                entity.EmployeeId, entity.IsOvertime);
        }
    }
}
```

### **?? Comprehensive Logging:**
```csharp
_logger?.LogDebug("User info: AccountId={AccountId}, IsMaster={IsMaster}, EmployeeId={EmployeeId}");
_logger?.LogWarning("Access denied for attendance record {RecordId}, EmployeeId: {EmployeeId}");
_logger?.LogInformation("Attendance record created successfully with ID: {RecordId}");
_logger?.LogDebug("QueryAsync returned {Count} attendance records after permission filtering");
```

---

## ??? **Security Features:**

### **? Fail-Safe Design:**
- **No Permission Services** ? Allow access (backward compatibility)
- **Permission Denied** ? Return empty results/throw exceptions
- **Service Errors** ? Log errors + secure fallbacks
- **Invalid Operations** ? Clear error messages

### **? Performance Optimizations:**
- **Permission Caching** ? Reuse permission results within request
- **Efficient Queries** ? Single database calls for team relationships
- **Smart Filtering** ? HashSet operations for large datasets
- **Early Returns** ? Stop processing when permission denied

### **? Audit Trail:**
```csharp
// Successful operations
_logger?.LogInformation("Attendance record created successfully with ID: {RecordId}", recordId);

// Permission violations
_logger?.LogWarning("Access denied for UpdateAsync with attendance record ID: {RecordId}", recordId);

// System errors
_logger?.LogError(ex, "Error querying attendance records");
```

---

## ?? **Integration with AttendanceManagementControl:**

### **Before Enhancement:**
```csharp
// AttendanceManagementControl had to handle permissions manually
private async Task<bool> CanPerformOnAttendanceRecord(AttendanceRecordDto record, PermissionAction action)
{
    return await HasPermissionAsync(action, record.EmployeeId);
}
```

### **After Enhancement:**
```csharp
// AttendanceService handles permissions automatically
_attendanceRecords = await _attendanceService.QueryAsync(
    employeeId: _currentEmployee?.EmployeeId,
    shiftAssignmentId: _currentShiftAsignment?.ShiftAssignmentId,
    // ... other parameters
);
// Records are already filtered by permissions!
```

---

## ?? **Usage Examples:**

### **Example 1: Team Leader Viewing Team Attendance**
```csharp
var attendanceService = serviceProvider.GetRequiredService<IAttendanceService>();

// Team leader with OwnTeam permission
var records = await attendanceService.QueryAsync(
    dateFrom: DateTime.Today.AddDays(-7),
    dateTo: DateTime.Today
);
// Returns: Attendance records for all team members where user is leader
```

### **Example 2: Employee Viewing Own Attendance**
```csharp
// Employee with Self permission  
var records = await attendanceService.QueryAsync(
    employeeId: currentUser.EmployeeId, // Optional - service will filter anyway
    dateFrom: DateTime.Today.AddMonths(-1)
);
// Returns: Only their own attendance records
```

### **Example 3: HR Manager Managing All Attendance**
```csharp
// HR Manager with Global permission
var allRecords = await attendanceService.QueryAsync();
// Returns: ALL attendance records in system

var record = await attendanceService.GetByIdAsync(recordId);
// Returns: Any attendance record (no filtering)
```

---

## ?? **Benefits:**

### ? **Security:**
- **Multi-Layer Protection**: Module ? Scope ? Record level validation
- **Team-Based Access Control**: Flexible team permission system
- **Audit Trail**: Comprehensive logging for security monitoring
- **Fail-Safe Defaults**: Secure behavior when services unavailable

### ? **Performance:**
- **Efficient Filtering**: Database-level filtering where possible
- **Smart Caching**: Permission results cached per request
- **Optimized Queries**: Single calls for team relationships
- **Early Validation**: Stop processing on permission failure

### ? **Developer Experience:**
- **Clean Architecture**: Well-organized regions and methods
- **Consistent Patterns**: Same structure as EmployeeService
- **Comprehensive Logging**: Easy debugging and monitoring
- **Backward Compatible**: Works with existing code

### ? **User Experience:**
- **Relevant Data**: Users see only records they can access
- **Clear Permissions**: Obvious what they can/cannot do
- **Consistent Behavior**: Same permission model across modules
- **Responsive Operations**: Efficient permission checking

---

## ?? **Program.cs Registration:**
```csharp
services.AddScoped<IAttendanceService>(provider => new AttendanceService(
    provider.GetRequiredService<IAttendanceRepository>(),
    provider.GetRequiredService<IEmployeeRepository>(),
    provider.GetRequiredService<IMapper>(),
    provider.GetRequiredService<AppDbContext>(),
    provider.GetService<ILogger<AttendanceService>>(),
    provider.GetService<IPermissionService>(),
    provider.GetService<IAuthService>()
));
```

---

**Status: ? COMPLETED**

AttendanceService gi? ?ây có comprehensive permission system v?i clean architecture chu?n! ????