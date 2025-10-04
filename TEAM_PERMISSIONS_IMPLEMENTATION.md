# ?? Team-Based Permission Implementation in EmployeeService

## ?? **M?c ?ích:**
Implement các comment "Team-based permission checks would go here..." trong `EmployeeService.cs` ?? h? tr? ??y ?? các lo?i scope permissions: Self, Team, và OwnTeam.

## ?? **Code ?ã implement:**

### 1. **HasPermissionAsync - Team Permission Logic**

```csharp
// Team-based permission checks
if (employeeId.HasValue && userInfo.EmployeeId.HasValue)
{
    // Get current user's employee data
    var currentEmployee = await _repo.GetByIdAsync(userInfo.EmployeeId.Value);
    if (currentEmployee != null)
    {
        // Get target employee's teams
        var targetEmployeeTeams = await _db.TeamMembers
            .Where(tm => tm.EmployeeId == employeeId.Value)
            .Select(tm => tm.TeamId)
            .ToListAsync();

        // Get current user's teams where they are leaders
        var currentUserLeaderTeams = await _db.TeamMembers
            .Where(tm => tm.EmployeeId == userInfo.EmployeeId.Value && tm.IsLeader)
            .Select(tm => tm.TeamId)
            .ToListAsync();

        // Check OwnTeam permission (user is leader of target employee's team)
        var commonLeaderTeams = targetEmployeeTeams.Intersect(currentUserLeaderTeams).ToList();
        foreach (var teamId in commonLeaderTeams)
        {
            var hasOwnTeamPermission = await _permissionService.HasPermissionAsync(
                userInfo.AccountId.Value, ModuleName.Employee, action, ScopeType.OwnTeam, teamId);
            if (hasOwnTeamPermission) return true;
        }

        // Check Team permission (user and target are in same team)
        var currentUserTeams = await _db.TeamMembers
            .Where(tm => tm.EmployeeId == userInfo.EmployeeId.Value)
            .Select(tm => tm.TeamId)
            .ToListAsync();

        var commonTeams = targetEmployeeTeams.Intersect(currentUserTeams).ToList();
        foreach (var teamId in commonTeams)
        {
            var hasTeamPermission = await _permissionService.HasPermissionAsync(
                userInfo.AccountId.Value, ModuleName.Employee, action, ScopeType.Team, teamId);
            if (hasTeamPermission) return true;
        }
    }
}
```

### 2. **SearchEmployeesAsync - Team Filtering Logic**

```csharp
// Team permissions
if (currentEmployeeId.HasValue)
{
    // Get teams where current user is a member
    var currentUserTeams = await _db.TeamMembers
        .Where(tm => tm.EmployeeId == currentEmployeeId.Value)
        .ToListAsync(ct);

    // Check Team scope permissions
    foreach (var userTeam in currentUserTeams)
    {
        var hasTeamPermission = await _permissionService.HasPermissionAsync(
            acctId, ModuleName.Employee, PermissionAction.View, ScopeType.Team, userTeam.TeamId, ct);
        
        if (hasTeamPermission)
        {
            // Add all team members to allowed list
            var teamMemberIds = await _db.TeamMembers
                .Where(tm => tm.TeamId == userTeam.TeamId)
                .Select(tm => tm.EmployeeId)
                .ToListAsync(ct);
            
            foreach (var memberId in teamMemberIds)
            {
                allowedEmployeeIds.Add(memberId);
            }
        }
    }

    // Check OwnTeam scope permissions (teams where user is leader)
    var leaderTeams = currentUserTeams.Where(ut => ut.IsLeader).ToList();
    foreach (var leaderTeam in leaderTeams)
    {
        var hasOwnTeamPermission = await _permissionService.HasPermissionAsync(
            acctId, ModuleName.Employee, PermissionAction.View, ScopeType.OwnTeam, leaderTeam.TeamId, ct);
        
        if (hasOwnTeamPermission)
        {
            // Add all team members to allowed list
            var teamMemberIds = await _db.TeamMembers
                .Where(tm => tm.TeamId == leaderTeam.TeamId)
                .Select(tm => tm.EmployeeId)
                .ToListAsync(ct);
            
            foreach (var memberId in teamMemberIds)
            {
                allowedEmployeeIds.Add(memberId);
            }
        }
    }
}
```

---

## ?? **Logic Flow:**

### **HasPermissionAsync Method:**

1. **Global Check** ? N?u có quy?n Global ? Allow
2. **Self Check** ? N?u target là chính mình và có quy?n Self ? Allow  
3. **OwnTeam Check** ? N?u user là leader c?a team mà target thu?c v? ? Allow
4. **Team Check** ? N?u user và target cùng team và có quy?n Team ? Allow
5. **Deny** ? N?u không th?a mãn ?i?u ki?n nào

### **SearchEmployeesAsync Method:**

1. **Global Check** ? N?u có quy?n Global ? Show t?t c?
2. **Self Check** ? Add chính mình vào allowed list
3. **Team Check** ? Add t?t c? members c?a teams mà user có quy?n Team
4. **OwnTeam Check** ? Add t?t c? members c?a teams mà user là leader
5. **Filter** ? Ch? show employees trong allowed list

---

## ?? **Scope Types Explained:**

### **?? Global Scope:**
- **Mô t?**: Quy?n toàn h? th?ng
- **Ví d?**: HR Manager có th? xem/s?a t?t c? employees
- **Implementation**: Check ??u tiên, n?u có thì allow t?t c?

### **?? Self Scope:**  
- **Mô t?**: Ch? quy?n v?i chính mình
- **Ví d?**: Employee ch? có th? xem/s?a thông tin c?a chính mình
- **Implementation**: So sánh `employeeId` v?i `currentEmployeeId`

### **?? Team Scope:**
- **Mô t?**: Quy?n v?i members trong cùng team
- **Ví d?**: Team member có th? xem thông tin các member khác trong team
- **Implementation**: Check intersection c?a user teams và target teams

### **?? OwnTeam Scope:**
- **Mô t?**: Quy?n v?i team mà user là leader
- **Ví d?**: Team Leader có th? qu?n lý t?t c? members trong team c?a mình  
- **Implementation**: Check user có ph?i leader c?a team ch?a target không

---

## ?? **Permission Priority:**

```
1. Master Account ? Always Allow
2. Global Scope ? Allow all
3. Self Scope ? Allow if target is self
4. OwnTeam Scope ? Allow if user is leader of target's team  
5. Team Scope ? Allow if user and target in same team
6. Deny ? No matching permission found
```

---

## ?? **Scenarios:**

### **Scenario 1: Team Leader**
```
User: John (Leader of Sales Team)
Target: Mary (Member of Sales Team)
Permission: Employee.Edit.OwnTeam.SalesTeam

Result: ? ALLOW
Reason: John là leader c?a Sales Team mà Mary thu?c v?
```

### **Scenario 2: Team Member**
```
User: Alice (Member of Marketing Team)  
Target: Bob (Member of Marketing Team)
Permission: Employee.View.Team.MarketingTeam

Result: ? ALLOW
Reason: Alice và Bob cùng thu?c Marketing Team
```

### **Scenario 3: Different Teams**
```
User: Charlie (Member of IT Team)
Target: David (Member of HR Team)  
Permission: Employee.View.Team.ITTeam

Result: ? DENY
Reason: Charlie và David không cùng team
```

### **Scenario 4: Self Permission**
```
User: Eve (Employee)
Target: Eve (Chính mình)
Permission: Employee.Edit.Self

Result: ? ALLOW  
Reason: Eve ?ang edit thông tin c?a chính mình
```

---

## ??? **Security Features:**

### ? **Comprehensive Checks:**
- Multiple scope levels v?i priority rõ ràng
- Team membership validation
- Leader role verification  
- Self-access protection

### ? **Error Handling:**
- Try-catch blocks cho database operations
- Logging for debugging và audit
- Graceful fallback khi có l?i

### ? **Performance Optimization:**
- Efficient database queries v?i proper indexing
- HashSet ?? avoid duplicates trong allowed list
- Early returns ?? tránh unnecessary checks

### ? **Flexibility:**
- Support multiple teams per user
- Support multiple roles (member, leader) per user
- Extensible cho future scope types

---

## ?? **Database Queries:**

### **Team Membership Queries:**
```sql
-- Get target employee's teams
SELECT TeamId FROM TeamMembers WHERE EmployeeId = @targetEmployeeId

-- Get current user's leader teams  
SELECT TeamId FROM TeamMembers WHERE EmployeeId = @currentEmployeeId AND IsLeader = 1

-- Get current user's all teams
SELECT TeamId FROM TeamMembers WHERE EmployeeId = @currentEmployeeId

-- Get team members for filtering
SELECT EmployeeId FROM TeamMembers WHERE TeamId = @teamId
```

---

## ?? **Benefits:**

### ? **Complete Permission System:**
- H? tr? ??y ?? t?t c? scope types
- Flexible team-based permissions
- Hierarchical permission model

### ? **Scalable Architecture:**
- Easy to extend thêm scope types
- Performant v?i large datasets  
- Maintainable code structure

### ? **User Experience:**
- Users ch? th?y data h? có quy?n access
- Clear permission boundaries
- Intuitive team-based access control

---

**Status: ? COMPLETED**

Team-based permissions ?ã ???c implement ??y ?? cho EmployeeService! ??