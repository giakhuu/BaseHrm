using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using BaseHrm.Reports;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BaseHrm.Controls
{
    public partial class AttendanceManagementControl : UserControl
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IShiftService _shiftService;
        private readonly IServiceProvider _provider;
        private readonly IBackupRestoreService _backupRestoreService;

        private List<AttendanceRecordDto> _attendanceRecords = new();
        private EmployeeDto? _currentEmployee = null;
        private ShiftAssignmentDto? _currentShiftAsignment = null;
        private TeamDto? _currentTeam = null;
        private bool _isResetting = false;

        private bool _isInitial = false;
        private bool _isLoadingData = false;
        private System.Windows.Forms.Timer _dateChangeTimer = new System.Windows.Forms.Timer();

        public AttendanceManagementControl(
            IAttendanceService attendanceService,
            IServiceProvider provider,
            IShiftService shiftService,
            IBackupRestoreService backupRestoreService
            )
        {
            InitializeComponent();
            _attendanceService = attendanceService;
            _shiftService = shiftService;
            _provider = provider;
            _backupRestoreService = backupRestoreService;

            // Setup date change timer to avoid frequent loading
            _dateChangeTimer.Interval = 500; // 500ms delay
            _dateChangeTimer.Tick += async (s, e) =>
            {
                _dateChangeTimer.Stop();
                await SafeLoadAttendanceRecordsAsync();
            };

            this.Load += async (s, e) =>
            {
                try
                {
                    SetupDateRangeDefaults(); // Remove await - it's not async
                    await LoadAttendaceRecordsAsync();
                    await LoadShiftType();
                    LoadControlInfo();
                    _isInitial = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khởi tạo control: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Setup disposal
            this.HandleDestroyed += (s, e) =>
            {
                try
                {
                    _dateChangeTimer?.Stop();
                    _dateChangeTimer?.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error disposing AttendanceManagementControl: {ex.Message}");
                }
            };
        }

        private void SetupDateRangeDefaults()
        {
            try
            {
                var today = DateTime.Today;
                var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                // Set date picker limits to prevent invalid selections
                dtpFromDate.MinDate = new DateTime(2020, 1, 1); // Company start date
                dtpFromDate.MaxDate = DateTime.Today.AddYears(1); // 1 year in future
                dtpToDate.MinDate = new DateTime(2020, 1, 1);
                dtpToDate.MaxDate = DateTime.Today.AddYears(1);

                // Set date range without triggering events
                dtpFromDate.ValueChanged -= dtpFromDate_ValueChanged;
                dtpToDate.ValueChanged -= dtpToDate_ValueChanged;

                dtpFromDate.Value = firstDayOfMonth;
                dtpToDate.Value = lastDayOfMonth;

                // Re-attach events
                dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
                dtpToDate.ValueChanged += dtpToDate_ValueChanged;

                Console.WriteLine($"Date range set: {dtpFromDate.Value:yyyy-MM-dd} to {dtpToDate.Value:yyyy-MM-dd}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up date defaults: {ex.Message}");

                // Fallback to safe defaults
                dtpFromDate.ValueChanged -= dtpFromDate_ValueChanged;
                dtpToDate.ValueChanged -= dtpToDate_ValueChanged;

                dtpFromDate.Value = DateTime.Today.AddDays(-30);
                dtpToDate.Value = DateTime.Today;

                dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
                dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            }
        }

        private async Task SafeLoadAttendanceRecordsAsync()
        {
            if (_isLoadingData) return;

            try
            {
                _isLoadingData = true;
                await LoadAttendaceRecordsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu chấm công: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoadingData = false;
            }
        }

        private bool ValidateDateRange()
        {
            try
            {
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date;

                // Check if from date is after to date
                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi ngày tháng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Auto-fix: set to date to from date
                    dtpToDate.ValueChanged -= dtpToDate_ValueChanged;
                    dtpToDate.Value = fromDate;
                    dtpToDate.ValueChanged += dtpToDate_ValueChanged;

                    return false;
                }

                // Check if date range is too large (more than 1 year)
                var daysDifference = (toDate - fromDate).TotalDays;
                if (daysDifference > 365)
                {
                    MessageBox.Show("Khoảng thời gian không được vượt quá 1 năm.", "Lỗi ngày tháng",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Auto-fix: set to date to 1 year from from date
                    dtpToDate.ValueChanged -= dtpToDate_ValueChanged;
                    dtpToDate.Value = fromDate.AddYears(1);
                    dtpToDate.ValueChanged += dtpToDate_ValueChanged;

                    return false;
                }

                // Check if dates are too far in the future
                if (fromDate > DateTime.Today.AddDays(30))
                {
                    MessageBox.Show("Ngày bắt đầu không nên quá xa trong tương lai.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating date range: {ex.Message}");
                return false;
            }
        }

        private async Task LoadAttendaceRecordsAsync()
        {
            try
            {
                Console.WriteLine("=== LOADING ATTENDANCE RECORDS ===");
                Console.WriteLine($"Date range: {dtpFromDate.Value:yyyy-MM-dd} to {dtpToDate.Value:yyyy-MM-dd}");
                if (!ValidateDateRange())
                {
                    Console.WriteLine("Date range validation failed");
                    return;
                }
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1).AddTicks(-1);
                Console.WriteLine($"Querying with employeeId: {_currentEmployee?.EmployeeId}");
                Console.WriteLine($"ShiftAssignment: {_currentShiftAsignment?.ShiftAssignmentId}");
                Console.WriteLine($"ShiftType: {(cmbShiftFilter.SelectedItem as ShiftTypeDto)?.ShiftTypeId}");
                Console.WriteLine($"Team: {_currentTeam?.Name}");
                _attendanceRecords = await _attendanceService.QueryAsync(
                    employeeId: _currentEmployee?.EmployeeId,
                    shiftAssignmentId: _currentShiftAsignment?.ShiftAssignmentId,
                    shiftTypeId: (cmbShiftFilter.SelectedItem as ShiftTypeDto)?.ShiftTypeId > 0 ? (cmbShiftFilter.SelectedItem as ShiftTypeDto)?.ShiftTypeId : null,
                    dateFrom: fromDate,
                    dateTo: toDate,
                    teamId: _currentTeam?.TeamId
                );
                Console.WriteLine($"Found {_attendanceRecords?.Count ?? 0} records");
                // Không cần lọc lại theo quyền nữa
                this.Invoke(new Action(() =>
                {
                    try
                    {
                        attendanceRecordDtoBindingSource.DataSource = _attendanceRecords ?? new List<AttendanceRecordDto>();
                        dgvAttendance.DataSource = attendanceRecordDtoBindingSource;
                        dgvAttendance.Refresh();
                        LoadControlInfo();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error updating UI: {ex.Message}");
                    }
                }));
                Console.WriteLine("=== ATTENDANCE RECORDS LOADED SUCCESSFULLY ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading attendance records: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                this.Invoke(new Action(() =>
                {
                    attendanceRecordDtoBindingSource.DataSource = new List<AttendanceRecordDto>();
                    dgvAttendance.DataSource = attendanceRecordDtoBindingSource;
                    LoadControlInfo();
                }));
                throw;
            }
        }

        private void LoadControlInfo()
        {
            try
            {
                var records = _attendanceRecords ?? new List<AttendanceRecordDto>();

                lblTotalRecordsValue.Text = records.Count.ToString();

                // Calculate total valid hours with PayMultiplier applied
                var totalValidHours = records.Sum(r => r.ValidDurationHours * (r.PayMultiplier ?? 1));
                lblTotalHoursValue.Text = totalValidHours.ToString("F2");

                lblPendingCheckoutsValue.Text = records.Count(r => r.CheckOut == null).ToString();
                lblAvgHoursValue.Text = (records.Count > 0 ? records.Average(r => r.DurationHours ?? 0) : 0).ToString("F2");


                Console.WriteLine("Pay Muti" + records[0].ShiftTypeName);
                var overtimeHours = records
                    .Where(r => r.IsOvertime)
                    .Sum(r => r.ValidDurationHours * (r.PayMultiplier ?? 1));
                lblOvertimeHoursValue.Text = overtimeHours.ToString("F2");

                int activeCount = records
                    .Count(r => r.ShiftDate.HasValue
                     && r.ShiftDate.Value.Date == DateTime.Today
                     && !r.CheckOut.HasValue);
                lblActiveEmployeesValue.Text = activeCount.ToString();
                lblRecordCount.Text = $"Tổng: {records.Count} bản ghi";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading control info: {ex.Message}");

                // Set default values if error occurs
                lblTotalRecordsValue.Text = "0";
                lblTotalHoursValue.Text = "0.00";
                lblPendingCheckoutsValue.Text = "0";
                lblAvgHoursValue.Text = "0.00";
                lblOvertimeHoursValue.Text = "0.00";
                lblActiveEmployeesValue.Text = "0";
                lblRecordCount.Text = "Tổng: 0 bản ghi";
            }
        }

        private async void btnAddRecord_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<AddAttendanceRecordForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadAttendaceRecordsAsync();
                LoadControlInfo();
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isInitial) return;

            try
            {
                Console.WriteLine($"From date changed to: {dtpFromDate.Value:yyyy-MM-dd}");

                // Stop current timer and restart
                _dateChangeTimer.Stop();
                _dateChangeTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in dtpFromDate_ValueChanged: {ex.Message}");
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isInitial) return;

            try
            {
                Console.WriteLine($"To date changed to: {dtpToDate.Value:yyyy-MM-dd}");

                // Stop current timer and restart
                _dateChangeTimer.Stop();
                _dateChangeTimer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in dtpToDate_ValueChanged: {ex.Message}");
            }
        }

        private void lblShiftFilter_Click(object sender, EventArgs e)
        {
        }

        private void txtEmployeeSearch_Click(object sender, EventArgs e)
        {
            var pick = _provider.GetRequiredService<PickEmployeeControl>();

            var host = new ToolStripControlHost(pick)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
            };

            var popup = new ToolStripDropDown
            {
                AutoClose = true,
                DropShadowEnabled = true
            };
            popup.Items.Add(host);

            pick.EmployeeSelected += async (emp) =>
            {
                this.Invoke(new Action(async () =>
                {
                    _currentEmployee = emp;
                    txtEmployeeSearch.Text = emp.FullName;
                    await LoadAttendaceRecordsAsync();
                }));

                popup.Close();
            };

            pick.RequestClose += () => popup.Close();

            var point = Cursor.Position;
            popup.Show(point);

            pick.Focus();
        }

        private void txtTeamSearch_Click(object sender, EventArgs e)
        {
            var pick = _provider.GetRequiredService<PickTeamControl>();

            var host = new ToolStripControlHost(pick)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
            };

            var popup = new ToolStripDropDown
            {
                AutoClose = true,
                DropShadowEnabled = true
            };
            popup.Items.Add(host);

            pick.TeamSelected += async (emp) =>
            {
                this.Invoke(new Action(async () =>
                {
                    _currentTeam = emp;
                    textBox1.Text = emp.Name;
                    await LoadAttendaceRecordsAsync();
                }));

                popup.Close();
            };

            pick.RequestClose += () => popup.Close();

            var point = Cursor.Position;
            popup.Show(point);

            pick.Focus();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatusFilter.SelectedIndex == 0)
            {
                attendanceRecordDtoBindingSource.DataSource = _attendanceRecords;
            }
            else if (cmbStatusFilter.SelectedIndex == 2)
            {
                attendanceRecordDtoBindingSource.DataSource = _attendanceRecords.Where(r => r.CheckIn != null).ToList();
            }
            else if (cmbStatusFilter.SelectedIndex == 1)
            {
                attendanceRecordDtoBindingSource.DataSource = _attendanceRecords.Where(r => r.CheckOut == null).ToList();
            }
        }

        private async void cmbShiftFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitial == false || _isResetting == true)
            {
                return;
            }
            await LoadAttendaceRecordsAsync();
        }

        private async void menuItemViewDetails_Click(object sender, EventArgs e)
        {
            if (_isInitial == false || _isResetting == true) return;
            if (dgvAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRecord = dgvAttendance.SelectedRows[0].DataBoundItem as AttendanceRecordDto;
            if (selectedRecord == null)
            {
                MessageBox.Show("Bản ghi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Không cần kiểm tra quyền ở đây nữa
            var form = ActivatorUtilities.CreateInstance<AddAttendanceRecordForm>(_provider, selectedRecord.AttendanceRecordId);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                await LoadAttendaceRecordsAsync();
            }
        }

        private async void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var selectedRecord = dgvAttendance.SelectedRows[0].DataBoundItem as AttendanceRecordDto;
            if (selectedRecord == null)
            {
                MessageBox.Show("Bản ghi không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Không cần kiểm tra quyền ở đây nữa
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi chấm công này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _attendanceService.DeleteAsync(selectedRecord.AttendanceRecordId);
                    await LoadAttendaceRecordsAsync();
                    MessageBox.Show("Xóa bản ghi thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa bản ghi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblOvertimeHoursValue_Click(object sender, EventArgs e)
        {
        }

        private async void btnExportData_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;
            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                sfd.Title = "Chọn đường dẫn lưu báo cáo";
                sfd.FileName = "BaoCaoChamCong.xlsx";
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                selectedPath = sfd.FileName;
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            btnExportData.Enabled = false;
            var attendanceCopy = _attendanceRecords.ToList();
            string reportTitle = $"Báo Cáo Chấm Công Từ {from:dd/MM/yyyy} Đến {to:dd/MM/yyyy}";
            if (selectedPath == "")
            {
                btnExportData.Enabled = true;
                return;
            }
            await Task.Run(() =>
            {
                var exporter = new AttendanceReportExporter();
                exporter.ExportToExcel(attendanceCopy, selectedPath!, reportTitle, from, to);
            });
            MessageBox.Show("Báo cáo đã được xuất thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnExportData.Enabled = true;
        }

        private async Task LoadShiftType()
        {
            try
            {
                Console.WriteLine("Loading shift types...");
                List<ShiftTypeDto> shifts = await _shiftService.GetAllShiftTypesAsync();
                shifts.Insert(0, new ShiftTypeDto { ShiftTypeId = 0, Name = "Tất cả" });

                cmbShiftFilter.DataSource = shifts;
                cmbShiftFilter.DisplayMember = "Name";
                cmbShiftFilter.ValueMember = "ShiftTypeId";
                cmbShiftFilter.SelectedIndex = 0; // Default to "Tất cả"

                Console.WriteLine($"Loaded {shifts.Count} shift types");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading shift types: {ex.Message}");
                MessageBox.Show($"Lỗi tải loại ca làm việc: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnClearFilters_Click(object sender, EventArgs e)
        {
            _isResetting = true;
            cmbShiftFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            _currentEmployee = null;
            txtEmployeeSearch.Text = "Chọn Nhân viên";
            _currentTeam = null;
            textBox1.Text = "Chọn Team";
            await LoadAttendaceRecordsAsync();
            _isResetting = false;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadAttendaceRecordsAsync();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                sfd.Title = "Chọn đường dẫn lưu dữ liệu chấm công";
                sfd.FileName = "BackupChamCong.json";
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;
                selectedPath = sfd.FileName;
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            if (selectedPath == "")
            {
                return;
            }
            await _backupRestoreService.BackupAttendanceAsync(selectedPath);
            MessageBox.Show("Đã backup và xóa dữ liệu chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                ofd.Title = "Chọn file dữ liệu chấm công để khôi phục";
                ofd.FileName = "BackupChamCong.json";
                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;
                selectedPath = ofd.FileName;
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            if (selectedPath == "")
            {
                return;
            }
            try
            {
                await _backupRestoreService.RestoreAttendanceAsync(selectedPath);

                MessageBox.Show("Đã khôi phục dữ liệu chấm công thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadAttendaceRecordsAsync();
            }
            catch (DbUpdateException dbEx)
            {
                var inner = dbEx.InnerException;

                string detail;
                if (inner is Microsoft.Data.SqlClient.SqlException sqlEx)
                {
                    detail = $"SQL Error {sqlEx.Number}: {sqlEx.Message}";
                }
                else
                {
                    detail = dbEx.Message;
                }
                MessageBox.Show($"Lỗi khi khôi phục dữ liệu chấm công:\n{detail}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Microsoft.Data.SqlClient.SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi SQL: {sqlEx.Number} - {sqlEx.Message}",
                    "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi: {ex.Message}", "Lỗi không xác định",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
