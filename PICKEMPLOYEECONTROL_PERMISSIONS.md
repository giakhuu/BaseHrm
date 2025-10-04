# ?? PickEmployeeControl - Enhanced with Permission System

## ?? **Tính n?ng ?ã thêm:**
Enhanced `PickEmployeeControl` v?i comprehensive permission system ?? ??m b?o users ch? th?y employees mà h? có quy?n access.

---

## ??? **Architecture Enhancements:**

### **?? Dependency Injection:**
```csharp
public PickEmployeeControl(
    IEmployeeService employeeService,
    IPermissionService? permissionService = null,    // NEW
    IAuthService? authService = null,                // NEW  
    ILogger<PickEmployeeControl>? logger = null)     // NEW
```

### **?? Permission Fields:**
```csharp
private readonly IPermissionService? _permissionService;
private readonly IAuthService? _authService;
private readonly ILogger<PickEmployeeControl>? _logger;

// Permission state
private int? _currentAccountId;
private bool _isMasterAccount; 
private int? _currentEmployeeId;
```

### **??? Advanced Filtering Properties:**
```csharp
// Custom employee filter
public Func<EmployeeDto, bool>? EmployeeFilter { get; set; }

// Restrict to specific teams
public List<int>? RestrictToTeamIds { get; set; }
```

---

## ?? **Permission Integration:**

### **1. ?? Permission Initialization:**
```csharp
private async Task InitializePermissionsAsync()
{
    if (_authService != null)
    {
        var userInfo = _authService.GetUserInfoFromToken();
        _currentAccountId = userInfo.AccountId;
        _isMasterAccount = userInfo.IsMaster;
        _currentEmployeeId = userInfo.EmployeeId;
    }
}
```

### **2. ??? Permission Validation:**
```csharp
private async Task<bool> HasPermissionToViewEmployeesAsync()
{
    if (_isMasterAccount) return true;
    
    if (_permissionService == null || !_currentAccountId.HasValue)
        return true; // Backward compatibility
    
    // Use HasModuleAccessAsync for flexible permission check
    return await _permissionService.HasModuleAccessAsync(
        _currentAccountId.Value, ModuleName.Employee, PermissionAction.View);
}
```

### **3. ?? Smart Employee Loading:**
```csharp
private async Task LoadEmployeesAsync()
{
    // Check permission first
    if (!await HasPermissionToViewEmployeesAsync())
    {
        _employees = new List<EmployeeDto>();
        UpdateDataSource();
        return;
    }

    // Load from service (already permission-filtered)
    var allEmployees = await _employeeService.SearchEmployeesAsync(searchQuery);
    
    // Apply additional filters
    _employees = ApplyAdditionalFilters(allEmployees);
    UpdateDataSource();
}
```

---

## ?? **Multi-Layer Filtering System:**

### **Layer 1: ?? Service-Level Permission Filtering**
- `EmployeeService.SearchEmployeesAsync()` already applies permission filtering
- Returns only employees user has permission to see
- Handles Global, Self, Team, OwnTeam scopes

### **Layer 2: ?? Team Restriction (Optional)**
```csharp
// Restrict to specific teams
if (RestrictToTeamIds?.Any() == true)
{
    filteredEmployees = filteredEmployees.Where(emp => 
        emp.TeamIds?.Any(teamId => RestrictToTeamIds.Contains(teamId)) == true);
}
```

### **Layer 3: ?? Custom Filter (Optional)**
```csharp
// Apply custom business logic filter
if (EmployeeFilter != null)
{
    filteredEmployees = filteredEmployees.Where(EmployeeFilter);
}
```

### **Layer 4: ? Active Status Filter**
```csharp
// Filter out inactive employees by default
filteredEmployees = filteredEmployees.Where(emp => emp.IsActive);
```

---

## ?? **Advanced Features:**

### **?? Dynamic Filtering Methods:**
```csharp
// Restrict to specific teams
await picker.RestrictToTeamsAsync(new List<int> { 1001, 1002 });

// Apply custom filter (e.g., only developers)
await picker.ApplyFilterAsync(emp => emp.Position?.Contains("Developer") == true);

// Clear all filters
await picker.ClearFiltersAsync();

// Refresh data
await picker.RefreshAsync();
```

### **?? Usage Examples:**

#### **Example 1: Team Leader Picking Team Members**
```csharp
var picker = serviceProvider.GetRequiredService<PickEmployeeControl>();

// Restrict to current user's teams
var currentUserTeams = await GetCurrentUserTeamIds();
await picker.RestrictToTeamsAsync(currentUserTeams);

// Only show active team members
await picker.ApplyFilterAsync(emp => emp.IsActive && emp.TeamIds?.Any() == true);

picker.EmployeeSelected += (employee) => {
    // Handle team member selection
    Console.WriteLine($"Selected team member: {employee.FullName}");
};
```

#### **Example 2: HR Manager Picking All Employees**
```csharp
var picker = serviceProvider.GetRequiredService<PickEmployeeControl>();

// HR Manager with Global permissions will see all employees
// No additional filters needed

picker.EmployeeSelected += (employee) => {
    // Handle employee selection for HR operations
    Console.WriteLine($"Selected employee: {employee.FullName}");
};
```

#### **Example 3: Project Manager Picking by Position**
```csharp
var picker = serviceProvider.GetRequiredService<PickEmployeeControl>();

// Only show developers and testers
await picker.ApplyFilterAsync(emp => 
    emp.Position?.Contains("Developer") == true || 
    emp.Position?.Contains("Tester") == true);

picker.EmployeeSelected += (employee) => {
    // Handle developer/tester selection
    Console.WriteLine($"Selected {employee.Position}: {employee.FullName}");
};
```

---

## ??? **Security Features:**

### **? Multi-Level Security:**
1. **Authentication Check** ? Ensure user is logged in
2. **Module Permission** ? Check Employee.View permission  
3. **Service Filtering** ? EmployeeService applies scope-based filtering
4. **Additional Filters** ? Team/custom business rules

### **? Fail-Safe Design:**
- **No Permission Service** ? Allow access (backward compatibility)
- **Permission Check Fails** ? Show empty list
- **Service Call Fails** ? Show error message + empty list
- **Filter Errors** ? Log error + continue with unfiltered data

### **? Comprehensive Logging:**
```csharp
_logger?.LogDebug("PickEmployeeControl initialized - AccountId: {AccountId}, IsMaster: {IsMaster}");
_logger?.LogDebug("Retrieved {Count} employees from service");
_logger?.LogDebug("After additional filtering: {Count} employees");
_logger?.LogDebug("Employee selected: {EmployeeId} - {FullName}");
```

---

## ?? **Permission Scenarios:**

### **Scenario 1: Master Account**
```
User: Master Admin
Permission: All
Result: Sees ALL employees in system
Filter Applied: None (full access)
```

### **Scenario 2: HR Manager**
```
User: HR Manager  
Permission: Employee.View.Global
Result: Sees ALL employees
Filter Applied: Service-level (none, has global access)
```

### **Scenario 3: Team Leader**
```
User: Team Leader
Permission: Employee.View.OwnTeam-NULL
Result: Sees employees in teams where user is leader
Filter Applied: Service-level (team-based filtering)
```

### **Scenario 4: Regular Employee**
```
User: Regular Employee
Permission: Employee.View.Self
Result: Sees only themselves
Filter Applied: Service-level (self-only)
```

### **Scenario 5: No Permission**
```
User: Contractor
Permission: None
Result: Sees empty list
Filter Applied: Permission denied
```

---

## ?? **Testing & Debugging:**

### **Debug Information:**
```
PickEmployeeControl initialized - AccountId: 16, IsMaster: False, EmployeeId: 101
User has employee view access: True
Loading employees with search query: 'John'
Retrieved 25 employees from service
Applied team restriction to teams: 1001, 1002
After additional filtering: 8 employees
Employee selected: 105 - John Smith
```

### **Error Handling:**
```csharp
try
{
    await LoadEmployeesAsync();
}
catch (Exception ex)
{
    _logger?.LogError(ex, "Error loading employees");
    MessageBox.Show("L?i t?i danh sách nhân viên. Vui lòng th? l?i.", "L?i", 
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
```

---

## ?? **Benefits:**

### ? **Security:**
- **Permission-Aware**: Respects user permissions at multiple levels
- **Fail-Safe**: Secure defaults when services unavailable
- **Audit Trail**: Comprehensive logging for security monitoring

### ? **Flexibility:**
- **Dynamic Filtering**: Runtime filter application
- **Team Restrictions**: Easy team-based filtering
- **Custom Logic**: Extensible with business rules

### ? **User Experience:**
- **Relevant Data**: Users see only employees they can access
- **Fast Search**: Efficient filtering and search
- **Clear Feedback**: Status updates and error messages

### ? **Maintainability:**
- **Clean Architecture**: Well-organized regions và methods
- **Dependency Injection**: Proper service integration
- **Comprehensive Logging**: Easy debugging và monitoring

---

**Status: ? COMPLETED**

PickEmployeeControl gi? ?ây có comprehensive permission system và advanced filtering capabilities! ????