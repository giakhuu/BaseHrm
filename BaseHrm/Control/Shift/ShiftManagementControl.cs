using BaseHrm.Auth;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class ShiftManagementControl : UserControl
    {
        private List<ShiftTypeDto>? shiftTypes;
        private List<EmployeeDto>? employees;
        private List<PositionDto>? positions;
        private List<TeamDto>? teams;
        private BindingList<EmployeeDto> selectedEmployees = new BindingList<EmployeeDto>();
        private List<ShiftAssignmentDto>? assignments;

        private EmployeeDto? employeeInSelected;
        private EmployeeDto? selectedEmployeeInSelected;

        private DateTime? selectedDate = null;
        public bool IsShiftOnlyMode { get; private set; } = false;

        private readonly IShiftService _shiftService;
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly ITeamService _teamService;
        private readonly IAuthService _authService;
        private readonly IPermissionService _permissionService;

        private int? _currentAccountId;
        private int? _currentEmployeeId;
        private bool _isMasterAccount;
        private readonly Dictionary<(PermissionAction action, ScopeType scope, int? scopeValue), bool> _permCache
            = new Dictionary<(PermissionAction, ScopeType, int?), bool>();

        public ShiftManagementControl(IShiftService shiftService, IEmployeeService employeeService, IPositionService positionService, ITeamService teamService, IAuthService authService, IPermissionService permissionService)
        {
            InitializeComponent();
            _shiftService = shiftService;
            _employeeService = employeeService;
            _positionService = positionService;
            _teamService = teamService;
            _authService = authService;
            _permissionService = permissionService;
            
            ApplyModernStyling();
            
            this.Load += async (s, e) =>
            {
                await InitializeIdentityAsync();
                await SetupPermissions();
                await InitializeData();
                LoadComboBoxes();
                LoadDataGridView();
                await ValidateFormAsync();
            };
        }

        private async Task InitializeIdentityAsync()
        {
            try
            {
                var info = _authService.GetUserInfoFromToken();
                _currentAccountId = info.AccountId;
                _isMasterAccount = info.IsMaster;
                _currentEmployeeId = info.EmployeeId;
                _permCache.Clear();
            }
            catch
            {
                _currentAccountId = null;
                _isMasterAccount = false;
                _currentEmployeeId = null;
            }
        }

        private async Task SetupPermissions()
        {
            if (_isMasterAccount) return;

            // Kiểm tra quyền và ẩn/hiện các control
            bool canCreate = await HasPermissionAsync(PermissionAction.Create);
            bool canView = await HasPermissionAsync(PermissionAction.View);

            // Chỉ cho phép tạo shift nếu có quyền Create
            saveButton.Enabled = canCreate;
            if (!canCreate)
            {
                saveButton.Text = "Không có quyền tạo ca làm";
                saveButton.BackColor = Color.Gray;
            }

            // Nếu không có quyền view, disable toàn bộ form
            if (!canView)
            {
                this.Enabled = false;
                MessageBox.Show("Bạn không có quyền truy cập chức năng quản lý ca làm việc.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task<bool> HasPermissionAsync(PermissionAction action)
        {
            if (_isMasterAccount) return true;
            if (!_currentAccountId.HasValue) return false;

            var accountId = _currentAccountId.Value;

            // Danh sách các scope cần check
            var scopes = new[] { ScopeType.Global, ScopeType.Team, ScopeType.OwnTeam, ScopeType.Self };

            foreach (var scope in scopes)
            {
                var key = (action, scope, (int?)null);

                if (!_permCache.TryGetValue(key, out bool allowed))
                {
                    allowed = await _permissionService.HasPermissionAsync(accountId, ModuleName.Shift, action, scope);
                    _permCache[key] = allowed;
                }

                if (allowed) return true; // chỉ cần 1 scope cho phép
            }

            return false;
        }


        private async Task InitializeData()
        {
            int? positionId = null;
            if (cmbPosition.SelectedValue is int pos && pos != 0)
                positionId = pos;

            // Chỉ load data nếu user có quyền
            if (_isMasterAccount || (_currentAccountId.HasValue && await HasPermissionAsync(PermissionAction.View)))
            {
                shiftTypes = await _shiftService.GetAllShiftTypesAsync();
                employees = await _employeeService.SearchEmployeesAsync(
                       name: textBox1.Text.Trim(),
                       positionId: positionId
                   ) ?? new List<EmployeeDto>();

                positions = await _positionService.GetAllAsync() ?? new List<PositionDto>();
                teams = await _teamService.SearchAsync() ?? new List<TeamDto>();
            }
            else
            {
                shiftTypes = new List<ShiftTypeDto>();
                employees = new List<EmployeeDto>();
                positions = new List<PositionDto>();
                teams = new List<TeamDto>();
            }

            assignments = new List<ShiftAssignmentDto>();
        }

        private void LoadDataGridView()
        {
            dgvPickEmployeeBindingSource.DataSource = employees ?? new List<EmployeeDto>();
            dgvPickEmployee.DataSource = dgvPickEmployeeBindingSource;
            dgvPickEmployee.Refresh();

            dgvSelectedEmployeeBindingSource.DataSource = selectedEmployees;
            dgvSelectedEmployee.DataSource = dgvSelectedEmployeeBindingSource;
            dgvSelectedEmployee.Refresh();
        }

        private void LoadComboBoxes()
        {
            if (shiftTypes != null)
            {
                shiftTypeComboBox.DisplayMember = "Name";
                shiftTypeComboBox.ValueMember = "Id";
                shiftTypeComboBox.DataSource = shiftTypes;
                if (shiftTypes.Count > 0)
                    shiftTypeComboBox.SelectedIndex = 0;
            }

            if (positions != null)
            {
                positions.Insert(0, new PositionDto { PositionId = 0, Name = "Tất cả" });
                cmbPosition.DataSource = null;
                cmbPosition.DisplayMember = "Name";
                cmbPosition.ValueMember = "PositionId";
                cmbPosition.DataSource = positions;
                if (positions.Count > 0)
                    cmbPosition.SelectedIndex = 0;
            }
        }

        private void ApplyModernStyling()
        {
            this.BackColor = Color.FromArgb(248, 249, 250);
            tabControl.BackColor = Color.White;
            ApplyButtonHoverEffects();
        }

        private void ApplyButtonHoverEffects()
        {
            saveButton.MouseEnter += (s, e) =>
            {
                if (saveButton.Enabled)
                    saveButton.BackColor = Color.FromArgb(64, 164, 231);
            };
            saveButton.MouseLeave += (s, e) =>
            {
                if (saveButton.Enabled)
                    saveButton.BackColor = Color.FromArgb(52, 152, 219);
            };

            cancelButton.MouseEnter += (s, e) => cancelButton.BackColor = Color.FromArgb(118, 127, 135);
            cancelButton.MouseLeave += (s, e) => cancelButton.BackColor = Color.FromArgb(108, 117, 125);
        }

        private async Task ValidateFormAsync()
        {
            bool isValid = await ValidateShiftInputAsync();

            if (!createShiftOnlyCheckBox.Checked)
            {
                isValid = isValid && selectedEmployees.Count > 0;
            }

            // Kiểm tra quyền tạo shift
            bool hasCreatePermission = await HasPermissionAsync(PermissionAction.Create);
            isValid = isValid && hasCreatePermission;

            saveButton.Enabled = isValid;
            if (saveButton.Enabled)
            {
                saveButton.BackColor = Color.FromArgb(52, 152, 219);
            }
            else
            {
                saveButton.BackColor = Color.FromArgb(108, 117, 125);
            }
        }

        private async Task<bool> ValidateShiftInputAsync()
        {
            bool isValid = true;
            var errorMessages = new List<string>();

            // Validate shift name
            if (string.IsNullOrWhiteSpace(shiftNameTextBox.Text))
            {
                errorMessages.Add("Tên ca làm việc không được để trống");
                isValid = false;
            }
            else if (shiftNameTextBox.Text.Trim().Length < 2)
            {
                errorMessages.Add("Tên ca làm việc phải có ít nhất 2 ký tự");
                isValid = false;
            }
            else if (shiftNameTextBox.Text.Trim().Length > 100)
            {
                errorMessages.Add("Tên ca làm việc không được quá 100 ký tự");
                isValid = false;
            }
            else
            {
                // Check if shift name already exists
                try
                {
                    var allShifts = await _shiftService.GetAllShiftsAsync();
                    var existingShift = allShifts?.FirstOrDefault(s => 
                        string.Equals(s.Name?.Trim(), shiftNameTextBox.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                    
                    if (existingShift != null)
                    {
                        errorMessages.Add("Tên ca làm việc này đã tồn tại");
                        isValid = false;
                    }
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"Lỗi kiểm tra tên ca làm việc: {ex.Message}");
                    isValid = false;
                }
            }

            // Validate shift type
            if (shiftTypeComboBox.SelectedItem == null)
            {
                errorMessages.Add("Vui lòng chọn loại ca làm việc");
                isValid = false;
            }

            // Validate expected hours
            if (expectedHoursNumeric.Value <= 0)
            {
                errorMessages.Add("Số giờ dự kiến phải lớn hơn 0");
                isValid = false;
            }
            else if (expectedHoursNumeric.Value > 24)
            {
                errorMessages.Add("Số giờ dự kiến không được quá 24 giờ");
                isValid = false;
            }

            // Validate time range
            var startTime = startTimePicker.Value.TimeOfDay;
            var endTime = endTimePicker.Value.TimeOfDay;

            if (startTime == endTime)
            {
                errorMessages.Add("Thời gian bắt đầu và kết thúc không được giống nhau");
                isValid = false;
            }

            // Calculate duration and validate against expected hours
            var duration = endTime > startTime
                ? endTime - startTime
                : TimeSpan.FromDays(1) - startTime + endTime;

            var calculatedHours = (decimal)duration.TotalHours;
            var expectedHours = expectedHoursNumeric.Value;

            if (Math.Abs(calculatedHours - expectedHours) > 0.5m) // Allow 30 minutes difference
            {
                errorMessages.Add($"Số giờ dự kiến ({expectedHours:F1}h) không khớp với thời gian ca làm việc ({calculatedHours:F1}h)");
                isValid = false;
            }

            // Validate date selection if not shift-only mode
            if (!createShiftOnlyCheckBox.Checked && selectedDate == null)
            {
                errorMessages.Add("Vui lòng chọn ngày cho ca làm việc");
                isValid = false;
            }
            else if (!createShiftOnlyCheckBox.Checked && selectedDate.HasValue)
            {
                if (selectedDate.Value.Date < DateTime.Today)
                {
                    errorMessages.Add("Không thể tạo ca làm việc cho ngày trong quá khứ");
                    isValid = false;
                }
                else if (selectedDate.Value.Date > DateTime.Today.AddDays(365))
                {
                    errorMessages.Add("Không thể tạo ca làm việc quá xa trong tương lai (tối đa 1 năm)");
                    isValid = false;
                }
            }

            // Validate employees selection if not shift-only mode
            if (!createShiftOnlyCheckBox.Checked)
            {
                if (selectedEmployees.Count == 0)
                {
                    errorMessages.Add("Vui lòng chọn ít nhất một nhân viên cho ca làm việc");
                    isValid = false;
                }
                else if (selectedEmployees.Count > 50)
                {
                    errorMessages.Add("Không thể gán quá 50 nhân viên cho một ca làm việc");
                    isValid = false;
                }

                // Check for duplicate employee assignments on the same date
                if (selectedDate.HasValue && selectedEmployees.Count > 0)
                {
                    try
                    {
                        foreach (var employee in selectedEmployees)
                        {
                            var existingAssignments = await _shiftService.QueryAssignmentsAsync(
                                dateFrom: selectedDate.Value.Date,
                                dateTo: selectedDate.Value.Date.AddDays(1).AddTicks(-1),
                                employeeId: employee.EmployeeId
                            );

                            if (existingAssignments != null && existingAssignments.Any())
                            {
                                errorMessages.Add($"Nhân viên {employee.FullName} đã có ca làm việc vào ngày {selectedDate.Value:dd/MM/yyyy}");
                                isValid = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessages.Add($"Lỗi kiểm tra phân ca nhân viên: {ex.Message}");
                        isValid = false;
                    }
                }
            }

            // Show error messages if validation failed
            if (!isValid && errorMessages.Count > 0)
            {
                var message = "Vui lòng sửa các lỗi sau:\n\n";
                for (int i = 0; i < errorMessages.Count; i++)
                {
                    message += $"{i + 1}. {errorMessages[i]}\n";
                }

                label2.Visible = true;
                errorProvider1.SetError(label2, message);
            }

            return isValid;
        }

        private async Task<List<string>> ValidateShiftInputDetailedAsync()
        {
            var errorMessages = new List<string>();

            // Validate shift name
            if (string.IsNullOrWhiteSpace(shiftNameTextBox.Text))
            {
                errorMessages.Add("Tên ca làm việc không được để trống");
            }
            else if (shiftNameTextBox.Text.Trim().Length < 2)
            {
                errorMessages.Add("Tên ca làm việc phải có ít nhất 2 ký tự");
            }
            else if (shiftNameTextBox.Text.Trim().Length > 100)
            {
                errorMessages.Add("Tên ca làm việc không được quá 100 ký tự");
            }

            // Validate shift type
            if (shiftTypeComboBox.SelectedItem == null)
            {
                errorMessages.Add("Vui lòng chọn loại ca làm việc");
            }

            // Validate expected hours
            if (expectedHoursNumeric.Value <= 0)
            {
                errorMessages.Add("Số giờ dự kiến phải lớn hơn 0");
            }
            else if (expectedHoursNumeric.Value > 24)
            {
                errorMessages.Add("Số giờ dự kiến không được quá 24 giờ");
            }

            // Validate time range
            var startTime = startTimePicker.Value.TimeOfDay;
            var endTime = endTimePicker.Value.TimeOfDay;

            if (startTime == endTime)
            {
                errorMessages.Add("Thời gian bắt đầu và kết thúc không được giống nhau");
            }

            // Validate date selection if not shift-only mode
            if (!createShiftOnlyCheckBox.Checked && selectedDate == null)
            {
                errorMessages.Add("Vui lòng chọn ngày cho ca làm việc");
            }
            else if (!createShiftOnlyCheckBox.Checked && selectedDate.HasValue)
            {
                if (selectedDate.Value.Date < DateTime.Today)
                {
                    errorMessages.Add("Không thể tạo ca làm việc cho ngày trong quá khứ");
                }
            }

            // Validate employees selection if not shift-only mode
            if (!createShiftOnlyCheckBox.Checked)
            {
                if (selectedEmployees.Count == 0)
                {
                    errorMessages.Add("Vui lòng chọn ít nhất một nhân viên cho ca làm việc");
                }
                else if (selectedEmployees.Count > 50)
                {
                    errorMessages.Add("Không thể gán quá 50 nhân viên cho một ca làm việc");
                }
            }

            return errorMessages;
        }

        private void CalculateExpectedHours()
        {
            var startTime = startTimePicker.Value.TimeOfDay;
            var endTime = endTimePicker.Value.TimeOfDay;

            var duration = endTime > startTime
                ? endTime - startTime
                : TimeSpan.FromDays(1) - startTime + endTime;

            expectedHoursNumeric.Value = (decimal)duration.TotalHours;
        }

        private async Task ShiftNameTextBox_TextChangedAsync(object? sender, EventArgs e)
        {
            await ValidateFormAsync();
        }

        private async Task TimePicker_ValueChangedAsync(object? sender, EventArgs e)
        {
            CalculateExpectedHours();
            await ValidateFormAsync();
        }

        private async Task CreateShiftOnlyCheckBox_CheckedChangedAsync(object? sender, EventArgs e)
        {
            assignmentTab.Enabled = !createShiftOnlyCheckBox.Checked;
            IsShiftOnlyMode = createShiftOnlyCheckBox.Checked;
            if (createShiftOnlyCheckBox.Checked)
            {
                tabControl.SelectedTab = shiftInfoTab;
            }

            await ValidateFormAsync();
        }

        private async void SaveButton_Click(object? sender, EventArgs e)
        {
            if (!await HasPermissionAsync(PermissionAction.Create))
            {
                MessageBox.Show("Bạn không có quyền tạo ca làm việc.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Perform detailed validation before saving
            var validationErrors = await ValidateShiftInputDetailedAsync();
            if (validationErrors.Count > 0)
            {
                var message = "Vui lòng sửa các lỗi sau trước khi lưu:\n\n";
                for (int i = 0; i < validationErrors.Count; i++)
                {
                    message += $"{i + 1}. {validationErrors[i]}\n";
                }
                
                MessageBox.Show(message, "Lỗi Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (shiftTypeComboBox.SelectedItem is not ShiftTypeDto selectedShiftType)
                {
                    MessageBox.Show("Vui lòng chọn loại ca làm việc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var shiftDto = new ShiftDto
                {
                    Name = shiftNameTextBox.Text.Trim(),
                    StartTime = startTimePicker.Value.TimeOfDay,
                    EndTime = endTimePicker.Value.TimeOfDay,
                    ExpectedHours = expectedHoursNumeric.Value,
                    ShiftTypeId = selectedShiftType.ShiftTypeId,
                    ShiftTypeName = selectedShiftType.Name
                };

                if (!createShiftOnlyCheckBox.Checked && selectedEmployees.Count > 0)
                {
                    var tokenInfo = _authService.GetUserInfoFromToken();
                    foreach (var emp in selectedEmployees)
                    {
                        var shift = await _shiftService.CreateShiftAsync(shiftDto);
                        var assignment = new ShiftAssignmentDto
                        {
                            EmployeeId = emp.EmployeeId,
                            ShiftId = shift.ShiftId,
                            Date = selectedDate ?? DateTime.Today,
                            ApprovedByAccountId = tokenInfo.EmployeeId
                        };

                        await _shiftService.AssignShiftAsync(assignment);
                    }

                    MessageBox.Show($"Tạo ca làm việc và phân công cho {selectedEmployees.Count} nhân viên thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _shiftService.CreateShiftAsync(shiftDto);
                    MessageBox.Show("Tạo ca làm việc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tạo ca làm việc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy? Dữ liệu chưa lưu sẽ bị mất.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetForm();
            }
        }

        private async void ResetForm()
        {
            shiftNameTextBox.Clear();
            startTimePicker.Value = new DateTime(2024, 1, 1, 9, 0, 0);
            endTimePicker.Value = new DateTime(2024, 1, 1, 17, 0, 0);
            expectedHoursNumeric.Value = 8;
            if (shiftTypeComboBox.Items.Count > 0)
                shiftTypeComboBox.SelectedIndex = 0;

            createShiftOnlyCheckBox.Checked = false;
            selectedEmployees.Clear();

            tabControl.SelectedTab = shiftInfoTab;

            await ValidateFormAsync();
        }

        private void assignmentControlsPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dgvPickEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPickEmployee.Rows[e.RowIndex];
                if (row.DataBoundItem is EmployeeDto employee)
                {
                    employeeInSelected = employee;
                }
            }
        }

        private async void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (employeeInSelected == null)
                return;

            if (!selectedEmployees.Any(x => x.EmployeeId == employeeInSelected.EmployeeId))
            {
                selectedEmployees.Add(employeeInSelected);
                await ValidateFormAsync();
            }
            else
            {
                MessageBox.Show("Nhân viên này đã được thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void dgvPickEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPickEmployee.Rows[e.RowIndex];
                if (row.DataBoundItem is EmployeeDto employee)
                {
                    employeeInSelected = employee;
                    if (!selectedEmployees.Any(x => x.EmployeeId == employeeInSelected.EmployeeId))
                    {
                        selectedEmployees.Add(employeeInSelected);
                        await ValidateFormAsync();
                    }
                    LoadDataGridView();
                }
            }
        }

        private void dgvSelectedEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSelectedEmployee.Rows[e.RowIndex];
                if (row.DataBoundItem is EmployeeDto employee)
                {
                    selectedEmployeeInSelected = employee;
                }
            }
        }

        private void removeEmployeeBtn_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeInSelected != null)
            {
                selectedEmployees.Remove(selectedEmployeeInSelected);
            }
            LoadDataGridView();
        }

        private void addAllEmployeeBtn_Click(object sender, EventArgs e)
        {
            selectedEmployees.Clear();
            if (employees != null)
            {
                foreach (var emp in employees)
                {
                    selectedEmployees.Add(emp);
                }
            }
            dgvSelectedEmployee.DataSource = null;
            dgvSelectedEmployee.DataSource = selectedEmployees;
        }

        private async void removeAllEmployee_Click(object sender, EventArgs e)
        {
            selectedEmployees.Clear();
            await ValidateFormAsync();
        }

        // Async method implementations
        private async Task datePicker_DateSelectedAsync(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            dateTextBox.Text = selectedDate.Value.ToString("dd/MM/yyyy");
            await ValidateFormAsync();
        }

        private async Task shiftTypeComboBox_SelectedValueChangedAsync(object sender, EventArgs e)
        {
            await ValidateFormAsync();
        }

        // Event handler methods
        private async void ShiftNameTextBox_TextChanged(object? sender, EventArgs e)
        {
            await ValidateFormAsync();
        }

        private async void TimePicker_ValueChanged(object? sender, EventArgs e)
        {
            CalculateExpectedHours();
            await ValidateFormAsync();
        }

        private async void CreateShiftOnlyCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            assignmentTab.Enabled = !createShiftOnlyCheckBox.Checked;
            IsShiftOnlyMode = createShiftOnlyCheckBox.Checked;
            if (createShiftOnlyCheckBox.Checked)
            {
                tabControl.SelectedTab = shiftInfoTab;
            }

            await ValidateFormAsync();
        }

        private async void datePicker_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            dateTextBox.Text = selectedDate.Value.ToString("dd/MM/yyyy");
            await ValidateFormAsync();
        }

        private async void shiftTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            await ValidateFormAsync();
        }

        private async void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            await InitializeData();
            LoadDataGridView();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            await InitializeData();
            LoadDataGridView();
        }
    }
}