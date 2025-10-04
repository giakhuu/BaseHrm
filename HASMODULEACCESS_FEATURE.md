# ?? New Feature: HasModuleAccessAsync - Simplified Permission Check for Menu Display

## ?? **M?c ?�ch:**
T?o m?t method m?i ?? ki?m tra quy?n truy c?p module m?t c�ch ??n gi?n - ch? c?n c� **b?t k? quy?n n�o** tr�n module ?� l� ?? ?? hi?n th? menu/button, **kh�ng quan t�m ??n ScopeType**.

## ? **Method m?i ?� th�m:**

### 1. **HasModuleAccessAsync** - Trong PermissionService
```csharp
/// <summary>
/// Ki?m tra xem user c� b?t k? quy?n n�o tr�n module hay kh�ng (b?t k? ScopeType)
/// D�ng ?? hi?n th?/?n c�c n�t menu
/// </summary>
public async Task<bool> HasModuleAccessAsync(int accountId, ModuleName module, PermissionAction action = PermissionAction.View, CancellationToken ct = default)
```

### 2. **HasModulePermission** - Helper method
```csharp
/// <summary>
/// Helper method ?? ki?m tra quy?n tr�n module v?i b?t k? scope n�o
/// </summary>
private bool HasModulePermission<T>(IEnumerable<T> permissions, ModuleName module, PermissionAction action)
```

---

## ?? **So s�nh v?i method c?:**

### ? **HasPermissionAsync (method c?):**
- Ki?m tra quy?n **c? th?** v?i ScopeType v� ScopeValue
- Ph?c t?p v?i logic scope matching
- Ph� h?p cho: Ki?m tra quy?n th?c thi action c? th?

```csharp
// V� d?: Ch? cho ph�p n?u c� quy?n Employee.View v?i Global scope
bool canView = await HasPermissionAsync(accountId, ModuleName.Employee, PermissionAction.View, ScopeType.Global);
```

### ? **HasModuleAccessAsync (method m?i):**
- Ki?m tra quy?n **b?t k?** tr�n module ?�
- ??n gi?n, ch? quan t�m Module + Action
- Ph� h?p cho: Hi?n th?/?n menu v� buttons

```csharp
// V� d?: Hi?n th? menu Employee n?u c� B?T K? quy?n Employee n�o (Global, Self, Team...)
bool showMenu = await HasModuleAccessAsync(accountId, ModuleName.Employee, PermissionAction.View);
```

---

## ?? **Logic c?a HasModuleAccessAsync:**

### ? **C�c tr??ng h?p s? return TRUE:**

1. **Global Permission**: User c� quy?n Global tr�n module
2. **Self Permission**: User c� quy?n Self tr�n module  
3. **Team Permission**: User c� quy?n Team tr�n module
4. **OwnTeam Permission**: User c� quy?n OwnTeam tr�n module
5. **B?t k? scope n�o kh�c**: Ch? c?n c� quy?n l� ???c

### ? **Tr??ng h?p return FALSE:**
- User kh�ng c� b?t k? quy?n n�o tr�n module ?�

---

## ?? **C�ch s? d?ng trong Test.cs:**

### **Tr??c (ph?c t?p):**
```csharp
private async Task SetMenuVisibility(Button menuButton, ModuleName module, PermissionAction action = PermissionAction.View)
{
    // Ph?i ki?m tra v?i scope c? th?
    bool hasPermission = await _permissionService.HasPermissionAsync(_currentAccountId.Value, module, action);
    menuButton.Visible = hasPermission;
}
```

### **Sau (??n gi?n):**
```csharp
private async Task SetMenuVisibility(Button menuButton, ModuleName module, PermissionAction action = PermissionAction.View)
{
    // Ki?m tra v?i B?T K? scope n�o
    bool hasPermission = await _permissionService.HasModuleAccessAsync(_currentAccountId.Value, module, action);
    menuButton.Visible = hasPermission;
}
```

---

## ?? **C�c menu ???c c?p nh?t:**

### ? **Menu ch�nh:**
- ? **Employee Management** - `ModuleName.Employee`
- ? **Team Management** - `ModuleName.Team`  
- ? **Shift Management** - `ModuleName.Shift`
- ? **Attendance Management** - `ModuleName.Attendance`
- ? **Account Management** - `ModuleName.Account`
- ? **Role Management** - `ModuleName.Account` v?i `PermissionAction.All`

### ? **Shift Submenu:**
- ? **Daily Shift Summary** - `ModuleName.Shift` + `PermissionAction.View`
- ? **Create Shift** - `ModuleName.Shift` + `PermissionAction.Create`
- ? **Add Shift Type** - `ModuleName.ShiftType` + `PermissionAction.Create`

---

## ?? **V� d? th?c t?:**

### **Scenario 1: User c� Employee.Self permission**
```csharp
// User c� quy?n: Employee.View.Self (ch? xem th�ng tin c?a ch�nh m�nh)
bool showEmployeeMenu = await HasModuleAccessAsync(accountId, ModuleName.Employee, PermissionAction.View);
// Result: TRUE - Menu Employee s? hi?n th?
// L� do: User c� quy?n Employee, d� ch? l� Self scope
```

### **Scenario 2: User c� Attendance.Team permission**
```csharp
// User c� quy?n: Attendance.View.Team (xem ch?m c�ng c?a team)
bool showAttendanceMenu = await HasModuleAccessAsync(accountId, ModuleName.Attendance, PermissionAction.View);
// Result: TRUE - Menu Attendance s? hi?n th?
// L� do: User c� quy?n Attendance, d� ch? l� Team scope
```

### **Scenario 3: User kh�ng c� quy?n n�o tr�n Shift module**
```csharp
// User kh�ng c� quy?n g� tr�n Shift
bool showShiftMenu = await HasModuleAccessAsync(accountId, ModuleName.Shift, PermissionAction.View);
// Result: FALSE - Menu Shift s? b? ?n
```

---

## ??? **B?o m?t:**

### ? **Menu Display Level:**
- S? d?ng `HasModuleAccessAsync` - ??n gi?n, ch? ?? hi?n th? menu
- User th?y menu n?u c� B?T K? quy?n n�o tr�n module

### ?? **Action Execution Level:**
- V?n s? d?ng `HasPermissionAsync` - Chi ti?t, ki?m tra scope c? th?
- User ch? th?c hi?n ???c action n?u c� ?�ng quy?n v?i ?�ng scope

### **V� d? ph�n t?ng b?o m?t:**
```csharp
// 1. Menu hi?n th? (loose check)
bool showEmployeeMenu = await HasModuleAccessAsync(accountId, ModuleName.Employee, PermissionAction.View);
if (showEmployeeMenu) 
{
    // Hi?n th? menu Employee
}

// 2. Action execution (strict check)
bool canEditEmployee = await HasPermissionAsync(accountId, ModuleName.Employee, PermissionAction.Edit, ScopeType.Global);
if (canEditEmployee) 
{
    // Cho ph�p edit employee
}
```

---

## ?? **K?t qu?:**

### ? **User Experience c?i thi?n:**
- Menu hi?n th? h?p l� h?n
- User th?y c�c ch?c n?ng h? c� th? truy c?p (? m?t m?c ?? n�o ?�)
- Gi?m confusion khi menu b? ?n kh�ng r� l� do

### ? **Developer Experience:**
- Code ??n gi?n h?n cho menu visibility
- T�ch bi?t r� r�ng: Menu display vs Action execution
- Method c? `HasPermissionAsync` v?n gi? nguy�n cho action checks

### ? **Security:**
- V?n ??m b?o b?o m?t ? level action execution
- Menu display ch? l� UX improvement, kh�ng ?nh h??ng security

---

## ?? **Debug Output:**

```
HasModuleAccessAsync called: AccountId=123, Module=Employee, Action=View
Found module access in role permissions
  Found permission: Module=Employee, Actions=View

HasModuleAccessAsync called: AccountId=123, Module=Team, Action=View  
No module access found for Team
```

---

**Status: ? COMPLETED**

B�y gi? menu s? hi?n th? th�ng minh h?n - user s? th?y menu c?a c�c module m� h? c� quy?n truy c?p, b?t k? scope type! ??