using BaseHrm.Controls;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaseHrm
{
    public partial class MainForm : Form
    {
        private Button? currentActiveButton;
        private readonly Color activeColor = Color.FromArgb(52, 152, 219);
        private readonly Color hoverColor = Color.FromArgb(64, 164, 231);
        private readonly Color inactiveColor = Color.Transparent;
        private readonly Color logoutHoverColor = Color.FromArgb(241, 86, 70);
        private readonly IServiceProvider _provider;
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authService;
        private readonly IPermissionService _permissionService;
        private EmployeeDto? employeeDto;
        private String username = "";
        private int? _currentAccountId;
        private bool _isMasterAccount;

        public MainForm(IServiceProvider provider, IAuthService authService, IEmployeeService employeeService, IPermissionService permissionService)
        {
            InitializeComponent();
            _provider = provider;
            _authService = authService;
            _employeeService = employeeService;
            _permissionService = permissionService;

            this.Load += async (sender, e) =>
            {
                await GetCurrentUser();
                InitializeForm();
                await SetupMenuPermissions();
            };
        }

        private void InitializeForm()
        {
            this.Icon = SystemIcons.Application;
            
            SetUserInfo(username, employeeDto?.FullName ?? "");
            Console.WriteLine($"usename: ${username}");
            AddHoverEffects();
        }

        private async Task GetCurrentUser()
        {
            var (AccountId, Username, Role, IsMaster, EmployeeId) = _authService.GetUserInfoFromToken();
            username = Username ?? "";
            _currentAccountId = AccountId;
            _isMasterAccount = IsMaster;
            employeeDto = await _employeeService.GetByIdAsync(EmployeeId ?? -1);
        }

        private async Task SetupMenuPermissions()
        {
            if (_isMasterAccount || !_currentAccountId.HasValue)
            {
                // Master account có tất cả quyền
                return;
            }

            // Kiểm tra quyền cho từng menu
            await SetMenuVisibility(employeesButton, ModuleName.Employee);
            await SetMenuVisibility(teamsButton, ModuleName.Team);
            await SetMenuVisibility(shiftsButton, ModuleName.Shift);
            await SetMenuVisibility(timekeepingButton, ModuleName.Attendance);
            await SetMenuVisibility(accountButton, ModuleName.Account);
            // roleButton chỉ hiển thị cho admin hoặc master
            roleButton.Visible = _isMasterAccount || await _permissionService.HasPermissionAsync(_currentAccountId.Value, ModuleName.Account, PermissionAction.All);
        }

        private async Task SetMenuVisibility(Button menuButton, ModuleName module)
        {
            if (!_currentAccountId.HasValue)
            {
                menuButton.Visible = false;
                return;
            }

            // Kiểm tra có ít nhất quyền View
            bool hasPermission = await _permissionService.HasPermissionAsync(_currentAccountId.Value, module, PermissionAction.View);
            menuButton.Visible = hasPermission;
        }

        private void AddHoverEffects()
        {
            foreach (System.Windows.Forms.Control control in menuPanel.Controls)
            {
                if (control is Button button && button != currentActiveButton && button.Visible)
                {
                    button.MouseEnter += MenuButton_MouseEnter;
                    button.MouseLeave += MenuButton_MouseLeave;
                }
            }
        }

        private void SetUserInfo(string username, string fullName)
        {
            usernameLabel.Text = username;
            fullNameLabel.Text = fullName;
        }

        private void SetActiveButton(Button activeButton)
        {
            foreach (System.Windows.Forms.Control control in menuPanel.Controls)
            {
                if (control is Button button && button.Visible)
                {
                    button.BackColor = inactiveColor;
                    button.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

                    button.MouseEnter -= MenuButton_MouseEnter;
                    button.MouseLeave -= MenuButton_MouseLeave;
                    button.MouseEnter += MenuButton_MouseEnter;
                    button.MouseLeave += MenuButton_MouseLeave;
                }
            }

            currentActiveButton = activeButton;
            activeButton.BackColor = activeColor;
            activeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            activeButton.MouseEnter -= MenuButton_MouseEnter;
            activeButton.MouseLeave -= MenuButton_MouseLeave;
        }

        private void MenuButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button button && button != currentActiveButton)
            {
                button.BackColor = hoverColor;
            }
        }

        private void MenuButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button button && button != currentActiveButton)
            {
                button.BackColor = inactiveColor;
            }
        }

        private void LogoutButton_MouseEnter(object? sender, EventArgs e)
        {
            logoutButton.BackColor = logoutHoverColor;
        }

        private void LogoutButton_MouseLeave(object? sender, EventArgs e)
        {
            logoutButton.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void UpdateContentPanel<T>(string title) where T : UserControl
        {
            contentPanel.Controls.Clear();

            var control = _provider.GetRequiredService<T>();
            control.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(control);

            this.Text = title;
        }

        private async void EmployeesButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Employee))
            {
                SetActiveButton(employeesButton);
                UpdateContentPanel<EmployeeManagementControl>("Control Nhân Viên");
            }
        }

        private async void TeamsButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Team))
            {
                SetActiveButton(teamsButton);
                UpdateContentPanel<TeamManagementControl>("Quản lý team");
            }
        }

        private async void ShiftsButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Shift))
            {
                SetActiveButton(shiftsButton);
                UpdateContentPanel<DailyShiftSummaryControl>("Quản lý ca làm việc");
            }
        }

        private async void TimekeepingButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Attendance))
            {
                SetActiveButton(timekeepingButton);
                UpdateContentPanel<AttendanceManagementControl>("Quản lý chấm công");
            }
        }

        private async void accountButton_Click(object sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Account))
            {
                SetActiveButton(accountButton);
                UpdateContentPanel<AccountManagementControl>("Quản lý tài khoản");
            }
        }

        private async void roleButton_Click(object sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Account, PermissionAction.All))
            {
                SetActiveButton(roleButton);
                UpdateContentPanel<RoleManagementControl>("Quản lý quyền");
            }
        }

        private async Task<bool> CheckModulePermission(ModuleName module, PermissionAction action = PermissionAction.View)
        {
            if (_isMasterAccount) return true;
            
            if (!_currentAccountId.HasValue) 
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool hasPermission = await _permissionService.HasPermissionAsync(_currentAccountId.Value, module, action);
            if (!hasPermission)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return hasPermission;
        }

        private void LogoutButton_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _authService.Logout();
                var loginForm = _provider.GetRequiredService<LoginForm>();
                loginForm.Show();
                this.Close();
            }
        }

        public void SetActiveMenu(string menuName)
        {
            switch (menuName.ToLower())
            {
                case "employees":
                case "nhânviên":
                    EmployeesButton_Click(null, EventArgs.Empty);
                    break;
                case "teams":
                case "team":
                    TeamsButton_Click(null, EventArgs.Empty);
                    break;
                case "shifts":
                case "calamviệc":
                    ShiftsButton_Click(null, EventArgs.Empty);
                    break;
                case "timekeeping":
                case "chấmcông":
                    TimekeepingButton_Click(null, EventArgs.Empty);
                    break;
            }
        }

        public void UpdateUserInfo(string username, string fullName)
        {
            SetUserInfo(username, fullName);
        }

        public Panel GetContentPanel()
        {
            return contentPanel;
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}