namespace BaseHrm
{
    partial class AddAttendanceRecordForm
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
            panelHeader = new Panel();
            lblFormTitle = new Label();
            panelMain = new Panel();
            groupBoxTimeInfo = new GroupBox();
            lblCheckOut = new Label();
            dtpCheckOut = new DateTimePicker();
            chkHasCheckOut = new CheckBox();
            lblCheckIn = new Label();
            dtpCheckIn = new DateTimePicker();
            lblDuration = new Label();
            numDurationHours = new NumericUpDown();
            groupBoxShiftInfo = new GroupBox();
            panelShiftDetails = new Panel();
            btnPickShift = new Button();
            txtExpectedHours = new Label();
            label2 = new Label();
            txtShiftToTime = new TextBox();
            label1 = new Label();
            txtShiftId = new TextBox();
            lblShiftName = new Label();
            txtShiftName = new TextBox();
            lblShiftTime = new Label();
            txtShiftFromTime = new TextBox();
            lblExpectedHours = new Label();
            groupBoxEmployeeInfo = new GroupBox();
            panelEmployeeDetails = new Panel();
            lblEmployeeId = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeName = new Label();
            txtEmployeeName = new TextBox();
            lblEmployeePosition = new Label();
            txtEmployeePosition = new TextBox();
            lblEmployeeEmail = new Label();
            txtEmployeeEmail = new TextBox();
            panelButtons = new Panel();
            btnEdit = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxTimeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDurationHours).BeginInit();
            groupBoxShiftInfo.SuspendLayout();
            panelShiftDetails.SuspendLayout();
            groupBoxEmployeeInfo.SuspendLayout();
            panelEmployeeDetails.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(40, 167, 69);
            panelHeader.Controls.Add(lblFormTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1143, 93);
            panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(23, 27);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(434, 41);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "➕ Thêm Bản Ghi Chấm Công";
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(groupBoxTimeInfo);
            panelMain.Controls.Add(groupBoxShiftInfo);
            panelMain.Controls.Add(groupBoxEmployeeInfo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(34, 40, 34, 40);
            panelMain.Size = new Size(1143, 774);
            panelMain.TabIndex = 1;
            // 
            // groupBoxTimeInfo
            // 
            groupBoxTimeInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxTimeInfo.BackColor = Color.White;
            groupBoxTimeInfo.Controls.Add(lblCheckOut);
            groupBoxTimeInfo.Controls.Add(dtpCheckOut);
            groupBoxTimeInfo.Controls.Add(chkHasCheckOut);
            groupBoxTimeInfo.Controls.Add(lblCheckIn);
            groupBoxTimeInfo.Controls.Add(dtpCheckIn);
            groupBoxTimeInfo.Controls.Add(lblDuration);
            groupBoxTimeInfo.Controls.Add(numDurationHours);
            groupBoxTimeInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxTimeInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxTimeInfo.Location = new Point(34, 600);
            groupBoxTimeInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxTimeInfo.Name = "groupBoxTimeInfo";
            groupBoxTimeInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxTimeInfo.Size = new Size(1042, 240);
            groupBoxTimeInfo.TabIndex = 2;
            groupBoxTimeInfo.TabStop = false;
            groupBoxTimeInfo.Text = "⏰ Thông Tin Thời Gian";
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 10F);
            lblCheckOut.ForeColor = Color.FromArgb(85, 85, 85);
            lblCheckOut.Location = new Point(34, 160);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(60, 23);
            lblCheckOut.TabIndex = 5;
            lblCheckOut.Text = "Giờ ra:";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpCheckOut.Enabled = false;
            dtpCheckOut.Font = new Font("Segoe UI", 10F);
            dtpCheckOut.Format = DateTimePickerFormat.Custom;
            dtpCheckOut.Location = new Point(114, 160);
            dtpCheckOut.Margin = new Padding(3, 4, 3, 4);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(228, 30);
            dtpCheckOut.TabIndex = 6;
            // 
            // chkHasCheckOut
            // 
            chkHasCheckOut.AutoSize = true;
            chkHasCheckOut.Font = new Font("Segoe UI", 10F);
            chkHasCheckOut.ForeColor = Color.FromArgb(0, 123, 255);
            chkHasCheckOut.Location = new Point(366, 160);
            chkHasCheckOut.Margin = new Padding(3, 4, 3, 4);
            chkHasCheckOut.Name = "chkHasCheckOut";
            chkHasCheckOut.Size = new Size(160, 27);
            chkHasCheckOut.TabIndex = 7;
            chkHasCheckOut.Text = "🚪 Đã check out";
            chkHasCheckOut.UseVisualStyleBackColor = true;
            chkHasCheckOut.CheckedChanged += chkHasCheckOut_CheckedChanged;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 10F);
            lblCheckIn.ForeColor = Color.FromArgb(85, 85, 85);
            lblCheckIn.Location = new Point(34, 100);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(72, 23);
            lblCheckIn.TabIndex = 1;
            lblCheckIn.Text = "Giờ vào:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpCheckIn.Font = new Font("Segoe UI", 10F);
            dtpCheckIn.Format = DateTimePickerFormat.Custom;
            dtpCheckIn.Location = new Point(114, 100);
            dtpCheckIn.Margin = new Padding(3, 4, 3, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(228, 30);
            dtpCheckIn.TabIndex = 2;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Font = new Font("Segoe UI", 10F);
            lblDuration.ForeColor = Color.FromArgb(85, 85, 85);
            lblDuration.Location = new Point(549, 100);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(87, 23);
            lblDuration.TabIndex = 3;
            lblDuration.Text = "Số giờ (h):";
            // 
            // numDurationHours
            // 
            numDurationHours.DecimalPlaces = 2;
            numDurationHours.Enabled = false;
            numDurationHours.Font = new Font("Segoe UI", 10F);
            numDurationHours.Location = new Point(651, 100);
            numDurationHours.Margin = new Padding(3, 4, 3, 4);
            numDurationHours.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numDurationHours.Name = "numDurationHours";
            numDurationHours.ReadOnly = true;
            numDurationHours.Size = new Size(137, 30);
            numDurationHours.TabIndex = 4;
            // 
            // groupBoxShiftInfo
            // 
            groupBoxShiftInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxShiftInfo.BackColor = Color.White;
            groupBoxShiftInfo.Controls.Add(panelShiftDetails);
            groupBoxShiftInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxShiftInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxShiftInfo.Location = new Point(34, 38);
            groupBoxShiftInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxShiftInfo.Name = "groupBoxShiftInfo";
            groupBoxShiftInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxShiftInfo.Size = new Size(1042, 267);
            groupBoxShiftInfo.TabIndex = 1;
            groupBoxShiftInfo.TabStop = false;
            groupBoxShiftInfo.Text = "🕐 Thông Tin Ca Làm";
            // 
            // panelShiftDetails
            // 
            panelShiftDetails.Controls.Add(btnPickShift);
            panelShiftDetails.Controls.Add(txtExpectedHours);
            panelShiftDetails.Controls.Add(label2);
            panelShiftDetails.Controls.Add(txtShiftToTime);
            panelShiftDetails.Controls.Add(label1);
            panelShiftDetails.Controls.Add(txtShiftId);
            panelShiftDetails.Controls.Add(lblShiftName);
            panelShiftDetails.Controls.Add(txtShiftName);
            panelShiftDetails.Controls.Add(lblShiftTime);
            panelShiftDetails.Controls.Add(txtShiftFromTime);
            panelShiftDetails.Controls.Add(lblExpectedHours);
            panelShiftDetails.Dock = DockStyle.Fill;
            panelShiftDetails.Location = new Point(23, 52);
            panelShiftDetails.Margin = new Padding(3, 4, 3, 4);
            panelShiftDetails.Name = "panelShiftDetails";
            panelShiftDetails.Size = new Size(996, 188);
            panelShiftDetails.TabIndex = 1;
            // 
            // btnPickShift
            // 
            btnPickShift.BackColor = Color.Blue;
            btnPickShift.ForeColor = Color.White;
            btnPickShift.Location = new Point(25, 134);
            btnPickShift.Name = "btnPickShift";
            btnPickShift.Size = new Size(209, 39);
            btnPickShift.TabIndex = 13;
            btnPickShift.Text = "🕐 Chọn ca làm";
            btnPickShift.UseVisualStyleBackColor = false;
            btnPickShift.Click += btnPickShift_Click;
            // 
            // txtExpectedHours
            // 
            txtExpectedHours.AutoSize = true;
            txtExpectedHours.Location = new Point(890, 138);
            txtExpectedHours.Name = "txtExpectedHours";
            txtExpectedHours.Size = new Size(39, 25);
            txtExpectedHours.TabIndex = 12;
            txtExpectedHours.Text = "0.0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(85, 85, 85);
            label2.Location = new Point(371, 85);
            label2.Name = "label2";
            label2.Size = new Size(152, 23);
            label2.TabIndex = 10;
            label2.Text = "Thời gian kết thúc:";
            // 
            // txtShiftToTime
            // 
            txtShiftToTime.Font = new Font("Segoe UI", 10F);
            txtShiftToTime.Location = new Point(526, 79);
            txtShiftToTime.Margin = new Padding(3, 4, 3, 4);
            txtShiftToTime.Name = "txtShiftToTime";
            txtShiftToTime.ReadOnly = true;
            txtShiftToTime.Size = new Size(228, 30);
            txtShiftToTime.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.FromArgb(85, 85, 85);
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 8;
            label1.Text = "Mã ca làm:";
            // 
            // txtShiftId
            // 
            txtShiftId.Font = new Font("Segoe UI", 10F);
            txtShiftId.Location = new Point(145, 18);
            txtShiftId.Margin = new Padding(3, 4, 3, 4);
            txtShiftId.Name = "txtShiftId";
            txtShiftId.ReadOnly = true;
            txtShiftId.Size = new Size(163, 30);
            txtShiftId.TabIndex = 9;
            // 
            // lblShiftName
            // 
            lblShiftName.AutoSize = true;
            lblShiftName.Font = new Font("Segoe UI", 10F);
            lblShiftName.ForeColor = Color.FromArgb(85, 85, 85);
            lblShiftName.Location = new Point(22, 79);
            lblShiftName.Name = "lblShiftName";
            lblShiftName.Size = new Size(62, 23);
            lblShiftName.TabIndex = 0;
            lblShiftName.Text = "Tên ca:";
            // 
            // txtShiftName
            // 
            txtShiftName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtShiftName.ForeColor = Color.FromArgb(0, 123, 255);
            txtShiftName.Location = new Point(145, 79);
            txtShiftName.Margin = new Padding(3, 4, 3, 4);
            txtShiftName.Name = "txtShiftName";
            txtShiftName.ReadOnly = true;
            txtShiftName.Size = new Size(163, 30);
            txtShiftName.TabIndex = 1;
            // 
            // lblShiftTime
            // 
            lblShiftTime.AutoSize = true;
            lblShiftTime.Font = new Font("Segoe UI", 10F);
            lblShiftTime.ForeColor = Color.FromArgb(85, 85, 85);
            lblShiftTime.Location = new Point(371, 27);
            lblShiftTime.Name = "lblShiftTime";
            lblShiftTime.Size = new Size(149, 23);
            lblShiftTime.TabIndex = 2;
            lblShiftTime.Text = "Thời gian bắt đầu:";
            // 
            // txtShiftFromTime
            // 
            txtShiftFromTime.Font = new Font("Segoe UI", 10F);
            txtShiftFromTime.Location = new Point(526, 21);
            txtShiftFromTime.Margin = new Padding(3, 4, 3, 4);
            txtShiftFromTime.Name = "txtShiftFromTime";
            txtShiftFromTime.ReadOnly = true;
            txtShiftFromTime.Size = new Size(228, 30);
            txtShiftFromTime.TabIndex = 3;
            // 
            // lblExpectedHours
            // 
            lblExpectedHours.AutoSize = true;
            lblExpectedHours.Font = new Font("Segoe UI", 10F);
            lblExpectedHours.ForeColor = Color.FromArgb(85, 85, 85);
            lblExpectedHours.Location = new Point(765, 140);
            lblExpectedHours.Name = "lblExpectedHours";
            lblExpectedHours.Size = new Size(101, 23);
            lblExpectedHours.TabIndex = 4;
            lblExpectedHours.Text = "Giờ dự kiến:";
            // 
            // groupBoxEmployeeInfo
            // 
            groupBoxEmployeeInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEmployeeInfo.BackColor = Color.White;
            groupBoxEmployeeInfo.Controls.Add(panelEmployeeDetails);
            groupBoxEmployeeInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxEmployeeInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxEmployeeInfo.Location = new Point(37, 313);
            groupBoxEmployeeInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxEmployeeInfo.Name = "groupBoxEmployeeInfo";
            groupBoxEmployeeInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxEmployeeInfo.Size = new Size(1039, 267);
            groupBoxEmployeeInfo.TabIndex = 0;
            groupBoxEmployeeInfo.TabStop = false;
            groupBoxEmployeeInfo.Text = "👤 Thông Tin Nhân Viên";
            // 
            // panelEmployeeDetails
            // 
            panelEmployeeDetails.Controls.Add(lblEmployeeId);
            panelEmployeeDetails.Controls.Add(txtEmployeeId);
            panelEmployeeDetails.Controls.Add(lblEmployeeName);
            panelEmployeeDetails.Controls.Add(txtEmployeeName);
            panelEmployeeDetails.Controls.Add(lblEmployeePosition);
            panelEmployeeDetails.Controls.Add(txtEmployeePosition);
            panelEmployeeDetails.Controls.Add(lblEmployeeEmail);
            panelEmployeeDetails.Controls.Add(txtEmployeeEmail);
            panelEmployeeDetails.Dock = DockStyle.Fill;
            panelEmployeeDetails.Location = new Point(23, 52);
            panelEmployeeDetails.Margin = new Padding(3, 4, 3, 4);
            panelEmployeeDetails.Name = "panelEmployeeDetails";
            panelEmployeeDetails.Size = new Size(993, 188);
            panelEmployeeDetails.TabIndex = 1;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 10F);
            lblEmployeeId.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeId.Location = new Point(11, 20);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(67, 23);
            lblEmployeeId.TabIndex = 0;
            lblEmployeeId.Text = "Mã NV:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtEmployeeId.ForeColor = Color.FromArgb(51, 122, 183);
            txtEmployeeId.Location = new Point(80, 20);
            txtEmployeeId.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(342, 30);
            txtEmployeeId.TabIndex = 1;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 10F);
            lblEmployeeName.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeName.Location = new Point(539, 33);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(88, 23);
            lblEmployeeName.TabIndex = 2;
            lblEmployeeName.Text = "Họ và tên:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtEmployeeName.ForeColor = Color.FromArgb(40, 167, 69);
            txtEmployeeName.Location = new Point(635, 30);
            txtEmployeeName.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(321, 30);
            txtEmployeeName.TabIndex = 3;
            // 
            // lblEmployeePosition
            // 
            lblEmployeePosition.AutoSize = true;
            lblEmployeePosition.Font = new Font("Segoe UI", 10F);
            lblEmployeePosition.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeePosition.Location = new Point(551, 89);
            lblEmployeePosition.Name = "lblEmployeePosition";
            lblEmployeePosition.Size = new Size(76, 23);
            lblEmployeePosition.TabIndex = 4;
            lblEmployeePosition.Text = "Chức vụ:";
            // 
            // txtEmployeePosition
            // 
            txtEmployeePosition.Font = new Font("Segoe UI", 10F);
            txtEmployeePosition.Location = new Point(635, 86);
            txtEmployeePosition.Margin = new Padding(3, 4, 3, 4);
            txtEmployeePosition.Name = "txtEmployeePosition";
            txtEmployeePosition.ReadOnly = true;
            txtEmployeePosition.Size = new Size(321, 30);
            txtEmployeePosition.TabIndex = 5;
            // 
            // lblEmployeeEmail
            // 
            lblEmployeeEmail.AutoSize = true;
            lblEmployeeEmail.Font = new Font("Segoe UI", 10F);
            lblEmployeeEmail.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeEmail.Location = new Point(11, 86);
            lblEmployeeEmail.Name = "lblEmployeeEmail";
            lblEmployeeEmail.Size = new Size(55, 23);
            lblEmployeeEmail.TabIndex = 6;
            lblEmployeeEmail.Text = "Email:";
            // 
            // txtEmployeeEmail
            // 
            txtEmployeeEmail.Font = new Font("Segoe UI", 10F);
            txtEmployeeEmail.Location = new Point(80, 86);
            txtEmployeeEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeEmail.Name = "txtEmployeeEmail";
            txtEmployeeEmail.ReadOnly = true;
            txtEmployeeEmail.Size = new Size(342, 30);
            txtEmployeeEmail.TabIndex = 7;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 867);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(34, 20, 34, 20);
            panelButtons.Size = new Size(1143, 93);
            panelButtons.TabIndex = 2;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.Goldenrod;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(728, 20);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 53);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(983, 20);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 53);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
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
            btnSave.Location = new Point(857, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 53);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // AddAttendanceRecordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 960);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 944);
            Name = "AddAttendanceRecordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Bản Ghi Chấm Công";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxTimeInfo.ResumeLayout(false);
            groupBoxTimeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDurationHours).EndInit();
            groupBoxShiftInfo.ResumeLayout(false);
            panelShiftDetails.ResumeLayout(false);
            panelShiftDetails.PerformLayout();
            groupBoxEmployeeInfo.ResumeLayout(false);
            panelEmployeeDetails.ResumeLayout(false);
            panelEmployeeDetails.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxEmployeeInfo;
        private System.Windows.Forms.Panel panelEmployeeDetails;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmployeePosition;
        private System.Windows.Forms.TextBox txtEmployeePosition;
        private System.Windows.Forms.Label lblEmployeeEmail;
        private System.Windows.Forms.TextBox txtEmployeeEmail;
        private System.Windows.Forms.GroupBox groupBoxShiftInfo;
        private System.Windows.Forms.Panel panelShiftDetails;
        private System.Windows.Forms.Label lblShiftName;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.Label lblShiftTime;
        private System.Windows.Forms.TextBox txtShiftFromTime;
        private System.Windows.Forms.Label lblExpectedHours;
        private System.Windows.Forms.GroupBox groupBoxTimeInfo;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.NumericUpDown numDurationHours;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.CheckBox chkHasCheckOut;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Label label1;
        private TextBox txtShiftId;
        private Button btnPickShift;
        private Label txtExpectedHours;
        private Label label2;
        private TextBox txtShiftToTime;
        private Button btnEdit;
    }
}