# Debug Guide - Th�m nh�n vi�n kh�ng ???c

## ?? C�c b??c debug v?n ??:

### 1. **Ki?m tra Console Output khi ch?y ?ng d?ng**
Khi b?n m? form th�m nh�n vi�n v� click Save, h�y xem Console (Debug Output) ?? th?y:
```
=== DEBUG AUTHENTICATION ===
AuthService null: False
PermissionService null: False  
User info - AccountId: 123, IsMaster: True
Has Employee Create permission: True
=============================

Creating employee: Nguy?n V?n A
Position ID: 1
Starting CreateAsync for new employee
Permission check result: True
Mapping DTO to entity
Adding entity to repository
Saving changes to database
Employee created with ID: 456
```

### 2. **C�c l?i ph? bi?n v� c�ch kh?c ph?c:**

#### ? **L?i Permission:** 
```
UnauthorizedAccessException: B?n kh�ng c� quy?n t?o nh�n vi�n m?i
```
**Nguy�n nh�n:** T�i kho?n kh�ng c� quy?n Employee Create
**Kh?c ph?c:** 
- Ki?m tra Role & Permission c?a t�i kho?n
- Ho?c d�ng t�i kho?n Master
- Ho?c temporary bypass ?� ???c th�m v�o code (ch? khi debug)

#### ? **L?i Database:**
```
SqlException: Cannot insert...
```
**Nguy�n nh�n:** 
- Connection string sai
- Database kh�ng t?n t?i
- Constraint violation (tr�ng email, phone, etc.)

**Kh?c ph?c:** Ki?m tra connection string trong appsettings.json

#### ? **L?i Validation:**
```
ValidationResult.IsValid = false
```
**Nguy�n nh�n:** D? li?u input kh�ng h?p l?
**Kh?c ph?c:** Xem message box validation chi ti?t

#### ? **L?i Mapping:**
```
AutoMapper exception
```
**Nguy�n nh�n:** AutoMapper profile ch?a configure ?�ng
**Kh?c ph?c:** Ki?m tra AutoMapperProfile.cs

### 3. **Test Manual Steps:**

1. **Ch?y ?ng d?ng v� ??ng nh?p**
2. **M? form th�m nh�n vi�n** 
3. **?i?n th�ng tin c? b?n:**
   - H?: Test
   - T�n: User  
   - Gi?i t�nh: Nam
   - V? tr�: (ch?n t? dropdown)
   - Ng�y sinh: 01/01/1990
   - Ng�y v�o l�m: h�m nay
   - Gi?/ng�y: 8
   - Gi?/th�ng: 160

4. **Click Save v� xem:**
   - Console output ?? debug
   - Message box hi?n th? g�
   - C� l?i exception kh�ng

### 4. **Temporary Fixes ?� implement:**

? **Debug Permission Bypass:**
```csharp
if (System.Diagnostics.Debugger.IsAttached)
{
    return true; // Bypass permission trong debug mode
}
```

? **Enhanced Error Messages:**
- Chi ti?t l?i UnauthorizedAccessException  
- Chi ti?t l?i database
- Chi ti?t validation errors

? **Debug Logging:**
- Permission check results
- Authentication status  
- Service availability

### 5. **Ki?m tra nhanh Database:**

Ch?y query n�y ?? xem c� employee n�o ???c t?o kh�ng:
```sql
SELECT TOP 10 * FROM Employees ORDER BY EmployeeId DESC
```

### 6. **N?u v?n kh�ng ???c:**

H�y th? c�c b??c sau theo th? t?:

1. **Restart ?ng d?ng** - Clear cache v� service scope
2. **Ki?m tra database connection** - Test query ??n gi?n
3. **Ki?m tra permissions** - D�ng t�i kho?n Master
4. **Ki?m tra validation** - Th? v?i data t?i thi?u
5. **Check console logs** - Xem chi ti?t debug output

### 7. **Contact Support:**

N?u t?t c? c�c b??c tr�n kh�ng gi?i quy?t ???c, h�y g?i:
- Screenshot c?a error message
- Console debug output
- Th�ng tin t�i kho?n ?ang d�ng
- Database connection string (?n password)

---

## ?? **L?U � QUAN TR?NG:**

Code bypass permission ch? ho?t ??ng khi ch?y trong Debug mode. Nh? remove n� trong Production:

```csharp
// REMOVE THIS IN PRODUCTION:
if (System.Diagnostics.Debugger.IsAttached)
{
    return true;
}
```