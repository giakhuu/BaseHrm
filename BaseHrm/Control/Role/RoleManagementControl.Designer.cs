namespace BaseHrm.Controls
{
    partial class RoleManagementControl
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
                _loadCts?.Cancel();
                _loadCts?.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            panelActions = new Panel();
            btnRefresh = new Button();
            btnAddRole = new Button();
            panelStats = new Panel();
            lblTotalAccounts = new Label();
            lblTotalRoles = new Label();
            lblTitle = new Label();
            panelSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            panelMain = new Panel();
            splitContainer = new SplitContainer();
            panelRoles = new Panel();
            dgvRoles = new DataGridView();
            roleIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextMenuRole = new ContextMenuStrip(components);
            viewDetailsToolStripMenuItem = new ToolStripMenuItem();
            editRoleToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteRoleToolStripMenuItem = new ToolStripMenuItem();
            roleWithAccountsDtoBindingSource = new BindingSource(components);
            panelRoleHeader = new Panel();
            lblRolesTitle = new Label();
            panelAccounts = new Panel();
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
            panelAccountHeader = new Panel();
            lblSelectedRole = new Label();
            lblAccountsTitle = new Label();
            panelHeader.SuspendLayout();
            panelActions.SuspendLayout();
            panelStats.SuspendLayout();
            panelSearch.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            panelRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            contextMenuRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roleWithAccountsDtoBindingSource).BeginInit();
            panelRoleHeader.SuspendLayout();
            panelAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountDtoBindingSource).BeginInit();
            panelAccountHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(99, 110, 114);
            panelHeader.Controls.Add(panelActions);
            panelHeader.Controls.Add(panelStats);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(29, 27, 29, 27);
            panelHeader.Size = new Size(1600, 120);
            panelHeader.TabIndex = 0;
            // 
            // panelActions
            // 
            panelActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(btnAddRole);
            panelActions.Location = new Point(1314, 27);
            panelActions.Margin = new Padding(3, 4, 3, 4);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(257, 67);
            panelActions.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(126, 11);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(91, 47);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddRole
            // 
            btnAddRole.BackColor = Color.FromArgb(255, 193, 7);
            btnAddRole.FlatAppearance.BorderSize = 0;
            btnAddRole.FlatStyle = FlatStyle.Flat;
            btnAddRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddRole.ForeColor = Color.FromArgb(33, 37, 41);
            btnAddRole.Location = new Point(0, 11);
            btnAddRole.Margin = new Padding(3, 4, 3, 4);
            btnAddRole.Name = "btnAddRole";
            btnAddRole.Size = new Size(114, 47);
            btnAddRole.TabIndex = 0;
            btnAddRole.Text = "Thêm Quyền";
            btnAddRole.UseVisualStyleBackColor = false;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // panelStats
            // 
            panelStats.Controls.Add(lblTotalAccounts);
            panelStats.Controls.Add(lblTotalRoles);
            panelStats.Location = new Point(320, 27);
            panelStats.Margin = new Padding(3, 4, 3, 4);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(457, 67);
            panelStats.TabIndex = 1;
            // 
            // lblTotalAccounts
            // 
            lblTotalAccounts.AutoSize = true;
            lblTotalAccounts.Font = new Font("Segoe UI", 10F);
            lblTotalAccounts.ForeColor = Color.FromArgb(220, 221, 225);
            lblTotalAccounts.Location = new Point(0, 33);
            lblTotalAccounts.Name = "lblTotalAccounts";
            lblTotalAccounts.Size = new Size(223, 23);
            lblTotalAccounts.TabIndex = 1;
            lblTotalAccounts.Text = "0 Tài khoản được cấp quyền";
            lblTotalAccounts.Click += lblTotalAccounts_Click;
            // 
            // lblTotalRoles
            // 
            lblTotalRoles.AutoSize = true;
            lblTotalRoles.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalRoles.ForeColor = Color.FromArgb(255, 193, 7);
            lblTotalRoles.Location = new Point(0, 7);
            lblTotalRoles.Name = "lblTotalRoles";
            lblTotalRoles.Size = new Size(86, 25);
            lblTotalRoles.TabIndex = 0;
            lblTotalRoles.Text = "0 Quyền";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(242, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Role Manager";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.FromArgb(248, 249, 250);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 120);
            panelSearch.Margin = new Padding(3, 4, 3, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(29, 20, 29, 20);
            panelSearch.Size = new Size(1600, 80);
            panelSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(73, 80, 87);
            lblSearch.Location = new Point(29, 28);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(68, 23);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(114, 24);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo tên";
            txtSearch.Size = new Size(399, 30);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(splitContainer);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 200);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(29, 27, 29, 27);
            panelMain.Size = new Size(1600, 733);
            panelMain.TabIndex = 2;
            panelMain.Paint += panelMain_Paint;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(29, 27);
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
            splitContainer.Size = new Size(1542, 679);
            splitContainer.SplitterDistance = 372;
            splitContainer.SplitterWidth = 11;
            splitContainer.TabIndex = 0;
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
            panelRoles.Size = new Size(1542, 372);
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
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(99, 110, 114);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(99, 110, 114);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvRoles.ColumnHeadersHeight = 45;
            dgvRoles.Columns.AddRange(new DataGridViewColumn[] { roleIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn });
            dgvRoles.ContextMenuStrip = contextMenuRole;
            dgvRoles.DataSource = roleWithAccountsDtoBindingSource;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 248, 220);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvRoles.DefaultCellStyle = dataGridViewCellStyle6;
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
            dgvRoles.Size = new Size(1540, 303);
            dgvRoles.TabIndex = 0;
            dgvRoles.CellDoubleClick += dgvRoles_CellDoubleClick;
            dgvRoles.SelectionChanged += dgvRoles_SelectionChanged;
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
            descriptionDataGridViewTextBoxColumn.HeaderText = "Miêu tả";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contextMenuRole
            // 
            contextMenuRole.ImageScalingSize = new Size(20, 20);
            contextMenuRole.Items.AddRange(new ToolStripItem[] { viewDetailsToolStripMenuItem, editRoleToolStripMenuItem, toolStripSeparator1, deleteRoleToolStripMenuItem });
            contextMenuRole.Name = "contextMenuRole";
            contextMenuRole.Size = new Size(161, 82);
            // 
            // viewDetailsToolStripMenuItem
            // 
            viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            viewDetailsToolStripMenuItem.Size = new Size(160, 24);
            viewDetailsToolStripMenuItem.Text = "View Details";
            viewDetailsToolStripMenuItem.Click += viewDetailsToolStripMenuItem_Click;
            // 
            // editRoleToolStripMenuItem
            // 
            editRoleToolStripMenuItem.Name = "editRoleToolStripMenuItem";
            editRoleToolStripMenuItem.Size = new Size(160, 24);
            editRoleToolStripMenuItem.Text = "Edit Role";
            editRoleToolStripMenuItem.Click += editRoleToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(157, 6);
            // 
            // deleteRoleToolStripMenuItem
            // 
            deleteRoleToolStripMenuItem.Name = "deleteRoleToolStripMenuItem";
            deleteRoleToolStripMenuItem.Size = new Size(160, 24);
            deleteRoleToolStripMenuItem.Text = "Delete Role";
            deleteRoleToolStripMenuItem.Click += deleteRoleToolStripMenuItem_Click;
            // 
            // roleWithAccountsDtoBindingSource
            // 
            roleWithAccountsDtoBindingSource.DataSource = typeof(Data.DTO.RoleWithAccountsDto);
            // 
            // panelRoleHeader
            // 
            panelRoleHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelRoleHeader.Controls.Add(lblRolesTitle);
            panelRoleHeader.Dock = DockStyle.Top;
            panelRoleHeader.Location = new Point(0, 0);
            panelRoleHeader.Margin = new Padding(3, 4, 3, 4);
            panelRoleHeader.Name = "panelRoleHeader";
            panelRoleHeader.Padding = new Padding(17, 16, 17, 16);
            panelRoleHeader.Size = new Size(1540, 67);
            panelRoleHeader.TabIndex = 1;
            // 
            // lblRolesTitle
            // 
            lblRolesTitle.AutoSize = true;
            lblRolesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRolesTitle.ForeColor = Color.FromArgb(99, 110, 114);
            lblRolesTitle.Location = new Point(17, 20);
            lblRolesTitle.Name = "lblRolesTitle";
            lblRolesTitle.Size = new Size(258, 28);
            lblRolesTitle.TabIndex = 0;
            lblRolesTitle.Text = "Các quyền trong hệ thống";
            // 
            // panelAccounts
            // 
            panelAccounts.BackColor = Color.White;
            panelAccounts.BorderStyle = BorderStyle.FixedSingle;
            panelAccounts.Controls.Add(dgvAccounts);
            panelAccounts.Controls.Add(panelAccountHeader);
            panelAccounts.Dock = DockStyle.Fill;
            panelAccounts.Location = new Point(0, 0);
            panelAccounts.Margin = new Padding(3, 4, 3, 4);
            panelAccounts.Name = "panelAccounts";
            panelAccounts.Size = new Size(1542, 296);
            panelAccounts.TabIndex = 0;
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 193, 7);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 193, 7);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAccounts.ColumnHeadersHeight = 40;
            dgvAccounts.Columns.AddRange(new DataGridViewColumn[] { accountIdDataGridViewTextBoxColumn, usernameDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, isMasterDataGridViewCheckBoxColumn, lastLoginDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, employeeFullNameDataGridViewTextBoxColumn, employeePhoneDataGridViewTextBoxColumn, employeePositionNameDataGridViewTextBoxColumn, employeeEmailDataGridViewTextBoxColumn });
            dgvAccounts.DataSource = accountDtoBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 248, 220);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.GridColor = Color.FromArgb(230, 230, 230);
            dgvAccounts.Location = new Point(0, 67);
            dgvAccounts.Margin = new Padding(3, 4, 3, 4);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 45;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(1540, 227);
            dgvAccounts.TabIndex = 0;
            // 
            // accountIdDataGridViewTextBoxColumn
            // 
            accountIdDataGridViewTextBoxColumn.DataPropertyName = "AccountId";
            accountIdDataGridViewTextBoxColumn.HeaderText = "Mã tài khoản";
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
            roleDataGridViewTextBoxColumn.HeaderText = "Quyền";
            roleDataGridViewTextBoxColumn.MinimumWidth = 6;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.ReadOnly = true;
            roleDataGridViewTextBoxColumn.Visible = false;
            // 
            // isMasterDataGridViewCheckBoxColumn
            // 
            isMasterDataGridViewCheckBoxColumn.DataPropertyName = "IsMaster";
            isMasterDataGridViewCheckBoxColumn.HeaderText = "IsMaster";
            isMasterDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isMasterDataGridViewCheckBoxColumn.Name = "isMasterDataGridViewCheckBoxColumn";
            isMasterDataGridViewCheckBoxColumn.ReadOnly = true;
            isMasterDataGridViewCheckBoxColumn.Visible = false;
            // 
            // lastLoginDataGridViewTextBoxColumn
            // 
            lastLoginDataGridViewTextBoxColumn.DataPropertyName = "LastLogin";
            lastLoginDataGridViewTextBoxColumn.HeaderText = "Lần đăng nhập cuối";
            lastLoginDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastLoginDataGridViewTextBoxColumn.Name = "lastLoginDataGridViewTextBoxColumn";
            lastLoginDataGridViewTextBoxColumn.ReadOnly = true;
            lastLoginDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "Mã nhân viên";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeFullNameDataGridViewTextBoxColumn
            // 
            employeeFullNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFullName";
            employeeFullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            employeeFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeFullNameDataGridViewTextBoxColumn.Name = "employeeFullNameDataGridViewTextBoxColumn";
            employeeFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeePhoneDataGridViewTextBoxColumn
            // 
            employeePhoneDataGridViewTextBoxColumn.DataPropertyName = "EmployeePhone";
            employeePhoneDataGridViewTextBoxColumn.HeaderText = "Số điện thoại";
            employeePhoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeePhoneDataGridViewTextBoxColumn.Name = "employeePhoneDataGridViewTextBoxColumn";
            employeePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeePositionNameDataGridViewTextBoxColumn
            // 
            employeePositionNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeePositionName";
            employeePositionNameDataGridViewTextBoxColumn.HeaderText = "Chức vụ";
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
            employeeEmailDataGridViewTextBoxColumn.Visible = false;
            // 
            // accountDtoBindingSource
            // 
            accountDtoBindingSource.DataSource = typeof(Data.DTO.AccountDto);
            // 
            // panelAccountHeader
            // 
            panelAccountHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelAccountHeader.Controls.Add(lblSelectedRole);
            panelAccountHeader.Controls.Add(lblAccountsTitle);
            panelAccountHeader.Dock = DockStyle.Top;
            panelAccountHeader.Location = new Point(0, 0);
            panelAccountHeader.Margin = new Padding(3, 4, 3, 4);
            panelAccountHeader.Name = "panelAccountHeader";
            panelAccountHeader.Padding = new Padding(17, 16, 17, 16);
            panelAccountHeader.Size = new Size(1540, 67);
            panelAccountHeader.TabIndex = 1;
            // 
            // lblSelectedRole
            // 
            lblSelectedRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSelectedRole.AutoSize = true;
            lblSelectedRole.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSelectedRole.ForeColor = Color.FromArgb(108, 117, 125);
            lblSelectedRole.Location = new Point(1110, 25);
            lblSelectedRole.Name = "lblSelectedRole";
            lblSelectedRole.Size = new Size(391, 23);
            lblSelectedRole.TabIndex = 1;
            lblSelectedRole.Text = "Chọn 1 quyền để xem các tài khoản được cấp quyền";
            // 
            // lblAccountsTitle
            // 
            lblAccountsTitle.AutoSize = true;
            lblAccountsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAccountsTitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblAccountsTitle.Location = new Point(17, 20);
            lblAccountsTitle.Name = "lblAccountsTitle";
            lblAccountsTitle.Size = new Size(261, 28);
            lblAccountsTitle.TabIndex = 0;
            lblAccountsTitle.Text = "Tài khoản được cấp quyền";
            // 
            // RoleManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelMain);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RoleManagementControl";
            Size = new Size(1600, 933);
            Load += RoleManagementControl_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelActions.ResumeLayout(false);
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelMain.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            panelRoles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            contextMenuRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)roleWithAccountsDtoBindingSource).EndInit();
            panelRoleHeader.ResumeLayout(false);
            panelRoleHeader.PerformLayout();
            panelAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountDtoBindingSource).EndInit();
            panelAccountHeader.ResumeLayout(false);
            panelAccountHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblTotalRoles;
        private System.Windows.Forms.Label lblTotalAccounts;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelRoles;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Panel panelRoleHeader;
        private System.Windows.Forms.Label lblRolesTitle;
        private System.Windows.Forms.Panel panelAccounts;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Panel panelAccountHeader;
        private System.Windows.Forms.Label lblAccountsTitle;
        private System.Windows.Forms.Label lblSelectedRole;
        private System.Windows.Forms.ContextMenuStrip contextMenuRole;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteRoleToolStripMenuItem;
        private BindingSource accountDtoBindingSource;
        private BindingSource roleWithAccountsDtoBindingSource;
        private DataGridViewTextBoxColumn roleIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
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
    }
}