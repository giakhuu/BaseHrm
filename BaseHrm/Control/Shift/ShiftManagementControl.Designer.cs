namespace BaseHrm.Controls
{
    partial class ShiftManagementControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            titleLabel = new Label();
            mainPanel = new Panel();
            tabControl = new TabControl();
            shiftInfoTab = new TabPage();
            shiftInfoPanel = new Panel();
            label2 = new Label();
            dateTextBox = new TextBox();
            datePicker = new MonthCalendar();
            label3 = new Label();
            shiftTypeComboBox = new ComboBox();
            shiftTypeLabel = new Label();
            expectedHoursNumeric = new NumericUpDown();
            expectedHoursLabel = new Label();
            endTimePicker = new DateTimePicker();
            endTimeLabel = new Label();
            startTimePicker = new DateTimePicker();
            startTimeLabel = new Label();
            shiftNameTextBox = new TextBox();
            shiftNameLabel = new Label();
            shiftInfoTitleLabel = new Label();
            assignmentTab = new TabPage();
            assignmentPanel = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            removeAllEmployee = new Button();
            addAllEmployeeBtn = new Button();
            removeEmployeeBtn = new Button();
            addEmployeeBtn = new Button();
            dgvSelectedEmployee = new DataGridView();
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
            dgvSelectedEmployeeBindingSource = new BindingSource(components);
            dgvPickEmployee = new DataGridView();
            employeeIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dateOfBirthDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            genderDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            addressDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            hireDateDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            isActiveDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            maxHoursPerDayDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            maxHoursPerMonthDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            totalHoursThisMonthDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            totalHoursTodayDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            positionIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            positionDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dgvPickEmployeeBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            button1 = new Button();
            cmbPosition = new ComboBox();
            label1 = new Label();
            textBox1 = new TextBox();
            lblSearchEmployee = new Label();
            assignmentTitleLabel = new Label();
            buttonPanel = new Panel();
            cancelButton = new Button();
            saveButton = new Button();
            createShiftOnlyCheckBox = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            tabControl.SuspendLayout();
            shiftInfoTab.SuspendLayout();
            shiftInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)expectedHoursNumeric).BeginInit();
            assignmentTab.SuspendLayout();
            assignmentPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedEmployeeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPickEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPickEmployeeBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1531, 107);
            headerPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1531, 107);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "🕒 Tạo Ca Làm Mới";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(248, 249, 250);
            mainPanel.Controls.Add(tabControl);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 107);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(46, 40, 46, 27);
            mainPanel.Size = new Size(1531, 739);
            mainPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(shiftInfoTab);
            tabControl.Controls.Add(assignmentTab);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 12F);
            tabControl.Location = new Point(46, 40);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1439, 672);
            tabControl.TabIndex = 0;
            // 
            // shiftInfoTab
            // 
            shiftInfoTab.BackColor = Color.White;
            shiftInfoTab.Controls.Add(shiftInfoPanel);
            shiftInfoTab.Location = new Point(4, 37);
            shiftInfoTab.Margin = new Padding(3, 4, 3, 4);
            shiftInfoTab.Name = "shiftInfoTab";
            shiftInfoTab.Padding = new Padding(3, 4, 3, 4);
            shiftInfoTab.Size = new Size(1431, 631);
            shiftInfoTab.TabIndex = 0;
            shiftInfoTab.Text = "📝 Thông tin ca làm";
            // 
            // shiftInfoPanel
            // 
            shiftInfoPanel.Controls.Add(dateTextBox);
            shiftInfoPanel.Controls.Add(datePicker);
            shiftInfoPanel.Controls.Add(label3);
            shiftInfoPanel.Controls.Add(shiftTypeComboBox);
            shiftInfoPanel.Controls.Add(shiftTypeLabel);
            shiftInfoPanel.Controls.Add(expectedHoursNumeric);
            shiftInfoPanel.Controls.Add(expectedHoursLabel);
            shiftInfoPanel.Controls.Add(endTimePicker);
            shiftInfoPanel.Controls.Add(endTimeLabel);
            shiftInfoPanel.Controls.Add(startTimePicker);
            shiftInfoPanel.Controls.Add(startTimeLabel);
            shiftInfoPanel.Controls.Add(shiftNameTextBox);
            shiftInfoPanel.Controls.Add(shiftNameLabel);
            shiftInfoPanel.Controls.Add(shiftInfoTitleLabel);
            shiftInfoPanel.Dock = DockStyle.Fill;
            shiftInfoPanel.Location = new Point(3, 4);
            shiftInfoPanel.Margin = new Padding(3, 4, 3, 4);
            shiftInfoPanel.Name = "shiftInfoPanel";
            shiftInfoPanel.Padding = new Padding(46, 40, 46, 40);
            shiftInfoPanel.Size = new Size(1425, 623);
            shiftInfoPanel.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(42, 16);
            label2.Name = "label2";
            label2.Size = new Size(361, 20);
            label2.TabIndex = 3;
            label2.Text = "❌ Thông tin có vấn đề, di chuột vào đây để kiểm tra";
            label2.Visible = false;
            // 
            // dateTextBox
            // 
            dateTextBox.Enabled = false;
            dateTextBox.Location = new Point(1051, 164);
            dateTextBox.Name = "dateTextBox";
            dateTextBox.Size = new Size(222, 34);
            dateTextBox.TabIndex = 14;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(945, 231);
            datePicker.MaxSelectionCount = 1;
            datePicker.Name = "datePicker";
            datePicker.TabIndex = 13;
            datePicker.DateSelected += datePicker_DateSelected;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(52, 58, 64);
            label3.Location = new Point(859, 167);
            label3.Name = "label3";
            label3.Size = new Size(186, 28);
            label3.TabIndex = 11;
            label3.Text = "📅 Ngày làm việc:";
            // 
            // shiftTypeComboBox
            // 
            shiftTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shiftTypeComboBox.Font = new Font("Segoe UI", 12F);
            shiftTypeComboBox.FormattingEnabled = true;
            shiftTypeComboBox.Location = new Point(286, 510);
            shiftTypeComboBox.Margin = new Padding(3, 4, 3, 4);
            shiftTypeComboBox.Name = "shiftTypeComboBox";
            shiftTypeComboBox.Size = new Size(342, 36);
            shiftTypeComboBox.TabIndex = 10;
            shiftTypeComboBox.SelectedValueChanged += shiftTypeComboBox_SelectedValueChanged;
            // 
            // shiftTypeLabel
            // 
            shiftTypeLabel.AutoSize = true;
            shiftTypeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            shiftTypeLabel.ForeColor = Color.FromArgb(52, 58, 64);
            shiftTypeLabel.Location = new Point(46, 514);
            shiftTypeLabel.Name = "shiftTypeLabel";
            shiftTypeLabel.Size = new Size(158, 28);
            shiftTypeLabel.TabIndex = 9;
            shiftTypeLabel.Text = "🏷️ Loại ca làm:";
            // 
            // expectedHoursNumeric
            // 
            expectedHoursNumeric.DecimalPlaces = 1;
            expectedHoursNumeric.Font = new Font("Segoe UI", 12F);
            expectedHoursNumeric.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            expectedHoursNumeric.Location = new Point(286, 424);
            expectedHoursNumeric.Margin = new Padding(3, 4, 3, 4);
            expectedHoursNumeric.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            expectedHoursNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            expectedHoursNumeric.Name = "expectedHoursNumeric";
            expectedHoursNumeric.ReadOnly = true;
            expectedHoursNumeric.Size = new Size(171, 34);
            expectedHoursNumeric.TabIndex = 8;
            expectedHoursNumeric.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // expectedHoursLabel
            // 
            expectedHoursLabel.AutoSize = true;
            expectedHoursLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            expectedHoursLabel.ForeColor = Color.FromArgb(52, 58, 64);
            expectedHoursLabel.Location = new Point(46, 427);
            expectedHoursLabel.Name = "expectedHoursLabel";
            expectedHoursLabel.Size = new Size(188, 28);
            expectedHoursLabel.TabIndex = 7;
            expectedHoursLabel.Text = "⏱️ Số giờ dự kiến:";
            // 
            // endTimePicker
            // 
            endTimePicker.CustomFormat = "HH:mm";
            endTimePicker.Font = new Font("Segoe UI", 12F);
            endTimePicker.Format = DateTimePickerFormat.Custom;
            endTimePicker.Location = new Point(286, 336);
            endTimePicker.Margin = new Padding(3, 4, 3, 4);
            endTimePicker.Name = "endTimePicker";
            endTimePicker.ShowUpDown = true;
            endTimePicker.Size = new Size(171, 34);
            endTimePicker.TabIndex = 6;
            endTimePicker.Value = new DateTime(2024, 1, 1, 17, 0, 0, 0);
            endTimePicker.ValueChanged += TimePicker_ValueChanged;
            // 
            // endTimeLabel
            // 
            endTimeLabel.AutoSize = true;
            endTimeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            endTimeLabel.ForeColor = Color.FromArgb(52, 58, 64);
            endTimeLabel.Location = new Point(46, 342);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new Size(168, 28);
            endTimeLabel.TabIndex = 5;
            endTimeLabel.Text = "🕕 Giờ kết thúc:";
            // 
            // startTimePicker
            // 
            startTimePicker.CustomFormat = "HH:mm";
            startTimePicker.Font = new Font("Segoe UI", 12F);
            startTimePicker.Format = DateTimePickerFormat.Custom;
            startTimePicker.Location = new Point(286, 251);
            startTimePicker.Margin = new Padding(3, 4, 3, 4);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.ShowUpDown = true;
            startTimePicker.Size = new Size(171, 34);
            startTimePicker.TabIndex = 4;
            startTimePicker.Value = new DateTime(2024, 1, 1, 9, 0, 0, 0);
            startTimePicker.ValueChanged += TimePicker_ValueChanged;
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            startTimeLabel.ForeColor = Color.FromArgb(52, 58, 64);
            startTimeLabel.Location = new Point(46, 258);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new Size(163, 28);
            startTimeLabel.TabIndex = 3;
            startTimeLabel.Text = "🕘 Giờ bắt đầu:";
            // 
            // shiftNameTextBox
            // 
            shiftNameTextBox.Font = new Font("Segoe UI", 12F);
            shiftNameTextBox.Location = new Point(286, 160);
            shiftNameTextBox.Margin = new Padding(3, 4, 3, 4);
            shiftNameTextBox.MaxLength = 100;
            shiftNameTextBox.Name = "shiftNameTextBox";
            shiftNameTextBox.PlaceholderText = "Nhập tên ca làm...";
            shiftNameTextBox.Size = new Size(457, 34);
            shiftNameTextBox.TabIndex = 2;
            shiftNameTextBox.TextChanged += ShiftNameTextBox_TextChanged;
            // 
            // shiftNameLabel
            // 
            shiftNameLabel.AutoSize = true;
            shiftNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            shiftNameLabel.ForeColor = Color.FromArgb(52, 58, 64);
            shiftNameLabel.Location = new Point(46, 164);
            shiftNameLabel.Name = "shiftNameLabel";
            shiftNameLabel.Size = new Size(152, 28);
            shiftNameLabel.TabIndex = 1;
            shiftNameLabel.Text = "📝 Tên ca làm:";
            // 
            // shiftInfoTitleLabel
            // 
            shiftInfoTitleLabel.AutoSize = true;
            shiftInfoTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            shiftInfoTitleLabel.ForeColor = Color.FromArgb(52, 152, 219);
            shiftInfoTitleLabel.Location = new Point(46, 67);
            shiftInfoTitleLabel.Name = "shiftInfoTitleLabel";
            shiftInfoTitleLabel.Size = new Size(304, 41);
            shiftInfoTitleLabel.TabIndex = 0;
            shiftInfoTitleLabel.Text = "ℹ️ Thông tin ca làm";
            // 
            // assignmentTab
            // 
            assignmentTab.BackColor = Color.White;
            assignmentTab.Controls.Add(assignmentPanel);
            assignmentTab.Location = new Point(4, 37);
            assignmentTab.Margin = new Padding(3, 4, 3, 4);
            assignmentTab.Name = "assignmentTab";
            assignmentTab.Padding = new Padding(3, 4, 3, 4);
            assignmentTab.Size = new Size(1431, 631);
            assignmentTab.TabIndex = 1;
            assignmentTab.Text = "👥 Phân ca nhân viên";
            // 
            // assignmentPanel
            // 
            assignmentPanel.Controls.Add(panel1);
            assignmentPanel.Controls.Add(assignmentTitleLabel);
            assignmentPanel.Dock = DockStyle.Fill;
            assignmentPanel.Location = new Point(3, 4);
            assignmentPanel.Margin = new Padding(3, 4, 3, 4);
            assignmentPanel.Name = "assignmentPanel";
            assignmentPanel.Padding = new Padding(46, 40, 46, 40);
            assignmentPanel.Size = new Size(1425, 623);
            assignmentPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(46, 108);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1333, 475);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(removeAllEmployee);
            panel2.Controls.Add(addAllEmployeeBtn);
            panel2.Controls.Add(removeEmployeeBtn);
            panel2.Controls.Add(addEmployeeBtn);
            panel2.Controls.Add(dgvSelectedEmployee);
            panel2.Controls.Add(dgvPickEmployee);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 145);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(1293, 310);
            panel2.TabIndex = 1;
            // 
            // removeAllEmployee
            // 
            removeAllEmployee.Location = new Point(620, 233);
            removeAllEmployee.Name = "removeAllEmployee";
            removeAllEmployee.Size = new Size(53, 43);
            removeAllEmployee.TabIndex = 5;
            removeAllEmployee.Text = "<<";
            removeAllEmployee.UseVisualStyleBackColor = true;
            removeAllEmployee.Click += removeAllEmployee_Click;
            // 
            // addAllEmployeeBtn
            // 
            addAllEmployeeBtn.Location = new Point(620, 161);
            addAllEmployeeBtn.Name = "addAllEmployeeBtn";
            addAllEmployeeBtn.Size = new Size(53, 43);
            addAllEmployeeBtn.TabIndex = 4;
            addAllEmployeeBtn.Text = ">>";
            addAllEmployeeBtn.UseVisualStyleBackColor = true;
            addAllEmployeeBtn.Click += addAllEmployeeBtn_Click;
            // 
            // removeEmployeeBtn
            // 
            removeEmployeeBtn.Location = new Point(620, 96);
            removeEmployeeBtn.Name = "removeEmployeeBtn";
            removeEmployeeBtn.Size = new Size(53, 43);
            removeEmployeeBtn.TabIndex = 3;
            removeEmployeeBtn.Text = "<";
            removeEmployeeBtn.UseVisualStyleBackColor = true;
            removeEmployeeBtn.Click += removeEmployeeBtn_Click;
            // 
            // addEmployeeBtn
            // 
            addEmployeeBtn.Location = new Point(620, 32);
            addEmployeeBtn.Name = "addEmployeeBtn";
            addEmployeeBtn.Size = new Size(53, 43);
            addEmployeeBtn.TabIndex = 2;
            addEmployeeBtn.Text = ">";
            addEmployeeBtn.UseVisualStyleBackColor = true;
            addEmployeeBtn.Click += addEmployeeBtn_Click;
            // 
            // dgvSelectedEmployee
            // 
            dgvSelectedEmployee.AllowUserToAddRows = false;
            dgvSelectedEmployee.AllowUserToDeleteRows = false;
            dgvSelectedEmployee.AutoGenerateColumns = false;
            dgvSelectedEmployee.BackgroundColor = Color.White;
            dgvSelectedEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSelectedEmployee.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, genderDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, addressDataGridViewTextBoxColumn, hireDateDataGridViewTextBoxColumn, isActiveDataGridViewCheckBoxColumn, maxHoursPerDayDataGridViewTextBoxColumn, maxHoursPerMonthDataGridViewTextBoxColumn, totalHoursThisMonthDataGridViewTextBoxColumn, totalHoursTodayDataGridViewTextBoxColumn, positionIdDataGridViewTextBoxColumn, positionDataGridViewTextBoxColumn });
            dgvSelectedEmployee.DataSource = dgvSelectedEmployeeBindingSource;
            dgvSelectedEmployee.Dock = DockStyle.Right;
            dgvSelectedEmployee.Location = new Point(804, 10);
            dgvSelectedEmployee.Name = "dgvSelectedEmployee";
            dgvSelectedEmployee.ReadOnly = true;
            dgvSelectedEmployee.RowHeadersVisible = false;
            dgvSelectedEmployee.RowHeadersWidth = 51;
            dgvSelectedEmployee.Size = new Size(479, 290);
            dgvSelectedEmployee.TabIndex = 1;
            dgvSelectedEmployee.CellClick += dgvSelectedEmployee_CellClick;
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
            // dgvSelectedEmployeeBindingSource
            // 
            dgvSelectedEmployeeBindingSource.DataSource = typeof(Data.DTO.EmployeeDto);
            // 
            // dgvPickEmployee
            // 
            dgvPickEmployee.AllowUserToAddRows = false;
            dgvPickEmployee.AllowUserToDeleteRows = false;
            dgvPickEmployee.AutoGenerateColumns = false;
            dgvPickEmployee.BackgroundColor = Color.White;
            dgvPickEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPickEmployee.Columns.AddRange(new DataGridViewColumn[] { employeeIdDataGridViewTextBoxColumn1, fullNameDataGridViewTextBoxColumn1, firstNameDataGridViewTextBoxColumn1, lastNameDataGridViewTextBoxColumn1, dateOfBirthDataGridViewTextBoxColumn1, genderDataGridViewTextBoxColumn1, emailDataGridViewTextBoxColumn1, phoneDataGridViewTextBoxColumn1, addressDataGridViewTextBoxColumn1, hireDateDataGridViewTextBoxColumn1, isActiveDataGridViewCheckBoxColumn1, maxHoursPerDayDataGridViewTextBoxColumn1, maxHoursPerMonthDataGridViewTextBoxColumn1, totalHoursThisMonthDataGridViewTextBoxColumn1, totalHoursTodayDataGridViewTextBoxColumn1, positionIdDataGridViewTextBoxColumn1, positionDataGridViewTextBoxColumn1 });
            dgvPickEmployee.DataSource = dgvPickEmployeeBindingSource;
            dgvPickEmployee.Dock = DockStyle.Left;
            dgvPickEmployee.GridColor = Color.Silver;
            dgvPickEmployee.Location = new Point(10, 10);
            dgvPickEmployee.Name = "dgvPickEmployee";
            dgvPickEmployee.ReadOnly = true;
            dgvPickEmployee.RowHeadersVisible = false;
            dgvPickEmployee.RowHeadersWidth = 51;
            dgvPickEmployee.Size = new Size(510, 290);
            dgvPickEmployee.TabIndex = 0;
            dgvPickEmployee.CellClick += dgvPickEmployee_CellClick;
            dgvPickEmployee.CellDoubleClick += dgvPickEmployee_CellDoubleClick;
            // 
            // employeeIdDataGridViewTextBoxColumn1
            // 
            employeeIdDataGridViewTextBoxColumn1.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn1.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn1.Name = "employeeIdDataGridViewTextBoxColumn1";
            employeeIdDataGridViewTextBoxColumn1.ReadOnly = true;
            employeeIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn1
            // 
            fullNameDataGridViewTextBoxColumn1.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn1.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn1.Name = "fullNameDataGridViewTextBoxColumn1";
            fullNameDataGridViewTextBoxColumn1.ReadOnly = true;
            fullNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn1
            // 
            firstNameDataGridViewTextBoxColumn1.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn1.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn1.Name = "firstNameDataGridViewTextBoxColumn1";
            firstNameDataGridViewTextBoxColumn1.ReadOnly = true;
            firstNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn1
            // 
            lastNameDataGridViewTextBoxColumn1.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn1.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn1.Name = "lastNameDataGridViewTextBoxColumn1";
            lastNameDataGridViewTextBoxColumn1.ReadOnly = true;
            lastNameDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dateOfBirthDataGridViewTextBoxColumn1
            // 
            dateOfBirthDataGridViewTextBoxColumn1.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn1.HeaderText = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn1.MinimumWidth = 6;
            dateOfBirthDataGridViewTextBoxColumn1.Name = "dateOfBirthDataGridViewTextBoxColumn1";
            dateOfBirthDataGridViewTextBoxColumn1.ReadOnly = true;
            dateOfBirthDataGridViewTextBoxColumn1.Width = 125;
            // 
            // genderDataGridViewTextBoxColumn1
            // 
            genderDataGridViewTextBoxColumn1.DataPropertyName = "Gender";
            genderDataGridViewTextBoxColumn1.HeaderText = "Gender";
            genderDataGridViewTextBoxColumn1.MinimumWidth = 6;
            genderDataGridViewTextBoxColumn1.Name = "genderDataGridViewTextBoxColumn1";
            genderDataGridViewTextBoxColumn1.ReadOnly = true;
            genderDataGridViewTextBoxColumn1.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn1
            // 
            emailDataGridViewTextBoxColumn1.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn1.HeaderText = "Email";
            emailDataGridViewTextBoxColumn1.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn1.Name = "emailDataGridViewTextBoxColumn1";
            emailDataGridViewTextBoxColumn1.ReadOnly = true;
            emailDataGridViewTextBoxColumn1.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn1
            // 
            phoneDataGridViewTextBoxColumn1.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn1.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn1.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn1.Name = "phoneDataGridViewTextBoxColumn1";
            phoneDataGridViewTextBoxColumn1.ReadOnly = true;
            phoneDataGridViewTextBoxColumn1.Width = 125;
            // 
            // addressDataGridViewTextBoxColumn1
            // 
            addressDataGridViewTextBoxColumn1.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn1.HeaderText = "Address";
            addressDataGridViewTextBoxColumn1.MinimumWidth = 6;
            addressDataGridViewTextBoxColumn1.Name = "addressDataGridViewTextBoxColumn1";
            addressDataGridViewTextBoxColumn1.ReadOnly = true;
            addressDataGridViewTextBoxColumn1.Width = 125;
            // 
            // hireDateDataGridViewTextBoxColumn1
            // 
            hireDateDataGridViewTextBoxColumn1.DataPropertyName = "HireDate";
            hireDateDataGridViewTextBoxColumn1.HeaderText = "HireDate";
            hireDateDataGridViewTextBoxColumn1.MinimumWidth = 6;
            hireDateDataGridViewTextBoxColumn1.Name = "hireDateDataGridViewTextBoxColumn1";
            hireDateDataGridViewTextBoxColumn1.ReadOnly = true;
            hireDateDataGridViewTextBoxColumn1.Width = 125;
            // 
            // isActiveDataGridViewCheckBoxColumn1
            // 
            isActiveDataGridViewCheckBoxColumn1.DataPropertyName = "IsActive";
            isActiveDataGridViewCheckBoxColumn1.HeaderText = "IsActive";
            isActiveDataGridViewCheckBoxColumn1.MinimumWidth = 6;
            isActiveDataGridViewCheckBoxColumn1.Name = "isActiveDataGridViewCheckBoxColumn1";
            isActiveDataGridViewCheckBoxColumn1.ReadOnly = true;
            isActiveDataGridViewCheckBoxColumn1.Width = 125;
            // 
            // maxHoursPerDayDataGridViewTextBoxColumn1
            // 
            maxHoursPerDayDataGridViewTextBoxColumn1.DataPropertyName = "MaxHoursPerDay";
            maxHoursPerDayDataGridViewTextBoxColumn1.HeaderText = "MaxHoursPerDay";
            maxHoursPerDayDataGridViewTextBoxColumn1.MinimumWidth = 6;
            maxHoursPerDayDataGridViewTextBoxColumn1.Name = "maxHoursPerDayDataGridViewTextBoxColumn1";
            maxHoursPerDayDataGridViewTextBoxColumn1.ReadOnly = true;
            maxHoursPerDayDataGridViewTextBoxColumn1.Width = 125;
            // 
            // maxHoursPerMonthDataGridViewTextBoxColumn1
            // 
            maxHoursPerMonthDataGridViewTextBoxColumn1.DataPropertyName = "MaxHoursPerMonth";
            maxHoursPerMonthDataGridViewTextBoxColumn1.HeaderText = "MaxHoursPerMonth";
            maxHoursPerMonthDataGridViewTextBoxColumn1.MinimumWidth = 6;
            maxHoursPerMonthDataGridViewTextBoxColumn1.Name = "maxHoursPerMonthDataGridViewTextBoxColumn1";
            maxHoursPerMonthDataGridViewTextBoxColumn1.ReadOnly = true;
            maxHoursPerMonthDataGridViewTextBoxColumn1.Width = 125;
            // 
            // totalHoursThisMonthDataGridViewTextBoxColumn1
            // 
            totalHoursThisMonthDataGridViewTextBoxColumn1.DataPropertyName = "TotalHoursThisMonth";
            totalHoursThisMonthDataGridViewTextBoxColumn1.HeaderText = "TotalHoursThisMonth";
            totalHoursThisMonthDataGridViewTextBoxColumn1.MinimumWidth = 6;
            totalHoursThisMonthDataGridViewTextBoxColumn1.Name = "totalHoursThisMonthDataGridViewTextBoxColumn1";
            totalHoursThisMonthDataGridViewTextBoxColumn1.ReadOnly = true;
            totalHoursThisMonthDataGridViewTextBoxColumn1.Visible = false;
            totalHoursThisMonthDataGridViewTextBoxColumn1.Width = 125;
            // 
            // totalHoursTodayDataGridViewTextBoxColumn1
            // 
            totalHoursTodayDataGridViewTextBoxColumn1.DataPropertyName = "TotalHoursToday";
            totalHoursTodayDataGridViewTextBoxColumn1.HeaderText = "TotalHoursToday";
            totalHoursTodayDataGridViewTextBoxColumn1.MinimumWidth = 6;
            totalHoursTodayDataGridViewTextBoxColumn1.Name = "totalHoursTodayDataGridViewTextBoxColumn1";
            totalHoursTodayDataGridViewTextBoxColumn1.ReadOnly = true;
            totalHoursTodayDataGridViewTextBoxColumn1.Visible = false;
            totalHoursTodayDataGridViewTextBoxColumn1.Width = 125;
            // 
            // positionIdDataGridViewTextBoxColumn1
            // 
            positionIdDataGridViewTextBoxColumn1.DataPropertyName = "PositionId";
            positionIdDataGridViewTextBoxColumn1.HeaderText = "PositionId";
            positionIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            positionIdDataGridViewTextBoxColumn1.Name = "positionIdDataGridViewTextBoxColumn1";
            positionIdDataGridViewTextBoxColumn1.ReadOnly = true;
            positionIdDataGridViewTextBoxColumn1.Visible = false;
            positionIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // positionDataGridViewTextBoxColumn1
            // 
            positionDataGridViewTextBoxColumn1.DataPropertyName = "Position";
            positionDataGridViewTextBoxColumn1.HeaderText = "Position";
            positionDataGridViewTextBoxColumn1.MinimumWidth = 6;
            positionDataGridViewTextBoxColumn1.Name = "positionDataGridViewTextBoxColumn1";
            positionDataGridViewTextBoxColumn1.ReadOnly = true;
            positionDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dgvPickEmployeeBindingSource
            // 
            dgvPickEmployeeBindingSource.DataSource = typeof(Data.DTO.EmployeeDto);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(cmbPosition);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lblSearchEmployee);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(20, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(20);
            groupBox1.Size = new Size(1293, 125);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chọn nhân viên phân ca";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1148, 53);
            button1.Name = "button1";
            button1.Size = new Size(122, 42);
            button1.TabIndex = 7;
            button1.Text = "Làm mới";
            button1.UseVisualStyleBackColor = false;
            // 
            // cmbPosition
            // 
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(847, 58);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(275, 36);
            cmbPosition.TabIndex = 4;
            cmbPosition.SelectedIndexChanged += cmbPosition_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(717, 66);
            label1.Name = "label1";
            label1.Size = new Size(106, 28);
            label1.TabIndex = 3;
            label1.Text = "Chọn vị trí:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(205, 58);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên nhân viên";
            textBox1.Size = new Size(290, 34);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // lblSearchEmployee
            // 
            lblSearchEmployee.AutoSize = true;
            lblSearchEmployee.Dock = DockStyle.Left;
            lblSearchEmployee.ForeColor = Color.Silver;
            lblSearchEmployee.Location = new Point(20, 47);
            lblSearchEmployee.Margin = new Padding(0);
            lblSearchEmployee.Name = "lblSearchEmployee";
            lblSearchEmployee.Padding = new Padding(10);
            lblSearchEmployee.Size = new Size(157, 48);
            lblSearchEmployee.TabIndex = 0;
            lblSearchEmployee.Text = "Tìm nhân viên:";
            // 
            // assignmentTitleLabel
            // 
            assignmentTitleLabel.AutoSize = true;
            assignmentTitleLabel.Dock = DockStyle.Top;
            assignmentTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            assignmentTitleLabel.ForeColor = Color.FromArgb(52, 152, 219);
            assignmentTitleLabel.Location = new Point(46, 40);
            assignmentTitleLabel.Name = "assignmentTitleLabel";
            assignmentTitleLabel.Padding = new Padding(0, 27, 0, 0);
            assignmentTitleLabel.Size = new Size(379, 68);
            assignmentTitleLabel.TabIndex = 0;
            assignmentTitleLabel.Text = "👥 Phân ca cho nhân viên";
            // 
            // buttonPanel
            // 
            buttonPanel.BackColor = Color.FromArgb(248, 249, 250);
            buttonPanel.Controls.Add(label2);
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(saveButton);
            buttonPanel.Controls.Add(createShiftOnlyCheckBox);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Location = new Point(0, 846);
            buttonPanel.Margin = new Padding(3, 4, 3, 4);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(46, 27, 46, 27);
            buttonPanel.Size = new Size(1531, 107);
            buttonPanel.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.BackColor = Color.FromArgb(108, 117, 125);
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(1104, 33);
            cancelButton.Margin = new Padding(3, 4, 3, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(137, 53);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "❌ Hủy";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveButton.BackColor = Color.FromArgb(52, 152, 219);
            saveButton.Cursor = Cursors.Hand;
            saveButton.Enabled = false;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(1383, 33);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(137, 53);
            saveButton.TabIndex = 1;
            saveButton.Text = "💾 Lưu";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += SaveButton_Click;
            // 
            // createShiftOnlyCheckBox
            // 
            createShiftOnlyCheckBox.AutoSize = true;
            createShiftOnlyCheckBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            createShiftOnlyCheckBox.ForeColor = Color.FromArgb(52, 58, 64);
            createShiftOnlyCheckBox.Location = new Point(46, 40);
            createShiftOnlyCheckBox.Margin = new Padding(3, 4, 3, 4);
            createShiftOnlyCheckBox.Name = "createShiftOnlyCheckBox";
            createShiftOnlyCheckBox.Size = new Size(335, 29);
            createShiftOnlyCheckBox.TabIndex = 0;
            createShiftOnlyCheckBox.Text = "🔧 Chỉ tạo ca làm (không phân ca)";
            createShiftOnlyCheckBox.UseVisualStyleBackColor = true;
            createShiftOnlyCheckBox.CheckedChanged += CreateShiftOnlyCheckBox_CheckedChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ShiftManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Controls.Add(buttonPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ShiftManagementControl";
            Size = new Size(1531, 953);
            headerPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            shiftInfoTab.ResumeLayout(false);
            shiftInfoPanel.ResumeLayout(false);
            shiftInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)expectedHoursNumeric).EndInit();
            assignmentTab.ResumeLayout(false);
            assignmentPanel.ResumeLayout(false);
            assignmentPanel.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSelectedEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSelectedEmployeeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPickEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPickEmployeeBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage shiftInfoTab;
        private System.Windows.Forms.Panel shiftInfoPanel;
        private System.Windows.Forms.Label shiftInfoTitleLabel;
        private System.Windows.Forms.TextBox shiftNameTextBox;
        private System.Windows.Forms.Label shiftNameLabel;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.NumericUpDown expectedHoursNumeric;
        private System.Windows.Forms.Label expectedHoursLabel;
        private System.Windows.Forms.ComboBox shiftTypeComboBox;
        private System.Windows.Forms.Label shiftTypeLabel;
        private System.Windows.Forms.TabPage assignmentTab;
        private System.Windows.Forms.Panel assignmentPanel;
        private System.Windows.Forms.Label assignmentTitleLabel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.CheckBox createShiftOnlyCheckBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private BindingSource dgvPickEmployeeBindingSource;
        private Panel panel1;
        private GroupBox groupBox1;
        private Button btnRefresh;
        private TextBox textBox1;
        private Label lblSearchEmployee;
        private Panel panel2;
        private DataGridView dgvSelectedEmployee;
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
        private BindingSource dgvSelectedEmployeeBindingSource;
        private DataGridView dgvPickEmployee;
        private Button removeEmployeeBtn;
        private Button addEmployeeBtn;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dateOfBirthDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn hireDateDataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn maxHoursPerDayDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn maxHoursPerMonthDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn totalHoursThisMonthDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn totalHoursTodayDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn positionIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn1;
        private Label label1;
        private Button button1;
        private ComboBox cmbPosition;
        private Button removeAllEmployee;
        private Button addAllEmployeeBtn;
        private Label label3;
        private MonthCalendar datePicker;
        private TextBox dateTextBox;
        private Label label2;
        private ErrorProvider errorProvider1;
    }
}