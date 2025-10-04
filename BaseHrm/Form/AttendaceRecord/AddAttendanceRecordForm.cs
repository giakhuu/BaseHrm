using BaseHrm.Controls;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using BaseHrm.Utils;
using Microsoft.Extensions.DependencyInjection;
using ScottPlot.Colormaps;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm
{
    public partial class AddAttendanceRecordForm : Form
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IServiceProvider _serviceProvider;

        private AttendanceRecordDto AttendanceRecordDto { get; set; } = new AttendanceRecordDto();
        private EmployeeDto? EmployeeDto { get; set; }
        private ShiftAssignmentDto? ShiftAssignmentDto { get; set; }

        private readonly int? _attendanceRecordId;
        private bool _isEditMode = false;

        public AddAttendanceRecordForm(
            IAttendanceService attendanceService,
            IServiceProvider serviceProvider,
            int? attendanceRecordId = null)
        {
            InitializeComponent();

            _attendanceService = attendanceService ?? throw new ArgumentNullException(nameof(attendanceService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _attendanceRecordId = attendanceRecordId;

            this.Load += async (s, e) => await LoadFormAsync();

            dtpCheckOut.Enabled = chkHasCheckOut.Checked;
            UpdateButtons();
        }

        private async Task LoadFormAsync()
        {
            if (!_attendanceRecordId.HasValue)
            {
                lblFormTitle.Text = "Thêm bản ghi chấm công";
                btnEdit.Visible = false;
                dtpCheckIn.Value = DateTime.Now;
                chkHasCheckOut.Checked = false;
                return;
            }

            try
            {
                lblFormTitle.Text = "Thông tin bản ghi chấm công";
                btnEdit.Visible = true;
                btnPickShift.Visible = false;
                dtpCheckIn.Enabled = false;
                chkHasCheckOut.Visible = false;

                // Lấy attendance dto
                AttendanceRecordDto = await _attendanceService.GetByIdAsync(_attendanceRecordId.Value);
                if (AttendanceRecordDto == null)
                {
                    MessageBox.Show("Không tìm thấy bản ghi chấm công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                var employeeService = _serviceProvider.GetRequiredService<IEmployeeService>();
                if (EmployeeDto == null || EmployeeDto.EmployeeId != AttendanceRecordDto.EmployeeId)
                {
                    EmployeeDto = await employeeService.GetByIdAsync(AttendanceRecordDto.EmployeeId);
                    if (EmployeeDto != null)
                    {
                        txtEmployeeId.Text = EmployeeDto.EmployeeId.ToString();
                        txtEmployeeName.Text = EmployeeDto.FullName;
                        txtEmployeePosition.Text = EmployeeDto.Position ?? "N/A";
                        txtEmployeeEmail.Text = EmployeeDto.Email;
                    }
                }
                var shiftService = _serviceProvider.GetRequiredService<IShiftService>();
                if (AttendanceRecordDto.ShiftAssignmentId.HasValue)
                {
                    ShiftAssignmentDto = await shiftService.GetAssignmentByIdAsync(AttendanceRecordDto.ShiftAssignmentId.Value);
                    if (ShiftAssignmentDto != null)
                    {
                        txtShiftName.Text = ShiftAssignmentDto.ShiftName;
                        txtShiftId.Text = ShiftAssignmentDto.ShiftAssignmentId.ToString();
                        txtShiftFromTime.Text = ShiftAssignmentDto.ShiftStart.ToString();
                        txtShiftToTime.Text = ShiftAssignmentDto.ShiftEnd.ToString();
                    }
                }

                try
                {
                    dtpCheckIn.Value = AttendanceRecordDto.CheckIn;
                }
                catch { dtpCheckIn.Value = DateTime.Now; }

                if (AttendanceRecordDto.CheckOut.HasValue)
                {
                    try { dtpCheckOut.Value = AttendanceRecordDto.CheckOut.Value; }
                    catch { dtpCheckOut.Value = dtpCheckIn.Value.AddHours(1); }

                    chkHasCheckOut.Checked = true;
                    dtpCheckOut.Enabled = true;
                }
                else
                {
                    chkHasCheckOut.Checked = false;
                    dtpCheckOut.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateButtons();
            }
        }

        private void UpdateButtons()
        {
            btnSave.Enabled = EmployeeDto != null && ShiftAssignmentDto != null;
        }

        private bool ValidateAttendanceInput()
        {
            var errors = new List<string>();

            // Validate employee selection
            if (EmployeeDto == null)
            {
                errors.Add("Vui lòng chọn nhân viên");
            }

            // Validate shift assignment
            if (ShiftAssignmentDto == null)
            {
                errors.Add("Vui lòng chọn ca làm việc");
            }

            // Validate check-in time
            var checkInTime = dtpCheckIn.Value;
            var now = DateTime.Now;
            
            if (checkInTime > now)
            {
                errors.Add("Thời gian check-in không được lớn hơn thời gian hiện tại");
            }

            // Check if check-in is too far in the past (more than 30 days)
            if ((now - checkInTime).TotalDays > 30)
            {
                errors.Add("Thời gian check-in không được quá 30 ngày trong quá khứ");
            }

            // Validate date consistency with shift assignment
            if (ShiftAssignmentDto != null)
            {
                var shiftDate = ShiftAssignmentDto.Date.Date;
                var checkInDate = checkInTime.Date;
                
                if (checkInDate != shiftDate)
                {
                    errors.Add($"Ngày check-in ({checkInDate:dd/MM/yyyy}) phải trùng với ngày ca làm việc ({shiftDate:dd/MM/yyyy})");
                }
            }

            // Validate check-out time if provided
            if (chkHasCheckOut.Checked)
            {
                var checkOutTime = dtpCheckOut.Value;

                if (checkOutTime <= checkInTime)
                {
                    errors.Add("Thời gian check-out phải sau thời gian check-in");
                }

                if (checkOutTime > now)
                {
                    errors.Add("Thời gian check-out không được lớn hơn thời gian hiện tại");
                }

                // Validate work duration
                var workDuration = checkOutTime - checkInTime;
                if (workDuration.TotalHours > 24)
                {
                    errors.Add("Thời gian làm việc không được quá 24 giờ");
                }
                else if (workDuration.TotalMinutes < 1)
                {
                    errors.Add("Thời gian làm việc tối thiểu là 1 phút");
                }

                // Warn if work duration is unusually long
                if (workDuration.TotalHours > 16)
                {
                    var result = MessageBox.Show(
                        $"⚠️ Thời gian làm việc ({workDuration.TotalHours:F1} giờ) có vẻ quá dài.\n\nBạn có chắc chắn muốn tiếp tục?",
                        "Cảnh báo thời gian làm việc",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    
                    if (result != DialogResult.Yes)
                    {
                        return false;
                    }
                }
            }

            // Validate working time against employee's max hours
            if (EmployeeDto != null && chkHasCheckOut.Checked)
            {
                var workDuration = dtpCheckOut.Value - checkInTime;
                var workHours = (decimal)workDuration.TotalHours;
                
                if (workHours > EmployeeDto.MaxHoursPerDay)
                {
                    errors.Add($"Thời gian làm việc ({workHours:F1} giờ) vượt quá giới hạn tối đa của nhân viên ({EmployeeDto.MaxHoursPerDay} giờ/ngày)");
                }
            }

            // Show validation errors if any
            if (errors.Count > 0)
            {
                this.ShowDetailedValidationErrors(errors, "Lỗi chấm công");
                return false;
            }

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAttendanceInput())
            {
                return;
            }

            try
            {
                // Prepare DTO to save
                AttendanceRecordDto.EmployeeId = EmployeeDto!.EmployeeId;
                AttendanceRecordDto.ShiftAssignmentId = ShiftAssignmentDto!.ShiftAssignmentId;
                AttendanceRecordDto.CheckIn = dtpCheckIn.Value;
                AttendanceRecordDto.CheckOut = chkHasCheckOut.Checked ? dtpCheckOut.Value : (DateTime?)null;

                if (_isEditMode && _attendanceRecordId.HasValue)
                {
                    // Update
                    AttendanceRecordDto.AttendanceRecordId = _attendanceRecordId.Value;
                    var updated = await _attendanceService.UpdateAsync(AttendanceRecordDto);
                    if (updated)
                    {
                        MessageBox.Show("Cập nhật bản ghi chấm công thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật bản ghi chấm công.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Create new
                    var created = await _attendanceService.CreateAsync(AttendanceRecordDto);
                    MessageBox.Show($"Tạo bản ghi chấm công thành công với ID: {created.AttendanceRecordId}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu bản ghi chấm công: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPickShift_Click(object sender, EventArgs e)
        {
            var pick = _serviceProvider.GetRequiredService<PickShiftAssignmentControl>();

            if (pick.Size.Width == 0 || pick.Size.Height == 0)
            {
                pick.Size = new Size(600, 400);
            }

            var host = new ToolStripControlHost(pick)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
            };

            host.AutoSize = false;
            host.Size = pick.Size;

            var popup = new ToolStripDropDown
            {
                AutoClose = true,
                DropShadowEnabled = true
            };

            popup.Items.Add(host);

            pick.ShiftAsignmentSelected += (shift) =>
            {
                this.Invoke(new Action(() =>
                {
                    ShiftAssignmentDto = shift;
                    txtEmployeeId.Text = shift.EmployeeId.ToString();
                    txtEmployeeName.Text = shift.EmployeeFullName;
                    txtEmployeePosition.Text = shift.EmployeePosition ?? "N/A";
                    txtEmployeeEmail.Text = shift.EmployeeEmail;
                    EmployeeDto = new EmployeeDto
                    {
                        EmployeeId = shift.EmployeeId,
                        Position = shift.EmployeePosition,
                        Email = shift.EmployeeEmail
                    };

                    txtShiftName.Text = shift.ShiftName;
                    txtShiftId.Text = shift.ShiftAssignmentId.ToString();
                    txtShiftFromTime.Text = shift.ShiftStart.ToString();
                    txtShiftToTime.Text = shift.ShiftEnd.ToString();
                    UpdateButtons();
                }));

                popup.Close();
            };

            pick.RequestClose += () => popup.Close();

            var clientPoint = this.PointToClient(Cursor.Position);
            popup.Show(this, clientPoint);

            pick.Focus();
        }

        private void chkHasCheckOut_CheckedChanged(object sender, EventArgs e)
        {
            dtpCheckOut.Enabled = chkHasCheckOut.Checked;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isEditMode = true;
            btnEdit.Visible = false;
            btnPickShift.Visible = true;
            dtpCheckIn.Enabled = true;
            chkHasCheckOut.Visible = true;
            UpdateButtons();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
