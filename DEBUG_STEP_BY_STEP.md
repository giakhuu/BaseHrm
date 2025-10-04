# ?? Debug Guide - Không th? thêm nhân viên m?i

## ?? **Các b??c test chi ti?t:**

### 1. **Ch?y ?ng d?ng và m? Console**
- Ch?y ?ng d?ng trong **Debug mode** (F5)
- M? **Console Window** ho?c **Output Window** ?? xem debug logs
- ??ng nh?p vào ?ng d?ng

### 2. **M? form thêm nhân viên**
- Click vào menu/button "Thêm nhân viên"
- Xem Console s? hi?n th?:
```
=== INITIALIZING ADD EMPLOYEE FORM ===
Loading positions...
Loaded X positions
  Position: ID=1, Name='Manager'
  Position: ID=2, Name='Developer'
...
Position ComboBox setup - Items count: X
New employee form - setting default values
Form initialization completed successfully
```

### 3. **?i?n thông tin test:**
Nh?p nh?ng thông tin sau (??n gi?n ?? test):
```
H?: Nguy?n
Tên: Test
Email: (?? tr?ng ho?c test@example.com)
Phone: (?? tr?ng ho?c 0901234567) 
Gi?i tính: Nam (ch?n t? dropdown)
V? trí: (ch?n b?t k? t? dropdown)
Ngày sinh: 01/01/1990
Ngày vào làm: hôm nay
Gi?/ngày: 8
Gi?/tháng: 160
```

### 4. **Click Save và quan sát Console**
S? th?y output nh?:
```
=== STARTING SAVE EMPLOYEE ===
Basic required fields check passed
Starting comprehensive validation...
=== DEBUG AUTHENTICATION ===
AuthService null: False
PermissionService null: False
User info - AccountId: 1, IsMaster: True
Has Employee Create permission: True
=============================
Validation result: IsValid = true
Number of errors: 0
Validation passed successfully
Creating new employee...
=== COLLECTING CREATE DTO ===
DTO collected successfully:
  FirstName: 'Nguy?n' (length: 7)
  LastName: 'Test' (length: 4)
  Gender: 'Nam'
  Email: 'test@example.com'
  Phone: '0901234567'
  ...
  PositionId: 1
Calling EmployeeService.CreateAsync...
Starting CreateAsync for new employee
Permission check result: True
Mapping DTO to entity
Adding entity to repository
Saving changes to database
Employee created with ID: 123
CreateAsync returned: Employee with ID 123
Employee created successfully!
=== END SAVE EMPLOYEE ===
```

### 5. **Các tình hu?ng l?i có th? x?y ra:**

#### ? **L?i Validation:**
```
Validation result: IsValid = false
Number of errors: 2
  1. Email không ?úng ??nh d?ng
  2. S? ?i?n tho?i không h?p l?
```
**Gi?i pháp:** S?a l?i email và phone theo ?úng format

#### ? **L?i Position không load:**
```
Loading positions...
Loaded 0 positions
Position ComboBox setup - Items count: 0
```
**Gi?i pháp:** Ki?m tra database có data Position không

#### ? **L?i Permission:**
```
Permission check result: False
UnauthorizedAccessException: B?n không có quy?n t?o nhân viên m?i
```
**Gi?i pháp:** Ki?m tra Role & Permission c?a user

#### ? **L?i Database:**
```
ERROR creating employee: SqlException: Cannot insert...
```
**Gi?i pháp:** Ki?m tra connection string và database

#### ? **Service returns null:**
```
CreateAsync returned: null
ERROR: Service returned null
```
**Gi?i pháp:** Ki?m tra AutoMapper và database constraints

### 6. **Test nhanh v?i data t?i thi?u:**

N?u g?p l?i validation, th? v?i data t?i thi?u:
```
H?: A
Tên: B  
Gi?i tính: Nam
V? trí: (ch?n ??u tiên)
(?? các field khác m?c ??nh)
```

### 7. **Ki?m tra Database sau khi Save:**

Ch?y query này ?? xem có employee nào ???c t?o:
```sql
SELECT TOP 5 * FROM Employees ORDER BY EmployeeId DESC
```

### 8. **Emergency Bypass:**

N?u v?n không ???c, t?m th?i comment out validation:
```csharp
// var validationResult = await ValidateFormAsync(showErrors: true);
// if (!validationResult.IsValid) return;
var validationResult = new ValidationResult { IsValid = true };
```

### 9. **Liên h? Support:**

N?u t?t c? fail, g?i cho tôi:
- Screenshot c?a Console debug output
- Screenshot c?a error message (n?u có)
- Thông tin user ?ang login
- Database có data Position không

---

## ?? **K?t qu? mong ??i:**

N?u m?i th? OK, b?n s? th?y:
1. ? Console hi?n th? debug info rõ ràng
2. ? Message "Thêm nhân viên thành công!"
3. ? Form ?óng l?i
4. ? Database có record m?i
5. ? Danh sách nhân viên c?p nh?t

## ?? **L?u ý:**

Debug code s? làm ch?m app. Sau khi fix xong, hãy remove các `Console.WriteLine` không c?n thi?t.