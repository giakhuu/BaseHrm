namespace BaseHrm.Controls
{
    partial class AttendanceManagementControl
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
                
                // Cleanup custom timer
                try
                {
                    if (this is AttendanceManagementControl control)
                    {
                        var timerField = this.GetType().GetField("_dateChangeTimer", 
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (timerField?.GetValue(this) is System.Windows.Forms.Timer timer)
                        {
                            timer?.Stop();
                            timer?.Dispose();
                        }
                        
                        var cacheField = this.GetType().GetField("_permCache", 
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (cacheField?.GetValue(this) is System.Collections.IDictionary cache)
                        {
                            cache?.Clear();
                        }
                    }
                }
                catch
                {
                    // Ignore cleanup errors
                }
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
            button3 = new Button();
            lblTitle = new Label();
            btnAddRecord = new Button();
            btnExportData = new Button();
            btnRefresh = new Button();
            panelSummary = new Panel();
            tableLayoutSummary = new TableLayoutPanel();
            cardTotalRecords = new Panel();
            lblTotalRecordsValue = new Label();
            lblTotalRecordsTitle = new Label();
            iconTotalRecords = new Label();
            cardTotalHours = new Panel();
            lblTotalHoursValue = new Label();
            lblTotalHoursTitle = new Label();
            iconTotalHours = new Label();
            cardOvertimeHours = new Panel();
            lblOvertimeHoursValue = new Label();
            lblOvertimeHoursTitle = new Label();
            iconOvertimeHours = new Label();
            cardActiveEmployees = new Panel();
            lblActiveEmployeesValue = new Label();
            lblActiveEmployeesTitle = new Label();
            iconActiveEmployees = new Label();
            cardAvgHours = new Panel();
            lblAvgHoursValue = new Label();
            lblAvgHoursTitle = new Label();
            iconAvgHours = new Label();
            cardPendingCheckouts = new Panel();
            lblPendingCheckoutsValue = new Label();
            lblPendingCheckoutsTitle = new Label();
            iconPendingCheckouts = new Label();
            panelFilters = new Panel();
            groupBoxFilters = new GroupBox();
            button2 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            lblDateRange = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            lblEmployeeSearch = new Label();
            txtEmployeeSearch = new TextBox();
            lblShiftFilter = new Label();
            cmbShiftFilter = new ComboBox();
            lblStatusFilter = new Label();
            cmbStatusFilter = new ComboBox();
            btnApplyFilters = new Button();
            btnClearFilters = new Button();
            panelMain = new Panel();
            dgvAttendance = new DataGridView();
            attendanceRecordIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            positionNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            checkInDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftStartDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            checkOutDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftEndDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            durationHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            validDurationHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            validDurationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isOvertimeDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            shiftAssignmentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftTypeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftTypeNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            payMultiplierDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            contextMenuAttendance = new ContextMenuStrip(components);
            menuItemViewDetails = new ToolStripMenuItem();
            menuItemDelete = new ToolStripMenuItem();
            attendanceRecordDtoBindingSource = new BindingSource(components);
            panelStatus = new Panel();
            lblStatus = new Label();
            lblRecordCount = new Label();
            progressBar = new ProgressBar();
            txtTeamSearch = new TextBox();
            button4 = new Button();
            panelHeader.SuspendLayout();
            panelSummary.SuspendLayout();
            tableLayoutSummary.SuspendLayout();
            cardTotalRecords.SuspendLayout();
            cardTotalHours.SuspendLayout();
            cardOvertimeHours.SuspendLayout();
            cardActiveEmployees.SuspendLayout();
            cardAvgHours.SuspendLayout();
            cardPendingCheckouts.SuspendLayout();
            panelFilters.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            contextMenuAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)attendanceRecordDtoBindingSource).BeginInit();
            panelStatus.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(33, 37, 41);
            panelHeader.Controls.Add(button4);
            panelHeader.Controls.Add(button3);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnAddRecord);
            panelHeader.Controls.Add(btnExportData);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1600, 107);
            panelHeader.TabIndex = 0;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(0, 123, 255);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 86, 179);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(1062, 27);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(114, 60);
            button3.TabIndex = 4;
            button3.Text = "📊 Lưu trữ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(398, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "⏰ Quản Lý Chấm Công";
            // 
            // btnAddRecord
            // 
            btnAddRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddRecord.BackColor = Color.FromArgb(40, 167, 69);
            btnAddRecord.FlatAppearance.BorderSize = 0;
            btnAddRecord.FlatAppearance.MouseOverBackColor = Color.FromArgb(33, 136, 56);
            btnAddRecord.FlatStyle = FlatStyle.Flat;
            btnAddRecord.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddRecord.ForeColor = Color.White;
            btnAddRecord.Location = new Point(1189, 27);
            btnAddRecord.Margin = new Padding(3, 4, 3, 4);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(137, 60);
            btnAddRecord.TabIndex = 1;
            btnAddRecord.Text = "➕ Thêm Mới";
            btnAddRecord.UseVisualStyleBackColor = false;
            btnAddRecord.Click += btnAddRecord_Click;
            // 
            // btnExportData
            // 
            btnExportData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportData.BackColor = Color.FromArgb(0, 123, 255);
            btnExportData.FlatAppearance.BorderSize = 0;
            btnExportData.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 86, 179);
            btnExportData.FlatStyle = FlatStyle.Flat;
            btnExportData.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExportData.ForeColor = Color.White;
            btnExportData.Location = new Point(1337, 27);
            btnExportData.Margin = new Padding(3, 4, 3, 4);
            btnExportData.Name = "btnExportData";
            btnExportData.Size = new Size(114, 60);
            btnExportData.TabIndex = 2;
            btnExportData.Text = "📊 Xuất";
            btnExportData.UseVisualStyleBackColor = false;
            btnExportData.Click += btnExportData_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 98, 104);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1463, 27);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 60);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "🔄 Làm Mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.FromArgb(248, 249, 250);
            panelSummary.Controls.Add(tableLayoutSummary);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(0, 107);
            panelSummary.Margin = new Padding(3, 4, 3, 4);
            panelSummary.Name = "panelSummary";
            panelSummary.Padding = new Padding(23, 20, 23, 20);
            panelSummary.Size = new Size(1600, 187);
            panelSummary.TabIndex = 1;
            // 
            // tableLayoutSummary
            // 
            tableLayoutSummary.ColumnCount = 6;
            tableLayoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutSummary.Controls.Add(cardTotalRecords, 0, 0);
            tableLayoutSummary.Controls.Add(cardTotalHours, 1, 0);
            tableLayoutSummary.Controls.Add(cardOvertimeHours, 2, 0);
            tableLayoutSummary.Controls.Add(cardActiveEmployees, 3, 0);
            tableLayoutSummary.Controls.Add(cardAvgHours, 4, 0);
            tableLayoutSummary.Controls.Add(cardPendingCheckouts, 5, 0);
            tableLayoutSummary.Dock = DockStyle.Fill;
            tableLayoutSummary.Location = new Point(23, 20);
            tableLayoutSummary.Margin = new Padding(3, 4, 3, 4);
            tableLayoutSummary.Name = "tableLayoutSummary";
            tableLayoutSummary.RowCount = 1;
            tableLayoutSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutSummary.Size = new Size(1554, 147);
            tableLayoutSummary.TabIndex = 0;
            // 
            // cardTotalRecords
            // 
            cardTotalRecords.BackColor = Color.White;
            cardTotalRecords.BorderStyle = BorderStyle.FixedSingle;
            cardTotalRecords.Controls.Add(lblTotalRecordsValue);
            cardTotalRecords.Controls.Add(lblTotalRecordsTitle);
            cardTotalRecords.Controls.Add(iconTotalRecords);
            cardTotalRecords.Dock = DockStyle.Fill;
            cardTotalRecords.Location = new Point(3, 4);
            cardTotalRecords.Margin = new Padding(3, 4, 3, 4);
            cardTotalRecords.Name = "cardTotalRecords";
            cardTotalRecords.Padding = new Padding(17, 20, 17, 20);
            cardTotalRecords.Size = new Size(253, 139);
            cardTotalRecords.TabIndex = 0;
            // 
            // lblTotalRecordsValue
            // 
            lblTotalRecordsValue.AutoSize = true;
            lblTotalRecordsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalRecordsValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotalRecordsValue.Location = new Point(17, 60);
            lblTotalRecordsValue.Name = "lblTotalRecordsValue";
            lblTotalRecordsValue.Size = new Size(35, 41);
            lblTotalRecordsValue.TabIndex = 1;
            lblTotalRecordsValue.Text = "0";
            // 
            // lblTotalRecordsTitle
            // 
            lblTotalRecordsTitle.AutoSize = true;
            lblTotalRecordsTitle.Font = new Font("Segoe UI", 10F);
            lblTotalRecordsTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblTotalRecordsTitle.Location = new Point(17, 20);
            lblTotalRecordsTitle.Name = "lblTotalRecordsTitle";
            lblTotalRecordsTitle.Size = new Size(114, 23);
            lblTotalRecordsTitle.TabIndex = 0;
            lblTotalRecordsTitle.Text = "Tổng Bản Ghi";
            // 
            // iconTotalRecords
            // 
            iconTotalRecords.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconTotalRecords.AutoSize = true;
            iconTotalRecords.Font = new Font("Segoe UI", 24F);
            iconTotalRecords.ForeColor = Color.FromArgb(40, 167, 69);
            iconTotalRecords.Location = new Point(174, 47);
            iconTotalRecords.Name = "iconTotalRecords";
            iconTotalRecords.Size = new Size(78, 54);
            iconTotalRecords.TabIndex = 2;
            iconTotalRecords.Text = "📋";
            // 
            // cardTotalHours
            // 
            cardTotalHours.BackColor = Color.White;
            cardTotalHours.BorderStyle = BorderStyle.FixedSingle;
            cardTotalHours.Controls.Add(lblTotalHoursValue);
            cardTotalHours.Controls.Add(lblTotalHoursTitle);
            cardTotalHours.Controls.Add(iconTotalHours);
            cardTotalHours.Dock = DockStyle.Fill;
            cardTotalHours.Location = new Point(262, 4);
            cardTotalHours.Margin = new Padding(3, 4, 3, 4);
            cardTotalHours.Name = "cardTotalHours";
            cardTotalHours.Padding = new Padding(17, 20, 17, 20);
            cardTotalHours.Size = new Size(253, 139);
            cardTotalHours.TabIndex = 1;
            // 
            // lblTotalHoursValue
            // 
            lblTotalHoursValue.AutoSize = true;
            lblTotalHoursValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalHoursValue.ForeColor = Color.FromArgb(0, 123, 255);
            lblTotalHoursValue.Location = new Point(17, 60);
            lblTotalHoursValue.Name = "lblTotalHoursValue";
            lblTotalHoursValue.Size = new Size(35, 41);
            lblTotalHoursValue.TabIndex = 1;
            lblTotalHoursValue.Text = "0";
            // 
            // lblTotalHoursTitle
            // 
            lblTotalHoursTitle.AutoSize = true;
            lblTotalHoursTitle.Font = new Font("Segoe UI", 10F);
            lblTotalHoursTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblTotalHoursTitle.Location = new Point(17, 20);
            lblTotalHoursTitle.Name = "lblTotalHoursTitle";
            lblTotalHoursTitle.Size = new Size(126, 23);
            lblTotalHoursTitle.TabIndex = 0;
            lblTotalHoursTitle.Text = "Tổng Giờ Công";
            // 
            // iconTotalHours
            // 
            iconTotalHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconTotalHours.AutoSize = true;
            iconTotalHours.Font = new Font("Segoe UI", 24F);
            iconTotalHours.ForeColor = Color.FromArgb(0, 123, 255);
            iconTotalHours.Location = new Point(174, 47);
            iconTotalHours.Name = "iconTotalHours";
            iconTotalHours.Size = new Size(78, 54);
            iconTotalHours.TabIndex = 2;
            iconTotalHours.Text = "⏱️";
            // 
            // cardOvertimeHours
            // 
            cardOvertimeHours.BackColor = Color.White;
            cardOvertimeHours.BorderStyle = BorderStyle.FixedSingle;
            cardOvertimeHours.Controls.Add(lblOvertimeHoursValue);
            cardOvertimeHours.Controls.Add(lblOvertimeHoursTitle);
            cardOvertimeHours.Controls.Add(iconOvertimeHours);
            cardOvertimeHours.Dock = DockStyle.Fill;
            cardOvertimeHours.Location = new Point(521, 4);
            cardOvertimeHours.Margin = new Padding(3, 4, 3, 4);
            cardOvertimeHours.Name = "cardOvertimeHours";
            cardOvertimeHours.Padding = new Padding(17, 20, 17, 20);
            cardOvertimeHours.Size = new Size(253, 139);
            cardOvertimeHours.TabIndex = 2;
            // 
            // lblOvertimeHoursValue
            // 
            lblOvertimeHoursValue.AutoSize = true;
            lblOvertimeHoursValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblOvertimeHoursValue.ForeColor = Color.FromArgb(255, 193, 7);
            lblOvertimeHoursValue.Location = new Point(17, 60);
            lblOvertimeHoursValue.Name = "lblOvertimeHoursValue";
            lblOvertimeHoursValue.Size = new Size(35, 41);
            lblOvertimeHoursValue.TabIndex = 1;
            lblOvertimeHoursValue.Text = "0";
            // 
            // lblOvertimeHoursTitle
            // 
            lblOvertimeHoursTitle.AutoSize = true;
            lblOvertimeHoursTitle.Font = new Font("Segoe UI", 10F);
            lblOvertimeHoursTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblOvertimeHoursTitle.Location = new Point(17, 20);
            lblOvertimeHoursTitle.Name = "lblOvertimeHoursTitle";
            lblOvertimeHoursTitle.Size = new Size(121, 23);
            lblOvertimeHoursTitle.TabIndex = 0;
            lblOvertimeHoursTitle.Text = "Giờ Làm Thêm";
            // 
            // iconOvertimeHours
            // 
            iconOvertimeHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconOvertimeHours.AutoSize = true;
            iconOvertimeHours.Font = new Font("Segoe UI", 24F);
            iconOvertimeHours.ForeColor = Color.FromArgb(255, 193, 7);
            iconOvertimeHours.Location = new Point(153, 47);
            iconOvertimeHours.Name = "iconOvertimeHours";
            iconOvertimeHours.Size = new Size(78, 54);
            iconOvertimeHours.TabIndex = 2;
            iconOvertimeHours.Text = "⚡";
            // 
            // cardActiveEmployees
            // 
            cardActiveEmployees.BackColor = Color.White;
            cardActiveEmployees.BorderStyle = BorderStyle.FixedSingle;
            cardActiveEmployees.Controls.Add(lblActiveEmployeesValue);
            cardActiveEmployees.Controls.Add(lblActiveEmployeesTitle);
            cardActiveEmployees.Controls.Add(iconActiveEmployees);
            cardActiveEmployees.Dock = DockStyle.Fill;
            cardActiveEmployees.Location = new Point(780, 4);
            cardActiveEmployees.Margin = new Padding(3, 4, 3, 4);
            cardActiveEmployees.Name = "cardActiveEmployees";
            cardActiveEmployees.Padding = new Padding(17, 20, 17, 20);
            cardActiveEmployees.Size = new Size(253, 139);
            cardActiveEmployees.TabIndex = 3;
            // 
            // lblActiveEmployeesValue
            // 
            lblActiveEmployeesValue.AutoSize = true;
            lblActiveEmployeesValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblActiveEmployeesValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblActiveEmployeesValue.Location = new Point(17, 60);
            lblActiveEmployeesValue.Name = "lblActiveEmployeesValue";
            lblActiveEmployeesValue.Size = new Size(35, 41);
            lblActiveEmployeesValue.TabIndex = 1;
            lblActiveEmployeesValue.Text = "0";
            // 
            // lblActiveEmployeesTitle
            // 
            lblActiveEmployeesTitle.AutoSize = true;
            lblActiveEmployeesTitle.Font = new Font("Segoe UI", 10F);
            lblActiveEmployeesTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblActiveEmployeesTitle.Location = new Point(17, 20);
            lblActiveEmployeesTitle.Name = "lblActiveEmployeesTitle";
            lblActiveEmployeesTitle.Size = new Size(154, 23);
            lblActiveEmployeesTitle.TabIndex = 0;
            lblActiveEmployeesTitle.Text = "NV Đang Làm Việc";
            // 
            // iconActiveEmployees
            // 
            iconActiveEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconActiveEmployees.AutoSize = true;
            iconActiveEmployees.Font = new Font("Segoe UI", 24F);
            iconActiveEmployees.ForeColor = Color.FromArgb(220, 53, 69);
            iconActiveEmployees.Location = new Point(153, 50);
            iconActiveEmployees.Name = "iconActiveEmployees";
            iconActiveEmployees.Size = new Size(78, 54);
            iconActiveEmployees.TabIndex = 2;
            iconActiveEmployees.Text = "👥";
            // 
            // cardAvgHours
            // 
            cardAvgHours.BackColor = Color.White;
            cardAvgHours.BorderStyle = BorderStyle.FixedSingle;
            cardAvgHours.Controls.Add(lblAvgHoursValue);
            cardAvgHours.Controls.Add(lblAvgHoursTitle);
            cardAvgHours.Controls.Add(iconAvgHours);
            cardAvgHours.Dock = DockStyle.Fill;
            cardAvgHours.Location = new Point(1039, 4);
            cardAvgHours.Margin = new Padding(3, 4, 3, 4);
            cardAvgHours.Name = "cardAvgHours";
            cardAvgHours.Padding = new Padding(17, 20, 17, 20);
            cardAvgHours.Size = new Size(253, 139);
            cardAvgHours.TabIndex = 4;
            // 
            // lblAvgHoursValue
            // 
            lblAvgHoursValue.AutoSize = true;
            lblAvgHoursValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAvgHoursValue.ForeColor = Color.FromArgb(111, 66, 193);
            lblAvgHoursValue.Location = new Point(17, 60);
            lblAvgHoursValue.Name = "lblAvgHoursValue";
            lblAvgHoursValue.Size = new Size(35, 41);
            lblAvgHoursValue.TabIndex = 1;
            lblAvgHoursValue.Text = "0";
            // 
            // lblAvgHoursTitle
            // 
            lblAvgHoursTitle.AutoSize = true;
            lblAvgHoursTitle.Font = new Font("Segoe UI", 10F);
            lblAvgHoursTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblAvgHoursTitle.Location = new Point(17, 20);
            lblAvgHoursTitle.Name = "lblAvgHoursTitle";
            lblAvgHoursTitle.Size = new Size(148, 23);
            lblAvgHoursTitle.TabIndex = 0;
            lblAvgHoursTitle.Text = "TB Giờ/Nhân Viên";
            // 
            // iconAvgHours
            // 
            iconAvgHours.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconAvgHours.AutoSize = true;
            iconAvgHours.Font = new Font("Segoe UI", 24F);
            iconAvgHours.ForeColor = Color.FromArgb(111, 66, 193);
            iconAvgHours.Location = new Point(174, 47);
            iconAvgHours.Name = "iconAvgHours";
            iconAvgHours.Size = new Size(78, 54);
            iconAvgHours.TabIndex = 2;
            iconAvgHours.Text = "📊";
            // 
            // cardPendingCheckouts
            // 
            cardPendingCheckouts.BackColor = Color.White;
            cardPendingCheckouts.BorderStyle = BorderStyle.FixedSingle;
            cardPendingCheckouts.Controls.Add(lblPendingCheckoutsValue);
            cardPendingCheckouts.Controls.Add(lblPendingCheckoutsTitle);
            cardPendingCheckouts.Controls.Add(iconPendingCheckouts);
            cardPendingCheckouts.Dock = DockStyle.Fill;
            cardPendingCheckouts.Location = new Point(1298, 4);
            cardPendingCheckouts.Margin = new Padding(3, 4, 3, 4);
            cardPendingCheckouts.Name = "cardPendingCheckouts";
            cardPendingCheckouts.Padding = new Padding(17, 20, 17, 20);
            cardPendingCheckouts.Size = new Size(253, 139);
            cardPendingCheckouts.TabIndex = 5;
            // 
            // lblPendingCheckoutsValue
            // 
            lblPendingCheckoutsValue.AutoSize = true;
            lblPendingCheckoutsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPendingCheckoutsValue.ForeColor = Color.FromArgb(255, 99, 132);
            lblPendingCheckoutsValue.Location = new Point(17, 60);
            lblPendingCheckoutsValue.Name = "lblPendingCheckoutsValue";
            lblPendingCheckoutsValue.Size = new Size(35, 41);
            lblPendingCheckoutsValue.TabIndex = 1;
            lblPendingCheckoutsValue.Text = "0";
            // 
            // lblPendingCheckoutsTitle
            // 
            lblPendingCheckoutsTitle.AutoSize = true;
            lblPendingCheckoutsTitle.Font = new Font("Segoe UI", 10F);
            lblPendingCheckoutsTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblPendingCheckoutsTitle.Location = new Point(17, 20);
            lblPendingCheckoutsTitle.Name = "lblPendingCheckoutsTitle";
            lblPendingCheckoutsTitle.Size = new Size(135, 23);
            lblPendingCheckoutsTitle.TabIndex = 0;
            lblPendingCheckoutsTitle.Text = "Chưa Check Out";
            // 
            // iconPendingCheckouts
            // 
            iconPendingCheckouts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPendingCheckouts.AutoSize = true;
            iconPendingCheckouts.Font = new Font("Segoe UI", 24F);
            iconPendingCheckouts.ForeColor = Color.FromArgb(255, 99, 132);
            iconPendingCheckouts.Location = new Point(174, 47);
            iconPendingCheckouts.Name = "iconPendingCheckouts";
            iconPendingCheckouts.Size = new Size(78, 54);
            iconPendingCheckouts.TabIndex = 2;
            iconPendingCheckouts.Text = "⚠️";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.FromArgb(248, 249, 250);
            panelFilters.Controls.Add(groupBoxFilters);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new Point(0, 294);
            panelFilters.Margin = new Padding(3, 4, 3, 4);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(23, 13, 23, 13);
            panelFilters.Size = new Size(1600, 160);
            panelFilters.TabIndex = 2;
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.BackColor = Color.White;
            groupBoxFilters.Controls.Add(button2);
            groupBoxFilters.Controls.Add(label3);
            groupBoxFilters.Controls.Add(textBox1);
            groupBoxFilters.Controls.Add(button1);
            groupBoxFilters.Controls.Add(lblDateRange);
            groupBoxFilters.Controls.Add(dtpFromDate);
            groupBoxFilters.Controls.Add(lblToDate);
            groupBoxFilters.Controls.Add(dtpToDate);
            groupBoxFilters.Controls.Add(lblEmployeeSearch);
            groupBoxFilters.Controls.Add(txtEmployeeSearch);
            groupBoxFilters.Controls.Add(lblShiftFilter);
            groupBoxFilters.Controls.Add(cmbShiftFilter);
            groupBoxFilters.Controls.Add(lblStatusFilter);
            groupBoxFilters.Controls.Add(cmbStatusFilter);
            groupBoxFilters.Controls.Add(btnApplyFilters);
            groupBoxFilters.Controls.Add(btnClearFilters);
            groupBoxFilters.Dock = DockStyle.Fill;
            groupBoxFilters.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxFilters.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxFilters.Location = new Point(23, 13);
            groupBoxFilters.Margin = new Padding(3, 4, 3, 4);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(23, 27, 23, 27);
            groupBoxFilters.Size = new Size(1554, 134);
            groupBoxFilters.TabIndex = 0;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "🔍 Tìm Kiếm & Lọc";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 123, 255);
            button2.FlatAppearance.BorderSize = 0;
            button2.ForeColor = Color.White;
            button2.Location = new Point(974, 93);
            button2.Name = "button2";
            button2.Size = new Size(199, 32);
            button2.TabIndex = 16;
            button2.Text = "Chọn team";
            button2.UseVisualStyleBackColor = false;
            button2.Click += txtTeamSearch_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(85, 85, 85);
            label3.Location = new Point(622, 96);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 14;
            label3.Text = "Team:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(740, 93);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Chọn team";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(228, 30);
            textBox1.TabIndex = 15;
            textBox1.Click += txtTeamSearch_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 123, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.White;
            button1.Location = new Point(375, 90);
            button1.Name = "button1";
            button1.Size = new Size(199, 32);
            button1.TabIndex = 13;
            button1.Text = "Chọn nhân viên";
            button1.UseVisualStyleBackColor = false;
            button1.Click += txtEmployeeSearch_Click;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Segoe UI", 10F);
            lblDateRange.ForeColor = Color.FromArgb(85, 85, 85);
            lblDateRange.Location = new Point(23, 47);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(75, 23);
            lblDateRange.TabIndex = 0;
            lblDateRange.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Font = new Font("Segoe UI", 10F);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(104, 47);
            dtpFromDate.Margin = new Padding(3, 4, 3, 4);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(137, 30);
            dtpFromDate.TabIndex = 1;
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Font = new Font("Segoe UI", 10F);
            lblToDate.ForeColor = Color.FromArgb(85, 85, 85);
            lblToDate.Location = new Point(311, 52);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(87, 23);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Font = new Font("Segoe UI", 10F);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(437, 47);
            dtpToDate.Margin = new Padding(3, 4, 3, 4);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(137, 30);
            dtpToDate.TabIndex = 3;
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            // 
            // lblEmployeeSearch
            // 
            lblEmployeeSearch.AutoSize = true;
            lblEmployeeSearch.Font = new Font("Segoe UI", 10F);
            lblEmployeeSearch.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeSearch.Location = new Point(23, 93);
            lblEmployeeSearch.Name = "lblEmployeeSearch";
            lblEmployeeSearch.Size = new Size(92, 23);
            lblEmployeeSearch.TabIndex = 4;
            lblEmployeeSearch.Text = "Nhân viên:";
            // 
            // txtEmployeeSearch
            // 
            txtEmployeeSearch.Font = new Font("Segoe UI", 10F);
            txtEmployeeSearch.Location = new Point(141, 90);
            txtEmployeeSearch.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeSearch.Name = "txtEmployeeSearch";
            txtEmployeeSearch.PlaceholderText = "Chọn nhân viên";
            txtEmployeeSearch.ReadOnly = true;
            txtEmployeeSearch.Size = new Size(228, 30);
            txtEmployeeSearch.TabIndex = 5;
            txtEmployeeSearch.Click += txtEmployeeSearch_Click;
            // 
            // lblShiftFilter
            // 
            lblShiftFilter.AutoSize = true;
            lblShiftFilter.Font = new Font("Segoe UI", 10F);
            lblShiftFilter.ForeColor = Color.FromArgb(85, 85, 85);
            lblShiftFilter.Location = new Point(631, 50);
            lblShiftFilter.Name = "lblShiftFilter";
            lblShiftFilter.Size = new Size(67, 23);
            lblShiftFilter.TabIndex = 6;
            lblShiftFilter.Text = "Loại ca:";
            lblShiftFilter.Click += lblShiftFilter_Click;
            // 
            // cmbShiftFilter
            // 
            cmbShiftFilter.DisplayMember = "--Chọn ca";
            cmbShiftFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShiftFilter.Font = new Font("Segoe UI", 10F);
            cmbShiftFilter.FormattingEnabled = true;
            cmbShiftFilter.Location = new Point(740, 46);
            cmbShiftFilter.Margin = new Padding(3, 4, 3, 4);
            cmbShiftFilter.Name = "cmbShiftFilter";
            cmbShiftFilter.Size = new Size(189, 31);
            cmbShiftFilter.TabIndex = 7;
            cmbShiftFilter.ValueMember = "--Chọn ca";
            cmbShiftFilter.SelectedIndexChanged += cmbShiftFilter_SelectedIndexChanged;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 10F);
            lblStatusFilter.ForeColor = Color.FromArgb(85, 85, 85);
            lblStatusFilter.Location = new Point(942, 53);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(91, 23);
            lblStatusFilter.TabIndex = 8;
            lblStatusFilter.Text = "Trạng thái:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "Tất cả", "Chưa CheckOut", "Đã CheckOut" });
            cmbStatusFilter.Location = new Point(1039, 50);
            cmbStatusFilter.Margin = new Padding(3, 4, 3, 4);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(185, 31);
            cmbStatusFilter.TabIndex = 9;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnApplyFilters.BackColor = Color.FromArgb(0, 123, 255);
            btnApplyFilters.FlatAppearance.BorderSize = 0;
            btnApplyFilters.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 86, 179);
            btnApplyFilters.FlatStyle = FlatStyle.Flat;
            btnApplyFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApplyFilters.ForeColor = Color.White;
            btnApplyFilters.Location = new Point(1258, 41);
            btnApplyFilters.Margin = new Padding(3, 4, 3, 4);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(103, 47);
            btnApplyFilters.TabIndex = 11;
            btnApplyFilters.Text = "🔍 Lọc";
            btnApplyFilters.UseVisualStyleBackColor = false;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearFilters.BackColor = Color.FromArgb(108, 117, 125);
            btnClearFilters.FlatAppearance.BorderSize = 0;
            btnClearFilters.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 98, 104);
            btnClearFilters.FlatStyle = FlatStyle.Flat;
            btnClearFilters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClearFilters.ForeColor = Color.White;
            btnClearFilters.Location = new Point(1398, 41);
            btnClearFilters.Margin = new Padding(3, 4, 3, 4);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(103, 47);
            btnClearFilters.TabIndex = 12;
            btnClearFilters.Text = "🗑️ Xóa";
            btnClearFilters.UseVisualStyleBackColor = false;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(dgvAttendance);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 454);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(23, 27, 23, 27);
            panelMain.Size = new Size(1600, 413);
            panelMain.TabIndex = 3;
            // 
            // dgvAttendance
            // 
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.AutoGenerateColumns = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BackgroundColor = Color.White;
            dgvAttendance.BorderStyle = BorderStyle.None;
            dgvAttendance.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Columns.AddRange(new DataGridViewColumn[] { attendanceRecordIdDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, positionNameDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, checkInDataGridViewTextBoxColumn, shiftStartDataGridViewTextBoxColumn, checkOutDataGridViewTextBoxColumn, shiftEndDataGridViewTextBoxColumn, durationHoursDataGridViewTextBoxColumn, validDurationHoursDataGridViewTextBoxColumn, validDurationDataGridViewTextBoxColumn, isOvertimeDataGridViewCheckBoxColumn, shiftAssignmentIdDataGridViewTextBoxColumn, shiftDateDataGridViewTextBoxColumn, shiftIdDataGridViewTextBoxColumn, shiftNameDataGridViewTextBoxColumn, shiftTypeIdDataGridViewTextBoxColumn, shiftTypeNameDataGridViewTextBoxColumn, payMultiplierDataGridViewTextBoxColumn });
            dgvAttendance.ContextMenuStrip = contextMenuAttendance;
            dgvAttendance.DataSource = attendanceRecordDtoBindingSource;
            dgvAttendance.Dock = DockStyle.Fill;
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.GridColor = Color.FromArgb(233, 236, 239);
            dgvAttendance.Location = new Point(23, 27);
            dgvAttendance.Margin = new Padding(3, 4, 3, 4);
            dgvAttendance.MultiSelect = false;
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.RowHeadersWidth = 51;
            dgvAttendance.RowTemplate.Height = 40;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Size = new Size(1554, 359);
            dgvAttendance.TabIndex = 0;
            // 
            // attendanceRecordIdDataGridViewTextBoxColumn
            // 
            attendanceRecordIdDataGridViewTextBoxColumn.DataPropertyName = "AttendanceRecordId";
            attendanceRecordIdDataGridViewTextBoxColumn.HeaderText = "Mã chấm công";
            attendanceRecordIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            attendanceRecordIdDataGridViewTextBoxColumn.Name = "attendanceRecordIdDataGridViewTextBoxColumn";
            attendanceRecordIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "Mã nhân viên";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "Tên nhân viên";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // positionNameDataGridViewTextBoxColumn
            // 
            positionNameDataGridViewTextBoxColumn.DataPropertyName = "PositionName";
            positionNameDataGridViewTextBoxColumn.HeaderText = "PositionName";
            positionNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            positionNameDataGridViewTextBoxColumn.Name = "positionNameDataGridViewTextBoxColumn";
            positionNameDataGridViewTextBoxColumn.ReadOnly = true;
            positionNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkInDataGridViewTextBoxColumn
            // 
            checkInDataGridViewTextBoxColumn.DataPropertyName = "CheckIn";
            checkInDataGridViewTextBoxColumn.HeaderText = "Giờ vào";
            checkInDataGridViewTextBoxColumn.MinimumWidth = 6;
            checkInDataGridViewTextBoxColumn.Name = "checkInDataGridViewTextBoxColumn";
            checkInDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shiftStartDataGridViewTextBoxColumn
            // 
            shiftStartDataGridViewTextBoxColumn.DataPropertyName = "ShiftStart";
            shiftStartDataGridViewTextBoxColumn.HeaderText = "Ca bắt dầu";
            shiftStartDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftStartDataGridViewTextBoxColumn.Name = "shiftStartDataGridViewTextBoxColumn";
            shiftStartDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkOutDataGridViewTextBoxColumn
            // 
            checkOutDataGridViewTextBoxColumn.DataPropertyName = "CheckOut";
            checkOutDataGridViewTextBoxColumn.HeaderText = "Giờ ra";
            checkOutDataGridViewTextBoxColumn.MinimumWidth = 6;
            checkOutDataGridViewTextBoxColumn.Name = "checkOutDataGridViewTextBoxColumn";
            checkOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shiftEndDataGridViewTextBoxColumn
            // 
            shiftEndDataGridViewTextBoxColumn.DataPropertyName = "ShiftEnd";
            shiftEndDataGridViewTextBoxColumn.HeaderText = "Ca kết thúc";
            shiftEndDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftEndDataGridViewTextBoxColumn.Name = "shiftEndDataGridViewTextBoxColumn";
            shiftEndDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationHoursDataGridViewTextBoxColumn
            // 
            durationHoursDataGridViewTextBoxColumn.DataPropertyName = "DurationHours";
            durationHoursDataGridViewTextBoxColumn.HeaderText = "Thời gian làm";
            durationHoursDataGridViewTextBoxColumn.MinimumWidth = 6;
            durationHoursDataGridViewTextBoxColumn.Name = "durationHoursDataGridViewTextBoxColumn";
            durationHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validDurationHoursDataGridViewTextBoxColumn
            // 
            validDurationHoursDataGridViewTextBoxColumn.DataPropertyName = "ValidDurationHours";
            validDurationHoursDataGridViewTextBoxColumn.HeaderText = "Giờ làm hợp lệ";
            validDurationHoursDataGridViewTextBoxColumn.MinimumWidth = 6;
            validDurationHoursDataGridViewTextBoxColumn.Name = "validDurationHoursDataGridViewTextBoxColumn";
            validDurationHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validDurationDataGridViewTextBoxColumn
            // 
            validDurationDataGridViewTextBoxColumn.DataPropertyName = "ValidDuration";
            validDurationDataGridViewTextBoxColumn.HeaderText = "Tổng giờ làm";
            validDurationDataGridViewTextBoxColumn.MinimumWidth = 6;
            validDurationDataGridViewTextBoxColumn.Name = "validDurationDataGridViewTextBoxColumn";
            validDurationDataGridViewTextBoxColumn.ReadOnly = true;
            validDurationDataGridViewTextBoxColumn.Visible = false;
            // 
            // isOvertimeDataGridViewCheckBoxColumn
            // 
            isOvertimeDataGridViewCheckBoxColumn.DataPropertyName = "IsOvertime";
            isOvertimeDataGridViewCheckBoxColumn.HeaderText = "Tăng ca";
            isOvertimeDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isOvertimeDataGridViewCheckBoxColumn.Name = "isOvertimeDataGridViewCheckBoxColumn";
            isOvertimeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // shiftAssignmentIdDataGridViewTextBoxColumn
            // 
            shiftAssignmentIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftAssignmentId";
            shiftAssignmentIdDataGridViewTextBoxColumn.HeaderText = "ShiftAssignmentId";
            shiftAssignmentIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftAssignmentIdDataGridViewTextBoxColumn.Name = "shiftAssignmentIdDataGridViewTextBoxColumn";
            shiftAssignmentIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftAssignmentIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shiftDateDataGridViewTextBoxColumn
            // 
            shiftDateDataGridViewTextBoxColumn.DataPropertyName = "ShiftDate";
            shiftDateDataGridViewTextBoxColumn.HeaderText = "Ngày";
            shiftDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftDateDataGridViewTextBoxColumn.Name = "shiftDateDataGridViewTextBoxColumn";
            shiftDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shiftIdDataGridViewTextBoxColumn
            // 
            shiftIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftId";
            shiftIdDataGridViewTextBoxColumn.HeaderText = "ShiftId";
            shiftIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftIdDataGridViewTextBoxColumn.Name = "shiftIdDataGridViewTextBoxColumn";
            shiftIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shiftNameDataGridViewTextBoxColumn
            // 
            shiftNameDataGridViewTextBoxColumn.DataPropertyName = "ShiftName";
            shiftNameDataGridViewTextBoxColumn.HeaderText = "ShiftName";
            shiftNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftNameDataGridViewTextBoxColumn.Name = "shiftNameDataGridViewTextBoxColumn";
            shiftNameDataGridViewTextBoxColumn.ReadOnly = true;
            shiftNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // shiftTypeIdDataGridViewTextBoxColumn
            // 
            shiftTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftTypeId";
            shiftTypeIdDataGridViewTextBoxColumn.HeaderText = "ShiftTypeId";
            shiftTypeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftTypeIdDataGridViewTextBoxColumn.Name = "shiftTypeIdDataGridViewTextBoxColumn";
            shiftTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // shiftTypeNameDataGridViewTextBoxColumn
            // 
            shiftTypeNameDataGridViewTextBoxColumn.DataPropertyName = "ShiftTypeName";
            shiftTypeNameDataGridViewTextBoxColumn.HeaderText = "Loại ca";
            shiftTypeNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftTypeNameDataGridViewTextBoxColumn.Name = "shiftTypeNameDataGridViewTextBoxColumn";
            shiftTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // payMultiplierDataGridViewTextBoxColumn
            // 
            payMultiplierDataGridViewTextBoxColumn.DataPropertyName = "PayMultiplier";
            payMultiplierDataGridViewTextBoxColumn.HeaderText = "Hệ số lương";
            payMultiplierDataGridViewTextBoxColumn.MinimumWidth = 6;
            payMultiplierDataGridViewTextBoxColumn.Name = "payMultiplierDataGridViewTextBoxColumn";
            payMultiplierDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contextMenuAttendance
            // 
            contextMenuAttendance.ImageScalingSize = new Size(20, 20);
            contextMenuAttendance.Items.AddRange(new ToolStripItem[] { menuItemViewDetails, menuItemDelete });
            contextMenuAttendance.Name = "contextMenuAttendance";
            contextMenuAttendance.Size = new Size(188, 52);
            // 
            // menuItemViewDetails
            // 
            menuItemViewDetails.Name = "menuItemViewDetails";
            menuItemViewDetails.Size = new Size(187, 24);
            menuItemViewDetails.Text = "👁️ Xem Chi Tiết";
            menuItemViewDetails.Click += menuItemViewDetails_Click;
            // 
            // menuItemDelete
            // 
            menuItemDelete.Name = "menuItemDelete";
            menuItemDelete.Size = new Size(187, 24);
            menuItemDelete.Text = "🗑️ Xóa Bản Ghi";
            menuItemDelete.Click += menuItemDelete_Click;
            // 
            // attendanceRecordDtoBindingSource
            // 
            attendanceRecordDtoBindingSource.DataSource = typeof(Data.DTO.AttendanceRecordDto);
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.FromArgb(248, 249, 250);
            panelStatus.BorderStyle = BorderStyle.FixedSingle;
            panelStatus.Controls.Add(lblStatus);
            panelStatus.Controls.Add(lblRecordCount);
            panelStatus.Controls.Add(progressBar);
            panelStatus.Dock = DockStyle.Bottom;
            panelStatus.Location = new Point(0, 867);
            panelStatus.Margin = new Padding(3, 4, 3, 4);
            panelStatus.Name = "panelStatus";
            panelStatus.Padding = new Padding(23, 13, 23, 13);
            panelStatus.Size = new Size(1600, 66);
            panelStatus.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(108, 117, 125);
            lblStatus.Location = new Point(23, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(79, 23);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Sẵn sàng";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRecordCount.AutoSize = true;
            lblRecordCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecordCount.ForeColor = Color.FromArgb(40, 167, 69);
            lblRecordCount.Location = new Point(1463, 20);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(137, 23);
            lblRecordCount.TabIndex = 2;
            lblRecordCount.Text = "Tổng: 0 bản ghi";
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            progressBar.Location = new Point(1200, 20);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(229, 27);
            progressBar.TabIndex = 1;
            progressBar.Visible = false;
            // 
            // txtTeamSearch
            // 
            txtTeamSearch.Font = new Font("Segoe UI", 10F);
            txtTeamSearch.Location = new Point(12, 40);
            txtTeamSearch.Name = "txtTeamSearch";
            txtTeamSearch.ReadOnly = true;
            txtTeamSearch.Size = new Size(200, 30);
            txtTeamSearch.TabIndex = 10;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = Color.FromArgb(0, 123, 255);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 86, 179);
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(933, 27);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(114, 60);
            button4.TabIndex = 5;
            button4.Text = "📊 Khôi phục";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // AttendanceManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelMain);
            Controls.Add(panelStatus);
            Controls.Add(panelFilters);
            Controls.Add(panelSummary);
            Controls.Add(panelHeader);
            Controls.Add(txtTeamSearch);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AttendanceManagementControl";
            Size = new Size(1600, 933);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSummary.ResumeLayout(false);
            tableLayoutSummary.ResumeLayout(false);
            cardTotalRecords.ResumeLayout(false);
            cardTotalRecords.PerformLayout();
            cardTotalHours.ResumeLayout(false);
            cardTotalHours.PerformLayout();
            cardOvertimeHours.ResumeLayout(false);
            cardOvertimeHours.PerformLayout();
            cardActiveEmployees.ResumeLayout(false);
            cardActiveEmployees.PerformLayout();
            cardAvgHours.ResumeLayout(false);
            cardAvgHours.PerformLayout();
            cardPendingCheckouts.ResumeLayout(false);
            cardPendingCheckouts.PerformLayout();
            panelFilters.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            groupBoxFilters.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            contextMenuAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)attendanceRecordDtoBindingSource).EndInit();
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSummary;
        private System.Windows.Forms.Panel cardTotalRecords;
        private System.Windows.Forms.Label lblTotalRecordsValue;
        private System.Windows.Forms.Label lblTotalRecordsTitle;
        private System.Windows.Forms.Label iconTotalRecords;
        private System.Windows.Forms.Panel cardTotalHours;
        private System.Windows.Forms.Label lblTotalHoursValue;
        private System.Windows.Forms.Label lblTotalHoursTitle;
        private System.Windows.Forms.Label iconTotalHours;
        private System.Windows.Forms.Panel cardActiveEmployees;
        private System.Windows.Forms.Label lblActiveEmployeesValue;
        private System.Windows.Forms.Label lblActiveEmployeesTitle;
        private System.Windows.Forms.Label iconActiveEmployees;
        private System.Windows.Forms.Panel cardAvgHours;
        private System.Windows.Forms.Label lblAvgHoursValue;
        private System.Windows.Forms.Label lblAvgHoursTitle;
        private System.Windows.Forms.Label iconAvgHours;
        private System.Windows.Forms.Panel cardPendingCheckouts;
        private System.Windows.Forms.Label lblPendingCheckoutsValue;
        private System.Windows.Forms.Label lblPendingCheckoutsTitle;
        private System.Windows.Forms.Label iconPendingCheckouts;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblShiftFilter;
        private System.Windows.Forms.ComboBox cmbShiftFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvAttendance;
        private System.Windows.Forms.ContextMenuStrip contextMenuAttendance;
        private System.Windows.Forms.ToolStripMenuItem menuItemViewDetails;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.ProgressBar progressBar;
        private Panel cardOvertimeHours;
        private Label lblOvertimeHoursValue;
        private Label lblOvertimeHoursTitle;
        private Label iconOvertimeHours;
        private Label lblEmployeeSearch;
        private TextBox txtEmployeeSearch;
        private Button button1;
        private BindingSource attendanceRecordDtoBindingSource;
        private System.Windows.Forms.DateTimePicker dtpTeamToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTeamFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTeamFilter;
        private System.Windows.Forms.Label lblTeamFilter;
        private System.Windows.Forms.TextBox txtTeamSearch;
        private DataGridViewTextBoxColumn attendanceRecordIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn positionNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn checkInDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftStartDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn checkOutDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftEndDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn durationHoursDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validDurationHoursDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn validDurationDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isOvertimeDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn shiftAssignmentIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftTypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftTypeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn payMultiplierDataGridViewTextBoxColumn;
        private Button button2;
        private Label label3;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
    }
}