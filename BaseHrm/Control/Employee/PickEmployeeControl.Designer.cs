namespace BaseHrm.Controls
{
    partial class PickEmployeeControl
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
            dgvEmployees = new DataGridView();
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
            label1 = new Label();
            txtSearch = new TextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, genderDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, addressDataGridViewTextBoxColumn, hireDateDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, maxHoursPerDayDataGridViewTextBoxColumn, maxHoursPerMonthDataGridViewTextBoxColumn, totalHoursThisMonthDataGridViewTextBoxColumn, totalHoursTodayDataGridViewTextBoxColumn, positionIdDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn });
            dgvEmployees.DataSource = employeeDtoBindingSource;
            dgvEmployees.GridColor = Color.FromArgb(233, 236, 239);
            dgvEmployees.Location = new Point(32, 96);
            dgvEmployees.Margin = new Padding(3, 4, 3, 4);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.RowTemplate.Height = 35;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(617, 384);
            dgvEmployees.TabIndex = 1;
            dgvEmployees.CellMouseDoubleClick += dgvEmployees_CellMouseDoubleClick;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
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
            firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.ReadOnly = true;
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            dateOfBirthDataGridViewTextBoxColumn.Width = 125;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            genderDataGridViewTextBoxColumn.DataPropertyName = "Gender";
            genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            genderDataGridViewTextBoxColumn.MinimumWidth = 6;
            genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            genderDataGridViewTextBoxColumn.ReadOnly = true;
            genderDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.ReadOnly = true;
            phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn.HeaderText = "Address";
            addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            addressDataGridViewTextBoxColumn.ReadOnly = true;
            addressDataGridViewTextBoxColumn.Width = 125;
            // 
            // hireDateDataGridViewTextBoxColumn
            // 
            hireDateDataGridViewTextBoxColumn.DataPropertyName = "HireDate";
            hireDateDataGridViewTextBoxColumn.HeaderText = "HireDate";
            hireDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            hireDateDataGridViewTextBoxColumn.Name = "hireDateDataGridViewTextBoxColumn";
            hireDateDataGridViewTextBoxColumn.ReadOnly = true;
            hireDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            isActiveDataGridViewCheckBoxColumn.HeaderText = "IsActive";
            isActiveDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            isActiveDataGridViewCheckBoxColumn.Width = 125;
            // 
            // maxHoursPerDayDataGridViewTextBoxColumn
            // 
            maxHoursPerDayDataGridViewTextBoxColumn.DataPropertyName = "MaxHoursPerDay";
            maxHoursPerDayDataGridViewTextBoxColumn.HeaderText = "MaxHoursPerDay";
            maxHoursPerDayDataGridViewTextBoxColumn.MinimumWidth = 6;
            maxHoursPerDayDataGridViewTextBoxColumn.Name = "maxHoursPerDayDataGridViewTextBoxColumn";
            maxHoursPerDayDataGridViewTextBoxColumn.ReadOnly = true;
            maxHoursPerDayDataGridViewTextBoxColumn.Width = 125;
            // 
            // maxHoursPerMonthDataGridViewTextBoxColumn
            // 
            maxHoursPerMonthDataGridViewTextBoxColumn.DataPropertyName = "MaxHoursPerMonth";
            maxHoursPerMonthDataGridViewTextBoxColumn.HeaderText = "MaxHoursPerMonth";
            maxHoursPerMonthDataGridViewTextBoxColumn.MinimumWidth = 6;
            maxHoursPerMonthDataGridViewTextBoxColumn.Name = "maxHoursPerMonthDataGridViewTextBoxColumn";
            maxHoursPerMonthDataGridViewTextBoxColumn.ReadOnly = true;
            maxHoursPerMonthDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalHoursThisMonthDataGridViewTextBoxColumn
            // 
            totalHoursThisMonthDataGridViewTextBoxColumn.DataPropertyName = "TotalHoursThisMonth";
            totalHoursThisMonthDataGridViewTextBoxColumn.HeaderText = "TotalHoursThisMonth";
            totalHoursThisMonthDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalHoursThisMonthDataGridViewTextBoxColumn.Name = "totalHoursThisMonthDataGridViewTextBoxColumn";
            totalHoursThisMonthDataGridViewTextBoxColumn.ReadOnly = true;
            totalHoursThisMonthDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalHoursTodayDataGridViewTextBoxColumn
            // 
            totalHoursTodayDataGridViewTextBoxColumn.DataPropertyName = "TotalHoursToday";
            totalHoursTodayDataGridViewTextBoxColumn.HeaderText = "TotalHoursToday";
            totalHoursTodayDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalHoursTodayDataGridViewTextBoxColumn.Name = "totalHoursTodayDataGridViewTextBoxColumn";
            totalHoursTodayDataGridViewTextBoxColumn.ReadOnly = true;
            totalHoursTodayDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionIdDataGridViewTextBoxColumn
            // 
            positionIdDataGridViewTextBoxColumn.DataPropertyName = "PositionId";
            positionIdDataGridViewTextBoxColumn.HeaderText = "PositionId";
            positionIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionIdDataGridViewTextBoxColumn.Name = "positionIdDataGridViewTextBoxColumn";
            positionIdDataGridViewTextBoxColumn.ReadOnly = true;
            positionIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn
            // 
            positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn.HeaderText = "Position";
            positionDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            positionDataGridViewTextBoxColumn.ReadOnly = true;
            positionDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeDtoBindingSource
            // 
            employeeDtoBindingSource.DataSource = typeof(Data.DTO.EmployeeDto);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 13);
            label1.Name = "label1";
            label1.Size = new Size(219, 31);
            label1.TabIndex = 2;
            label1.Text = "Chọn một nhân viên";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(32, 62);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo tên";
            txtSearch.Size = new Size(349, 27);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(387, 60);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "🔍Tìm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(566, 60);
            button2.Name = "button2";
            button2.Size = new Size(83, 29);
            button2.TabIndex = 5;
            button2.Text = "Chọn";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // PickEmployeeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvEmployees);
            Name = "PickEmployeeControl";
            Size = new Size(676, 497);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeDtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
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
        private Label label1;
        private TextBox txtSearch;
        private Button button1;
        private Button button2;
    }
}
