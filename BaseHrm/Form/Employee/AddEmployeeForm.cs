using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using BaseHrm.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    public partial class AddEmployeeForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly EmployeeDto? _employee;
        private readonly ErrorProvider _errorProvider;
        
        public AddEmployeeForm(IEmployeeService employeeService, IPositionService positionService)
        {
            InitializeComponent();
            _errorProvider = new ErrorProvider
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };

            _employeeService = employeeService;
            _positionService = positionService;
            _employee = null;

            this.Load += async (s, e) => await InitFormAsync();
        }

        public AddEmployeeForm(IEmployeeService employeeService, IPositionService positionService, EmployeeDto employee)
        {
            InitializeComponent();
            _errorProvider = new ErrorProvider
            {
                ContainerControl = this,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            };
            
            _employeeService = employeeService;
            _positionService = positionService;
            _employee = employee;

            this.Load += async (s, e) => await InitFormAsync();
        }

        private async Task InitFormAsync()
        {
            try
            {
                Console.WriteLine("=== INITIALIZING ADD EMPLOYEE FORM ===");
                
                Console.WriteLine("Loading positions...");
                var positions = await _positionService.GetAllAsync();
                Console.WriteLine($"Loaded {positions?.Count ?? 0} positions");
                
                if (positions != null && positions.Count > 0)
                {
                    foreach (var pos in positions)
                    {
                        Console.WriteLine($"  Position: ID={pos.PositionId}, Name='{pos.Name}'");
                    }
                }
                
                cmbPosition.DataSource = positions;
                cmbPosition.DisplayMember = "Name";
                cmbPosition.ValueMember = "PositionId";
                
                Console.WriteLine($"Position ComboBox setup - Items count: {cmbPosition.Items.Count}");

                if (_employee != null)
                {
                    Console.WriteLine("Loading existing employee data...");
                    txtFirstName.Text = _employee.FirstName ?? "";
                    txtLastName.Text = _employee.LastName ?? "";
                    dtpDateOfBirth.Value = _employee.DateOfBirth;
                    cmbGender.SelectedItem = _employee.Gender ?? "";
                    txtEmail.Text = _employee.Email ?? "";
                    txtPhone.Text = _employee.Phone ?? "";
                    txtAddress.Text = _employee.Address ?? "";
                    dtpHireDate.Value = _employee.HireDate;
                    numMaxHoursPerDay.Text = _employee.MaxHoursPerDay.ToString();
                    numMaxHoursPerMonth.Text = _employee.MaxHoursPerMonth.ToString();
                    if (_employee.PositionId.HasValue)
                        cmbPosition.SelectedValue = _employee.PositionId.Value;

                    lblFormTitle.Text = "Chỉnh sửa nhân viên";
                    Console.WriteLine("Existing employee data loaded");
                }
                else
                {
                    Console.WriteLine("New employee form - setting default values");
                    // Set some default values for new employee
                    dtpDateOfBirth.Value = DateTime.Today.AddYears(-25); // Default age 25
                    dtpHireDate.Value = DateTime.Today;
                    numMaxHoursPerDay.Text = "8";
                    numMaxHoursPerMonth.Text = "160";
                    
                    // Set default gender
                    if (cmbGender.Items.Count > 0)
                    {
                        cmbGender.SelectedIndex = 0;
                    }
                }
                
                Console.WriteLine("Form initialization completed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR initializing form: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CreateEmployeeDto CollectCreateDto()
        {
            Console.WriteLine("=== COLLECTING CREATE DTO ===");
            
            try
            {
                var dto = new CreateEmployeeDto
                {
                    FirstName = txtFirstName.Text?.Trim() ?? "",
                    LastName = txtLastName.Text?.Trim() ?? "",
                    DateOfBirth = dtpDateOfBirth.Value,
                    Gender = cmbGender.SelectedItem?.ToString() ?? "",
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                    Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                    HireDate = dtpHireDate.Value,
                    MaxHoursPerDay = decimal.TryParse(numMaxHoursPerDay.Text, out var maxPerDay) ? maxPerDay : 8,
                    MaxHoursPerMonth = decimal.TryParse(numMaxHoursPerMonth.Text, out var maxPerMonth) ? maxPerMonth : 160,
                    PositionId = cmbPosition.SelectedValue is int posId ? posId : null
                };
                
                Console.WriteLine("DTO collected successfully:");
                Console.WriteLine($"  FirstName: '{dto.FirstName}' (length: {dto.FirstName?.Length ?? 0})");
                Console.WriteLine($"  LastName: '{dto.LastName}' (length: {dto.LastName?.Length ?? 0})");
                Console.WriteLine($"  Gender: '{dto.Gender}'");
                Console.WriteLine($"  Email: '{dto.Email}'");
                Console.WriteLine($"  Phone: '{dto.Phone}'");
                Console.WriteLine($"  Address: '{dto.Address}'");
                Console.WriteLine($"  DateOfBirth: {dto.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine($"  HireDate: {dto.HireDate:yyyy-MM-dd}");
                Console.WriteLine($"  MaxHoursPerDay: {dto.MaxHoursPerDay}");
                Console.WriteLine($"  MaxHoursPerMonth: {dto.MaxHoursPerMonth}");
                Console.WriteLine($"  PositionId: {dto.PositionId}");
                Console.WriteLine($"  cmbPosition.SelectedValue type: {cmbPosition.SelectedValue?.GetType().Name ?? "null"}");
                Console.WriteLine($"  cmbPosition.SelectedValue: {cmbPosition.SelectedValue}");
                
                return dto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR collecting DTO: {ex.Message}");
                throw;
            }
        }

        private async Task<ValidationResult> ValidateFormAsync(bool showErrors)
        {
            var result = new ValidationResult { IsValid = true };

            // Clear previous errors if showing errors
            if (showErrors)
                _errorProvider.Clear();

            // DEBUG: Check authentication status
            try
            {
                Console.WriteLine("=== DEBUG AUTHENTICATION ===");
                var hasCreatePermission = await CheckCreatePermissionAsync();
                Console.WriteLine($"Has Create Permission: {hasCreatePermission}");
                Console.WriteLine("=============================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Auth check error: {ex.Message}");
            }

            // Basic validation using ValidationHelper
            var basicErrors = ValidationHelper.ValidateEmployeeData(
                txtFirstName.Text?.Trim() ?? "",
                txtLastName.Text?.Trim() ?? "",
                txtEmail.Text?.Trim() ?? "",
                txtPhone.Text?.Trim() ?? "",
                dtpDateOfBirth.Value,
                dtpHireDate.Value,
                decimal.TryParse(numMaxHoursPerDay.Text, out var maxDay) ? maxDay : 0,
                decimal.TryParse(numMaxHoursPerMonth.Text, out var maxMonth) ? maxMonth : 0
            );

            result.Errors.AddRange(basicErrors);
            if (basicErrors.Count > 0)
            {
                result.IsValid = false;
            }

            // Position validation
            if (cmbPosition.SelectedValue == null || string.IsNullOrWhiteSpace(cmbPosition.Text))
            {
                if (showErrors) _errorProvider.SetError(cmbPosition, "Vui lòng chọn vị trí.");
                result.Errors.Add("Vui lòng chọn vị trí");
                result.IsValid = false;
            }

            // Gender validation
            if (cmbGender.SelectedItem == null || string.IsNullOrWhiteSpace(cmbGender.Text))
            {
                if (showErrors) _errorProvider.SetError(cmbGender, "Vui lòng chọn giới tính.");
                result.Errors.Add("Vui lòng chọn giới tính");
                result.IsValid = false;
            }

            // Set error provider for basic validations
            if (showErrors)
            {
                if (!ValidationHelper.IsValidName(txtFirstName.Text?.Trim() ?? ""))
                {
                    _errorProvider.SetError(txtFirstName, "Họ không hợp lệ.");
                }
                if (!ValidationHelper.IsValidName(txtLastName.Text?.Trim() ?? ""))
                {
                    _errorProvider.SetError(txtLastName, "Tên không hợp lệ.");
                }
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidationHelper.IsValidEmail(txtEmail.Text.Trim()))
                {
                    _errorProvider.SetError(txtEmail, "Email không đúng định dạng.");
                }
                if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !ValidationHelper.IsValidPhone(txtPhone.Text.Trim()))
                {
                    _errorProvider.SetError(txtPhone, "Số điện thoại không hợp lệ.");
                }
                if (!ValidationHelper.IsValidAge(dtpDateOfBirth.Value))
                {
                    _errorProvider.SetError(dtpDateOfBirth, "Tuổi không hợp lệ.");
                }
                if (!ValidationHelper.IsValidHireDate(dtpHireDate.Value, dtpDateOfBirth.Value))
                {
                    _errorProvider.SetError(dtpHireDate, "Ngày vào làm không hợp lệ.");
                }
            }

            // Check email uniqueness
            var email = txtEmail.Text?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(email) && ValidationHelper.IsValidEmail(email))
            {
                try
                {
                    var existingEmployees = await _employeeService.SearchEmployeesAsync(email: email);
                    var existingEmployee = existingEmployees?.FirstOrDefault();
                    
                    if (existingEmployee != null && (_employee == null || existingEmployee.EmployeeId != _employee.EmployeeId))
                    {
                        if (showErrors) _errorProvider.SetError(txtEmail, "Email này đã được sử dụng bởi nhân viên khác.");
                        result.Errors.Add("Email này đã được sử dụng bởi nhân viên khác");
                        result.IsValid = false;
                    }
                }
                catch (Exception ex)
                {
                    result.Errors.Add($"Lỗi kiểm tra email: {ex.Message}");
                    result.IsValid = false;
                }
            }

            // Check phone uniqueness
            var phone = txtPhone.Text?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(phone) && ValidationHelper.IsValidPhone(phone))
            {
                try
                {
                    var allEmployees = await _employeeService.SearchEmployeesAsync();
                    var normalizedInputPhone = ValidationHelper.NormalizePhone(phone);
                    var existingEmployee = allEmployees?.FirstOrDefault(e => 
                        !string.IsNullOrEmpty(e.Phone) && 
                        ValidationHelper.NormalizePhone(e.Phone) == normalizedInputPhone);
                    
                    if (existingEmployee != null && (_employee == null || existingEmployee.EmployeeId != _employee.EmployeeId))
                    {
                        if (showErrors) _errorProvider.SetError(txtPhone, "Số điện thoại này đã được sử dụng bởi nhân viên khác.");
                        result.Errors.Add("Số điện thoại này đã được sử dụng bởi nhân viên khác");
                        result.IsValid = false;
                    }
                }
                catch (Exception ex)
                {
                    result.Errors.Add($"Lỗi kiểm tra số điện thoại: {ex.Message}");
                    result.IsValid = false;
                }
            }

            // Address validation
            var address = txtAddress.Text?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(address) && address.Length > 200)
            {
                if (showErrors) _errorProvider.SetError(txtAddress, "Địa chỉ không được quá 200 ký tự.");
                result.Errors.Add("Địa chỉ không được quá 200 ký tự");
                result.IsValid = false;
            }

            return result;
        }

        private async Task<bool> CheckCreatePermissionAsync()
        {
            try
            {
                // Try to call the same permission check that EmployeeService uses
                var serviceProvider = Program.ServiceProvider;
                var authService = serviceProvider?.GetService<IAuthService>();
                var permissionService = serviceProvider?.GetService<IPermissionService>();
                
                Console.WriteLine($"AuthService null: {authService == null}");
                Console.WriteLine($"PermissionService null: {permissionService == null}");
                
                if (authService != null)
                {
                    var userInfo = authService.GetUserInfoFromToken();
                    Console.WriteLine($"User info - AccountId: {userInfo.AccountId}, IsMaster: {userInfo.IsMaster}");
                    
                    if (userInfo.IsMaster)
                    {
                        Console.WriteLine("User is master - should have all permissions");
                        return true;
                    }
                    
                    if (permissionService != null && userInfo.AccountId.HasValue)
                    {
                        var hasPermission = await permissionService.HasPermissionAsync(
                            userInfo.AccountId.Value, 
                            BaseHrm.Data.Enums.ModuleName.Employee, 
                            BaseHrm.Data.Enums.PermissionAction.Create, 
                            BaseHrm.Data.Enums.ScopeType.Global);
                        Console.WriteLine($"Has Employee Create permission: {hasPermission}");
                        return hasPermission;
                    }
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Permission check failed: {ex.Message}");
                return false;
            }
        }

        private async Task SaveEmployeeAsync()
        {
            try 
            {
                Console.WriteLine("=== STARTING SAVE EMPLOYEE ===");
                
                // Basic required field check
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    cmbPosition.SelectedValue == null)
                {
                    Console.WriteLine("Missing required fields:");
                    Console.WriteLine($"FirstName: '{txtFirstName.Text}'");
                    Console.WriteLine($"LastName: '{txtLastName.Text}'"); 
                    Console.WriteLine($"Position: '{cmbPosition.SelectedValue}'");
                    
                    MessageBox.Show("Vui lòng điền đầy đủ các thông tin bắt buộc:\n\n• Họ\n• Tên\n• Vị trí công việc", 
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Console.WriteLine("Basic required fields check passed");

                // Comprehensive validation
                Console.WriteLine("Starting comprehensive validation...");
                var validationResult = await ValidateFormAsync(showErrors: true);
                
                Console.WriteLine($"Validation result: IsValid = {validationResult.IsValid}");
                Console.WriteLine($"Number of errors: {validationResult.Errors.Count}");
                
                if (validationResult.Errors.Count > 0)
                {
                    Console.WriteLine("Validation errors found:");
                    for (int i = 0; i < validationResult.Errors.Count; i++)
                    {
                        Console.WriteLine($"  {i + 1}. {validationResult.Errors[i]}");
                    }
                }
                
                if (!validationResult.IsValid)
                {
                    Console.WriteLine("Validation failed - showing error dialog");
                    // Show detailed validation errors in message box
                    ShowValidationErrors(validationResult.Errors);
                    return;
                }

                Console.WriteLine("Validation passed successfully");

                if (_employee == null)
                {
                    Console.WriteLine("Creating new employee...");
                    
                    // Create new employee
                    var createDto = CollectCreateDto();
                    
                    // Debug logging
                    Console.WriteLine($"DTO created:");
                    Console.WriteLine($"  FirstName: '{createDto.FirstName}'");
                    Console.WriteLine($"  LastName: '{createDto.LastName}'");
                    Console.WriteLine($"  Email: '{createDto.Email}'");
                    Console.WriteLine($"  Phone: '{createDto.Phone}'");
                    Console.WriteLine($"  Gender: '{createDto.Gender}'");
                    Console.WriteLine($"  PositionId: {createDto.PositionId}");
                    Console.WriteLine($"  DateOfBirth: {createDto.DateOfBirth:yyyy-MM-dd}");
                    Console.WriteLine($"  HireDate: {createDto.HireDate:yyyy-MM-dd}");
                    Console.WriteLine($"  MaxHoursPerDay: {createDto.MaxHoursPerDay}");
                    Console.WriteLine($"  MaxHoursPerMonth: {createDto.MaxHoursPerMonth}");
                    
                    Console.WriteLine("Calling EmployeeService.CreateAsync...");
                    var result = await _employeeService.CreateAsync(createDto);
                    
                    if (result != null)
                    {
                        Console.WriteLine($"CreateAsync returned: Employee with ID {result.EmployeeId}");
                    }
                    else
                    {
                        Console.WriteLine("CreateAsync returned: null");
                    }
                    
                    if (result != null)
                    {
                        Console.WriteLine("Employee created successfully!");
                        MessageBox.Show("Thêm nhân viên thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Service returned null");
                        MessageBox.Show("Không thể thêm nhân viên. Service trả về null.\n\nKiểm tra Console để xem chi tiết lỗi.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Console.WriteLine("Updating existing employee...");
                    // Update existing employee logic here...
                    var updateDto = new UpdateEmployeeDto
                    {
                        EmployeeId = _employee.EmployeeId,
                        FirstName = txtFirstName.Text.Trim(),
                        LastName = txtLastName.Text.Trim(),
                        DateOfBirth = dtpDateOfBirth.Value,
                        Gender = cmbGender.SelectedItem?.ToString() ?? "",
                        Email = txtEmail.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        HireDate = dtpHireDate.Value,
                        MaxHoursPerDay = decimal.TryParse(numMaxHoursPerDay.Text, out var maxPerDay) ? maxPerDay : 8,
                        MaxHoursPerMonth = decimal.TryParse(numMaxHoursPerMonth.Text, out var maxPerMonth) ? maxPerMonth : 160,
                        PositionId = cmbPosition.SelectedValue is int posId ? posId : null
                    };

                    var success = await _employeeService.UpdateAsync(updateDto);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật nhân viên. Vui lòng thử lại.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine($"UnauthorizedAccessException: {uae.Message}");
                MessageBox.Show($"Lỗi quyền truy cập:\n\n{uae.Message}\n\nVui lòng kiểm tra quyền của tài khoản hoặc liên hệ quản trị viên.", 
                    "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                
                var detailMessage = $"Lỗi khi lưu nhân viên:\n\n";
                detailMessage += $"Message: {ex.Message}\n\n";
                
                if (ex.InnerException != null)
                {
                    detailMessage += $"Inner Exception: {ex.InnerException.Message}\n\n";
                }
                
                detailMessage += $"Type: {ex.GetType().Name}\n\n";
                detailMessage += "Vui lòng chụp ảnh màn hình Console và thông báo này để gửi IT support.";
                
                MessageBox.Show(detailMessage, "Lỗi chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Console.WriteLine("=== END SAVE EMPLOYEE ===");
            }
        }

        private void ShowValidationErrors(List<string> errors)
        {
            if (errors == null || errors.Count == 0) return;

            // Use the enhanced validation error display
            this.ShowDetailedValidationErrors(errors, "Lỗi nhập liệu");
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            _ = SaveEmployeeAsync();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ = SaveEmployeeAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async Task TestServicesAsync()
        {
            try
            {
                Console.WriteLine("=== TESTING SERVICES ===");
                
                // Test EmployeeService
                Console.WriteLine("Testing EmployeeService...");
                var employees = await _employeeService.SearchEmployeesAsync();
                Console.WriteLine($"EmployeeService working - found {employees?.Count ?? 0} employees");
                
                // Test PositionService
                Console.WriteLine("Testing PositionService...");
                var positions = await _positionService.GetAllAsync();
                Console.WriteLine($"PositionService working - found {positions?.Count ?? 0} positions");
                
                Console.WriteLine("All services are working correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR testing services: {ex.Message}");
                MessageBox.Show($"Lỗi test services: {ex.Message}", "Service Test Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add this to constructor or form load for testing
        private async void btnTestServices_Click(object sender, EventArgs e)
        {
            await TestServicesAsync();
        }
    }
}
