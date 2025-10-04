# ?? Debug Guide - Kh�ng th? th�m nh�n vi�n m?i

## ?? **C�c b??c test chi ti?t:**

### 1. **Ch?y ?ng d?ng v� m? Console**
- Ch?y ?ng d?ng trong **Debug mode** (F5)
- M? **Console Window** ho?c **Output Window** ?? xem debug logs
- ??ng nh?p v�o ?ng d?ng

### 2. **M? form th�m nh�n vi�n**
- Click v�o menu/button "Th�m nh�n vi�n"
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

### 3. **?i?n th�ng tin test:**
Nh?p nh?ng th�ng tin sau (??n gi?n ?? test):
```
H?: Nguy?n
T�n: Test
Email: (?? tr?ng ho?c test@example.com)
Phone: (?? tr?ng ho?c 0901234567) 
Gi?i t�nh: Nam (ch?n t? dropdown)
V? tr�: (ch?n b?t k? t? dropdown)
Ng�y sinh: 01/01/1990
Ng�y v�o l�m: h�m nay
Gi?/ng�y: 8
Gi?/th�ng: 160
```

### 4. **Click Save v� quan s�t Console**
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

### 5. **C�c t�nh hu?ng l?i c� th? x?y ra:**

#### ? **L?i Validation:**
```
Validation result: IsValid = false
Number of errors: 2
  1. Email kh�ng ?�ng ??nh d?ng
  2. S? ?i?n tho?i kh�ng h?p l?
```
**Gi?i ph�p:** S?a l?i email v� phone theo ?�ng format

#### ? **L?i Position kh�ng load:**
```
Loading positions...
Loaded 0 positions
Position ComboBox setup - Items count: 0
```
**Gi?i ph�p:** Ki?m tra database c� data Position kh�ng

#### ? **L?i Permission:**
```
Permission check result: False
UnauthorizedAccessException: B?n kh�ng c� quy?n t?o nh�n vi�n m?i
```
**Gi?i ph�p:** Ki?m tra Role & Permission c?a user

#### ? **L?i Database:**
```
ERROR creating employee: SqlException: Cannot insert...
```
**Gi?i ph�p:** Ki?m tra connection string v� database

#### ? **Service returns null:**
```
CreateAsync returned: null
ERROR: Service returned null
```
**Gi?i ph�p:** Ki?m tra AutoMapper v� database constraints

### 6. **Test nhanh v?i data t?i thi?u:**

N?u g?p l?i validation, th? v?i data t?i thi?u:
```
H?: A
T�n: B  
Gi?i t�nh: Nam
V? tr�: (ch?n ??u ti�n)
(?? c�c field kh�c m?c ??nh)
```

### 7. **Ki?m tra Database sau khi Save:**

Ch?y query n�y ?? xem c� employee n�o ???c t?o:
```sql
SELECT TOP 5 * FROM Employees ORDER BY EmployeeId DESC
```

### 8. **Emergency Bypass:**

N?u v?n kh�ng ???c, t?m th?i comment out validation:
```csharp
// var validationResult = await ValidateFormAsync(showErrors: true);
// if (!validationResult.IsValid) return;
var validationResult = new ValidationResult { IsValid = true };
```

### 9. **Li�n h? Support:**

N?u t?t c? fail, g?i cho t�i:
- Screenshot c?a Console debug output
- Screenshot c?a error message (n?u c�)
- Th�ng tin user ?ang login
- Database c� data Position kh�ng

---

## ?? **K?t qu? mong ??i:**

N?u m?i th? OK, b?n s? th?y:
1. ? Console hi?n th? debug info r� r�ng
2. ? Message "Th�m nh�n vi�n th�nh c�ng!"
3. ? Form ?�ng l?i
4. ? Database c� record m?i
5. ? Danh s�ch nh�n vi�n c?p nh?t

## ?? **L?u �:**

Debug code s? l�m ch?m app. Sau khi fix xong, h�y remove c�c `Console.WriteLine` kh�ng c?n thi?t.