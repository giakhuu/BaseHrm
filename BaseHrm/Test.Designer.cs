namespace BaseHrm
{
    partial class Test
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            logoutButton = new Button();
            userInfoPanel = new Panel();
            fullNameLabel = new Label();
            usernameLabel = new Label();
            userIconLabel = new Label();
            menuPanel = new Panel();
            roleButton = new Button();
            accountButton = new Button();
            timekeepingButton = new Button();
            shiftsButton = new Button();
            teamsButton = new Button();
            employeesButton = new Button();
            checkInButton = new Button();
            logoPanel = new Panel();
            logoLabel = new Label();
            contentPanel = new Panel();
            welcomeLabel = new Label();
            sidebarPanel.SuspendLayout();
            userInfoPanel.SuspendLayout();
            menuPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(41, 44, 51);
            sidebarPanel.Controls.Add(logoutButton);
            sidebarPanel.Controls.Add(userInfoPanel);
            sidebarPanel.Controls.Add(menuPanel);
            sidebarPanel.Controls.Add(logoPanel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Margin = new Padding(3, 4, 3, 4);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(320, 953);
            sidebarPanel.TabIndex = 0;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.FromArgb(231, 76, 60);
            logoutButton.Cursor = Cursors.Hand;
            logoutButton.Dock = DockStyle.Bottom;
            logoutButton.FlatAppearance.BorderSize = 0;
            logoutButton.FlatStyle = FlatStyle.Flat;
            logoutButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            logoutButton.ForeColor = Color.White;
            logoutButton.Location = new Point(0, 766);
            logoutButton.Margin = new Padding(3, 4, 3, 4);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(320, 67);
            logoutButton.TabIndex = 3;
            logoutButton.Text = "🚪 Đăng xuất";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += LogoutButton_Click;
            logoutButton.MouseEnter += LogoutButton_MouseEnter;
            logoutButton.MouseLeave += LogoutButton_MouseLeave;
            // 
            // userInfoPanel
            // 
            userInfoPanel.BackColor = Color.FromArgb(52, 58, 64);
            userInfoPanel.Controls.Add(fullNameLabel);
            userInfoPanel.Controls.Add(usernameLabel);
            userInfoPanel.Controls.Add(userIconLabel);
            userInfoPanel.Dock = DockStyle.Bottom;
            userInfoPanel.Location = new Point(0, 833);
            userInfoPanel.Margin = new Padding(3, 4, 3, 4);
            userInfoPanel.Name = "userInfoPanel";
            userInfoPanel.Size = new Size(320, 120);
            userInfoPanel.TabIndex = 2;
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Font = new Font("Segoe UI", 10F);
            fullNameLabel.ForeColor = Color.FromArgb(189, 195, 199);
            fullNameLabel.Location = new Point(80, 60);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new Size(171, 23);
            fullNameLabel.TabIndex = 2;
            fullNameLabel.Text = "Nguyễn Văn Quản Lý";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            usernameLabel.ForeColor = Color.White;
            usernameLabel.Location = new Point(80, 27);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(91, 25);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "manager";
            // 
            // userIconLabel
            // 
            userIconLabel.Font = new Font("Segoe UI", 24F);
            userIconLabel.ForeColor = Color.FromArgb(52, 152, 219);
            userIconLabel.Location = new Point(17, 33);
            userIconLabel.Name = "userIconLabel";
            userIconLabel.Size = new Size(46, 53);
            userIconLabel.TabIndex = 0;
            userIconLabel.Text = "👤";
            userIconLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(roleButton);
            menuPanel.Controls.Add(accountButton);
            menuPanel.Controls.Add(timekeepingButton);
            menuPanel.Controls.Add(shiftsButton);
            menuPanel.Controls.Add(teamsButton);
            menuPanel.Controls.Add(employeesButton);
            menuPanel.Controls.Add(checkInButton);
            menuPanel.Dock = DockStyle.Fill;
            menuPanel.Location = new Point(0, 160);
            menuPanel.Margin = new Padding(3, 4, 3, 4);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(320, 793);
            menuPanel.TabIndex = 1;
            menuPanel.Paint += menuPanel_Paint;
            // 
            // roleButton
            // 
            roleButton.BackColor = Color.Transparent;
            roleButton.Cursor = Cursors.Hand;
            roleButton.Dock = DockStyle.Top;
            roleButton.FlatAppearance.BorderSize = 0;
            roleButton.FlatStyle = FlatStyle.Flat;
            roleButton.Font = new Font("Segoe UI", 12F);
            roleButton.ForeColor = Color.White;
            roleButton.Location = new Point(0, 508);
            roleButton.Margin = new Padding(3, 4, 3, 4);
            roleButton.Name = "roleButton";
            roleButton.Padding = new Padding(23, 0, 0, 0);
            roleButton.Size = new Size(320, 87);
            roleButton.TabIndex = 5;
            roleButton.Text = "🔐 Quản lý quyền";
            roleButton.TextAlign = ContentAlignment.MiddleLeft;
            roleButton.UseVisualStyleBackColor = false;
            roleButton.Click += roleButton_Click;
            // 
            // accountButton
            // 
            accountButton.BackColor = Color.Transparent;
            accountButton.Cursor = Cursors.Hand;
            accountButton.Dock = DockStyle.Top;
            accountButton.FlatAppearance.BorderSize = 0;
            accountButton.FlatStyle = FlatStyle.Flat;
            accountButton.Font = new Font("Segoe UI", 12F);
            accountButton.ForeColor = Color.White;
            accountButton.Location = new Point(0, 421);
            accountButton.Margin = new Padding(3, 4, 3, 4);
            accountButton.Name = "accountButton";
            accountButton.Padding = new Padding(23, 0, 0, 0);
            accountButton.Size = new Size(320, 87);
            accountButton.TabIndex = 4;
            accountButton.Text = "👤 Quản lý tài khoản";
            accountButton.TextAlign = ContentAlignment.MiddleLeft;
            accountButton.UseVisualStyleBackColor = false;
            accountButton.Click += accountButton_Click;
            // 
            // timekeepingButton
            // 
            timekeepingButton.BackColor = Color.Transparent;
            timekeepingButton.Cursor = Cursors.Hand;
            timekeepingButton.Dock = DockStyle.Top;
            timekeepingButton.FlatAppearance.BorderSize = 0;
            timekeepingButton.FlatStyle = FlatStyle.Flat;
            timekeepingButton.Font = new Font("Segoe UI", 12F);
            timekeepingButton.ForeColor = Color.White;
            timekeepingButton.Location = new Point(0, 334);
            timekeepingButton.Margin = new Padding(3, 4, 3, 4);
            timekeepingButton.Name = "timekeepingButton";
            timekeepingButton.Padding = new Padding(23, 0, 0, 0);
            timekeepingButton.Size = new Size(320, 87);
            timekeepingButton.TabIndex = 3;
            timekeepingButton.Text = "⏰ Quản lý chấm công";
            timekeepingButton.TextAlign = ContentAlignment.MiddleLeft;
            timekeepingButton.UseVisualStyleBackColor = false;
            timekeepingButton.Click += TimekeepingButton_Click;
            // 
            // shiftsButton
            // 
            shiftsButton.BackColor = Color.Transparent;
            shiftsButton.Cursor = Cursors.Hand;
            shiftsButton.Dock = DockStyle.Top;
            shiftsButton.FlatAppearance.BorderSize = 0;
            shiftsButton.FlatStyle = FlatStyle.Flat;
            shiftsButton.Font = new Font("Segoe UI", 12F);
            shiftsButton.ForeColor = Color.White;
            shiftsButton.Location = new Point(0, 247);
            shiftsButton.Margin = new Padding(3, 4, 3, 4);
            shiftsButton.Name = "shiftsButton";
            shiftsButton.Padding = new Padding(23, 0, 0, 0);
            shiftsButton.Size = new Size(320, 87);
            shiftsButton.TabIndex = 2;
            shiftsButton.Text = "🕒 Quản lý ca làm";
            shiftsButton.TextAlign = ContentAlignment.MiddleLeft;
            shiftsButton.UseVisualStyleBackColor = false;
            shiftsButton.Click += ShiftsButton_Click;
            // 
            // teamsButton
            // 
            teamsButton.BackColor = Color.Transparent;
            teamsButton.Cursor = Cursors.Hand;
            teamsButton.Dock = DockStyle.Top;
            teamsButton.FlatAppearance.BorderSize = 0;
            teamsButton.FlatStyle = FlatStyle.Flat;
            teamsButton.Font = new Font("Segoe UI", 12F);
            teamsButton.ForeColor = Color.White;
            teamsButton.Location = new Point(0, 167);
            teamsButton.Margin = new Padding(3, 4, 3, 4);
            teamsButton.Name = "teamsButton";
            teamsButton.Padding = new Padding(23, 0, 0, 0);
            teamsButton.Size = new Size(320, 80);
            teamsButton.TabIndex = 1;
            teamsButton.Text = "👥 Quản lý team";
            teamsButton.TextAlign = ContentAlignment.MiddleLeft;
            teamsButton.UseVisualStyleBackColor = false;
            teamsButton.Click += TeamsButton_Click;
            // 
            // employeesButton
            // 
            employeesButton.BackColor = Color.FromArgb(52, 152, 219);
            employeesButton.Cursor = Cursors.Hand;
            employeesButton.Dock = DockStyle.Top;
            employeesButton.FlatAppearance.BorderSize = 0;
            employeesButton.FlatStyle = FlatStyle.Flat;
            employeesButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            employeesButton.ForeColor = Color.White;
            employeesButton.Location = new Point(0, 87);
            employeesButton.Margin = new Padding(3, 4, 3, 4);
            employeesButton.Name = "employeesButton";
            employeesButton.Padding = new Padding(23, 0, 0, 0);
            employeesButton.Size = new Size(320, 80);
            employeesButton.TabIndex = 0;
            employeesButton.Text = "👨‍💼 Quản lý nhân viên";
            employeesButton.TextAlign = ContentAlignment.MiddleLeft;
            employeesButton.UseVisualStyleBackColor = false;
            employeesButton.Click += EmployeesButton_Click;
            // 
            // checkInButton
            // 
            checkInButton.BackColor = Color.Transparent;
            checkInButton.Cursor = Cursors.Hand;
            checkInButton.Dock = DockStyle.Top;
            checkInButton.FlatAppearance.BorderSize = 0;
            checkInButton.FlatStyle = FlatStyle.Flat;
            checkInButton.Font = new Font("Segoe UI", 12F);
            checkInButton.ForeColor = Color.White;
            checkInButton.Location = new Point(0, 0);
            checkInButton.Margin = new Padding(3, 4, 3, 4);
            checkInButton.Name = "checkInButton";
            checkInButton.Padding = new Padding(23, 0, 0, 0);
            checkInButton.Size = new Size(320, 87);
            checkInButton.TabIndex = 6;
            checkInButton.Text = "⏰Chấm công";
            checkInButton.TextAlign = ContentAlignment.MiddleLeft;
            checkInButton.UseVisualStyleBackColor = false;
            checkInButton.Click += checkInButton_Click;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.FromArgb(52, 152, 219);
            logoPanel.Controls.Add(logoLabel);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Margin = new Padding(3, 4, 3, 4);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(320, 160);
            logoPanel.TabIndex = 0;
            // 
            // logoLabel
            // 
            logoLabel.Dock = DockStyle.Fill;
            logoLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            logoLabel.ForeColor = Color.White;
            logoLabel.Location = new Point(0, 0);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new Size(320, 160);
            logoLabel.TabIndex = 0;
            logoLabel.Text = "🏢\r\nCÔNG TY ABC";
            logoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(248, 249, 250);
            contentPanel.Controls.Add(welcomeLabel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(320, 0);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1531, 953);
            contentPanel.TabIndex = 1;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.None;
            welcomeLabel.Font = new Font("Segoe UI", 24F);
            welcomeLabel.ForeColor = Color.FromArgb(73, 80, 87);
            welcomeLabel.Location = new Point(343, 419);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(846, 113);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Chào mừng đến với hệ thống quản lý nhân viên\r\nVui lòng chọn chức năng từ menu bên trái";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1851, 953);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1369, 918);
            Name = "Test";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Nhân viên";
            sidebarPanel.ResumeLayout(false);
            userInfoPanel.ResumeLayout(false);
            userInfoPanel.PerformLayout();
            menuPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button employeesButton;
        private System.Windows.Forms.Button checkInButton;
        private System.Windows.Forms.Button teamsButton;
        private System.Windows.Forms.Button shiftsButton;
        private System.Windows.Forms.Button timekeepingButton;
        private System.Windows.Forms.Panel userInfoPanel;
        private System.Windows.Forms.Label userIconLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private Button accountButton;
        private Button roleButton;

        // Added for shift submenu
        private Panel shiftSubMenuPanel;
        private Button dailyShiftButton;
        private Button createShiftButton;
        private Button addShiftTypeButton;
        private System.Windows.Forms.Timer animationTimer;
        private bool isExpanding = false;
    }
}