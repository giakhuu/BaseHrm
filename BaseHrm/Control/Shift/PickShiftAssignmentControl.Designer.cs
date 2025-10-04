namespace BaseHrm.Controls
{
    partial class PickShiftAssignmentControl
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
            groupBoxShiftDetails = new GroupBox();
            dgvShiftAssignments = new DataGridView();
            shiftAssignmentIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftStartDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftEndDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            expectedHoursDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftTypeNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeFirstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeLastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeeEmailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeePhoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            employeePositionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            approvedByAccountIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            approverNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            shiftAssignmentDtoBindingSource = new BindingSource(components);
            panelShiftControls = new Panel();
            button2 = new Button();
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
            groupBoxShiftDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShiftAssignments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shiftAssignmentDtoBindingSource).BeginInit();
            panelShiftControls.SuspendLayout();
            SuspendLayout();
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
            groupBoxShiftDetails.TabIndex = 2;
            groupBoxShiftDetails.TabStop = false;
            groupBoxShiftDetails.Text = "📋 Chọn Ca Làm Việc";
            // 
            // dgvShiftAssignments
            // 
            dgvShiftAssignments.AllowUserToAddRows = false;
            dgvShiftAssignments.AllowUserToDeleteRows = false;
            dgvShiftAssignments.AutoGenerateColumns = false;
            dgvShiftAssignments.BackgroundColor = Color.White;
            dgvShiftAssignments.BorderStyle = BorderStyle.None;
            dgvShiftAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShiftAssignments.Columns.AddRange(new DataGridViewColumn[] { shiftAssignmentIdDataGridViewTextBoxColumn, dateDataGridViewTextBoxColumn, shiftIdDataGridViewTextBoxColumn, shiftNameDataGridViewTextBoxColumn, shiftStartDataGridViewTextBoxColumn, shiftEndDataGridViewTextBoxColumn, expectedHoursDataGridViewTextBoxColumn, shiftTypeNameDataGridViewTextBoxColumn, employeeIdDataGridViewTextBoxColumn, employeeFirstNameDataGridViewTextBoxColumn, employeeLastNameDataGridViewTextBoxColumn, employeeFullNameDataGridViewTextBoxColumn, employeeEmailDataGridViewTextBoxColumn, employeePhoneDataGridViewTextBoxColumn, employeePositionDataGridViewTextBoxColumn, approvedByAccountIdDataGridViewTextBoxColumn, approverNameDataGridViewTextBoxColumn });
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
            dgvShiftAssignments.CellMouseDoubleClick += dgvShiftAssignments_CellMouseDoubleClick;
            // 
            // shiftAssignmentIdDataGridViewTextBoxColumn
            // 
            shiftAssignmentIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftAssignmentId";
            shiftAssignmentIdDataGridViewTextBoxColumn.HeaderText = "Mã ca";
            shiftAssignmentIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftAssignmentIdDataGridViewTextBoxColumn.Name = "shiftAssignmentIdDataGridViewTextBoxColumn";
            shiftAssignmentIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftAssignmentIdDataGridViewTextBoxColumn.Width = 125;
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
            // shiftIdDataGridViewTextBoxColumn
            // 
            shiftIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftId";
            shiftIdDataGridViewTextBoxColumn.HeaderText = "ShiftId";
            shiftIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftIdDataGridViewTextBoxColumn.Name = "shiftIdDataGridViewTextBoxColumn";
            shiftIdDataGridViewTextBoxColumn.ReadOnly = true;
            shiftIdDataGridViewTextBoxColumn.Visible = false;
            shiftIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftNameDataGridViewTextBoxColumn
            // 
            shiftNameDataGridViewTextBoxColumn.DataPropertyName = "ShiftName";
            shiftNameDataGridViewTextBoxColumn.HeaderText = "Tên ca";
            shiftNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftNameDataGridViewTextBoxColumn.Name = "shiftNameDataGridViewTextBoxColumn";
            shiftNameDataGridViewTextBoxColumn.ReadOnly = true;
            shiftNameDataGridViewTextBoxColumn.Width = 125;
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
            // employeeFullNameDataGridViewTextBoxColumn
            // 
            employeeFullNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeFullName";
            employeeFullNameDataGridViewTextBoxColumn.HeaderText = "Tên nhân viên";
            employeeFullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeFullNameDataGridViewTextBoxColumn.Name = "employeeFullNameDataGridViewTextBoxColumn";
            employeeFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            employeeFullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeeEmailDataGridViewTextBoxColumn
            // 
            employeeEmailDataGridViewTextBoxColumn.DataPropertyName = "EmployeeEmail";
            employeeEmailDataGridViewTextBoxColumn.HeaderText = "Email";
            employeeEmailDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeeEmailDataGridViewTextBoxColumn.Name = "employeeEmailDataGridViewTextBoxColumn";
            employeeEmailDataGridViewTextBoxColumn.ReadOnly = true;
            employeeEmailDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeePhoneDataGridViewTextBoxColumn
            // 
            employeePhoneDataGridViewTextBoxColumn.DataPropertyName = "EmployeePhone";
            employeePhoneDataGridViewTextBoxColumn.HeaderText = "EmployeePhone";
            employeePhoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeePhoneDataGridViewTextBoxColumn.Name = "employeePhoneDataGridViewTextBoxColumn";
            employeePhoneDataGridViewTextBoxColumn.ReadOnly = true;
            employeePhoneDataGridViewTextBoxColumn.Visible = false;
            employeePhoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // employeePositionDataGridViewTextBoxColumn
            // 
            employeePositionDataGridViewTextBoxColumn.DataPropertyName = "EmployeePosition";
            employeePositionDataGridViewTextBoxColumn.HeaderText = "Chức vụ";
            employeePositionDataGridViewTextBoxColumn.MinimumWidth = 6;
            employeePositionDataGridViewTextBoxColumn.Name = "employeePositionDataGridViewTextBoxColumn";
            employeePositionDataGridViewTextBoxColumn.ReadOnly = true;
            employeePositionDataGridViewTextBoxColumn.Width = 125;
            // 
            // approvedByAccountIdDataGridViewTextBoxColumn
            // 
            approvedByAccountIdDataGridViewTextBoxColumn.DataPropertyName = "ApprovedByAccountId";
            approvedByAccountIdDataGridViewTextBoxColumn.HeaderText = "ApprovedByAccountId";
            approvedByAccountIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            approvedByAccountIdDataGridViewTextBoxColumn.Name = "approvedByAccountIdDataGridViewTextBoxColumn";
            approvedByAccountIdDataGridViewTextBoxColumn.ReadOnly = true;
            approvedByAccountIdDataGridViewTextBoxColumn.Visible = false;
            approvedByAccountIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // approverNameDataGridViewTextBoxColumn
            // 
            approverNameDataGridViewTextBoxColumn.DataPropertyName = "ApproverName";
            approverNameDataGridViewTextBoxColumn.HeaderText = "Người giao ca";
            approverNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            approverNameDataGridViewTextBoxColumn.Name = "approverNameDataGridViewTextBoxColumn";
            approverNameDataGridViewTextBoxColumn.ReadOnly = true;
            approverNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // shiftAssignmentDtoBindingSource
            // 
            shiftAssignmentDtoBindingSource.DataSource = typeof(Data.DTO.ShiftAssignmentDto);
            // 
            // panelShiftControls
            // 
            panelShiftControls.BackColor = Color.FromArgb(248, 249, 250);
            panelShiftControls.Controls.Add(button2);
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
            panelShiftControls.Dock = DockStyle.Top;
            panelShiftControls.Location = new Point(17, 47);
            panelShiftControls.Margin = new Padding(3, 4, 3, 4);
            panelShiftControls.Name = "panelShiftControls";
            panelShiftControls.Padding = new Padding(11, 13, 11, 13);
            panelShiftControls.Size = new Size(994, 156);
            panelShiftControls.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(51, 122, 183);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(774, 87);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(132, 54);
            button2.TabIndex = 13;
            button2.Text = "Lưu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnDelEmployee
            // 
            btnDelEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelEmployee.BackColor = Color.Red;
            btnDelEmployee.FlatAppearance.BorderSize = 0;
            btnDelEmployee.FlatStyle = FlatStyle.Flat;
            btnDelEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelEmployee.ForeColor = Color.White;
            btnDelEmployee.Location = new Point(509, 97);
            btnDelEmployee.Margin = new Padding(3, 4, 3, 4);
            btnDelEmployee.Name = "btnDelEmployee";
            btnDelEmployee.Size = new Size(49, 34);
            btnDelEmployee.TabIndex = 12;
            btnDelEmployee.Text = "Xóa";
            btnDelEmployee.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(51, 122, 183);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(358, 97);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(126, 34);
            button1.TabIndex = 11;
            button1.Text = "Chọn nhân viên";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtEmployee
            // 
            txtEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmployee.Location = new Point(134, 97);
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
            label2.Location = new Point(22, 105);
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
            label1.Location = new Point(631, 53);
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
            dtpToDate.Location = new Point(729, 45);
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
            lblFrom.Location = new Point(314, 53);
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
            dtpFromDate.Location = new Point(416, 45);
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
            lblShiftFilter.Location = new Point(22, 53);
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
            cmbShiftFilter.Location = new Point(109, 45);
            cmbShiftFilter.Margin = new Padding(3, 4, 3, 4);
            cmbShiftFilter.Name = "cmbShiftFilter";
            cmbShiftFilter.Size = new Size(171, 31);
            cmbShiftFilter.TabIndex = 1;
            cmbShiftFilter.SelectedIndexChanged += cmbShiftFilter_SelectedIndexChanged;
            // 
            // PickShiftAssignmentControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxShiftDetails);
            Name = "PickShiftAssignmentControl";
            Size = new Size(1028, 635);
            groupBoxShiftDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShiftAssignments).EndInit();
            ((System.ComponentModel.ISupportInitialize)shiftAssignmentDtoBindingSource).EndInit();
            panelShiftControls.ResumeLayout(false);
            panelShiftControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxShiftDetails;
        private DataGridView dgvShiftAssignments;
        private Panel panelShiftControls;
        private Button btnDelEmployee;
        private Button button1;
        private TextBox txtEmployee;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpToDate;
        private Label lblFrom;
        private DateTimePicker dtpFromDate;
        private Label lblShiftFilter;
        private ComboBox cmbShiftFilter;
        private BindingSource shiftAssignmentDtoBindingSource;
        private DataGridViewTextBoxColumn shiftAssignmentIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftStartDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftEndDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn expectedHoursDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn shiftTypeNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeFirstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeLastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeEmailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeePhoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeePositionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn approvedByAccountIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn approverNameDataGridViewTextBoxColumn;
        private Button button2;
    }
}
