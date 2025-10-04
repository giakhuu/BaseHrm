namespace BaseHrm.Controls
{
    partial class DailyShiftSummaryControl
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
            btnRefresh = new Button();
            btnExportReport = new Button();
            panelMain = new Panel();
            splitContainerMain = new SplitContainer();
            panelSummaryCards = new Panel();
            cardTotalHours = new Panel();
            lblTotalHoursValue = new Label();
            lblTotalHoursTitle = new Label();
            iconTotalHours = new Label();
            cardTotalEmployees = new Panel();
            lblTotalEmployeesValue = new Label();
            lblTotalEmployeesTitle = new Label();
            iconTotalEmployees = new Label();
            cardTotalShifts = new Panel();
            lblTotalShiftsValue = new Label();
            lblTotalShiftsTitle = new Label();
            iconTotalShifts = new Label();
            cardAverageHours = new Panel();
            lblAverageHoursValue = new Label();
            lblAverageHoursTitle = new Label();
            iconAverageHours = new Label();
            groupBoxShiftDetails = new GroupBox();
            dgvShiftAssignments = new DataGridView();
            shiftIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftStartDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftEndDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            expectedHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftTypeNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeFirstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeLastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeEmailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            approvedByAccountIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftAssignmentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftAssignmentDtoBindingSource = new BindingSource(components);
            panelShiftControls = new Panel();
            btnDelEmployee = new Button();
            button1 = new Button();
            txtEmployee = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dtpToDate = new DateTimePicker();
            lblFrom = new Label();
            dtpFromDate = new DateTimePicker();
            lblShiftFilter = new Label();
            cmbShiftFilter = new ComboBox();
            btnViewDetails = new Button();
            splitContainerCharts = new SplitContainer();
            groupBoxShiftDistribution = new GroupBox();
            panelShiftChart = new Panel();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            groupBoxHourlyBreakdown = new GroupBox();
            panelHourlyChart = new Panel();
            formsPlot2 = new ScottPlot.WinForms.FormsPlot();
            lblHourlyChartPlaceholder = new Label();
            panelStatus = new Panel();
            lblStatus = new Label();
            lblLastUpdated = new Label();
            shiftContextMenu = new ContextMenuStrip(components);
            shiftInfo = new ToolStripMenuItem();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelSummaryCards.SuspendLayout();
            cardTotalHours.SuspendLayout();
            cardTotalEmployees.SuspendLayout();
            cardTotalShifts.SuspendLayout();
            cardAverageHours.SuspendLayout();
            groupBoxShiftDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShiftAssignments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shiftAssignmentDtoBindingSource).BeginInit();
            panelShiftControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCharts).BeginInit();
            splitContainerCharts.Panel1.SuspendLayout();
            splitContainerCharts.Panel2.SuspendLayout();
            splitContainerCharts.SuspendLayout();
            groupBoxShiftDistribution.SuspendLayout();
            panelShiftChart.SuspendLayout();
            groupBoxHourlyBreakdown.SuspendLayout();
            panelHourlyChart.SuspendLayout();
            panelStatus.SuspendLayout();
            shiftContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(23, 162, 184);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Controls.Add(btnExportReport);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1600, 93);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(526, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Tổng Hợp Ca Làm Việc Hôm Nay";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(40, 167, 69);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1269, 20);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(137, 53);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Làm Mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExportReport
            // 
            btnExportReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportReport.BackColor = Color.FromArgb(255, 193, 7);
            btnExportReport.FlatAppearance.BorderSize = 0;
            btnExportReport.FlatStyle = FlatStyle.Flat;
            btnExportReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportReport.ForeColor = Color.FromArgb(68, 68, 68);
            btnExportReport.Location = new Point(1417, 20);
            btnExportReport.Margin = new Padding(3, 4, 3, 4);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(160, 53);
            btnExportReport.TabIndex = 3;
            btnExportReport.Text = "📄 Xuất Báo Cáo";
            btnExportReport.UseVisualStyleBackColor = false;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(splitContainerMain);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(23, 27, 23, 27);
            panelMain.Size = new Size(1600, 894);
            panelMain.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(23, 27);
            splitContainerMain.Margin = new Padding(3, 4, 3, 4);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(panelSummaryCards);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(groupBoxShiftDetails);
            splitContainerMain.Panel2.Controls.Add(splitContainerCharts);
            splitContainerMain.Size = new Size(1554, 840);
            splitContainerMain.SplitterDistance = 200;
            splitContainerMain.SplitterWidth = 5;
            splitContainerMain.TabIndex = 0;
            // 
            // panelSummaryCards
            // 
            panelSummaryCards.Controls.Add(cardTotalHours);
            panelSummaryCards.Controls.Add(cardTotalEmployees);
            panelSummaryCards.Controls.Add(cardTotalShifts);
            panelSummaryCards.Controls.Add(cardAverageHours);
            panelSummaryCards.Dock = DockStyle.Fill;
            panelSummaryCards.Location = new Point(0, 0);
            panelSummaryCards.Margin = new Padding(3, 4, 3, 4);
            panelSummaryCards.Name = "panelSummaryCards";
            panelSummaryCards.Padding = new Padding(11, 13, 11, 13);
            panelSummaryCards.Size = new Size(1554, 200);
            panelSummaryCards.TabIndex = 0;
            // 
            // cardTotalHours
            // 
            cardTotalHours.BackColor = Color.White;
            cardTotalHours.BorderStyle = BorderStyle.FixedSingle;
            cardTotalHours.Controls.Add(lblTotalHoursValue);
            cardTotalHours.Controls.Add(lblTotalHoursTitle);
            cardTotalHours.Controls.Add(iconTotalHours);
            cardTotalHours.Location = new Point(11, 13);
            cardTotalHours.Margin = new Padding(3, 4, 3, 4);
            cardTotalHours.Name = "cardTotalHours";
            cardTotalHours.Padding = new Padding(23, 27, 23, 27);
            cardTotalHours.Size = new Size(365, 173);
            cardTotalHours.TabIndex = 0;
            // 
            // lblTotalHoursValue
            // 
            lblTotalHoursValue.AutoSize = true;
            lblTotalHoursValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalHoursValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotalHoursValue.Location = new Point(114, 61);
            lblTotalHoursValue.Name = "lblTotalHoursValue";
            lblTotalHoursValue.Size = new Size(46, 54);
            lblTotalHoursValue.TabIndex = 2;
            lblTotalHoursValue.Text = "0";
            // 
            // lblTotalHoursTitle
            // 
            lblTotalHoursTitle.AutoSize = true;
            lblTotalHoursTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalHoursTitle.ForeColor = Color.FromArgb(68, 68, 68);
            lblTotalHoursTitle.Location = new Point(91, 27);
            lblTotalHoursTitle.Name = "lblTotalHoursTitle";
            lblTotalHoursTitle.Size = new Size(153, 28);
            lblTotalHoursTitle.TabIndex = 1;
            lblTotalHoursTitle.Text = "Tổng Giờ Công";
            // 
            // iconTotalHours
            // 
            iconTotalHours.AutoSize = true;
            iconTotalHours.Font = new Font("Segoe UI", 32F);
            iconTotalHours.ForeColor = Color.FromArgb(40, 167, 69);
            iconTotalHours.Location = new Point(23, 47);
            iconTotalHours.Name = "iconTotalHours";
            iconTotalHours.Size = new Size(104, 72);
            iconTotalHours.TabIndex = 0;
            iconTotalHours.Text = "⏰";
            // 
            // cardTotalEmployees
            // 
            cardTotalEmployees.BackColor = Color.White;
            cardTotalEmployees.BorderStyle = BorderStyle.FixedSingle;
            cardTotalEmployees.Controls.Add(lblTotalEmployeesValue);
            cardTotalEmployees.Controls.Add(lblTotalEmployeesTitle);
            cardTotalEmployees.Controls.Add(iconTotalEmployees);
            cardTotalEmployees.Location = new Point(389, 13);
            cardTotalEmployees.Margin = new Padding(3, 4, 3, 4);
            cardTotalEmployees.Name = "cardTotalEmployees";
            cardTotalEmployees.Padding = new Padding(23, 27, 23, 27);
            cardTotalEmployees.Size = new Size(365, 173);
            cardTotalEmployees.TabIndex = 1;
            // 
            // lblTotalEmployeesValue
            // 
            lblTotalEmployeesValue.AutoSize = true;
            lblTotalEmployeesValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalEmployeesValue.ForeColor = Color.FromArgb(23, 162, 184);
            lblTotalEmployeesValue.Location = new Point(114, 60);
            lblTotalEmployeesValue.Name = "lblTotalEmployeesValue";
            lblTotalEmployeesValue.Size = new Size(46, 54);
            lblTotalEmployeesValue.TabIndex = 2;
            lblTotalEmployeesValue.Text = "0";
            // 
            // lblTotalEmployeesTitle
            // 
            lblTotalEmployeesTitle.AutoSize = true;
            lblTotalEmployeesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalEmployeesTitle.ForeColor = Color.FromArgb(68, 68, 68);
            lblTotalEmployeesTitle.Location = new Point(91, 27);
            lblTotalEmployeesTitle.Name = "lblTotalEmployeesTitle";
            lblTotalEmployeesTitle.Size = new Size(165, 28);
            lblTotalEmployeesTitle.TabIndex = 1;
            lblTotalEmployeesTitle.Text = "Tổng Nhân Viên";
            // 
            // iconTotalEmployees
            // 
            iconTotalEmployees.AutoSize = true;
            iconTotalEmployees.Font = new Font("Segoe UI", 32F);
            iconTotalEmployees.ForeColor = Color.FromArgb(23, 162, 184);
            iconTotalEmployees.Location = new Point(23, 47);
            iconTotalEmployees.Name = "iconTotalEmployees";
            iconTotalEmployees.Size = new Size(104, 72);
            iconTotalEmployees.TabIndex = 0;
            iconTotalEmployees.Text = "👥";
            // 
            // cardTotalShifts
            // 
            cardTotalShifts.BackColor = Color.White;
            cardTotalShifts.BorderStyle = BorderStyle.FixedSingle;
            cardTotalShifts.Controls.Add(lblTotalShiftsValue);
            cardTotalShifts.Controls.Add(lblTotalShiftsTitle);
            cardTotalShifts.Controls.Add(iconTotalShifts);
            cardTotalShifts.Location = new Point(766, 13);
            cardTotalShifts.Margin = new Padding(3, 4, 3, 4);
            cardTotalShifts.Name = "cardTotalShifts";
            cardTotalShifts.Padding = new Padding(23, 27, 23, 27);
            cardTotalShifts.Size = new Size(365, 173);
            cardTotalShifts.TabIndex = 2;
            // 
            // lblTotalShiftsValue
            // 
            lblTotalShiftsValue.AutoSize = true;
            lblTotalShiftsValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalShiftsValue.ForeColor = Color.FromArgb(255, 193, 7);
            lblTotalShiftsValue.Location = new Point(107, 60);
            lblTotalShiftsValue.Name = "lblTotalShiftsValue";
            lblTotalShiftsValue.Size = new Size(46, 54);
            lblTotalShiftsValue.TabIndex = 2;
            lblTotalShiftsValue.Text = "0";
            // 
            // lblTotalShiftsTitle
            // 
            lblTotalShiftsTitle.AutoSize = true;
            lblTotalShiftsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalShiftsTitle.ForeColor = Color.FromArgb(68, 68, 68);
            lblTotalShiftsTitle.Location = new Point(91, 27);
            lblTotalShiftsTitle.Name = "lblTotalShiftsTitle";
            lblTotalShiftsTitle.Size = new Size(89, 28);
            lblTotalShiftsTitle.TabIndex = 1;
            lblTotalShiftsTitle.Text = "Tổng Ca";
            // 
            // iconTotalShifts
            // 
            iconTotalShifts.AutoSize = true;
            iconTotalShifts.Font = new Font("Segoe UI", 32F);
            iconTotalShifts.ForeColor = Color.FromArgb(255, 193, 7);
            iconTotalShifts.Location = new Point(23, 47);
            iconTotalShifts.Name = "iconTotalShifts";
            iconTotalShifts.Size = new Size(104, 72);
            iconTotalShifts.TabIndex = 0;
            iconTotalShifts.Text = "🕐";
            // 
            // cardAverageHours
            // 
            cardAverageHours.BackColor = Color.White;
            cardAverageHours.BorderStyle = BorderStyle.FixedSingle;
            cardAverageHours.Controls.Add(lblAverageHoursValue);
            cardAverageHours.Controls.Add(lblAverageHoursTitle);
            cardAverageHours.Controls.Add(iconAverageHours);
            cardAverageHours.Location = new Point(1143, 13);
            cardAverageHours.Margin = new Padding(3, 4, 3, 4);
            cardAverageHours.Name = "cardAverageHours";
            cardAverageHours.Padding = new Padding(23, 27, 23, 27);
            cardAverageHours.Size = new Size(365, 173);
            cardAverageHours.TabIndex = 3;
            // 
            // lblAverageHoursValue
            // 
            lblAverageHoursValue.AutoSize = true;
            lblAverageHoursValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAverageHoursValue.ForeColor = Color.FromArgb(220, 53, 69);
            lblAverageHoursValue.Location = new Point(118, 61);
            lblAverageHoursValue.Name = "lblAverageHoursValue";
            lblAverageHoursValue.Size = new Size(46, 54);
            lblAverageHoursValue.TabIndex = 2;
            lblAverageHoursValue.Text = "0";
            // 
            // lblAverageHoursTitle
            // 
            lblAverageHoursTitle.AutoSize = true;
            lblAverageHoursTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAverageHoursTitle.ForeColor = Color.FromArgb(68, 68, 68);
            lblAverageHoursTitle.Location = new Point(91, 27);
            lblAverageHoursTitle.Name = "lblAverageHoursTitle";
            lblAverageHoursTitle.Size = new Size(192, 28);
            lblAverageHoursTitle.TabIndex = 1;
            lblAverageHoursTitle.Text = "Trung Bình Giờ/NV";
            // 
            // iconAverageHours
            // 
            iconAverageHours.AutoSize = true;
            iconAverageHours.Font = new Font("Segoe UI", 32F);
            iconAverageHours.ForeColor = Color.FromArgb(220, 53, 69);
            iconAverageHours.Location = new Point(23, 47);
            iconAverageHours.Name = "iconAverageHours";
            iconAverageHours.Size = new Size(104, 72);
            iconAverageHours.TabIndex = 0;
            iconAverageHours.Text = "📊";
            // 
            // groupBoxShiftDetails
            // 
            groupBoxShiftDetails.BackColor = Color.White;
            groupBoxShiftDetails.Controls.Add(dgvShiftAssignments);
            groupBoxShiftDetails.Controls.Add(panelShiftControls);
            groupBoxShiftDetails.Dock = DockStyle.Fill;
            groupBoxShiftDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBoxShiftDetails.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxShiftDetails.Location = new Point(0, 0);
            groupBoxShiftDetails.Margin = new Padding(3, 4, 3, 4);
            groupBoxShiftDetails.Name = "groupBoxShiftDetails";
            groupBoxShiftDetails.Padding = new Padding(17, 20, 17, 20);
            groupBoxShiftDetails.Size = new Size(1028, 635);
            groupBoxShiftDetails.TabIndex = 1;
            groupBoxShiftDetails.TabStop = false;
            groupBoxShiftDetails.Text = "📋 Chi Tiết Ca Làm Việc";
            // 
            // dgvShiftAssignments
            // 
            dgvShiftAssignments.AllowUserToAddRows = false;
            dgvShiftAssignments.AllowUserToDeleteRows = false;
            dgvShiftAssignments.AutoGenerateColumns = false;
            dgvShiftAssignments.BackgroundColor = Color.White;
            dgvShiftAssignments.BorderStyle = BorderStyle.None;
            dgvShiftAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShiftAssignments.Columns.AddRange(new DataGridViewColumn[] { shiftIdDataGridViewTextBoxColumn, dateDataGridViewTextBoxColumn, employeeFullNameDataGridViewTextBoxColumn, shiftStartDataGridViewTextBoxColumn, shiftEndDataGridViewTextBoxColumn, expectedHoursDataGridViewTextBoxColumn, shiftTypeNameDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, employeeFirstNameDataGridViewTextBoxColumn, employeeLastNameDataGridViewTextBoxColumn, employeeEmailDataGridViewTextBoxColumn, approvedByAccountIdDataGridViewTextBoxColumn, shiftAssignmentIdDataGridViewTextBoxColumn, shiftNameDataGridViewTextBoxColumn });
            dgvShiftAssignments.DataSource = shiftAssignmentDtoBindingSource;
            dgvShiftAssignments.Dock = DockStyle.Fill;
            dgvShiftAssignments.GridColor = Color.FromArgb(233, 236, 239);
            dgvShiftAssignments.Location = new Point(17, 203);
            dgvShiftAssignments.Margin = new Padding(3, 4, 3, 4);
            dgvShiftAssignments.MultiSelect = false;
            dgvShiftAssignments.Name = "dgvShiftAssignments";
            dgvShiftAssignments.ReadOnly = true;
            dgvShiftAssignments.RowHeadersVisible = false;
            dgvShiftAssignments.RowHeadersWidth = 51;
            dgvShiftAssignments.RowTemplate.Height = 35;
            dgvShiftAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShiftAssignments.Size = new Size(994, 412);
            dgvShiftAssignments.TabIndex = 1;
            dgvShiftAssignments.CellMouseClick += dgvShiftAssignments_CellMouseClick;
            // 
            // shiftIdDataGridViewTextBoxColumn
            // 
            shiftIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftId";
            shiftIdDataGridViewTextBoxColumn.HeaderText = "Mã ca";
            shiftIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftIdDataGridViewTextBoxColumn.Name = "shiftIdDataGridViewTextBoxColumn";
            shiftIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            dateDataGridViewTextBoxColumn.HeaderText = "Ngày";
            dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            dateDataGridViewTextBoxColumn.ReadOnly = true;
            dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeFullNameDataGridViewTextBoxColumn
            // 
            employeeFullNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFullName";
            employeeFullNameDataGridViewTextBoxColumn.HeaderText = "Nhân viên";
            employeeFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeFullNameDataGridViewTextBoxColumn.Name = "employeeFullNameDataGridViewTextBoxColumn";
            employeeFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            employeeFullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftStartDataGridViewTextBoxColumn
            // 
            shiftStartDataGridViewTextBoxColumn.DataPropertyName = "ShiftStart";
            shiftStartDataGridViewTextBoxColumn.HeaderText = "Bắt đầu";
            shiftStartDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftStartDataGridViewTextBoxColumn.Name = "shiftStartDataGridViewTextBoxColumn";
            shiftStartDataGridViewTextBoxColumn.ReadOnly = true;
            shiftStartDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftEndDataGridViewTextBoxColumn
            // 
            shiftEndDataGridViewTextBoxColumn.DataPropertyName = "ShiftEnd";
            shiftEndDataGridViewTextBoxColumn.HeaderText = "Kết thúc";
            shiftEndDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftEndDataGridViewTextBoxColumn.Name = "shiftEndDataGridViewTextBoxColumn";
            shiftEndDataGridViewTextBoxColumn.ReadOnly = true;
            shiftEndDataGridViewTextBoxColumn.Width = 125;
            // 
            // expectedHoursDataGridViewTextBoxColumn
            // 
            expectedHoursDataGridViewTextBoxColumn.DataPropertyName = "ExpectedHours";
            expectedHoursDataGridViewTextBoxColumn.HeaderText = "Tổng giờ";
            expectedHoursDataGridViewTextBoxColumn.MinimumWidth = 6;
            expectedHoursDataGridViewTextBoxColumn.Name = "expectedHoursDataGridViewTextBoxColumn";
            expectedHoursDataGridViewTextBoxColumn.ReadOnly = true;
            expectedHoursDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftTypeNameDataGridViewTextBoxColumn
            // 
            shiftTypeNameDataGridViewTextBoxColumn.DataPropertyName = "ShiftTypeName";
            shiftTypeNameDataGridViewTextBoxColumn.HeaderText = "Loại ca";
            shiftTypeNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftTypeNameDataGridViewTextBoxColumn.Name = "shiftTypeNameDataGridViewTextBoxColumn";
            shiftTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            shiftTypeNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            employeeIdDataGridViewTextBoxColumn.DataPropertyName = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.HeaderText = "EmployeeId";
            employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            employeeIdDataGridViewTextBoxColumn.Visible = false;
            employeeIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeFirstNameDataGridViewTextBoxColumn
            // 
            employeeFirstNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFirstName";
            employeeFirstNameDataGridViewTextBoxColumn.HeaderText = "EmployeeFirstName";
            employeeFirstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeFirstNameDataGridViewTextBoxColumn.Name = "employeeFirstNameDataGridViewTextBoxColumn";
            employeeFirstNameDataGridViewTextBoxColumn.ReadOnly = true;
            employeeFirstNameDataGridViewTextBoxColumn.Visible = false;
            employeeFirstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeLastNameDataGridViewTextBoxColumn
            // 
            employeeLastNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeLastName";
            employeeLastNameDataGridViewTextBoxColumn.HeaderText = "EmployeeLastName";
            employeeLastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeLastNameDataGridViewTextBoxColumn.Name = "employeeLastNameDataGridViewTextBoxColumn";
            employeeLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            employeeLastNameDataGridViewTextBoxColumn.Visible = false;
            employeeLastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeEmailDataGridViewTextBoxColumn
            // 
            employeeEmailDataGridViewTextBoxColumn.DataPropertyName = "EmployeeEmail";
            employeeEmailDataGridViewTextBoxColumn.HeaderText = "EmployeeEmail";
            employeeEmailDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeEmailDataGridViewTextBoxColumn.Name = "employeeEmailDataGridViewTextBoxColumn";
            employeeEmailDataGridViewTextBoxColumn.ReadOnly = true;
            employeeEmailDataGridViewTextBoxColumn.Visible = false;
            employeeEmailDataGridViewTextBoxColumn.Width = 125;
            // 
            // approvedByAccountIdDataGridViewTextBoxColumn
            // 
            approvedByAccountIdDataGridViewTextBoxColumn.DataPropertyName = "ApprovedByAccountId";
            approvedByAccountIdDataGridViewTextBoxColumn.HeaderText = "Mã người giao";
            approvedByAccountIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            approvedByAccountIdDataGridViewTextBoxColumn.Name = "approvedByAccountIdDataGridViewTextBoxColumn";
            approvedByAccountIdDataGridViewTextBoxColumn.ReadOnly = true;
            approvedByAccountIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftAssignmentIdDataGridViewTextBoxColumn
            // 
            shiftAssignmentIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftAssignmentId";
            shiftAssignmentIdDataGridViewTextBoxColumn.HeaderText = "Mã ca";
            shiftAssignmentIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftAssignmentIdDataGridViewTextBoxColumn.Name = "shiftAssignmentIdDataGridViewTextBoxColumn";
            shiftAssignmentIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftAssignmentIdDataGridViewTextBoxColumn.Visible = false;
            shiftAssignmentIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftNameDataGridViewTextBoxColumn
            // 
            shiftNameDataGridViewTextBoxColumn.DataPropertyName = "ShiftName";
            shiftNameDataGridViewTextBoxColumn.HeaderText = "Loại ca";
            shiftNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftNameDataGridViewTextBoxColumn.Name = "shiftNameDataGridViewTextBoxColumn";
            shiftNameDataGridViewTextBoxColumn.ReadOnly = true;
            shiftNameDataGridViewTextBoxColumn.Visible = false;
            shiftNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftAssignmentDtoBindingSource
            // 
            shiftAssignmentDtoBindingSource.DataSource = typeof(Data.DTO.ShiftAssignmentDto);
            // 
            // panelShiftControls
            // 
            panelShiftControls.BackColor = Color.FromArgb(248, 249, 250);
            panelShiftControls.Controls.Add(button2);
            panelShiftControls.Controls.Add(button3);
            panelShiftControls.Controls.Add(textBox1);
            panelShiftControls.Controls.Add(label3);
            panelShiftControls.Controls.Add(btnDelEmployee);
            panelShiftControls.Controls.Add(button1);
            panelShiftControls.Controls.Add(txtEmployee);
            panelShiftControls.Controls.Add(label2);
            panelShiftControls.Controls.Add(label1);
            panelShiftControls.Controls.Add(dtpToDate);
            panelShiftControls.Controls.Add(lblFrom);
            panelShiftControls.Controls.Add(dtpFromDate);
            panelShiftControls.Controls.Add(lblShiftFilter);
            panelShiftControls.Controls.Add(cmbShiftFilter);
            panelShiftControls.Controls.Add(btnViewDetails);
            panelShiftControls.Dock = DockStyle.Top;
            panelShiftControls.Location = new Point(17, 47);
            panelShiftControls.Margin = new Padding(3, 4, 3, 4);
            panelShiftControls.Name = "panelShiftControls";
            panelShiftControls.Padding = new Padding(11, 13, 11, 13);
            panelShiftControls.Size = new Size(994, 156);
            panelShiftControls.TabIndex = 0;
            // 
            // btnDelEmployee
            // 
            btnDelEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelEmployee.BackColor = Color.Red;
            btnDelEmployee.FlatAppearance.BorderSize = 0;
            btnDelEmployee.FlatStyle = FlatStyle.Flat;
            btnDelEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelEmployee.ForeColor = Color.White;
            btnDelEmployee.Location = new Point(441, 81);
            btnDelEmployee.Margin = new Padding(3, 4, 3, 4);
            btnDelEmployee.Name = "btnDelEmployee";
            btnDelEmployee.Size = new Size(49, 40);
            btnDelEmployee.TabIndex = 12;
            btnDelEmployee.Text = "Xóa";
            btnDelEmployee.UseVisualStyleBackColor = false;
            btnDelEmployee.Click += btnDelEmployee_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(51, 122, 183);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(309, 81);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(126, 40);
            button1.TabIndex = 11;
            button1.Text = "Chọn nhân viên";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtEmployee
            // 
            txtEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmployee.Location = new Point(109, 84);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.PlaceholderText = "--Tên";
            txtEmployee.ReadOnly = true;
            txtEmployee.Size = new Size(194, 34);
            txtEmployee.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(85, 85, 85);
            label2.Location = new Point(11, 92);
            label2.Name = "label2";
            label2.Size = new Size(92, 23);
            label2.TabIndex = 9;
            label2.Text = "Nhân viên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(85, 85, 85);
            label1.Location = new Point(581, 32);
            label1.Name = "label1";
            label1.Size = new Size(79, 23);
            label1.TabIndex = 8;
            label1.Text = "Tới ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpToDate.Font = new Font("Segoe UI", 11F);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(662, 25);
            dtpToDate.Margin = new Padding(3, 4, 3, 4);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(171, 32);
            dtpToDate.TabIndex = 7;
            dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.ForeColor = Color.FromArgb(85, 85, 85);
            lblFrom.Location = new Point(303, 34);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(75, 23);
            lblFrom.TabIndex = 6;
            lblFrom.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFromDate.Font = new Font("Segoe UI", 11F);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(384, 27);
            dtpFromDate.Margin = new Padding(3, 4, 3, 4);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(171, 32);
            dtpFromDate.TabIndex = 5;
            dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
            // 
            // lblShiftFilter
            // 
            lblShiftFilter.AutoSize = true;
            lblShiftFilter.Font = new Font("Segoe UI", 10F);
            lblShiftFilter.ForeColor = Color.FromArgb(85, 85, 85);
            lblShiftFilter.Location = new Point(11, 27);
            lblShiftFilter.Name = "lblShiftFilter";
            lblShiftFilter.Size = new Size(67, 23);
            lblShiftFilter.TabIndex = 0;
            lblShiftFilter.Text = "Loại ca:";
            // 
            // cmbShiftFilter
            // 
            cmbShiftFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbShiftFilter.Font = new Font("Segoe UI", 10F);
            cmbShiftFilter.FormattingEnabled = true;
            cmbShiftFilter.Location = new Point(91, 27);
            cmbShiftFilter.Margin = new Padding(3, 4, 3, 4);
            cmbShiftFilter.Name = "cmbShiftFilter";
            cmbShiftFilter.Size = new Size(171, 31);
            cmbShiftFilter.TabIndex = 1;
            cmbShiftFilter.SelectedIndexChanged += cmbShiftFilter_SelectedIndexChanged;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewDetails.BackColor = Color.FromArgb(51, 122, 183);
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewDetails.ForeColor = Color.White;
            btnViewDetails.Location = new Point(857, 20);
            btnViewDetails.Margin = new Padding(3, 4, 3, 4);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(126, 40);
            btnViewDetails.TabIndex = 4;
            btnViewDetails.Text = "👁️ Xem Chi Tiết";
            btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // splitContainerCharts
            // 
            splitContainerCharts.Dock = DockStyle.Right;
            splitContainerCharts.Location = new Point(1028, 0);
            splitContainerCharts.Margin = new Padding(3, 4, 3, 4);
            splitContainerCharts.Name = "splitContainerCharts";
            splitContainerCharts.Orientation = Orientation.Horizontal;
            // 
            // splitContainerCharts.Panel1
            // 
            splitContainerCharts.Panel1.Controls.Add(groupBoxShiftDistribution);
            // 
            // splitContainerCharts.Panel2
            // 
            splitContainerCharts.Panel2.Controls.Add(groupBoxHourlyBreakdown);
            splitContainerCharts.Size = new Size(526, 635);
            splitContainerCharts.SplitterDistance = 317;
            splitContainerCharts.SplitterWidth = 5;
            splitContainerCharts.TabIndex = 0;
            // 
            // groupBoxShiftDistribution
            // 
            groupBoxShiftDistribution.BackColor = Color.White;
            groupBoxShiftDistribution.Controls.Add(panelShiftChart);
            groupBoxShiftDistribution.Dock = DockStyle.Fill;
            groupBoxShiftDistribution.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxShiftDistribution.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxShiftDistribution.Location = new Point(0, 0);
            groupBoxShiftDistribution.Margin = new Padding(3, 4, 3, 4);
            groupBoxShiftDistribution.Name = "groupBoxShiftDistribution";
            groupBoxShiftDistribution.Padding = new Padding(17, 20, 17, 20);
            groupBoxShiftDistribution.Size = new Size(526, 317);
            groupBoxShiftDistribution.TabIndex = 0;
            groupBoxShiftDistribution.TabStop = false;
            groupBoxShiftDistribution.Text = "\U0001f967 Phân Bố Ca Làm";
            // 
            // panelShiftChart
            // 
            panelShiftChart.Controls.Add(formsPlot1);
            panelShiftChart.Dock = DockStyle.Fill;
            panelShiftChart.Location = new Point(17, 45);
            panelShiftChart.Margin = new Padding(3, 4, 3, 4);
            panelShiftChart.Name = "panelShiftChart";
            panelShiftChart.Size = new Size(492, 252);
            panelShiftChart.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(0, 0);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(492, 252);
            formsPlot1.TabIndex = 1;
            // 
            // groupBoxHourlyBreakdown
            // 
            groupBoxHourlyBreakdown.BackColor = Color.White;
            groupBoxHourlyBreakdown.Controls.Add(panelHourlyChart);
            groupBoxHourlyBreakdown.Dock = DockStyle.Fill;
            groupBoxHourlyBreakdown.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxHourlyBreakdown.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxHourlyBreakdown.Location = new Point(0, 0);
            groupBoxHourlyBreakdown.Margin = new Padding(3, 4, 3, 4);
            groupBoxHourlyBreakdown.Name = "groupBoxHourlyBreakdown";
            groupBoxHourlyBreakdown.Padding = new Padding(17, 20, 17, 20);
            groupBoxHourlyBreakdown.Size = new Size(526, 313);
            groupBoxHourlyBreakdown.TabIndex = 0;
            groupBoxHourlyBreakdown.TabStop = false;
            groupBoxHourlyBreakdown.Text = "📈 Phân bố loại ca";
            // 
            // panelHourlyChart
            // 
            panelHourlyChart.Controls.Add(formsPlot2);
            panelHourlyChart.Controls.Add(lblHourlyChartPlaceholder);
            panelHourlyChart.Dock = DockStyle.Fill;
            panelHourlyChart.Location = new Point(17, 45);
            panelHourlyChart.Margin = new Padding(3, 4, 3, 4);
            panelHourlyChart.Name = "panelHourlyChart";
            panelHourlyChart.Size = new Size(492, 248);
            panelHourlyChart.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.DisplayScale = 1.25F;
            formsPlot2.Dock = DockStyle.Fill;
            formsPlot2.Location = new Point(0, 0);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(492, 248);
            formsPlot2.TabIndex = 1;
            // 
            // lblHourlyChartPlaceholder
            // 
            lblHourlyChartPlaceholder.Anchor = AnchorStyles.None;
            lblHourlyChartPlaceholder.AutoSize = true;
            lblHourlyChartPlaceholder.Font = new Font("Segoe UI", 12F);
            lblHourlyChartPlaceholder.ForeColor = Color.FromArgb(108, 117, 125);
            lblHourlyChartPlaceholder.Location = new Point(138, 109);
            lblHourlyChartPlaceholder.Name = "lblHourlyChartPlaceholder";
            lblHourlyChartPlaceholder.Size = new Size(267, 28);
            lblHourlyChartPlaceholder.TabIndex = 0;
            lblHourlyChartPlaceholder.Text = "📈 Biểu đồ phân tích giờ làm";
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.FromArgb(248, 249, 250);
            panelStatus.BorderStyle = BorderStyle.FixedSingle;
            panelStatus.Controls.Add(lblStatus);
            panelStatus.Controls.Add(lblLastUpdated);
            panelStatus.Dock = DockStyle.Bottom;
            panelStatus.Location = new Point(0, 987);
            panelStatus.Margin = new Padding(3, 4, 3, 4);
            panelStatus.Name = "panelStatus";
            panelStatus.Padding = new Padding(23, 13, 23, 13);
            panelStatus.Size = new Size(1600, 53);
            panelStatus.TabIndex = 2;
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
            // lblLastUpdated
            // 
            lblLastUpdated.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLastUpdated.AutoSize = true;
            lblLastUpdated.Font = new Font("Segoe UI", 9F);
            lblLastUpdated.ForeColor = Color.FromArgb(108, 117, 125);
            lblLastUpdated.Location = new Point(1429, 16);
            lblLastUpdated.Name = "lblLastUpdated";
            lblLastUpdated.Size = new Size(129, 20);
            lblLastUpdated.TabIndex = 1;
            lblLastUpdated.Text = "Cập nhật: 00:00:00";
            // 
            // shiftContextMenu
            // 
            shiftContextMenu.ImageScalingSize = new Size(20, 20);
            shiftContextMenu.Items.AddRange(new ToolStripItem[] { shiftInfo });
            shiftContextMenu.Name = "shiftContextMenu";
            shiftContextMenu.Size = new Size(179, 28);
            // 
            // shiftInfo
            // 
            shiftInfo.Name = "shiftInfo";
            shiftInfo.Size = new Size(178, 24);
            shiftInfo.Text = "👁Xem chi tiết";
            shiftInfo.Click += shiftInfo_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.Red;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(931, 84);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(49, 40);
            button2.TabIndex = 16;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.FromArgb(51, 122, 183);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(786, 84);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(126, 40);
            button3.TabIndex = 15;
            button3.Text = "Chọn team";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(570, 84);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "--Tên";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(194, 34);
            textBox1.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(85, 85, 85);
            label3.Location = new Point(510, 89);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 13;
            label3.Text = "Team:";
            // 
            // DailyShiftSummaryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelMain);
            Controls.Add(panelStatus);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DailyShiftSummaryControl";
            Size = new Size(1600, 1040);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelSummaryCards.ResumeLayout(false);
            cardTotalHours.ResumeLayout(false);
            cardTotalHours.PerformLayout();
            cardTotalEmployees.ResumeLayout(false);
            cardTotalEmployees.PerformLayout();
            cardTotalShifts.ResumeLayout(false);
            cardTotalShifts.PerformLayout();
            cardAverageHours.ResumeLayout(false);
            cardAverageHours.PerformLayout();
            groupBoxShiftDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShiftAssignments).EndInit();
            ((System.ComponentModel.ISupportInitialize)shiftAssignmentDtoBindingSource).EndInit();
            panelShiftControls.ResumeLayout(false);
            panelShiftControls.PerformLayout();
            splitContainerCharts.Panel1.ResumeLayout(false);
            splitContainerCharts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerCharts).EndInit();
            splitContainerCharts.ResumeLayout(false);
            groupBoxShiftDistribution.ResumeLayout(false);
            panelShiftChart.ResumeLayout(false);
            groupBoxHourlyBreakdown.ResumeLayout(false);
            panelHourlyChart.ResumeLayout(false);
            panelHourlyChart.PerformLayout();
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            shiftContextMenu.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelSummaryCards;
        private System.Windows.Forms.Panel cardTotalHours;
        private System.Windows.Forms.Label lblTotalHoursValue;
        private System.Windows.Forms.Label lblTotalHoursTitle;
        private System.Windows.Forms.Label iconTotalHours;
        private System.Windows.Forms.Panel cardTotalEmployees;
        private System.Windows.Forms.Label lblTotalEmployeesValue;
        private System.Windows.Forms.Label lblTotalEmployeesTitle;
        private System.Windows.Forms.Label iconTotalEmployees;
        private System.Windows.Forms.Panel cardTotalShifts;
        private System.Windows.Forms.Label lblTotalShiftsValue;
        private System.Windows.Forms.Label lblTotalShiftsTitle;
        private System.Windows.Forms.Label iconTotalShifts;
        private System.Windows.Forms.Panel cardAverageHours;
        private System.Windows.Forms.Label lblAverageHoursValue;
        private System.Windows.Forms.Label lblAverageHoursTitle;
        private System.Windows.Forms.Label iconAverageHours;
        private System.Windows.Forms.GroupBox groupBoxShiftDetails;
        private System.Windows.Forms.DataGridView dgvShiftAssignments;
        private System.Windows.Forms.Panel panelShiftControls;
        private System.Windows.Forms.Label lblShiftFilter;
        private System.Windows.Forms.ComboBox cmbShiftFilter;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.SplitContainer splitContainerCharts;
        private System.Windows.Forms.GroupBox groupBoxShiftDistribution;
        private System.Windows.Forms.Panel panelShiftChart;
        private System.Windows.Forms.GroupBox groupBoxHourlyBreakdown;
        private System.Windows.Forms.Panel panelHourlyChart;
        private System.Windows.Forms.Label lblHourlyChartPlaceholder;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLastUpdated;
        private BindingSource shiftAssignmentDtoBindingSource;
        private DataGridViewTextBoxColumn shiftIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftStartDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftEndDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn expectedHoursDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftTypeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeFirstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeLastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeEmailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn approvedByAccountIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftAssignmentIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftNameDataGridViewTextBoxColumn;
        private Label label1;
        private DateTimePicker dtpToDate;
        private Label lblFrom;
        private DateTimePicker dtpFromDate;
        private ContextMenuStrip shiftContextMenu;
        private ToolStripMenuItem shiftInfo;
        private Label label2;
        private Button button1;
        private TextBox txtEmployee;
        private Button btnDelEmployee;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private ScottPlot.WinForms.FormsPlot formsPlot2;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Label label3;
    }
}