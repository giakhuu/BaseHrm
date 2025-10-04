namespace BaseHrm
{
    partial class AccountDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panelMain = new Panel();
            groupBoxEmployee = new GroupBox();
            txtEmployeePosition = new TextBox();
            lblEmployeePosition = new Label();
            txtEmployeePhone = new TextBox();
            lblEmployeePhone = new Label();
            txtEmployeeEmail = new TextBox();
            lblEmployeeEmail = new Label();
            txtEmployeeName = new TextBox();
            lblEmployeeName = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeId = new Label();
            groupBoxAccount = new GroupBox();
            chkIsMaster = new CheckBox();
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtLastLogin = new TextBox();
            lblLastLogin = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            txtAccountId = new TextBox();
            lblAccountId = new Label();
            tabPage2 = new TabPage();
            splitContainer = new SplitContainer();
            panelRoles = new Panel();
            dgvRoles = new DataGridView();
            roleIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rolePermissionsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            accountCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            roleWithAccountsDtoBindingSource = new BindingSource(components);
            panelRoleHeader = new Panel();
            btnAddRole = new ReaLTaiizor.Controls.HopeButton();
            lblRolesTitle = new Label();
            panelAccounts = new Panel();
            flowLayoutPermissions = new FlowLayoutPanel();
            panelPermissionHeader = new Panel();
            btnAddPermission = new Button();
            lblPermissionsTitle = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            panelButtons = new Panel();
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxEmployee.SuspendLayout();
            groupBoxAccount.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roleWithAccountsDtoBindingSource).BeginInit();
            panelRoleHeader.SuspendLayout();
            panelAccounts.SuspendLayout();
            panelPermissionHeader.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(914, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(306, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👤Thông tin tài khoản";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 80);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(914, 640);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panelMain);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(906, 607);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Thông tin tài khoản";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(groupBoxEmployee);
            panelMain.Controls.Add(groupBoxAccount);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(3, 3);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(10, 10, 0, 10);
            panelMain.Size = new Size(900, 601);
            panelMain.TabIndex = 2;
            // 
            // groupBoxEmployee
            // 
            groupBoxEmployee.BackColor = Color.White;
            groupBoxEmployee.Controls.Add(txtEmployeePosition);
            groupBoxEmployee.Controls.Add(lblEmployeePosition);
            groupBoxEmployee.Controls.Add(txtEmployeePhone);
            groupBoxEmployee.Controls.Add(lblEmployeePhone);
            groupBoxEmployee.Controls.Add(txtEmployeeEmail);
            groupBoxEmployee.Controls.Add(lblEmployeeEmail);
            groupBoxEmployee.Controls.Add(txtEmployeeName);
            groupBoxEmployee.Controls.Add(lblEmployeeName);
            groupBoxEmployee.Controls.Add(txtEmployeeId);
            groupBoxEmployee.Controls.Add(lblEmployeeId);
            groupBoxEmployee.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxEmployee.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxEmployee.Location = new Point(16, 323);
            groupBoxEmployee.Margin = new Padding(3, 4, 3, 4);
            groupBoxEmployee.Name = "groupBoxEmployee";
            groupBoxEmployee.Padding = new Padding(17, 20, 17, 20);
            groupBoxEmployee.Size = new Size(869, 267);
            groupBoxEmployee.TabIndex = 1;
            groupBoxEmployee.TabStop = false;
            groupBoxEmployee.Text = "Thông tin nhân viên";
            // 
            // txtEmployeePosition
            // 
            txtEmployeePosition.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeePosition.Font = new Font("Segoe UI", 9F);
            txtEmployeePosition.Location = new Point(549, 114);
            txtEmployeePosition.Margin = new Padding(3, 4, 3, 4);
            txtEmployeePosition.Name = "txtEmployeePosition";
            txtEmployeePosition.ReadOnly = true;
            txtEmployeePosition.Size = new Size(228, 27);
            txtEmployeePosition.TabIndex = 9;
            // 
            // lblEmployeePosition
            // 
            lblEmployeePosition.AutoSize = true;
            lblEmployeePosition.Font = new Font("Segoe UI", 9F);
            lblEmployeePosition.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeePosition.Location = new Point(471, 117);
            lblEmployeePosition.Name = "lblEmployeePosition";
            lblEmployeePosition.Size = new Size(64, 20);
            lblEmployeePosition.TabIndex = 8;
            lblEmployeePosition.Text = "Position:";
            // 
            // txtEmployeePhone
            // 
            txtEmployeePhone.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeePhone.Font = new Font("Segoe UI", 9F);
            txtEmployeePhone.Location = new Point(549, 67);
            txtEmployeePhone.Margin = new Padding(3, 4, 3, 4);
            txtEmployeePhone.Name = "txtEmployeePhone";
            txtEmployeePhone.ReadOnly = true;
            txtEmployeePhone.Size = new Size(228, 27);
            txtEmployeePhone.TabIndex = 7;
            // 
            // lblEmployeePhone
            // 
            lblEmployeePhone.AutoSize = true;
            lblEmployeePhone.Font = new Font("Segoe UI", 9F);
            lblEmployeePhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeePhone.Location = new Point(471, 70);
            lblEmployeePhone.Name = "lblEmployeePhone";
            lblEmployeePhone.Size = new Size(53, 20);
            lblEmployeePhone.TabIndex = 6;
            lblEmployeePhone.Text = "Phone:";
            // 
            // txtEmployeeEmail
            // 
            txtEmployeeEmail.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeeEmail.Font = new Font("Segoe UI", 9F);
            txtEmployeeEmail.Location = new Point(137, 157);
            txtEmployeeEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeEmail.Name = "txtEmployeeEmail";
            txtEmployeeEmail.ReadOnly = true;
            txtEmployeeEmail.Size = new Size(285, 27);
            txtEmployeeEmail.TabIndex = 5;
            // 
            // lblEmployeeEmail
            // 
            lblEmployeeEmail.AutoSize = true;
            lblEmployeeEmail.Font = new Font("Segoe UI", 9F);
            lblEmployeeEmail.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeEmail.Location = new Point(37, 164);
            lblEmployeeEmail.Name = "lblEmployeeEmail";
            lblEmployeeEmail.Size = new Size(49, 20);
            lblEmployeeEmail.TabIndex = 4;
            lblEmployeeEmail.Text = "Email:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeeName.Font = new Font("Segoe UI", 9F);
            txtEmployeeName.Location = new Point(137, 110);
            txtEmployeeName.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(285, 27);
            txtEmployeeName.TabIndex = 3;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 9F);
            lblEmployeeName.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeName.Location = new Point(37, 117);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(52, 20);
            lblEmployeeName.TabIndex = 2;
            lblEmployeeName.Text = "Name:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeeId.Font = new Font("Segoe UI", 9F);
            txtEmployeeId.Location = new Point(137, 63);
            txtEmployeeId.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(114, 27);
            txtEmployeeId.TabIndex = 1;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 9F);
            lblEmployeeId.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeId.Location = new Point(37, 70);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(97, 20);
            lblEmployeeId.TabIndex = 0;
            lblEmployeeId.Text = "Employee ID:";
            // 
            // groupBoxAccount
            // 
            groupBoxAccount.BackColor = Color.White;
            groupBoxAccount.Controls.Add(chkIsMaster);
            groupBoxAccount.Controls.Add(cmbRole);
            groupBoxAccount.Controls.Add(lblRole);
            groupBoxAccount.Controls.Add(txtPassword);
            groupBoxAccount.Controls.Add(lblPassword);
            groupBoxAccount.Controls.Add(txtLastLogin);
            groupBoxAccount.Controls.Add(lblLastLogin);
            groupBoxAccount.Controls.Add(txtUsername);
            groupBoxAccount.Controls.Add(lblUsername);
            groupBoxAccount.Controls.Add(txtAccountId);
            groupBoxAccount.Controls.Add(lblAccountId);
            groupBoxAccount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxAccount.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxAccount.Location = new Point(16, 3);
            groupBoxAccount.Margin = new Padding(3, 4, 3, 4);
            groupBoxAccount.Name = "groupBoxAccount";
            groupBoxAccount.Padding = new Padding(17, 20, 17, 20);
            groupBoxAccount.Size = new Size(869, 293);
            groupBoxAccount.TabIndex = 0;
            groupBoxAccount.TabStop = false;
            groupBoxAccount.Text = "Thông tin tài khoản";
            // 
            // chkIsMaster
            // 
            chkIsMaster.AutoSize = true;
            chkIsMaster.Font = new Font("Segoe UI", 9F);
            chkIsMaster.Location = new Point(611, 120);
            chkIsMaster.Name = "chkIsMaster";
            chkIsMaster.Size = new Size(90, 24);
            chkIsMaster.TabIndex = 12;
            chkIsMaster.Text = "Is Master";
            chkIsMaster.UseVisualStyleBackColor = true;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 9F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(137, 118);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(228, 28);
            cmbRole.TabIndex = 11;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(37, 121);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(42, 20);
            lblRole.TabIndex = 10;
            lblRole.Text = "Role:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(137, 165);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(228, 27);
            txtPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblPassword.Location = new Point(37, 165);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password:";
            // 
            // txtLastLogin
            // 
            txtLastLogin.BackColor = Color.FromArgb(248, 249, 250);
            txtLastLogin.Font = new Font("Segoe UI", 9F);
            txtLastLogin.Location = new Point(611, 165);
            txtLastLogin.Margin = new Padding(3, 4, 3, 4);
            txtLastLogin.Name = "txtLastLogin";
            txtLastLogin.ReadOnly = true;
            txtLastLogin.Size = new Size(228, 27);
            txtLastLogin.TabIndex = 8;
            // 
            // lblLastLogin
            // 
            lblLastLogin.AutoSize = true;
            lblLastLogin.Font = new Font("Segoe UI", 9F);
            lblLastLogin.ForeColor = Color.FromArgb(73, 80, 87);
            lblLastLogin.Location = new Point(493, 165);
            lblLastLogin.Name = "lblLastLogin";
            lblLastLogin.Size = new Size(79, 20);
            lblLastLogin.TabIndex = 7;
            lblLastLogin.Text = "Last Login:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(611, 64);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(228, 27);
            txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.ForeColor = Color.FromArgb(73, 80, 87);
            lblUsername.Location = new Point(491, 67);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtAccountId
            // 
            txtAccountId.BackColor = Color.FromArgb(248, 249, 250);
            txtAccountId.Font = new Font("Segoe UI", 9F);
            txtAccountId.Location = new Point(137, 67);
            txtAccountId.Margin = new Padding(3, 4, 3, 4);
            txtAccountId.Name = "txtAccountId";
            txtAccountId.ReadOnly = true;
            txtAccountId.Size = new Size(228, 27);
            txtAccountId.TabIndex = 1;
            // 
            // lblAccountId
            // 
            lblAccountId.AutoSize = true;
            lblAccountId.Font = new Font("Segoe UI", 9F);
            lblAccountId.ForeColor = Color.FromArgb(73, 80, 87);
            lblAccountId.Location = new Point(37, 70);
            lblAccountId.Name = "lblAccountId";
            lblAccountId.Size = new Size(85, 20);
            lblAccountId.TabIndex = 0;
            lblAccountId.Text = "Account ID:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(906, 607);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quyền tài khoản";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(3, 3);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(panelRoles);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(panelAccounts);
            splitContainer.Size = new Size(900, 601);
            splitContainer.SplitterDistance = 329;
            splitContainer.SplitterWidth = 11;
            splitContainer.TabIndex = 1;
            // 
            // panelRoles
            // 
            panelRoles.BackColor = Color.White;
            panelRoles.BorderStyle = BorderStyle.FixedSingle;
            panelRoles.Controls.Add(dgvRoles);
            panelRoles.Controls.Add(panelRoleHeader);
            panelRoles.Dock = DockStyle.Fill;
            panelRoles.Location = new Point(0, 0);
            panelRoles.Margin = new Padding(3, 4, 3, 4);
            panelRoles.Name = "panelRoles";
            panelRoles.Size = new Size(900, 329);
            panelRoles.TabIndex = 0;
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.BackgroundColor = Color.White;
            dgvRoles.BorderStyle = BorderStyle.None;
            dgvRoles.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(99, 110, 114);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(99, 110, 114);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRoles.ColumnHeadersHeight = 45;
            dgvRoles.Columns.AddRange(new DataGridViewColumn[] { roleIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, rolePermissionsDataGridViewTextBoxColumn, accountCountDataGridViewTextBoxColumn });
            dgvRoles.ContextMenuStrip = contextMenuStrip1;
            dgvRoles.DataSource = roleWithAccountsDtoBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 248, 220);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRoles.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRoles.Dock = DockStyle.Fill;
            dgvRoles.EnableHeadersVisualStyles = false;
            dgvRoles.GridColor = Color.FromArgb(230, 230, 230);
            dgvRoles.Location = new Point(0, 67);
            dgvRoles.Margin = new Padding(3, 4, 3, 4);
            dgvRoles.MultiSelect = false;
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.RowHeadersWidth = 51;
            dgvRoles.RowTemplate.Height = 50;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(898, 260);
            dgvRoles.TabIndex = 0;
            // 
            // roleIdDataGridViewTextBoxColumn
            // 
            roleIdDataGridViewTextBoxColumn.DataPropertyName = "RoleId";
            roleIdDataGridViewTextBoxColumn.HeaderText = "Mã quyền";
            roleIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            roleIdDataGridViewTextBoxColumn.Name = "roleIdDataGridViewTextBoxColumn";
            roleIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Tên quyền";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Mô tả";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolePermissionsDataGridViewTextBoxColumn
            // 
            rolePermissionsDataGridViewTextBoxColumn.DataPropertyName = "RolePermissions";
            rolePermissionsDataGridViewTextBoxColumn.HeaderText = "RolePermissions";
            rolePermissionsDataGridViewTextBoxColumn.MinimumWidth = 6;
            rolePermissionsDataGridViewTextBoxColumn.Name = "rolePermissionsDataGridViewTextBoxColumn";
            rolePermissionsDataGridViewTextBoxColumn.ReadOnly = true;
            rolePermissionsDataGridViewTextBoxColumn.Visible = false;
            // 
            // accountCountDataGridViewTextBoxColumn
            // 
            accountCountDataGridViewTextBoxColumn.DataPropertyName = "AccountCount";
            accountCountDataGridViewTextBoxColumn.HeaderText = "AccountCount";
            accountCountDataGridViewTextBoxColumn.MinimumWidth = 6;
            accountCountDataGridViewTextBoxColumn.Name = "accountCountDataGridViewTextBoxColumn";
            accountCountDataGridViewTextBoxColumn.ReadOnly = true;
            accountCountDataGridViewTextBoxColumn.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(246, 80);
            contextMenuStrip1.Text = "Quyền tài khoản";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(245, 24);
            toolStripMenuItem1.Text = "Xem chi tiết";
            toolStripMenuItem1.Click += viewDetailsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(245, 24);
            toolStripMenuItem2.Text = "Xóa quyền khỏi tài khoản";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // roleWithAccountsDtoBindingSource
            // 
            roleWithAccountsDtoBindingSource.DataSource = typeof(Data.DTO.RoleWithAccountsDto);
            // 
            // panelRoleHeader
            // 
            panelRoleHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelRoleHeader.Controls.Add(btnAddRole);
            panelRoleHeader.Controls.Add(lblRolesTitle);
            panelRoleHeader.Dock = DockStyle.Top;
            panelRoleHeader.Location = new Point(0, 0);
            panelRoleHeader.Margin = new Padding(3, 4, 3, 4);
            panelRoleHeader.Name = "panelRoleHeader";
            panelRoleHeader.Padding = new Padding(17, 16, 17, 16);
            panelRoleHeader.Size = new Size(898, 67);
            panelRoleHeader.TabIndex = 1;
            // 
            // btnAddRole
            // 
            btnAddRole.BorderColor = Color.FromArgb(220, 223, 230);
            btnAddRole.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnAddRole.DangerColor = Color.FromArgb(245, 108, 108);
            btnAddRole.DefaultColor = Color.FromArgb(255, 255, 255);
            btnAddRole.Font = new Font("Segoe UI", 12F);
            btnAddRole.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnAddRole.InfoColor = Color.FromArgb(144, 147, 153);
            btnAddRole.Location = new Point(728, 14);
            btnAddRole.Name = "btnAddRole";
            btnAddRole.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnAddRole.Size = new Size(150, 41);
            btnAddRole.SuccessColor = Color.FromArgb(103, 194, 58);
            btnAddRole.TabIndex = 1;
            btnAddRole.Text = "Thêm quyền";
            btnAddRole.TextColor = Color.White;
            btnAddRole.WarningColor = Color.FromArgb(230, 162, 60);
            btnAddRole.Click += btnAddRole_Click;
            // 
            // lblRolesTitle
            // 
            lblRolesTitle.AutoSize = true;
            lblRolesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRolesTitle.ForeColor = Color.FromArgb(99, 110, 114);
            lblRolesTitle.Location = new Point(15, 19);
            lblRolesTitle.Name = "lblRolesTitle";
            lblRolesTitle.Size = new Size(243, 28);
            lblRolesTitle.TabIndex = 0;
            lblRolesTitle.Text = "Các quyền của tài khoản";
            // 
            // panelAccounts
            // 
            panelAccounts.BackColor = Color.White;
            panelAccounts.BorderStyle = BorderStyle.FixedSingle;
            panelAccounts.Controls.Add(flowLayoutPermissions);
            panelAccounts.Controls.Add(panelPermissionHeader);
            panelAccounts.Dock = DockStyle.Fill;
            panelAccounts.Location = new Point(0, 0);
            panelAccounts.Margin = new Padding(3, 4, 3, 4);
            panelAccounts.Name = "panelAccounts";
            panelAccounts.Size = new Size(900, 261);
            panelAccounts.TabIndex = 0;
            // 
            // flowLayoutPermissions
            // 
            flowLayoutPermissions.AutoScroll = true;
            flowLayoutPermissions.BackColor = Color.WhiteSmoke;
            flowLayoutPermissions.Dock = DockStyle.Fill;
            flowLayoutPermissions.FlowDirection = FlowDirection.TopDown;
            flowLayoutPermissions.Location = new Point(0, 80);
            flowLayoutPermissions.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPermissions.Name = "flowLayoutPermissions";
            flowLayoutPermissions.Padding = new Padding(11, 13, 11, 13);
            flowLayoutPermissions.Size = new Size(898, 179);
            flowLayoutPermissions.TabIndex = 3;
            flowLayoutPermissions.WrapContents = false;
            // 
            // panelPermissionHeader
            // 
            panelPermissionHeader.BackColor = Color.FromArgb(255, 193, 7);
            panelPermissionHeader.Controls.Add(btnAddPermission);
            panelPermissionHeader.Controls.Add(lblPermissionsTitle);
            panelPermissionHeader.Dock = DockStyle.Top;
            panelPermissionHeader.Location = new Point(0, 0);
            panelPermissionHeader.Margin = new Padding(3, 4, 3, 4);
            panelPermissionHeader.Name = "panelPermissionHeader";
            panelPermissionHeader.Padding = new Padding(23, 20, 23, 20);
            panelPermissionHeader.Size = new Size(898, 80);
            panelPermissionHeader.TabIndex = 2;
            // 
            // btnAddPermission
            // 
            btnAddPermission.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddPermission.BackColor = Color.FromArgb(40, 167, 69);
            btnAddPermission.FlatAppearance.BorderSize = 0;
            btnAddPermission.FlatStyle = FlatStyle.Flat;
            btnAddPermission.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddPermission.ForeColor = Color.White;
            btnAddPermission.Location = new Point(682, 24);
            btnAddPermission.Margin = new Padding(3, 4, 3, 4);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(190, 40);
            btnAddPermission.TabIndex = 1;
            btnAddPermission.Text = "Thêm quyền tài khoản";
            btnAddPermission.UseVisualStyleBackColor = false;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // lblPermissionsTitle
            // 
            lblPermissionsTitle.AutoSize = true;
            lblPermissionsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPermissionsTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblPermissionsTitle.Location = new Point(26, 27);
            lblPermissionsTitle.Name = "lblPermissionsTitle";
            lblPermissionsTitle.Size = new Size(168, 28);
            lblPermissionsTitle.TabIndex = 0;
            lblPermissionsTitle.Text = "Quyền tài khoản";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(801, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 47);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(671, 20);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(91, 47);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 720);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(914, 80);
            panelButtons.TabIndex = 2;
            // 
            // AccountDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(914, 800);
            Controls.Add(tabControl1);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AccountDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Account Details";
            Load += AccountDetailForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            groupBoxEmployee.ResumeLayout(false);
            groupBoxEmployee.PerformLayout();
            groupBoxAccount.ResumeLayout(false);
            groupBoxAccount.PerformLayout();
            tabPage2.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)roleWithAccountsDtoBindingSource).EndInit();
            panelRoleHeader.ResumeLayout(false);
            panelRoleHeader.PerformLayout();
            panelAccounts.ResumeLayout(false);
            panelPermissionHeader.ResumeLayout(false);
            panelPermissionHeader.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelButtons;
        private SplitContainer splitContainer;
        private Panel panelRoles;
        private DataGridView dgvRoles;
        private Panel panelRoleHeader;
        private Label lblRolesTitle;
        private Panel panelAccounts;
        private DataGridViewTextBoxColumn roleIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rolePermissionsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accountCountDataGridViewTextBoxColumn;
        private BindingSource roleWithAccountsDtoBindingSource;
        private ReaLTaiizor.Controls.HopeButton btnAddRole;
        private Panel panelMain;
        private GroupBox groupBoxEmployee;
        private TextBox txtEmployeePosition;
        private Label lblEmployeePosition;
        private TextBox txtEmployeePhone;
        private Label lblEmployeePhone;
        private TextBox txtEmployeeEmail;
        private Label lblEmployeeEmail;
        private TextBox txtEmployeeName;
        private Label lblEmployeeName;
        private TextBox txtEmployeeId;
        private Label lblEmployeeId;
        private GroupBox groupBoxAccount;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtLastLogin;
        private Label lblLastLogin;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtAccountId;
        private Label lblAccountId;
        private TabPage tabPage2;
        private Panel panelPermissionHeader;
        private Button btnAddPermission;
        private Label lblPermissionsTitle;
        private FlowLayoutPanel flowLayoutPermissions;
        private CheckBox chkIsMaster;
        private ComboBox cmbRole;
        private Label lblRole;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}
