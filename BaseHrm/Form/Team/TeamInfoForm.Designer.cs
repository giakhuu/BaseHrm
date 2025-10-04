namespace BaseHrm
{
    partial class TeamInfoForm
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
            panelHeader = new Panel();
            lblFormTitle = new Label();
            panelMain = new Panel();
            groupBoxMembers = new GroupBox();
            dgvMembers = new DataGridView();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            genderDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            addressDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            hireDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            maxHoursPerDayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            maxHoursPerMonthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalHoursThisMonthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalHoursTodayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeDtoBindingSource = new BindingSource(components);
            panelMembersHeader = new Panel();
            lblMemberCount = new Label();
            btnAddMember = new Button();
            btnRemoveMember = new Button();
            groupBoxLeaderInfo = new GroupBox();
            panelLeaderContent = new Panel();
            lblLeaderPosition = new Label();
            txtLeaderPosition = new TextBox();
            lblLeaderEmail = new Label();
            txtLeaderEmail = new TextBox();
            lblLeaderPhone = new Label();
            txtLeaderPhone = new TextBox();
            lblLeaderName = new Label();
            txtLeaderName = new TextBox();
            lblLeaderEmployeeId = new Label();
            txtLeaderEmployeeId = new TextBox();
            panelNoLeader = new Panel();
            lblNoLeader = new Label();
            groupBoxTeamInfo = new GroupBox();
            lblTeamDescription = new Label();
            txtTeamDescription = new TextBox();
            lblTeamName = new Label();
            txtTeamName = new TextBox();
            lblTeamId = new Label();
            txtTeamId = new TextBox();
            panelButtons = new Panel();
            btnClose = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            employeeContextMenuStrip = new ContextMenuStrip(components);
            addLeader = new ToolStripMenuItem();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).BeginInit();
            panelMembersHeader.SuspendLayout();
            groupBoxLeaderInfo.SuspendLayout();
            panelLeaderContent.SuspendLayout();
            panelNoLeader.SuspendLayout();
            groupBoxTeamInfo.SuspendLayout();
            panelButtons.SuspendLayout();
            employeeContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 58, 64);
            panelHeader.Controls.Add(lblFormTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1371, 93);
            panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(23, 27);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(244, 41);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Thông Tin Team";
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(groupBoxMembers);
            panelMain.Controls.Add(groupBoxLeaderInfo);
            panelMain.Controls.Add(groupBoxTeamInfo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(34, 40, 34, 40);
            panelMain.Size = new Size(1371, 774);
            panelMain.TabIndex = 1;
            // 
            // groupBoxMembers
            // 
            groupBoxMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxMembers.BackColor = Color.White;
            groupBoxMembers.Controls.Add(dgvMembers);
            groupBoxMembers.Controls.Add(panelMembersHeader);
            groupBoxMembers.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxMembers.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxMembers.Location = new Point(34, 467);
            groupBoxMembers.Margin = new Padding(3, 4, 3, 4);
            groupBoxMembers.Name = "groupBoxMembers";
            groupBoxMembers.Padding = new Padding(23, 27, 23, 27);
            groupBoxMembers.Size = new Size(1303, 263);
            groupBoxMembers.TabIndex = 2;
            groupBoxMembers.TabStop = false;
            groupBoxMembers.Text = "👥 Danh Sách Thành Viên";
            // 
            // dgvMembers
            // 
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.BackgroundColor = Color.FromArgb(224, 224, 224);
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, genderDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, addressDataGridViewTextBoxColumn, hireDateDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, maxHoursPerDayDataGridViewTextBoxColumn, maxHoursPerMonthDataGridViewTextBoxColumn, totalHoursThisMonthDataGridViewTextBoxColumn, totalHoursTodayDataGridViewTextBoxColumn, positionIdDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn });
            dgvMembers.DataSource = employeeDtoBindingSource;
            dgvMembers.Location = new Point(23, 103);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.Size = new Size(1257, 160);
            dgvMembers.TabIndex = 1;
            dgvMembers.CellMouseDown += dgvMembers_CellMouseDown;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.Width = 125;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            genderDataGridViewTextBoxColumn.MinimumWidth = 6;
            genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            genderDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn.HeaderText = "Address";
            addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // hireDateDataGridViewTextBoxColumn
            // 
            hireDateDataGridViewTextBoxColumn.DataPropertyName = "HireDate";
            hireDateDataGridViewTextBoxColumn.HeaderText = "HireDate";
            hireDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            hireDateDataGridViewTextBoxColumn.Name = "hireDateDataGridViewTextBoxColumn";
            hireDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            isActiveDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            isActiveDataGridViewCheckBoxColumn.Width = 125;
            // 
            // maxHoursPerDayDataGridViewTextBoxColumn
            // 
            maxHoursPerDayDataGridViewTextBoxColumn.DataPropertyName = "MaxHoursPerDay";
            maxHoursPerDayDataGridViewTextBoxColumn.HeaderText = "MaxHoursPerDay";
            maxHoursPerDayDataGridViewTextBoxColumn.MinimumWidth = 6;
            maxHoursPerDayDataGridViewTextBoxColumn.Name = "maxHoursPerDayDataGridViewTextBoxColumn";
            maxHoursPerDayDataGridViewTextBoxColumn.Width = 125;
            // 
            // maxHoursPerMonthDataGridViewTextBoxColumn
            // 
            maxHoursPerMonthDataGridViewTextBoxColumn.DataPropertyName = "MaxHoursPerMonth";
            maxHoursPerMonthDataGridViewTextBoxColumn.HeaderText = "MaxHoursPerMonth";
            maxHoursPerMonthDataGridViewTextBoxColumn.MinimumWidth = 6;
            maxHoursPerMonthDataGridViewTextBoxColumn.Name = "maxHoursPerMonthDataGridViewTextBoxColumn";
            maxHoursPerMonthDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalHoursThisMonthDataGridViewTextBoxColumn
            // 
            totalHoursThisMonthDataGridViewTextBoxColumn.DataPropertyName = "TotalHoursThisMonth";
            totalHoursThisMonthDataGridViewTextBoxColumn.HeaderText = "TotalHoursThisMonth";
            totalHoursThisMonthDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalHoursThisMonthDataGridViewTextBoxColumn.Name = "totalHoursThisMonthDataGridViewTextBoxColumn";
            totalHoursThisMonthDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalHoursTodayDataGridViewTextBoxColumn
            // 
            totalHoursTodayDataGridViewTextBoxColumn.DataPropertyName = "TotalHoursToday";
            totalHoursTodayDataGridViewTextBoxColumn.HeaderText = "TotalHoursToday";
            totalHoursTodayDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalHoursTodayDataGridViewTextBoxColumn.Name = "totalHoursTodayDataGridViewTextBoxColumn";
            totalHoursTodayDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionIdDataGridViewTextBoxColumn
            // 
            positionIdDataGridViewTextBoxColumn.DataPropertyName = "PositionId";
            positionIdDataGridViewTextBoxColumn.HeaderText = "PositionId";
            positionIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionIdDataGridViewTextBoxColumn.Name = "positionIdDataGridViewTextBoxColumn";
            positionIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Position";
            positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeDtoBindingSource
            // 
            employeeDtoBindingSource.DataSource = typeof(Data.DTO.EmployeeDto);
            // 
            // panelMembersHeader
            // 
            panelMembersHeader.BackColor = Color.FromArgb(248, 249, 250);
            panelMembersHeader.Controls.Add(lblMemberCount);
            panelMembersHeader.Controls.Add(btnAddMember);
            panelMembersHeader.Controls.Add(btnRemoveMember);
            panelMembersHeader.Dock = DockStyle.Top;
            panelMembersHeader.Location = new Point(23, 52);
            panelMembersHeader.Margin = new Padding(3, 4, 3, 4);
            panelMembersHeader.Name = "panelMembersHeader";
            panelMembersHeader.Padding = new Padding(11, 13, 11, 13);
            panelMembersHeader.Size = new Size(1257, 53);
            panelMembersHeader.TabIndex = 0;
            // 
            // lblMemberCount
            // 
            lblMemberCount.AutoSize = true;
            lblMemberCount.Font = new Font("Segoe UI", 10F);
            lblMemberCount.ForeColor = Color.FromArgb(108, 117, 125);
            lblMemberCount.Location = new Point(11, 13);
            lblMemberCount.Name = "lblMemberCount";
            lblMemberCount.Size = new Size(153, 23);
            lblMemberCount.TabIndex = 0;
            lblMemberCount.Text = "Tổng: 0 thành viên";
            // 
            // btnAddMember
            // 
            btnAddMember.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddMember.BackColor = Color.FromArgb(40, 167, 69);
            btnAddMember.FlatAppearance.BorderSize = 0;
            btnAddMember.FlatStyle = FlatStyle.Flat;
            btnAddMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddMember.ForeColor = Color.White;
            btnAddMember.Location = new Point(1006, 7);
            btnAddMember.Margin = new Padding(3, 4, 3, 4);
            btnAddMember.Name = "btnAddMember";
            btnAddMember.Size = new Size(114, 40);
            btnAddMember.TabIndex = 1;
            btnAddMember.Text = "+ Thêm";
            btnAddMember.UseVisualStyleBackColor = false;
            btnAddMember.Click += btnAddMember_Click;
            // 
            // btnRemoveMember
            // 
            btnRemoveMember.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveMember.BackColor = Color.FromArgb(220, 53, 69);
            btnRemoveMember.FlatAppearance.BorderSize = 0;
            btnRemoveMember.FlatStyle = FlatStyle.Flat;
            btnRemoveMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveMember.ForeColor = Color.White;
            btnRemoveMember.Location = new Point(1131, 7);
            btnRemoveMember.Margin = new Padding(3, 4, 3, 4);
            btnRemoveMember.Name = "btnRemoveMember";
            btnRemoveMember.Size = new Size(114, 40);
            btnRemoveMember.TabIndex = 2;
            btnRemoveMember.Text = "- Xóa";
            btnRemoveMember.UseVisualStyleBackColor = false;
            btnRemoveMember.Click += btnRemoveMember_Click;
            // 
            // groupBoxLeaderInfo
            // 
            groupBoxLeaderInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxLeaderInfo.BackColor = Color.White;
            groupBoxLeaderInfo.Controls.Add(panelLeaderContent);
            groupBoxLeaderInfo.Controls.Add(panelNoLeader);
            groupBoxLeaderInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxLeaderInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxLeaderInfo.Location = new Point(34, 240);
            groupBoxLeaderInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxLeaderInfo.Name = "groupBoxLeaderInfo";
            groupBoxLeaderInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxLeaderInfo.Size = new Size(1303, 213);
            groupBoxLeaderInfo.TabIndex = 1;
            groupBoxLeaderInfo.TabStop = false;
            groupBoxLeaderInfo.Text = "👑 Thông Tin Leader";
            // 
            // panelLeaderContent
            // 
            panelLeaderContent.Controls.Add(lblLeaderPosition);
            panelLeaderContent.Controls.Add(txtLeaderPosition);
            panelLeaderContent.Controls.Add(lblLeaderEmail);
            panelLeaderContent.Controls.Add(txtLeaderEmail);
            panelLeaderContent.Controls.Add(lblLeaderPhone);
            panelLeaderContent.Controls.Add(txtLeaderPhone);
            panelLeaderContent.Controls.Add(lblLeaderName);
            panelLeaderContent.Controls.Add(txtLeaderName);
            panelLeaderContent.Controls.Add(lblLeaderEmployeeId);
            panelLeaderContent.Controls.Add(txtLeaderEmployeeId);
            panelLeaderContent.Dock = DockStyle.Fill;
            panelLeaderContent.Location = new Point(23, 52);
            panelLeaderContent.Margin = new Padding(3, 4, 3, 4);
            panelLeaderContent.Name = "panelLeaderContent";
            panelLeaderContent.Size = new Size(1257, 134);
            panelLeaderContent.TabIndex = 1;
            // 
            // lblLeaderPosition
            // 
            lblLeaderPosition.AutoSize = true;
            lblLeaderPosition.Font = new Font("Segoe UI", 10F);
            lblLeaderPosition.ForeColor = Color.FromArgb(85, 85, 85);
            lblLeaderPosition.Location = new Point(843, 13);
            lblLeaderPosition.Name = "lblLeaderPosition";
            lblLeaderPosition.Size = new Size(76, 23);
            lblLeaderPosition.TabIndex = 9;
            lblLeaderPosition.Text = "Chức vụ:";
            // 
            // txtLeaderPosition
            // 
            txtLeaderPosition.Font = new Font("Segoe UI", 10F);
            txtLeaderPosition.Location = new Point(951, 13);
            txtLeaderPosition.Margin = new Padding(3, 4, 3, 4);
            txtLeaderPosition.Name = "txtLeaderPosition";
            txtLeaderPosition.ReadOnly = true;
            txtLeaderPosition.Size = new Size(228, 30);
            txtLeaderPosition.TabIndex = 10;
            // 
            // lblLeaderEmail
            // 
            lblLeaderEmail.AutoSize = true;
            lblLeaderEmail.Font = new Font("Segoe UI", 10F);
            lblLeaderEmail.ForeColor = Color.FromArgb(85, 85, 85);
            lblLeaderEmail.Location = new Point(376, 90);
            lblLeaderEmail.Name = "lblLeaderEmail";
            lblLeaderEmail.Size = new Size(55, 23);
            lblLeaderEmail.TabIndex = 7;
            lblLeaderEmail.Text = "Email:";
            // 
            // txtLeaderEmail
            // 
            txtLeaderEmail.Font = new Font("Segoe UI", 10F);
            txtLeaderEmail.Location = new Point(470, 87);
            txtLeaderEmail.Margin = new Padding(3, 4, 3, 4);
            txtLeaderEmail.Name = "txtLeaderEmail";
            txtLeaderEmail.ReadOnly = true;
            txtLeaderEmail.Size = new Size(342, 30);
            txtLeaderEmail.TabIndex = 8;
            // 
            // lblLeaderPhone
            // 
            lblLeaderPhone.AutoSize = true;
            lblLeaderPhone.Font = new Font("Segoe UI", 10F);
            lblLeaderPhone.ForeColor = Color.FromArgb(85, 85, 85);
            lblLeaderPhone.Location = new Point(11, 87);
            lblLeaderPhone.Name = "lblLeaderPhone";
            lblLeaderPhone.Size = new Size(115, 23);
            lblLeaderPhone.TabIndex = 5;
            lblLeaderPhone.Text = "Số điện thoại:";
            // 
            // txtLeaderPhone
            // 
            txtLeaderPhone.Font = new Font("Segoe UI", 10F);
            txtLeaderPhone.Location = new Point(137, 87);
            txtLeaderPhone.Margin = new Padding(3, 4, 3, 4);
            txtLeaderPhone.Name = "txtLeaderPhone";
            txtLeaderPhone.ReadOnly = true;
            txtLeaderPhone.Size = new Size(217, 30);
            txtLeaderPhone.TabIndex = 6;
            // 
            // lblLeaderName
            // 
            lblLeaderName.AutoSize = true;
            lblLeaderName.Font = new Font("Segoe UI", 10F);
            lblLeaderName.ForeColor = Color.FromArgb(85, 85, 85);
            lblLeaderName.Location = new Point(376, 16);
            lblLeaderName.Name = "lblLeaderName";
            lblLeaderName.Size = new Size(88, 23);
            lblLeaderName.TabIndex = 3;
            lblLeaderName.Text = "Họ và tên:";
            // 
            // txtLeaderName
            // 
            txtLeaderName.Font = new Font("Segoe UI", 10F);
            txtLeaderName.Location = new Point(470, 13);
            txtLeaderName.Margin = new Padding(3, 4, 3, 4);
            txtLeaderName.Name = "txtLeaderName";
            txtLeaderName.ReadOnly = true;
            txtLeaderName.Size = new Size(342, 30);
            txtLeaderName.TabIndex = 4;
            // 
            // lblLeaderEmployeeId
            // 
            lblLeaderEmployeeId.AutoSize = true;
            lblLeaderEmployeeId.Font = new Font("Segoe UI", 10F);
            lblLeaderEmployeeId.ForeColor = Color.FromArgb(85, 85, 85);
            lblLeaderEmployeeId.Location = new Point(11, 13);
            lblLeaderEmployeeId.Name = "lblLeaderEmployeeId";
            lblLeaderEmployeeId.Size = new Size(118, 23);
            lblLeaderEmployeeId.TabIndex = 1;
            lblLeaderEmployeeId.Text = "Mã nhân viên:";
            // 
            // txtLeaderEmployeeId
            // 
            txtLeaderEmployeeId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtLeaderEmployeeId.ForeColor = Color.FromArgb(220, 53, 69);
            txtLeaderEmployeeId.Location = new Point(137, 13);
            txtLeaderEmployeeId.Margin = new Padding(3, 4, 3, 4);
            txtLeaderEmployeeId.Name = "txtLeaderEmployeeId";
            txtLeaderEmployeeId.ReadOnly = true;
            txtLeaderEmployeeId.Size = new Size(217, 30);
            txtLeaderEmployeeId.TabIndex = 2;
            // 
            // panelNoLeader
            // 
            panelNoLeader.Controls.Add(lblNoLeader);
            panelNoLeader.Dock = DockStyle.Fill;
            panelNoLeader.Location = new Point(23, 52);
            panelNoLeader.Margin = new Padding(3, 4, 3, 4);
            panelNoLeader.Name = "panelNoLeader";
            panelNoLeader.Size = new Size(1257, 134);
            panelNoLeader.TabIndex = 0;
            // 
            // lblNoLeader
            // 
            lblNoLeader.Anchor = AnchorStyles.None;
            lblNoLeader.AutoSize = true;
            lblNoLeader.Font = new Font("Segoe UI", 12F);
            lblNoLeader.ForeColor = Color.FromArgb(108, 117, 125);
            lblNoLeader.Location = new Point(514, 31);
            lblNoLeader.Name = "lblNoLeader";
            lblNoLeader.Size = new Size(313, 28);
            lblNoLeader.TabIndex = 0;
            lblNoLeader.Text = "Team chưa có leader được chỉ định";
            // 
            // groupBoxTeamInfo
            // 
            groupBoxTeamInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxTeamInfo.BackColor = Color.White;
            groupBoxTeamInfo.Controls.Add(lblTeamDescription);
            groupBoxTeamInfo.Controls.Add(txtTeamDescription);
            groupBoxTeamInfo.Controls.Add(lblTeamName);
            groupBoxTeamInfo.Controls.Add(txtTeamName);
            groupBoxTeamInfo.Controls.Add(lblTeamId);
            groupBoxTeamInfo.Controls.Add(txtTeamId);
            groupBoxTeamInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxTeamInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxTeamInfo.Location = new Point(34, 40);
            groupBoxTeamInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxTeamInfo.Name = "groupBoxTeamInfo";
            groupBoxTeamInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxTeamInfo.Size = new Size(1303, 187);
            groupBoxTeamInfo.TabIndex = 0;
            groupBoxTeamInfo.TabStop = false;
            groupBoxTeamInfo.Text = "🏢 Thông Tin Team";
            // 
            // lblTeamDescription
            // 
            lblTeamDescription.AutoSize = true;
            lblTeamDescription.Font = new Font("Segoe UI", 10F);
            lblTeamDescription.ForeColor = Color.FromArgb(85, 85, 85);
            lblTeamDescription.Location = new Point(34, 100);
            lblTeamDescription.Name = "lblTeamDescription";
            lblTeamDescription.Size = new Size(59, 23);
            lblTeamDescription.TabIndex = 5;
            lblTeamDescription.Text = "Mô tả:";
            // 
            // txtTeamDescription
            // 
            txtTeamDescription.Font = new Font("Segoe UI", 10F);
            txtTeamDescription.Location = new Point(103, 100);
            txtTeamDescription.Margin = new Padding(3, 4, 3, 4);
            txtTeamDescription.Multiline = true;
            txtTeamDescription.Name = "txtTeamDescription";
            txtTeamDescription.ReadOnly = true;
            txtTeamDescription.Size = new Size(1165, 65);
            txtTeamDescription.TabIndex = 6;
            // 
            // lblTeamName
            // 
            lblTeamName.AutoSize = true;
            lblTeamName.Font = new Font("Segoe UI", 10F);
            lblTeamName.ForeColor = Color.FromArgb(85, 85, 85);
            lblTeamName.Location = new Point(263, 53);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(85, 23);
            lblTeamName.TabIndex = 3;
            lblTeamName.Text = "Tên Team:";
            // 
            // txtTeamName
            // 
            txtTeamName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtTeamName.ForeColor = Color.FromArgb(40, 167, 69);
            txtTeamName.Location = new Point(354, 53);
            txtTeamName.Margin = new Padding(3, 4, 3, 4);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.ReadOnly = true;
            txtTeamName.Size = new Size(457, 30);
            txtTeamName.TabIndex = 4;
            // 
            // lblTeamId
            // 
            lblTeamId.AutoSize = true;
            lblTeamId.Font = new Font("Segoe UI", 10F);
            lblTeamId.ForeColor = Color.FromArgb(85, 85, 85);
            lblTeamId.Location = new Point(34, 53);
            lblTeamId.Name = "lblTeamId";
            lblTeamId.Size = new Size(83, 23);
            lblTeamId.TabIndex = 1;
            lblTeamId.Text = "Mã Team:";
            // 
            // txtTeamId
            // 
            txtTeamId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtTeamId.ForeColor = Color.FromArgb(51, 122, 183);
            txtTeamId.Location = new Point(126, 53);
            txtTeamId.Margin = new Padding(3, 4, 3, 4);
            txtTeamId.Name = "txtTeamId";
            txtTeamId.ReadOnly = true;
            txtTeamId.Size = new Size(114, 30);
            txtTeamId.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 867);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(34, 20, 34, 20);
            panelButtons.Size = new Size(1371, 93);
            panelButtons.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1211, 20);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 53);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(255, 193, 7);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(68, 68, 68);
            btnEdit.Location = new Point(1086, 20);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 53);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(960, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 53);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // employeeContextMenuStrip
            // 
            employeeContextMenuStrip.ImageScalingSize = new Size(20, 20);
            employeeContextMenuStrip.Items.AddRange(new ToolStripItem[] { addLeader });
            employeeContextMenuStrip.Name = "employeeContextMenuStrip";
            employeeContextMenuStrip.Size = new Size(220, 28);
            // 
            // addLeader
            // 
            addLeader.Name = "addLeader";
            addLeader.Size = new Size(219, 24);
            addLeader.Text = "Bổ nhiệm làm Leader";
            addLeader.Click += addLeader_Click;
            // 
            // TeamInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 960);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1369, 944);
            Name = "TeamInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông Tin Team";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).EndInit();
            panelMembersHeader.ResumeLayout(false);
            panelMembersHeader.PerformLayout();
            groupBoxLeaderInfo.ResumeLayout(false);
            panelLeaderContent.ResumeLayout(false);
            panelLeaderContent.PerformLayout();
            panelNoLeader.ResumeLayout(false);
            panelNoLeader.PerformLayout();
            groupBoxTeamInfo.ResumeLayout(false);
            groupBoxTeamInfo.PerformLayout();
            panelButtons.ResumeLayout(false);
            employeeContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxTeamInfo;
        private System.Windows.Forms.Label lblTeamId;
        private System.Windows.Forms.TextBox txtTeamId;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label lblTeamDescription;
        private System.Windows.Forms.TextBox txtTeamDescription;
        private System.Windows.Forms.GroupBox groupBoxLeaderInfo;
        private System.Windows.Forms.Panel panelNoLeader;
        private System.Windows.Forms.Label lblNoLeader;
        private System.Windows.Forms.Panel panelLeaderContent;
        private System.Windows.Forms.Label lblLeaderEmployeeId;
        private System.Windows.Forms.TextBox txtLeaderEmployeeId;
        private System.Windows.Forms.Label lblLeaderName;
        private System.Windows.Forms.TextBox txtLeaderName;
        private System.Windows.Forms.Label lblLeaderPhone;
        private System.Windows.Forms.TextBox txtLeaderPhone;
        private System.Windows.Forms.Label lblLeaderEmail;
        private System.Windows.Forms.TextBox txtLeaderEmail;
        private System.Windows.Forms.Label lblLeaderPosition;
        private System.Windows.Forms.TextBox txtLeaderPosition;
        private System.Windows.Forms.GroupBox groupBoxMembers;
        private System.Windows.Forms.Panel panelMembersHeader;
        private System.Windows.Forms.Label lblMemberCount;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnRemoveMember;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private BindingSource employeeDtoBindingSource;
        private DataGridView dgvMembers;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hireDateDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn maxHoursPerDayDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxHoursPerMonthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalHoursThisMonthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalHoursTodayDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private ContextMenuStrip employeeContextMenuStrip;
        private ToolStripMenuItem addLeader;
    }
}