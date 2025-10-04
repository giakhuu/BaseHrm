using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace BaseHrm.Controls
{
    public partial class CheckInControl : UserControl
    {
        private Timer clockTimer;
        private DateTime lastCheckTime = DateTime.MinValue;
        private IShiftService _shiftService;
        private IAttendanceService _attendanceService;
        private IServiceProvider _provider;
        private ShiftAssignmentDto? _todayShift;
        private AttendanceRecordDto? _todayAttendance;
        private bool _isCheckInMode = true;

        public CheckInControl()
        {
            InitializeComponent();
            InitializeClockTimer();
            // Lấy service từ DI
            _provider = Program.ServiceProvider;
            _shiftService = _provider.GetRequiredService<IShiftService>();
            _attendanceService = _provider.GetRequiredService<IAttendanceService>();
            this.Load += async (s, e) => await LoadTodayShiftAndAttendance();
        }

        private void InitializeClockTimer()
        {
            clockTimer = new Timer();
            clockTimer.Interval = 1000; // Update every second
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
            CenterControls(); // Update positions to ensure centering
        }

        private async Task LoadTodayShiftAndAttendance()
        {
            var now = DateTime.Now;
            var userInfo = _provider.GetRequiredService<IAuthService>().GetUserInfoFromToken();
            int? employeeId = userInfo.EmployeeId;
            if (!employeeId.HasValue)
            {
                txtAttendanceStatus.Text = "Không xác định nhân viên";
                return;
            }
            // Lấy shift assignment hôm nay
            _todayShift = await _shiftService.getTodayShiftAssignmentAsync();
            if (_todayShift == null)
            {
                txtAttendanceStatus.Text = "Không có ca làm hôm nay";
                return;
            }
            // Hiển thị thông tin ca làm
            txtShiftName.Text = _todayShift.ShiftName;
            txtShiftStart.Text = _todayShift.ShiftStart.ToString(@"hh\:mm");
            txtShiftEnd.Text = _todayShift.ShiftEnd.ToString(@"hh\:mm");
            // Lấy attendance record của ca làm này
            _todayAttendance = await _attendanceService.selfTodayAttendance();
            if (_todayAttendance != null)
            {
                txtCheckIn.Text = _todayAttendance.CheckIn.ToString("HH:mm:ss");
                txtCheckOut.Text = _todayAttendance.CheckOut?.ToString("HH:mm:ss") ?? "";
                txtAttendanceStatus.Text = _todayAttendance.CheckOut == null ? "Đã check in" : "Đã check out";
            }
            else
            {
                txtCheckIn.Text = "";
                txtCheckOut.Text = "";
                txtAttendanceStatus.Text = "Chưa chấm công";
            }
            UpdateCheckButtonState(now);
        }

        private void UpdateCheckButtonState(DateTime now)
        {
            if (_todayShift == null)
            {
                btnCheckAttendance.Enabled = false;
                btnCheckAttendance.Text = "Không có ca làm";
                return;
            }
            var checkInTime = _todayShift.ShiftStart;
            var checkOutTime = _todayShift.ShiftEnd;
            var nowTime = now.TimeOfDay;
            var checkInWindowStart = checkInTime - TimeSpan.FromMinutes(30);
            var checkInWindowEnd = checkInTime + TimeSpan.FromMinutes(30);
            if (_todayAttendance == null)
            {
                // Nếu giờ hiện tại nằm trong khoảng nửa tiếng trước/sau giờ check in thì là check in
                if (nowTime >= checkInWindowStart && nowTime <= checkInWindowEnd)
                {
                    _isCheckInMode = true;
                    btnCheckAttendance.Text = "Check In";
                    btnCheckAttendance.Enabled = true;
                }
                else if (nowTime > checkInWindowEnd)
                {
                    // Quá nửa tiếng sau giờ check in thì là check out
                    _isCheckInMode = false;
                    btnCheckAttendance.Text = "Check Out";
                    btnCheckAttendance.Enabled = true;
                }
                else
                {
                    btnCheckAttendance.Text = "Chưa đến giờ chấm công";
                    btnCheckAttendance.Enabled = false;
                }
            }
            else
            {
                if (_todayAttendance.CheckOut == null)
                {
                    // Nếu đã check in mà chưa check out thì cho phép check out
                    _isCheckInMode = false;
                    btnCheckAttendance.Text = "Check Out";
                    btnCheckAttendance.Enabled = true;
                }
                else
                {
                    btnCheckAttendance.Text = "Đã hoàn thành";
                    btnCheckAttendance.Enabled = false;
                }
            }
        }

        private async void btnCheckAttendance_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var userInfo = _provider.GetRequiredService<IAuthService>().GetUserInfoFromToken();
            int? employeeId = userInfo.EmployeeId;
            if (!employeeId.HasValue || _todayShift == null)
            {
                MessageBox.Show("Không xác định nhân viên hoặc ca làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_isCheckInMode)
            {
                // Tạo attendance record mới
                var dto = new Data.DTO.AttendanceRecordDto
                {
                    EmployeeId = employeeId.Value,
                    ShiftAssignmentId = _todayShift.ShiftAssignmentId,
                    CheckIn = now
                };
                var created = await _attendanceService.selfCheck(dto);
                MessageBox.Show("Check in thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Update attendance record với check out
                if (_todayAttendance == null)
                {
                    var dto = new Data.DTO.AttendanceRecordDto
                    {
                        EmployeeId = employeeId.Value,
                        ShiftAssignmentId = _todayShift.ShiftAssignmentId,
                        CheckOut = now
                    };
                    var created = await _attendanceService.selfCheck(dto);
                }
                var updated = await _attendanceService.selfCheckOut();
                MessageBox.Show("Check out thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            await LoadTodayShiftAndAttendance();
        }

        private void CheckInControl_Load(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CheckInControl_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }

        private void CenterControls()
        {
            // Center lblCurrentTime
            int xCurrentTime = (ClientSize.Width - lblCurrentTime.Width) / 2;
            int yCurrentTime = (ClientSize.Height - lblCurrentTime.Height) / 2;
            lblCurrentTime.Location = new Point(xCurrentTime, yCurrentTime);

            // Center btnCheckAttendance below lblCurrentTime with some spacing
            int xButton = (ClientSize.Width - btnCheckAttendance.Width) / 2;
            int yButton = yCurrentTime + lblCurrentTime.Height + 30; // 30 pixels spacing
            btnCheckAttendance.Location = new Point(xButton, yButton);

            // Center lblLastCheck below btnCheckAttendance with some spacing
            int xLastCheck = (ClientSize.Width - lblLastCheck.Width) / 2;
            int yLastCheck = yButton + btnCheckAttendance.Height + 20; // 20 pixels spacing
            lblLastCheck.Location = new Point(xLastCheck, yLastCheck);
        }
    }
}