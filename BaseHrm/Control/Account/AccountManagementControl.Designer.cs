namespace BaseHrm.Controls
{
    partial class AccountManagementControl
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

        #region Component Designer generated code

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
            btnRefresh = new Button();
            btnAddAccount = new Button();
            lblTotalAccounts = new Label();
            lblTitle = new Label();
            panelFilters = new Panel();
            cmbRole = new ComboBox();
            lblRole = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelMain = new Panel();
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
            contextMenuAccount = new ContextMenuStrip(components);
            viewDetailsToolStripMenuItem = new ToolStripMenuItem();
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteAccountToolStripMenuItem = new ToolStripMenuItem();
            accountDtoBindingSource = new BindingSource(components);
            panelHeader.SuspendLayout();
            panelFilters.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            contextMenuAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accountDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Controls.Add(btnAddAccount);
            panelHeader.Controls.Add(lblTotalAccounts);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1083, 107);
            panelHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(927, 27);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(91, 47);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddAccount.BackColor = Color.FromArgb(46, 204, 113);
            btnAddAccount.FlatAppearance.BorderSize = 0;
            btnAddAccount.FlatStyle = FlatStyle.Flat;
            btnAddAccount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddAccount.ForeColor = Color.White;
            btnAddAccount.Location = new Point(754, 27);
            btnAddAccount.Margin = new Padding(3, 4, 3, 4);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(137, 47);
            btnAddAccount.TabIndex = 2;
            btnAddAccount.Text = "Thêm tài khoản";
            btnAddAccount.UseVisualStyleBackColor = false;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // lblTotalAccounts
            // 
            lblTotalAccounts.AutoSize = true;
            lblTotalAccounts.Font = new Font("Segoe UI", 10F);
            lblTotalAccounts.ForeColor = Color.FromArgb(236, 240, 241);
            lblTotalAccounts.Location = new Point(295, 38);
            lblTotalAccounts.Name = "lblTotalAccounts";
            lblTotalAccounts.Size = new Size(95, 23);
            lblTotalAccounts.TabIndex = 1;
            lblTotalAccounts.Text = "0 tài khoản";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(266, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý tài khoản";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.FromArgb(248, 249, 250);
            panelFilters.Controls.Add(cmbRole);
            panelFilters.Controls.Add(lblRole);
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(lblSearch);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 107);
            panelFilters.Margin = new Padding(3, 4, 3, 4);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(23, 20, 23, 20);
            panelFilters.Size = new Size(1083, 93);
            panelFilters.TabIndex = 1;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 9F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(627, 33);
            cmbRole.Margin = new Padding(3, 4, 3, 4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(391, 28);
            cmbRole.TabIndex = 3;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(566, 36);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(54, 20);
            lblRole.TabIndex = 2;
            lblRole.Text = "Quyền:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(86, 29);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm bằng username";
            txtSearch.Size = new Size(285, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F);
            lblSearch.ForeColor = Color.FromArgb(73, 80, 87);
            lblSearch.Location = new Point(23, 33);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(dgvAccounts);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 200);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(23, 27, 23, 27);
            panelMain.Size = new Size(1083, 600);
            panelMain.TabIndex = 2;
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAccounts.ColumnHeadersHeight = 40;
            dgvAccounts.Columns.AddRange(new DataGridViewColumn[] { accountIdDataGridViewTextBoxColumn, usernameDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, isMasterDataGridViewCheckBoxColumn, lastLoginDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, employeeFullNameDataGridViewTextBoxColumn, employeePhoneDataGridViewTextBoxColumn, employeePositionNameDataGridViewTextBoxColumn, employeeEmailDataGridViewTextBoxColumn });
            dgvAccounts.ContextMenuStrip = contextMenuAccount;
            dgvAccounts.DataSource = accountDtoBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.GridColor = Color.FromArgb(230, 230, 230);
            dgvAccounts.Location = new Point(23, 27);
            dgvAccounts.Margin = new Padding(3, 4, 3, 4);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersVisible = false;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 45;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(1037, 546);
            dgvAccounts.TabIndex = 0;
            dgvAccounts.CellDoubleClick += dgvAccounts_CellDoubleClick;
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
            roleDataGridViewTextBoxColumn.HeaderText = "Chức vụ";
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
            employeeFullNameDataGridViewTextBoxColumn.HeaderText = "Tên nhân viên";
            employeeFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeFullNameDataGridViewTextBoxColumn.Name = "employeeFullNameDataGridViewTextBoxColumn";
            employeeFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeePhoneDataGridViewTextBoxColumn
            // 
            employeePhoneDataGridViewTextBoxColumn.DataPropertyName = "EmployeePhone";
            employeePhoneDataGridViewTextBoxColumn.HeaderText = "SĐT";
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
            employeeEmailDataGridViewTextBoxColumn.HeaderText = "Email";
            employeeEmailDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeEmailDataGridViewTextBoxColumn.Name = "employeeEmailDataGridViewTextBoxColumn";
            employeeEmailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contextMenuAccount
            // 
            contextMenuAccount.ImageScalingSize = new Size(20, 20);
            contextMenuAccount.Items.AddRange(new ToolStripItem[] { viewDetailsToolStripMenuItem, editAccountToolStripMenuItem, toolStripSeparator1, deleteAccountToolStripMenuItem });
            contextMenuAccount.Name = "contextMenuAccount";
            contextMenuAccount.Size = new Size(170, 82);
            // 
            // viewDetailsToolStripMenuItem
            // 
            viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            viewDetailsToolStripMenuItem.Size = new Size(169, 24);
            viewDetailsToolStripMenuItem.Text = "Xem chi tiết";
            viewDetailsToolStripMenuItem.Click += viewDetailsToolStripMenuItem_Click;
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.Size = new Size(169, 24);
            editAccountToolStripMenuItem.Text = "Chỉnh sửa";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(166, 6);
            // 
            // deleteAccountToolStripMenuItem
            // 
            deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            deleteAccountToolStripMenuItem.Size = new Size(169, 24);
            deleteAccountToolStripMenuItem.Text = "Xóa tài khoản";
            deleteAccountToolStripMenuItem.Click += deleteAccountToolStripMenuItem_Click;
            // 
            // accountDtoBindingSource
            // 
            accountDtoBindingSource.DataSource = typeof(Data.DTO.AccountDto);
            // 
            // AccountManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panelMain);
            Controls.Add(panelFilters);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AccountManagementControl";
            Size = new Size(1083, 800);
            Load += AccountManagementControl_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            contextMenuAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)accountDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalAccounts;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.ContextMenuStrip contextMenuAccount;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem;
        private BindingSource accountDtoBindingSource;
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