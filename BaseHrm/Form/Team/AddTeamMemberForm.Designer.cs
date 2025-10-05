namespace BaseHrm
{
    partial class AddTeamMemberForm
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
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            teamName = new ReaLTaiizor.Controls.FoxBigLabel();
            employeeDataGridView = new DataGridView();
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
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            teamMemberDataGridView = new DataGridView();
            employeeIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            isLeaderDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            joinedAtDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            teamMemberBindingSource = new BindingSource(components);
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            ((System.ComponentModel.ISupportInitialize)employeeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teamMemberDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teamMemberBindingSource).BeginInit();
            SuspendLayout();
            // 
            // nightControlBox1
            // 
            nightControlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(801, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 0;
            // 
            // teamName
            // 
            teamName.BackColor = Color.Transparent;
            teamName.Font = new Font("Segoe UI Semibold", 20F);
            teamName.ForeColor = Color.FromArgb(76, 88, 100);
            teamName.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            teamName.LineColor = Color.FromArgb(200, 200, 200);
            teamName.Location = new Point(62, 26);
            teamName.Name = "teamName";
            teamName.Size = new Size(206, 48);
            teamName.TabIndex = 1;
            teamName.Text = "Tên Team";
            // 
            // employeeDataGridView
            // 
            employeeDataGridView.AutoGenerateColumns = false;
            employeeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeeDataGridView.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, genderDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, addressDataGridViewTextBoxColumn, hireDateDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, maxHoursPerDayDataGridViewTextBoxColumn, maxHoursPerMonthDataGridViewTextBoxColumn, totalHoursThisMonthDataGridViewTextBoxColumn, totalHoursTodayDataGridViewTextBoxColumn, positionIdDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn });
            employeeDataGridView.DataSource = employeeDtoBindingSource;
            employeeDataGridView.Location = new Point(62, 125);
            employeeDataGridView.Name = "employeeDataGridView";
            employeeDataGridView.RowHeadersWidth = 51;
            employeeDataGridView.Size = new Size(300, 302);
            employeeDataGridView.TabIndex = 2;
            employeeDataGridView.CellDoubleClick += employeeDataGridView_CellDoubleClick;
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
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(62, 93);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(111, 19);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Chọn nhân viên";
            // 
            // teamMemberDataGridView
            // 
            teamMemberDataGridView.AutoGenerateColumns = false;
            teamMemberDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            teamMemberDataGridView.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn1, fullNameDataGridViewTextBoxColumn1, isLeaderDataGridViewCheckBoxColumn, joinedAtDataGridViewTextBoxColumn });
            teamMemberDataGridView.DataSource = teamMemberBindingSource;
            teamMemberDataGridView.Enabled = false;
            teamMemberDataGridView.Location = new Point(387, 125);
            teamMemberDataGridView.Name = "teamMemberDataGridView";
            teamMemberDataGridView.RowHeadersWidth = 51;
            teamMemberDataGridView.Size = new Size(543, 302);
            teamMemberDataGridView.TabIndex = 4;
            teamMemberDataGridView.CellMouseClick += teamMemberDataGridView_CellMouseClick;
            // 
            // employeeIdDataGridViewTextBoxColumn1
            // 
            employeeIdDataGridViewTextBoxColumn1.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn1.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn1.Name = "employeeIdDataGridViewTextBoxColumn1";
            employeeIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn1
            // 
            fullNameDataGridViewTextBoxColumn1.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn1.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn1.Name = "fullNameDataGridViewTextBoxColumn1";
            fullNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // isLeaderDataGridViewCheckBoxColumn
            // 
            isLeaderDataGridViewCheckBoxColumn.DataPropertyName = "IsLeader";
            isLeaderDataGridViewCheckBoxColumn.HeaderText = "IsLeader";
            isLeaderDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isLeaderDataGridViewCheckBoxColumn.Name = "isLeaderDataGridViewCheckBoxColumn";
            isLeaderDataGridViewCheckBoxColumn.Width = 125;
            // 
            // joinedAtDataGridViewTextBoxColumn
            // 
            joinedAtDataGridViewTextBoxColumn.DataPropertyName = "JoinedAt";
            joinedAtDataGridViewTextBoxColumn.HeaderText = "JoinedAt";
            joinedAtDataGridViewTextBoxColumn.MinimumWidth = 6;
            joinedAtDataGridViewTextBoxColumn.Name = "joinedAtDataGridViewTextBoxColumn";
            joinedAtDataGridViewTextBoxColumn.Width = 125;
            // 
            // teamMemberBindingSource
            // 
            teamMemberBindingSource.DataSource = typeof(Data.DTO.TeamMemberDto);
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(387, 93);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(135, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Nhân viên đã thêm";
            // 
            // hopeButton1
            // 
            hopeButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeButton1.Font = new Font("Segoe UI", 12F);
            hopeButton1.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeButton1.Location = new Point(780, 443);
            hopeButton1.Name = "hopeButton1";
            hopeButton1.PrimaryColor = Color.FromArgb(64, 158, 255);
            hopeButton1.Size = new Size(150, 50);
            hopeButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton1.TabIndex = 6;
            hopeButton1.Text = "Xác nhận thêm";
            hopeButton1.TextColor = Color.White;
            hopeButton1.WarningColor = Color.FromArgb(230, 162, 60);
            hopeButton1.Click += hopeButton1_Click;
            // 
            // AddTeamMemberForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 514);
            Controls.Add(hopeButton1);
            Controls.Add(materialLabel2);
            Controls.Add(teamMemberDataGridView);
            Controls.Add(materialLabel1);
            Controls.Add(employeeDataGridView);
            Controls.Add(teamName);
            Controls.Add(nightControlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddTeamMemberForm";
            Text = "AddTeamMemberForm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)employeeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)teamMemberDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)teamMemberBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private ReaLTaiizor.Controls.FoxBigLabel teamName;
        private DataGridView employeeDataGridView;
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
        private BindingSource employeeDtoBindingSource;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private BindingSource teamMemberDtoBindingSource;
        private DataGridView teamMemberDataGridView;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn isLeaderDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn joinedAtDataGridViewTextBoxColumn;
        private BindingSource teamMemberBindingSource;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
    }
}