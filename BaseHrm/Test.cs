using BaseHrm.Controls;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm
{
    public partial class Test : Form
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

        public Test(IServiceProvider provider, IAuthService authService, IEmployeeService employeeService, IPermissionService permissionService)
        {
            InitializeComponent();
            _provider = provider;
            _authService = authService;
            _employeeService = employeeService;
            _permissionService = permissionService;
            InitializeShiftSubMenu();

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
            var allPermisstion = await _permissionService.GetEffectivePermissionsAsync(_currentAccountId ?? 0);
            Helper.PrintJson(allPermisstion);
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
            
            // roleButton sử dụng HasModuleAccessAsync với PermissionAction.All hoặc kiểm tra đơn giản hơn
            roleButton.Visible = _isMasterAccount || await _permissionService.HasModuleAccessAsync(_currentAccountId.Value, ModuleName.Account, PermissionAction.All);
            
            // Kiểm tra quyền cho shift submenu buttons
            await SetMenuVisibility(dailyShiftButton, ModuleName.Shift);
            await SetMenuVisibility(createShiftButton, ModuleName.Shift, PermissionAction.Create);
            await SetMenuVisibility(addShiftTypeButton, ModuleName.ShiftType, PermissionAction.Create);
        }

        private async Task SetMenuVisibility(Button menuButton, ModuleName module, PermissionAction action = PermissionAction.View)
        {
            if (!_currentAccountId.HasValue)
            {
                menuButton.Visible = false;
                return;
            }

            // Sử dụng HasModuleAccessAsync để kiểm tra quyền với bất kỳ scope nào
            bool hasPermission = await _permissionService.HasModuleAccessAsync(_currentAccountId.Value, module, action);
            menuButton.Visible = hasPermission;
        }

        private async Task<bool> CheckModulePermission(ModuleName module, PermissionAction action = PermissionAction.View)
        {
            if (_isMasterAccount) return true;
            
            if (!_currentAccountId.HasValue) 
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Sử dụng HasModuleAccessAsync thay vì HasPermissionAsync để check đơn giản hơn
            bool hasPermission = await _permissionService.HasModuleAccessAsync(_currentAccountId.Value, module, action);
            if (!hasPermission)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return hasPermission;
        }

        private void InitializeShiftSubMenu()
        {
            // Create submenu panel
            shiftSubMenuPanel = new Panel();
            shiftSubMenuPanel.Dock = DockStyle.Top;
            shiftSubMenuPanel.BackColor = Color.FromArgb(41, 44, 51); // Match sidebar color
            shiftSubMenuPanel.Height = 0; // Initially collapsed

            // Create sub buttons
            addShiftTypeButton = new Button();
            addShiftTypeButton.BackColor = Color.Transparent;
            addShiftTypeButton.Cursor = Cursors.Hand;
            addShiftTypeButton.Dock = DockStyle.Top;
            addShiftTypeButton.FlatAppearance.BorderSize = 0;
            addShiftTypeButton.FlatStyle = FlatStyle.Flat;
            addShiftTypeButton.Font = new Font("Segoe UI", 11F);
            addShiftTypeButton.ForeColor = Color.White;
            addShiftTypeButton.Padding = new Padding(43, 0, 0, 0); // Indent more
            addShiftTypeButton.Size = new Size(320, 67);
            addShiftTypeButton.Text = "🆕 Thêm loại ca làm";
            addShiftTypeButton.TextAlign = ContentAlignment.MiddleLeft;
            addShiftTypeButton.UseVisualStyleBackColor = false;
            addShiftTypeButton.Click += AddShiftTypeButton_Click;

            createShiftButton = new Button();
            createShiftButton.BackColor = Color.Transparent;
            createShiftButton.Cursor = Cursors.Hand;
            createShiftButton.Dock = DockStyle.Top;
            createShiftButton.FlatAppearance.BorderSize = 0;
            createShiftButton.FlatStyle = FlatStyle.Flat;
            createShiftButton.Font = new Font("Segoe UI", 11F);
            createShiftButton.ForeColor = Color.White;
            createShiftButton.Padding = new Padding(43, 0, 0, 0); // Indent more
            createShiftButton.Size = new Size(320, 67);
            createShiftButton.Text = "➕ Tạo ca làm mới";
            createShiftButton.TextAlign = ContentAlignment.MiddleLeft;
            createShiftButton.UseVisualStyleBackColor = false;
            createShiftButton.Click += CreateShiftButton_Click;

            dailyShiftButton = new Button();
            dailyShiftButton.BackColor = Color.Transparent;
            dailyShiftButton.Cursor = Cursors.Hand;
            dailyShiftButton.Dock = DockStyle.Top;
            dailyShiftButton.FlatAppearance.BorderSize = 0;
            dailyShiftButton.FlatStyle = FlatStyle.Flat;
            dailyShiftButton.Font = new Font("Segoe UI", 11F);
            dailyShiftButton.ForeColor = Color.White;
            dailyShiftButton.Padding = new Padding(43, 0, 0, 0); // Indent more
            dailyShiftButton.Size = new Size(320, 67);
            dailyShiftButton.Text = "📅 Bảng ca làm";
            dailyShiftButton.TextAlign = ContentAlignment.MiddleLeft;
            dailyShiftButton.UseVisualStyleBackColor = false;
            dailyShiftButton.Click += DailyShiftButton_Click;

            shiftSubMenuPanel.Controls.Add(dailyShiftButton);
            shiftSubMenuPanel.Controls.Add(createShiftButton);
            shiftSubMenuPanel.Controls.Add(addShiftTypeButton);

            // Insert submenu panel right after shiftsButton in menuPanel
            int shiftsIndex = menuPanel.Controls.GetChildIndex(shiftsButton);
            menuPanel.Controls.Add(shiftSubMenuPanel);
            menuPanel.Controls.SetChildIndex(shiftSubMenuPanel, shiftsIndex );

            // Initialize animation timer
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += AnimationTimer_Tick;

            // Add hover effects to sub buttons
            AddHoverEffectsToSubButtons();
        }

        private void AddHoverEffectsToSubButtons()
        {
            dailyShiftButton.MouseEnter += SubButton_MouseEnter;
            dailyShiftButton.MouseLeave += SubButton_MouseLeave;
            createShiftButton.MouseEnter += SubButton_MouseEnter;
            createShiftButton.MouseLeave += SubButton_MouseLeave;
            addShiftTypeButton.MouseEnter += SubButton_MouseEnter;
            addShiftTypeButton.MouseLeave += SubButton_MouseLeave;
        }

        private void SubButton_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = hoverColor;
            }
        }

        private void SubButton_MouseLeave(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = inactiveColor;
            }
        }

        private void AddHoverEffects()
        {
            // Add hover effects for menu buttons
            foreach (System.Windows.Forms.Control control in menuPanel.Controls)
            {
                if (control is Button button && button != currentActiveButton && !IsSubButton(button))
                {
                    button.MouseEnter += MenuButton_MouseEnter;
                    button.MouseLeave += MenuButton_MouseLeave;
                }
            }
        }

        private bool IsSubButton(Button button)
        {
            return button == dailyShiftButton || button == createShiftButton || button == addShiftTypeButton;
        }

        private void SetUserInfo(string username, string fullName)
        {
            usernameLabel.Text = username;
            fullNameLabel.Text = fullName;
        }

        private void SetActiveButton(Button activeButton)
        {
            // Reset all buttons to inactive state
            foreach (System.Windows.Forms.Control control in menuPanel.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = inactiveColor;
                    button.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

                    // Re-add hover effects for inactive buttons (exclude sub buttons)
                    if (!IsSubButton(button))
                    {
                        button.MouseEnter -= MenuButton_MouseEnter;
                        button.MouseLeave -= MenuButton_MouseLeave;
                        button.MouseEnter += MenuButton_MouseEnter;
                        button.MouseLeave += MenuButton_MouseLeave;
                    }
                }
            }

            // Set the active button
            currentActiveButton = activeButton;
            activeButton.BackColor = activeColor;
            activeButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // Remove hover effects from active button
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

            // resolve control từ DI
            var control = _provider.GetRequiredService<T>();
            control.Dock = DockStyle.Fill;

            // thêm vào panel
            contentPanel.Controls.Add(control);

            // nếu bạn có label hoặc title hiển thị tên trang thì set ở đây
            this.Text = title;
        }

        // Menu button click events with permission checks
        private async Task EmployeesButton_ClickAsync(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Employee))
            {
                SetActiveButton(employeesButton);
                UpdateContentPanel<EmployeeManagementControl>("Control Nhân Viên");
            }
        }

        private async Task TeamsButton_ClickAsync(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Team))
            {
                SetActiveButton(teamsButton);
                UpdateContentPanel<TeamManagementControl>("Quản lý team");
            }
        }

        private async Task ShiftsButton_ClickAsync(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Shift))
            {
                SetActiveButton(shiftsButton);

                // Toggle submenu animation
                if (shiftSubMenuPanel.Height == 0)
                {
                    isExpanding = true;
                    animationTimer.Start();
                    // Load default sub content (Bảng ca làm)
                    UpdateContentPanel<DailyShiftSummaryControl>("Bảng ca làm");
                }
                else
                {
                    isExpanding = false;
                    animationTimer.Start();
                }
            }
        }

        private async Task TimekeepingButton_ClickAsync(object? sender, EventArgs e)
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

        // Submenu button clicks with permission checks
        private async void DailyShiftButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Shift))
            {
                // Keep parent active
                SetActiveButton(shiftsButton);
                UpdateContentPanel<DailyShiftSummaryControl>("Bảng ca làm");
            }
        }

        private async void CreateShiftButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.Shift, PermissionAction.Create))
            {
                // Keep parent active
                SetActiveButton(shiftsButton);
                UpdateContentPanel<ShiftManagementControl>("Tạo ca làm mới");
            }
        }

        private async void AddShiftTypeButton_Click(object? sender, EventArgs e)
        {
            if (await CheckModulePermission(ModuleName.ShiftType, PermissionAction.Create))
            {
                // Keep parent active
                SetActiveButton(shiftsButton);
                UpdateContentPanel<AddShiftTypeControl>("Thêm loại ca làm");
            }
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
                this.Hide();
                loginForm.Show();
            }
        }

        // Public methods to programmatically change active menu with permission checks
        public async Task SetActiveMenuAsync(string menuName)
        {
            switch (menuName.ToLower())
            {
                case "employees":
                case "nhânviên":
                    await EmployeesButton_ClickAsync(null, EventArgs.Empty);
                    break;
                case "teams":
                case "team":
                    await TeamsButton_ClickAsync(null, EventArgs.Empty);
                    break;
                case "shifts":
                case "calamviệc":
                    await ShiftsButton_ClickAsync(null, EventArgs.Empty);
                    break;
                case "timekeeping":
                case "chấmcông":
                    await TimekeepingButton_ClickAsync(null, EventArgs.Empty);
                    break;
            }
        }

        // Method to update user information dynamically
        public void UpdateUserInfo(string username, string fullName)
        {
            SetUserInfo(username, fullName);
        }

        // Method to get reference to content panel for loading user controls
        public Panel GetContentPanel()
        {
            return contentPanel;
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            int step = 20;
            int targetHeight = 3 * 67; // 3 buttons x 67 height

            if (isExpanding)
            {
                shiftSubMenuPanel.Height += step;
                if (shiftSubMenuPanel.Height >= targetHeight)
                {
                    shiftSubMenuPanel.Height = targetHeight;
                    animationTimer.Stop();
                }
            }
            else
            {
                shiftSubMenuPanel.Height -= step;
                if (shiftSubMenuPanel.Height <= 0)
                {
                    shiftSubMenuPanel.Height = 0;
                    animationTimer.Stop();
                }
            }
        }

        // Event handler wrappers for async methods
        private async void EmployeesButton_Click(object? sender, EventArgs e)
        {
            await EmployeesButton_ClickAsync(sender, e);
        }

        private async void TeamsButton_Click(object? sender, EventArgs e)
        {
            await TeamsButton_ClickAsync(sender, e);
        }

        private async void ShiftsButton_Click(object? sender, EventArgs e)
        {
            await ShiftsButton_ClickAsync(sender, e);
        }

        private async void TimekeepingButton_Click(object? sender, EventArgs e)
        {
            await TimekeepingButton_ClickAsync(sender, e);
        }

        private async void checkInButton_Click(object sender, EventArgs e)
        {
                SetActiveButton(checkInButton);
                UpdateContentPanel<CheckInControl>("Chấm công");
           
        }
    }
}