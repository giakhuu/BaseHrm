# Debug Guide - Thêm nhân viên không ???c

## ?? Các b??c debug v?n ??:

### 1. **Ki?m tra Console Output khi ch?y ?ng d?ng**
Khi b?n m? form thêm nhân viên và click Save, hãy xem Console (Debug Output) ?? th?y:
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

### 2. **Các l?i ph? bi?n và cách kh?c ph?c:**

#### ? **L?i Permission:** 
```
UnauthorizedAccessException: B?n không có quy?n t?o nhân viên m?i
```
**Nguyên nhân:** Tài kho?n không có quy?n Employee Create
**Kh?c ph?c:** 
- Ki?m tra Role & Permission c?a tài kho?n
- Ho?c dùng tài kho?n Master
- Ho?c temporary bypass ?ã ???c thêm vào code (ch? khi debug)

#### ? **L?i Database:**
```
SqlException: Cannot insert...
```
**Nguyên nhân:** 
- Connection string sai
- Database không t?n t?i
- Constraint violation (trùng email, phone, etc.)

**Kh?c ph?c:** Ki?m tra connection string trong appsettings.json

#### ? **L?i Validation:**
```
ValidationResult.IsValid = false
```
**Nguyên nhân:** D? li?u input không h?p l?
**Kh?c ph?c:** Xem message box validation chi ti?t

#### ? **L?i Mapping:**
```
AutoMapper exception
```
**Nguyên nhân:** AutoMapper profile ch?a configure ?úng
**Kh?c ph?c:** Ki?m tra AutoMapperProfile.cs

### 3. **Test Manual Steps:**

1. **Ch?y ?ng d?ng và ??ng nh?p**
2. **M? form thêm nhân viên** 
3. **?i?n thông tin c? b?n:**
   - H?: Test
   - Tên: User  
   - Gi?i tính: Nam
   - V? trí: (ch?n t? dropdown)
   - Ngày sinh: 01/01/1990
   - Ngày vào làm: hôm nay
   - Gi?/ngày: 8
   - Gi?/tháng: 160

4. **Click Save và xem:**
   - Console output ?? debug
   - Message box hi?n th? gì
   - Có l?i exception không

### 4. **Temporary Fixes ?ã implement:**

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

Ch?y query này ?? xem có employee nào ???c t?o không:
```sql
SELECT TOP 10 * FROM Employees ORDER BY EmployeeId DESC
```

### 6. **N?u v?n không ???c:**

Hãy th? các b??c sau theo th? t?:

1. **Restart ?ng d?ng** - Clear cache và service scope
2. **Ki?m tra database connection** - Test query ??n gi?n
3. **Ki?m tra permissions** - Dùng tài kho?n Master
4. **Ki?m tra validation** - Th? v?i data t?i thi?u
5. **Check console logs** - Xem chi ti?t debug output

### 7. **Contact Support:**

N?u t?t c? các b??c trên không gi?i quy?t ???c, hãy g?i:
- Screenshot c?a error message
- Console debug output
- Thông tin tài kho?n ?ang dùng
- Database connection string (?n password)

---

## ?? **L?U Ý QUAN TR?NG:**

Code bypass permission ch? ho?t ??ng khi ch?y trong Debug mode. Nh? remove nó trong Production:

```csharp
// REMOVE THIS IN PRODUCTION:
if (System.Diagnostics.Debugger.IsAttached)
{
    return true;
}
```