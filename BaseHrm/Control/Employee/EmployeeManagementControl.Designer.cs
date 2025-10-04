namespace BaseHrm.Controls
{
    partial class EmployeeManagementControl
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
            panelHeader = new Panel();
            lblTitle = new Label();
            btnAddEmployee = new Button();
            panelFilters = new Panel();
            groupBoxFilters = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            txtFilterEmail = new TextBox();
            btnClearFilters = new Button();
            btnApplyFilters = new Button();
            lblFilterPosition = new Label();
            cmbFilterPosition = new ComboBox();
            lblFilterGender = new Label();
            cmbFilterGender = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            txtTeamSearch = new TextBox();
            panelMain = new Panel();
            dgvEmployees = new DataGridView();
            colEmployeeId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colHireDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            contextMenuEmployee = new ContextMenuStrip(components);
            menuItemViewDetails = new ToolStripMenuItem();
            menuItemEdit = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            menuItemDelete = new ToolStripMenuItem();
            employeeDtoBindingSource = new BindingSource(components);
            panelStatus = new Panel();
            lblEmployeeCount = new Label();
            lblStatus = new Label();
            panelHeader.SuspendLayout();
            panelFilters.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            contextMenuEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).BeginInit();
            panelStatus.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 58, 64);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnAddEmployee);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1371, 93);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(336, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👥 Quản Lý Nhân Viên";
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddEmployee.BackColor = Color.FromArgb(40, 167, 69);
            btnAddEmployee.FlatAppearance.BorderSize = 0;
            btnAddEmployee.FlatStyle = FlatStyle.Flat;
            btnAddEmployee.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddEmployee.ForeColor = Color.White;
            btnAddEmployee.Location = new Point(1189, 20);
            btnAddEmployee.Margin = new Padding(3, 4, 3, 4);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(160, 53);
            btnAddEmployee.TabIndex = 1;
            btnAddEmployee.Text = "+ Thêm NV";
            btnAddEmployee.UseVisualStyleBackColor = false;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.FromArgb(248, 249, 250);
            panelFilters.Controls.Add(groupBoxFilters);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 93);
            panelFilters.Margin = new Padding(3, 4, 3, 4);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(23, 27, 23, 27);
            panelFilters.Size = new Size(1371, 160);
            panelFilters.TabIndex = 1;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.BackColor = Color.White;
            groupBoxFilters.Controls.Add(label2);
            groupBoxFilters.Controls.Add(label1);
            groupBoxFilters.Controls.Add(txtFilterEmail);
            groupBoxFilters.Controls.Add(btnClearFilters);
            groupBoxFilters.Controls.Add(btnApplyFilters);
            groupBoxFilters.Controls.Add(lblFilterPosition);
            groupBoxFilters.Controls.Add(cmbFilterPosition);
            groupBoxFilters.Controls.Add(lblFilterGender);
            groupBoxFilters.Controls.Add(cmbFilterGender);
            groupBoxFilters.Controls.Add(lblSearch);
            groupBoxFilters.Controls.Add(txtSearch);
            groupBoxFilters.Controls.Add(txtTeamSearch);
            groupBoxFilters.Dock = DockStyle.Fill;
            groupBoxFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFilters.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxFilters.Location = new Point(23, 27);
            groupBoxFilters.Margin = new Padding(3, 4, 3, 4);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(17, 20, 17, 20);
            groupBoxFilters.Size = new Size(1325, 106);
            groupBoxFilters.TabIndex = 0;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "🔍 Tìm Kiếm & Lọc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.FromArgb(85, 85, 85);
            label2.Location = new Point(885, 30);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 13;
            label2.Text = "Team:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(85, 85, 85);
            label1.Location = new Point(637, 33);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 11;
            label1.Text = "Email:";
            // 
            // txtFilterEmail
            // 
            txtFilterEmail.Font = new Font("Segoe UI", 9F);
            txtFilterEmail.Location = new Point(637, 54);
            txtFilterEmail.Margin = new Padding(3, 4, 3, 4);
            txtFilterEmail.Name = "txtFilterEmail";
            txtFilterEmail.PlaceholderText = "Nhập email...";
            txtFilterEmail.Size = new Size(238, 27);
            txtFilterEmail.TabIndex = 10;
            txtFilterEmail.TextChanged += txtEmail_TextChanged;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearFilters.BackColor = Color.FromArgb(108, 117, 125);
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(1210, 47);
            btnClearFilters.Margin = new Padding(3, 4, 3, 4);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(91, 40);
            btnClearFilters.TabIndex = 9;
            btnClearFilters.Text = "Xóa";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApplyFilters.BackColor = Color.FromArgb(51, 122, 183);
            btnApplyFilters.FlatAppearance.BorderSize = 0;
            btnApplyFilters.FlatStyle = FlatStyle.Flat;
            btnApplyFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApplyFilters.ForeColor = Color.White;
            btnApplyFilters.Location = new Point(1108, 47);
            btnApplyFilters.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(91, 40);
            btnApplyFilters.TabIndex = 8;
            btnApplyFilters.Text = "Lọc";
            btnApplyFilters.UseVisualStyleBackColor = false;
            // 
            // lblFilterPosition
            // 
            lblFilterPosition.AutoSize = true;
            lblFilterPosition.Font = new Font("Segoe UI", 9F);
            lblFilterPosition.ForeColor = Color.FromArgb(85, 85, 85);
            lblFilterPosition.Location = new Point(476, 33);
            lblFilterPosition.Name = "lblFilterPosition";
            lblFilterPosition.Size = new Size(64, 20);
            lblFilterPosition.TabIndex = 4;
            lblFilterPosition.Text = "Chức vụ:";
            // 
            // cmbFilterPosition
            // 
            cmbFilterPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPosition.Font = new Font("Segoe UI", 9F);
            cmbFilterPosition.FormattingEnabled = true;
            cmbFilterPosition.Location = new Point(476, 55);
            cmbFilterPosition.Margin = new Padding(3, 4, 3, 4);
            cmbFilterPosition.Name = "cmbFilterPosition";
            cmbFilterPosition.Size = new Size(140, 28);
            cmbFilterPosition.TabIndex = 5;
            cmbFilterPosition.SelectedIndexChanged += cmbFilterPosition_SelectedIndexChanged;
            // 
            // lblFilterGender
            // 
            lblFilterGender.AutoSize = true;
            lblFilterGender.Font = new Font("Segoe UI", 9F);
            lblFilterGender.ForeColor = Color.FromArgb(85, 85, 85);
            lblFilterGender.Location = new Point(308, 33);
            lblFilterGender.Name = "lblFilterGender";
            lblFilterGender.Size = new Size(68, 20);
            lblFilterGender.TabIndex = 2;
            lblFilterGender.Text = "Giới tính:";
            // 
            // cmbFilterGender
            // 
            cmbFilterGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterGender.Font = new Font("Segoe UI", 9F);
            cmbFilterGender.FormattingEnabled = true;
            cmbFilterGender.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ" });
            cmbFilterGender.Location = new Point(308, 55);
            cmbFilterGender.Margin = new Padding(3, 4, 3, 4);
            cmbFilterGender.Name = "cmbFilterGender";
            cmbFilterGender.Size = new Size(148, 28);
            cmbFilterGender.TabIndex = 3;
            cmbFilterGender.SelectedIndexChanged += cmbFilterGender_SelectedIndexChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F);
            lblSearch.ForeColor = Color.FromArgb(85, 85, 85);
            lblSearch.Location = new Point(23, 33);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(96, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm theo tên:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.Location = new Point(23, 56);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên nhân viên...";
            txtSearch.Size = new Size(249, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // txtTeamSearch
            // 
            txtTeamSearch.Font = new Font("Segoe UI", 9F);
            txtTeamSearch.Location = new Point(885, 54);
            txtTeamSearch.Margin = new Padding(3, 4, 3, 4);
            txtTeamSearch.Name = "txtTeamSearch";
            txtTeamSearch.PlaceholderText = "Nhập team...";
            txtTeamSearch.ReadOnly = true;
            txtTeamSearch.Size = new Size(217, 27);
            txtTeamSearch.TabIndex = 12;
            txtTeamSearch.Click += btnPickTeam_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(dgvEmployees);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 253);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(23, 27, 23, 27);
            panelMain.Size = new Size(1371, 547);
            panelMain.TabIndex = 2;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { colEmployeeId, colFullName, colGender, colEmail, colPhone, colPosition, colHireDate, colStatus });
            dgvEmployees.ContextMenuStrip = contextMenuEmployee;
            dgvEmployees.DataSource = employeeDtoBindingSource;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.GridColor = Color.FromArgb(233, 236, 239);
            dgvEmployees.Location = new Point(23, 27);
            dgvEmployees.Margin = new Padding(3, 4, 3, 4);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.RowTemplate.Height = 35;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1325, 493);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellMouseDown += DgvEmployees_CellMouseDown;
            // 
            // colEmployeeId
            // 
            colEmployeeId.DataPropertyName = "EmployeeId";
            colEmployeeId.HeaderText = "Mã NV";
            colEmployeeId.MinimumWidth = 6;
            colEmployeeId.Name = "colEmployeeId";
            colEmployeeId.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.HeaderText = "Họ và Tên";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colGender
            // 
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "Giới Tính";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "Số ĐT";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colPosition
            // 
            colPosition.DataPropertyName = "Position";
            colPosition.HeaderText = "Chức Vụ";
            colPosition.MinimumWidth = 6;
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            // 
            // colHireDate
            // 
            colHireDate.DataPropertyName = "HireDate";
            colHireDate.HeaderText = "Ngày Vào Làm";
            colHireDate.MinimumWidth = 6;
            colHireDate.Name = "colHireDate";
            colHireDate.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "IsActive";
            colStatus.HeaderText = "Trạng Thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // contextMenuEmployee
            // 
            contextMenuEmployee.ImageScalingSize = new Size(20, 20);
            contextMenuEmployee.Items.AddRange(new ToolStripItem[] { menuItemViewDetails, menuItemEdit, toolStripSeparator1, menuItemDelete });
            contextMenuEmployee.Name = "contextMenuEmployee";
            contextMenuEmployee.Size = new Size(202, 82);
            // 
            // menuItemViewDetails
            // 
            menuItemViewDetails.Name = "menuItemViewDetails";
            menuItemViewDetails.Size = new Size(201, 24);
            menuItemViewDetails.Text = "👁️ Xem Chi Tiết";
            menuItemViewDetails.Click += MenuView_Click;
            // 
            // menuItemEdit
            // 
            menuItemEdit.Name = "menuItemEdit";
            menuItemEdit.Size = new Size(201, 24);
            menuItemEdit.Text = "✏️ Chỉnh Sửa";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(198, 6);
            // 
            // menuItemDelete
            // 
            menuItemDelete.Name = "menuItemDelete";
            menuItemDelete.Size = new Size(201, 24);
            menuItemDelete.Text = "🗑️ Xóa Nhân Viên";
            // 
            // employeeDtoBindingSource
            // 
            employeeDtoBindingSource.DataSource = typeof(Data.DTO.EmployeeDto);
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.FromArgb(248, 249, 250);
            panelStatus.BorderStyle = BorderStyle.FixedSingle;
            panelStatus.Controls.Add(lblEmployeeCount);
            panelStatus.Controls.Add(lblStatus);
            panelStatus.Dock = DockStyle.Bottom;
            panelStatus.Location = new Point(0, 800);
            panelStatus.Margin = new Padding(3, 4, 3, 4);
            panelStatus.Name = "panelStatus";
            panelStatus.Padding = new Padding(23, 13, 23, 13);
            panelStatus.Size = new Size(1371, 53);
            panelStatus.TabIndex = 3;
            // 
            // lblEmployeeCount
            // 
            lblEmployeeCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEmployeeCount.AutoSize = true;
            lblEmployeeCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmployeeCount.ForeColor = Color.FromArgb(40, 167, 69);
            lblEmployeeCount.Location = new Point(1234, 16);
            lblEmployeeCount.Name = "lblEmployeeCount";
            lblEmployeeCount.Size = new Size(134, 20);
            lblEmployeeCount.TabIndex = 1;
            lblEmployeeCount.Text = "Tổng: 0 nhân viên";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(108, 117, 125);
            lblStatus.Location = new Point(23, 16);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(68, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Sẵn sàng";
            // 
            // EmployeeManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelMain);
            Controls.Add(panelStatus);
            Controls.Add(panelFilters);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeManagementControl";
            Size = new Size(1371, 853);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilters.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            contextMenuEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).EndInit();
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterGender;
        private System.Windows.Forms.ComboBox cmbFilterGender;
        private System.Windows.Forms.Label lblFilterPosition;
        private System.Windows.Forms.ComboBox cmbFilterPosition;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuEmployee;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewDetails;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEmployeeCount;
        private BindingSource employeeDtoBindingSource;
        private TextBox txtFilterEmail;
        private Label label1;
        private TextBox txtTeamSearch;
        private Label label2;
    }
}