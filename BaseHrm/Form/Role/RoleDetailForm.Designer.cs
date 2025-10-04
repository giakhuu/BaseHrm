namespace BaseHrm
{
    partial class RoleDetailForm
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
            btnClose = new Button();
            lblTitle = new Label();
            panelMain = new Panel();
            tabControl = new TabControl();
            tabBasicInfo = new TabPage();
            groupBoxBasicInfo = new GroupBox();
            txtDescription = new TextBox();
            lblDescription = new Label();
            txtRoleName = new TextBox();
            lblRoleName = new Label();
            txtRoleId = new TextBox();
            lblRoleId = new Label();
            tabPermissions = new TabPage();
            panelPermissions = new Panel();
            flowLayoutPermissions = new FlowLayoutPanel();
            panelPermissionHeader = new Panel();
            btnAddPermission = new Button();
            lblPermissionsTitle = new Label();
            tabAccounts = new TabPage();
            panelAccountsTab = new Panel();
            dgvAccounts = new DataGridView();
            accountIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usernameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isMasterDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            lastLoginDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeePhoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeePositionNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeEmailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            accountDtoBindingSource = new BindingSource(components);
            panelAccountsHeader = new Panel();
            lblAccountsCount = new Label();
            lblAccountsTitle = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabBasicInfo.SuspendLayout();
            groupBoxBasicInfo.SuspendLayout();
            tabPermissions.SuspendLayout();
            panelPermissions.SuspendLayout();
            panelPermissionHeader.SuspendLayout();
            tabAccounts.SuspendLayout();
            panelAccountsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountDtoBindingSource).BeginInit();
            panelAccountsHeader.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(99, 110, 114);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(29, 27, 29, 27);
            panelHeader.Size = new Size(1143, 93);
            panelHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1051, 27);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(63, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(170, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Role Details";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(tabControl);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(29, 27, 29, 27);
            panelMain.Size = new Size(1143, 760);
            panelMain.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabBasicInfo);
            tabControl.Controls.Add(tabPermissions);
            tabControl.Controls.Add(tabAccounts);
            tabControl.Dock = DockStyle.Top;
            tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabControl.Location = new Point(29, 27);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1085, 653);
            tabControl.TabIndex = 0;
            // 
            // tabBasicInfo
            // 
            tabBasicInfo.BackColor = Color.White;
            tabBasicInfo.Controls.Add(groupBoxBasicInfo);
            tabBasicInfo.Location = new Point(4, 32);
            tabBasicInfo.Margin = new Padding(3, 4, 3, 4);
            tabBasicInfo.Name = "tabBasicInfo";
            tabBasicInfo.Padding = new Padding(23, 27, 23, 27);
            tabBasicInfo.Size = new Size(1077, 617);
            tabBasicInfo.TabIndex = 0;
            tabBasicInfo.Text = "Basic Information";
            // 
            // groupBoxBasicInfo
            // 
            groupBoxBasicInfo.Controls.Add(txtDescription);
            groupBoxBasicInfo.Controls.Add(lblDescription);
            groupBoxBasicInfo.Controls.Add(txtRoleName);
            groupBoxBasicInfo.Controls.Add(lblRoleName);
            groupBoxBasicInfo.Controls.Add(txtRoleId);
            groupBoxBasicInfo.Controls.Add(lblRoleId);
            groupBoxBasicInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxBasicInfo.ForeColor = Color.FromArgb(99, 110, 114);
            groupBoxBasicInfo.Location = new Point(23, 27);
            groupBoxBasicInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxBasicInfo.Name = "groupBoxBasicInfo";
            groupBoxBasicInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxBasicInfo.Size = new Size(1029, 333);
            groupBoxBasicInfo.TabIndex = 0;
            groupBoxBasicInfo.TabStop = false;
            groupBoxBasicInfo.Text = "Role Information";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(171, 169);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(571, 105);
            txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.FromArgb(73, 80, 87);
            lblDescription.Location = new Point(29, 173);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description:";
            // 
            // txtRoleName
            // 
            txtRoleName.Font = new Font("Segoe UI", 10F);
            txtRoleName.Location = new Point(171, 116);
            txtRoleName.Margin = new Padding(3, 4, 3, 4);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(342, 30);
            txtRoleName.TabIndex = 3;
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Font = new Font("Segoe UI", 10F);
            lblRoleName.ForeColor = Color.FromArgb(73, 80, 87);
            lblRoleName.Location = new Point(29, 120);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(98, 23);
            lblRoleName.TabIndex = 2;
            lblRoleName.Text = "Role Name:";
            // 
            // txtRoleId
            // 
            txtRoleId.BackColor = Color.FromArgb(248, 249, 250);
            txtRoleId.Font = new Font("Segoe UI", 10F);
            txtRoleId.Location = new Point(171, 63);
            txtRoleId.Margin = new Padding(3, 4, 3, 4);
            txtRoleId.Name = "txtRoleId";
            txtRoleId.ReadOnly = true;
            txtRoleId.Size = new Size(114, 30);
            txtRoleId.TabIndex = 1;
            // 
            // lblRoleId
            // 
            lblRoleId.AutoSize = true;
            lblRoleId.Font = new Font("Segoe UI", 10F);
            lblRoleId.ForeColor = Color.FromArgb(73, 80, 87);
            lblRoleId.Location = new Point(29, 67);
            lblRoleId.Name = "lblRoleId";
            lblRoleId.Size = new Size(69, 23);
            lblRoleId.TabIndex = 0;
            lblRoleId.Text = "Role ID:";
            // 
            // tabPermissions
            // 
            tabPermissions.BackColor = Color.White;
            tabPermissions.Controls.Add(panelPermissions);
            tabPermissions.Location = new Point(4, 32);
            tabPermissions.Margin = new Padding(3, 4, 3, 4);
            tabPermissions.Name = "tabPermissions";
            tabPermissions.Padding = new Padding(23, 27, 23, 27);
            tabPermissions.Size = new Size(1077, 617);
            tabPermissions.TabIndex = 1;
            tabPermissions.Text = "Permissions";
            // 
            // panelPermissions
            // 
            panelPermissions.Controls.Add(flowLayoutPermissions);
            panelPermissions.Controls.Add(panelPermissionHeader);
            panelPermissions.Dock = DockStyle.Fill;
            panelPermissions.Location = new Point(23, 27);
            panelPermissions.Margin = new Padding(3, 4, 3, 4);
            panelPermissions.Name = "panelPermissions";
            panelPermissions.Size = new Size(1031, 563);
            panelPermissions.TabIndex = 0;
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
            flowLayoutPermissions.Size = new Size(1031, 483);
            flowLayoutPermissions.TabIndex = 1;
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
            panelPermissionHeader.Size = new Size(1031, 80);
            panelPermissionHeader.TabIndex = 0;
            // 
            // btnAddPermission
            // 
            btnAddPermission.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddPermission.BackColor = Color.FromArgb(40, 167, 69);
            btnAddPermission.FlatAppearance.BorderSize = 0;
            btnAddPermission.FlatStyle = FlatStyle.Flat;
            btnAddPermission.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddPermission.ForeColor = Color.White;
            btnAddPermission.Location = new Point(834, 20);
            btnAddPermission.Margin = new Padding(3, 4, 3, 4);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(137, 40);
            btnAddPermission.TabIndex = 1;
            btnAddPermission.Text = "Add Permission";
            btnAddPermission.UseVisualStyleBackColor = false;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // lblPermissionsTitle
            // 
            lblPermissionsTitle.AutoSize = true;
            lblPermissionsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPermissionsTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblPermissionsTitle.Location = new Point(23, 24);
            lblPermissionsTitle.Name = "lblPermissionsTitle";
            lblPermissionsTitle.Size = new Size(171, 28);
            lblPermissionsTitle.TabIndex = 0;
            lblPermissionsTitle.Text = "Role Permissions";
            // 
            // tabAccounts
            // 
            tabAccounts.BackColor = Color.White;
            tabAccounts.Controls.Add(panelAccountsTab);
            tabAccounts.Location = new Point(4, 32);
            tabAccounts.Margin = new Padding(3, 4, 3, 4);
            tabAccounts.Name = "tabAccounts";
            tabAccounts.Padding = new Padding(23, 27, 23, 27);
            tabAccounts.Size = new Size(1077, 617);
            tabAccounts.TabIndex = 2;
            tabAccounts.Text = "Assigned Accounts";
            // 
            // panelAccountsTab
            // 
            panelAccountsTab.Controls.Add(dgvAccounts);
            panelAccountsTab.Controls.Add(panelAccountsHeader);
            panelAccountsTab.Dock = DockStyle.Fill;
            panelAccountsTab.Location = new Point(23, 27);
            panelAccountsTab.Margin = new Padding(3, 4, 3, 4);
            panelAccountsTab.Name = "panelAccountsTab";
            panelAccountsTab.Size = new Size(1031, 563);
            panelAccountsTab.TabIndex = 0;
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = Color.White;
            dgvAccounts.BorderStyle = BorderStyle.None;
            dgvAccounts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAccounts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(99, 110, 114);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(99, 110, 114);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAccounts.ColumnHeadersHeight = 45;
            dgvAccounts.Columns.AddRange(new DataGridViewColumn[] { accountIdDataGridViewTextBoxColumn, usernameDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, isMasterDataGridViewCheckBoxColumn, lastLoginDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, employeeFullNameDataGridViewTextBoxColumn, employeePhoneDataGridViewTextBoxColumn, employeePositionNameDataGridViewTextBoxColumn, employeeEmailDataGridViewTextBoxColumn });
            dgvAccounts.DataSource = accountDtoBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 248, 220);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.GridColor = Color.FromArgb(230, 230, 230);
            dgvAccounts.Location = new Point(0, 80);
            dgvAccounts.Margin = new Padding(3, 4, 3, 4);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 45;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(1031, 483);
            dgvAccounts.TabIndex = 1;
            // 
            // accountIdDataGridViewTextBoxColumn
            // 
            accountIdDataGridViewTextBoxColumn.DataPropertyName = "AccountId";
            accountIdDataGridViewTextBoxColumn.HeaderText = "AccountId";
            accountIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            accountIdDataGridViewTextBoxColumn.Name = "accountIdDataGridViewTextBoxColumn";
            accountIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            usernameDataGridViewTextBoxColumn.MinimumWidth = 6;
            usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            usernameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Role";
            roleDataGridViewTextBoxColumn.MinimumWidth = 6;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isMasterDataGridViewCheckBoxColumn
            // 
            isMasterDataGridViewCheckBoxColumn.DataPropertyName = "IsMaster";
            isMasterDataGridViewCheckBoxColumn.HeaderText = "IsMaster";
            isMasterDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isMasterDataGridViewCheckBoxColumn.Name = "isMasterDataGridViewCheckBoxColumn";
            isMasterDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lastLoginDataGridViewTextBoxColumn
            // 
            lastLoginDataGridViewTextBoxColumn.DataPropertyName = "LastLogin";
            lastLoginDataGridViewTextBoxColumn.HeaderText = "LastLogin";
            lastLoginDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastLoginDataGridViewTextBoxColumn.Name = "lastLoginDataGridViewTextBoxColumn";
            lastLoginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeFullNameDataGridViewTextBoxColumn
            // 
            employeeFullNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFullName";
            employeeFullNameDataGridViewTextBoxColumn.HeaderText = "EmployeeFullName";
            employeeFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeFullNameDataGridViewTextBoxColumn.Name = "employeeFullNameDataGridViewTextBoxColumn";
            employeeFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeePhoneDataGridViewTextBoxColumn
            // 
            employeePhoneDataGridViewTextBoxColumn.DataPropertyName = "EmployeePhone";
            employeePhoneDataGridViewTextBoxColumn.HeaderText = "EmployeePhone";
            employeePhoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeePhoneDataGridViewTextBoxColumn.Name = "employeePhoneDataGridViewTextBoxColumn";
            employeePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeePositionNameDataGridViewTextBoxColumn
            // 
            employeePositionNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeePositionName";
            employeePositionNameDataGridViewTextBoxColumn.HeaderText = "EmployeePositionName";
            employeePositionNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeePositionNameDataGridViewTextBoxColumn.Name = "employeePositionNameDataGridViewTextBoxColumn";
            employeePositionNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeEmailDataGridViewTextBoxColumn
            // 
            employeeEmailDataGridViewTextBoxColumn.DataPropertyName = "EmployeeEmail";
            employeeEmailDataGridViewTextBoxColumn.HeaderText = "EmployeeEmail";
            employeeEmailDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeEmailDataGridViewTextBoxColumn.Name = "employeeEmailDataGridViewTextBoxColumn";
            employeeEmailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountDtoBindingSource
            // 
            accountDtoBindingSource.DataSource = typeof(Data.DTO.AccountDto);
            // 
            // panelAccountsHeader
            // 
            panelAccountsHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelAccountsHeader.Controls.Add(lblAccountsCount);
            panelAccountsHeader.Controls.Add(lblAccountsTitle);
            panelAccountsHeader.Dock = DockStyle.Top;
            panelAccountsHeader.Location = new Point(0, 0);
            panelAccountsHeader.Margin = new Padding(3, 4, 3, 4);
            panelAccountsHeader.Name = "panelAccountsHeader";
            panelAccountsHeader.Padding = new Padding(23, 20, 23, 20);
            panelAccountsHeader.Size = new Size(1031, 80);
            panelAccountsHeader.TabIndex = 0;
            // 
            // lblAccountsCount
            // 
            lblAccountsCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAccountsCount.AutoSize = true;
            lblAccountsCount.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblAccountsCount.ForeColor = Color.FromArgb(108, 117, 125);
            lblAccountsCount.Location = new Point(914, 27);
            lblAccountsCount.Name = "lblAccountsCount";
            lblAccountsCount.Size = new Size(88, 23);
            lblAccountsCount.TabIndex = 1;
            lblAccountsCount.Text = "0 accounts";
            // 
            // lblAccountsTitle
            // 
            lblAccountsTitle.AutoSize = true;
            lblAccountsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAccountsTitle.ForeColor = Color.FromArgb(99, 110, 114);
            lblAccountsTitle.Location = new Point(23, 24);
            lblAccountsTitle.Name = "lblAccountsTitle";
            lblAccountsTitle.Size = new Size(190, 28);
            lblAccountsTitle.TabIndex = 0;
            lblAccountsTitle.Text = "Assigned Accounts";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 773);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1143, 80);
            panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1018, 20);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(91, 47);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(915, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 47);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // RoleDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(1143, 853);
            Controls.Add(panelButtons);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "RoleDetailForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Role Details";
            Load += RoleDetailForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabBasicInfo.ResumeLayout(false);
            groupBoxBasicInfo.ResumeLayout(false);
            groupBoxBasicInfo.PerformLayout();
            tabPermissions.ResumeLayout(false);
            panelPermissions.ResumeLayout(false);
            panelPermissionHeader.ResumeLayout(false);
            panelPermissionHeader.PerformLayout();
            tabAccounts.ResumeLayout(false);
            panelAccountsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountDtoBindingSource).EndInit();
            panelAccountsHeader.ResumeLayout(false);
            panelAccountsHeader.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBasicInfo;
        private System.Windows.Forms.GroupBox groupBoxBasicInfo;
        private System.Windows.Forms.Label lblRoleId;
        private System.Windows.Forms.TextBox txtRoleId;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabPage tabPermissions;
        private System.Windows.Forms.Panel panelPermissions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPermissions;
        private System.Windows.Forms.Panel panelPermissionHeader;
        private System.Windows.Forms.Label lblPermissionsTitle;
        private System.Windows.Forms.Button btnAddPermission;
        private System.Windows.Forms.TabPage tabAccounts;
        private System.Windows.Forms.Panel panelAccountsTab;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Panel panelAccountsHeader;
        private System.Windows.Forms.Label lblAccountsTitle;
        private System.Windows.Forms.Label lblAccountsCount;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private DataGridViewTextBoxColumn accountIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isMasterDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn lastLoginDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeePhoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeePositionNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeEmailDataGridViewTextBoxColumn;
        private BindingSource accountDtoBindingSource;
    }
}