namespace BaseHrm
{
    partial class ShiftDetailForm
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
            groupBoxNotes = new GroupBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            groupBoxWorkingHours = new GroupBox();
            lblActualStartTime = new Label();
            txtActualStartTime = new TextBox();
            lblActualEndTime = new Label();
            txtActualEndTime = new TextBox();
            lblActualHours = new Label();
            txtActualHours = new TextBox();
            lblBreakTime = new Label();
            txtBreakTime = new TextBox();
            lblOvertimeHours = new Label();
            txtOvertimeHours = new TextBox();
            lblWorkingStatus = new Label();
            cmbWorkingStatus = new ComboBox();
            groupBoxEmployeeInfo = new GroupBox();
            changeEmployee = new Button();
            txtPosition = new TextBox();
            lblPostion = new Label();
            lblEmployeeId = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeName = new Label();
            txtEmployeeName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            groupBoxAssignmentInfo = new GroupBox();
            txtAssignmentDate = new DateTimePicker();
            lblAssignmentDate = new Label();
            lblApprovedBy = new Label();
            txtApprovedBy = new TextBox();
            groupBoxShiftInfo = new GroupBox();
            cmbShiftType = new ComboBox();
            lblShiftName = new Label();
            txtShiftName = new TextBox();
            lblStartTime = new Label();
            txtStartTime = new TextBox();
            lblEndTime = new Label();
            txtEndTime = new TextBox();
            lblExpectedHours = new Label();
            txtExpectedHours = new TextBox();
            lblIsOvernight = new Label();
            panelButtons = new Panel();
            btnClose = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxNotes.SuspendLayout();
            groupBoxWorkingHours.SuspendLayout();
            groupBoxEmployeeInfo.SuspendLayout();
            groupBoxAssignmentInfo.SuspendLayout();
            groupBoxShiftInfo.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(102, 16, 242);
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
            lblFormTitle.Size = new Size(353, 41);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "🔍 Chi Tiết Ca Làm Việc";
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(groupBoxNotes);
            panelMain.Controls.Add(groupBoxWorkingHours);
            panelMain.Controls.Add(groupBoxEmployeeInfo);
            panelMain.Controls.Add(groupBoxAssignmentInfo);
            panelMain.Controls.Add(groupBoxShiftInfo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(34, 40, 34, 40);
            panelMain.Size = new Size(1143, 778);
            panelMain.TabIndex = 1;
            // 
            // groupBoxNotes
            // 
            groupBoxNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxNotes.BackColor = Color.White;
            groupBoxNotes.Controls.Add(lblNotes);
            groupBoxNotes.Controls.Add(txtNotes);
            groupBoxNotes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxNotes.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxNotes.Location = new Point(34, 893);
            groupBoxNotes.Margin = new Padding(3, 4, 3, 4);
            groupBoxNotes.Name = "groupBoxNotes";
            groupBoxNotes.Padding = new Padding(23, 27, 23, 27);
            groupBoxNotes.Size = new Size(1053, 160);
            groupBoxNotes.TabIndex = 4;
            groupBoxNotes.TabStop = false;
            groupBoxNotes.Text = "📝 Ghi Chú";
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 10F);
            lblNotes.ForeColor = Color.FromArgb(85, 85, 85);
            lblNotes.Location = new Point(34, 53);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(73, 23);
            lblNotes.TabIndex = 0;
            lblNotes.Text = "Ghi chú:";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 10F);
            txtNotes.Location = new Point(34, 87);
            txtNotes.Margin = new Padding(3, 4, 3, 4);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Nhập ghi chú về ca làm việc...";
            txtNotes.Size = new Size(1005, 52);
            txtNotes.TabIndex = 1;
            // 
            // groupBoxWorkingHours
            // 
            groupBoxWorkingHours.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxWorkingHours.BackColor = Color.White;
            groupBoxWorkingHours.Controls.Add(lblActualStartTime);
            groupBoxWorkingHours.Controls.Add(txtActualStartTime);
            groupBoxWorkingHours.Controls.Add(lblActualEndTime);
            groupBoxWorkingHours.Controls.Add(txtActualEndTime);
            groupBoxWorkingHours.Controls.Add(lblActualHours);
            groupBoxWorkingHours.Controls.Add(txtActualHours);
            groupBoxWorkingHours.Controls.Add(lblBreakTime);
            groupBoxWorkingHours.Controls.Add(txtBreakTime);
            groupBoxWorkingHours.Controls.Add(lblOvertimeHours);
            groupBoxWorkingHours.Controls.Add(txtOvertimeHours);
            groupBoxWorkingHours.Controls.Add(lblWorkingStatus);
            groupBoxWorkingHours.Controls.Add(cmbWorkingStatus);
            groupBoxWorkingHours.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxWorkingHours.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxWorkingHours.Location = new Point(34, 640);
            groupBoxWorkingHours.Margin = new Padding(3, 4, 3, 4);
            groupBoxWorkingHours.Name = "groupBoxWorkingHours";
            groupBoxWorkingHours.Padding = new Padding(23, 27, 23, 27);
            groupBoxWorkingHours.Size = new Size(1053, 201);
            groupBoxWorkingHours.TabIndex = 3;
            groupBoxWorkingHours.TabStop = false;
            groupBoxWorkingHours.Text = "⏱️ Thông Tin Giờ Làm Thực Tế";
            // 
            // lblActualStartTime
            // 
            lblActualStartTime.AutoSize = true;
            lblActualStartTime.Font = new Font("Segoe UI", 10F);
            lblActualStartTime.ForeColor = Color.FromArgb(85, 85, 85);
            lblActualStartTime.Location = new Point(34, 37);
            lblActualStartTime.Name = "lblActualStartTime";
            lblActualStartTime.Size = new Size(163, 23);
            lblActualStartTime.TabIndex = 0;
            lblActualStartTime.Text = "Giờ bắt đầu thực tế:";
            // 
            // txtActualStartTime
            // 
            txtActualStartTime.Font = new Font("Segoe UI", 10F);
            txtActualStartTime.Location = new Point(34, 71);
            txtActualStartTime.Margin = new Padding(3, 4, 3, 4);
            txtActualStartTime.Name = "txtActualStartTime";
            txtActualStartTime.Size = new Size(137, 30);
            txtActualStartTime.TabIndex = 1;
            // 
            // lblActualEndTime
            // 
            lblActualEndTime.AutoSize = true;
            lblActualEndTime.Font = new Font("Segoe UI", 10F);
            lblActualEndTime.ForeColor = Color.FromArgb(85, 85, 85);
            lblActualEndTime.Location = new Point(194, 37);
            lblActualEndTime.Name = "lblActualEndTime";
            lblActualEndTime.Size = new Size(166, 23);
            lblActualEndTime.TabIndex = 2;
            lblActualEndTime.Text = "Giờ kết thúc thực tế:";
            // 
            // txtActualEndTime
            // 
            txtActualEndTime.Font = new Font("Segoe UI", 10F);
            txtActualEndTime.Location = new Point(194, 71);
            txtActualEndTime.Margin = new Padding(3, 4, 3, 4);
            txtActualEndTime.Name = "txtActualEndTime";
            txtActualEndTime.Size = new Size(137, 30);
            txtActualEndTime.TabIndex = 3;
            // 
            // lblActualHours
            // 
            lblActualHours.AutoSize = true;
            lblActualHours.Font = new Font("Segoe UI", 10F);
            lblActualHours.ForeColor = Color.FromArgb(85, 85, 85);
            lblActualHours.Location = new Point(354, 37);
            lblActualHours.Name = "lblActualHours";
            lblActualHours.Size = new Size(121, 23);
            lblActualHours.TabIndex = 4;
            lblActualHours.Text = "Số giờ thực tế:";
            // 
            // txtActualHours
            // 
            txtActualHours.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtActualHours.ForeColor = Color.FromArgb(40, 167, 69);
            txtActualHours.Location = new Point(354, 71);
            txtActualHours.Margin = new Padding(3, 4, 3, 4);
            txtActualHours.Name = "txtActualHours";
            txtActualHours.ReadOnly = true;
            txtActualHours.Size = new Size(137, 30);
            txtActualHours.TabIndex = 5;
            // 
            // lblBreakTime
            // 
            lblBreakTime.AutoSize = true;
            lblBreakTime.Font = new Font("Segoe UI", 10F);
            lblBreakTime.ForeColor = Color.FromArgb(85, 85, 85);
            lblBreakTime.Location = new Point(34, 124);
            lblBreakTime.Name = "lblBreakTime";
            lblBreakTime.Size = new Size(124, 23);
            lblBreakTime.TabIndex = 6;
            lblBreakTime.Text = "Thời gian nghỉ:";
            // 
            // txtBreakTime
            // 
            txtBreakTime.Font = new Font("Segoe UI", 10F);
            txtBreakTime.Location = new Point(34, 157);
            txtBreakTime.Margin = new Padding(3, 4, 3, 4);
            txtBreakTime.Name = "txtBreakTime";
            txtBreakTime.Size = new Size(137, 30);
            txtBreakTime.TabIndex = 7;
            // 
            // lblOvertimeHours
            // 
            lblOvertimeHours.AutoSize = true;
            lblOvertimeHours.Font = new Font("Segoe UI", 10F);
            lblOvertimeHours.ForeColor = Color.FromArgb(85, 85, 85);
            lblOvertimeHours.Location = new Point(194, 124);
            lblOvertimeHours.Name = "lblOvertimeHours";
            lblOvertimeHours.Size = new Size(118, 23);
            lblOvertimeHours.TabIndex = 8;
            lblOvertimeHours.Text = "Giờ làm thêm:";
            // 
            // txtOvertimeHours
            // 
            txtOvertimeHours.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtOvertimeHours.ForeColor = Color.FromArgb(220, 53, 69);
            txtOvertimeHours.Location = new Point(194, 157);
            txtOvertimeHours.Margin = new Padding(3, 4, 3, 4);
            txtOvertimeHours.Name = "txtOvertimeHours";
            txtOvertimeHours.ReadOnly = true;
            txtOvertimeHours.Size = new Size(137, 30);
            txtOvertimeHours.TabIndex = 9;
            // 
            // lblWorkingStatus
            // 
            lblWorkingStatus.AutoSize = true;
            lblWorkingStatus.Font = new Font("Segoe UI", 10F);
            lblWorkingStatus.ForeColor = Color.FromArgb(85, 85, 85);
            lblWorkingStatus.Location = new Point(354, 124);
            lblWorkingStatus.Name = "lblWorkingStatus";
            lblWorkingStatus.Size = new Size(91, 23);
            lblWorkingStatus.TabIndex = 10;
            lblWorkingStatus.Text = "Trạng thái:";
            // 
            // cmbWorkingStatus
            // 
            cmbWorkingStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWorkingStatus.Font = new Font("Segoe UI", 10F);
            cmbWorkingStatus.FormattingEnabled = true;
            cmbWorkingStatus.Items.AddRange(new object[] { "Chưa bắt đầu", "Đang làm việc", "Đã hoàn thành", "Vắng mặt", "Nghỉ phép" });
            cmbWorkingStatus.Location = new Point(354, 157);
            cmbWorkingStatus.Margin = new Padding(3, 4, 3, 4);
            cmbWorkingStatus.Name = "cmbWorkingStatus";
            cmbWorkingStatus.Size = new Size(171, 31);
            cmbWorkingStatus.TabIndex = 11;
            // 
            // groupBoxEmployeeInfo
            // 
            groupBoxEmployeeInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxEmployeeInfo.BackColor = Color.White;
            groupBoxEmployeeInfo.Controls.Add(changeEmployee);
            groupBoxEmployeeInfo.Controls.Add(txtPosition);
            groupBoxEmployeeInfo.Controls.Add(lblPostion);
            groupBoxEmployeeInfo.Controls.Add(lblEmployeeId);
            groupBoxEmployeeInfo.Controls.Add(txtEmployeeId);
            groupBoxEmployeeInfo.Controls.Add(lblEmployeeName);
            groupBoxEmployeeInfo.Controls.Add(txtEmployeeName);
            groupBoxEmployeeInfo.Controls.Add(lblEmail);
            groupBoxEmployeeInfo.Controls.Add(txtEmail);
            groupBoxEmployeeInfo.Controls.Add(lblPhone);
            groupBoxEmployeeInfo.Controls.Add(txtPhone);
            groupBoxEmployeeInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxEmployeeInfo.ForeColor = SystemColors.WindowText;
            groupBoxEmployeeInfo.Location = new Point(34, 413);
            groupBoxEmployeeInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxEmployeeInfo.Name = "groupBoxEmployeeInfo";
            groupBoxEmployeeInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxEmployeeInfo.Size = new Size(1053, 213);
            groupBoxEmployeeInfo.TabIndex = 2;
            groupBoxEmployeeInfo.TabStop = false;
            groupBoxEmployeeInfo.Text = "👤 Thông Tin Nhân Viên";
            // 
            // changeEmployee
            // 
            changeEmployee.Enabled = false;
            changeEmployee.Location = new Point(872, 85);
            changeEmployee.Name = "changeEmployee";
            changeEmployee.Size = new Size(137, 85);
            changeEmployee.TabIndex = 12;
            changeEmployee.Text = "Đổi nhân viên";
            changeEmployee.UseVisualStyleBackColor = true;
            changeEmployee.Visible = false;
            changeEmployee.Click += changeEmployee_Click;
            // 
            // txtPosition
            // 
            txtPosition.Font = new Font("Segoe UI", 10F);
            txtPosition.Location = new Point(571, 86);
            txtPosition.Margin = new Padding(3, 4, 3, 4);
            txtPosition.Name = "txtPosition";
            txtPosition.ReadOnly = true;
            txtPosition.Size = new Size(228, 30);
            txtPosition.TabIndex = 11;
            // 
            // lblPostion
            // 
            lblPostion.AutoSize = true;
            lblPostion.Font = new Font("Segoe UI", 10F);
            lblPostion.ForeColor = Color.FromArgb(85, 85, 85);
            lblPostion.Location = new Point(571, 52);
            lblPostion.Name = "lblPostion";
            lblPostion.Size = new Size(76, 23);
            lblPostion.TabIndex = 10;
            lblPostion.Text = "Chức vụ:";
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 10F);
            lblEmployeeId.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeId.Location = new Point(34, 52);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(118, 23);
            lblEmployeeId.TabIndex = 0;
            lblEmployeeId.Text = "Mã nhân viên:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtEmployeeId.ForeColor = SystemColors.WindowText;
            txtEmployeeId.Location = new Point(34, 86);
            txtEmployeeId.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(176, 30);
            txtEmployeeId.TabIndex = 1;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 10F);
            lblEmployeeName.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeName.Location = new Point(286, 52);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(88, 23);
            lblEmployeeName.TabIndex = 2;
            lblEmployeeName.Text = "Họ và tên:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtEmployeeName.ForeColor = SystemColors.WindowText;
            txtEmployeeName.Location = new Point(286, 86);
            txtEmployeeName.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(192, 30);
            txtEmployeeName.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmail.Location = new Point(34, 140);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(91, 140);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(342, 30);
            txtEmail.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.FromArgb(85, 85, 85);
            lblPhone.Location = new Point(457, 140);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(115, 23);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(571, 140);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(228, 30);
            txtPhone.TabIndex = 9;
            // 
            // groupBoxAssignmentInfo
            // 
            groupBoxAssignmentInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxAssignmentInfo.BackColor = Color.White;
            groupBoxAssignmentInfo.Controls.Add(txtAssignmentDate);
            groupBoxAssignmentInfo.Controls.Add(lblAssignmentDate);
            groupBoxAssignmentInfo.Controls.Add(lblApprovedBy);
            groupBoxAssignmentInfo.Controls.Add(txtApprovedBy);
            groupBoxAssignmentInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxAssignmentInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxAssignmentInfo.Location = new Point(34, 240);
            groupBoxAssignmentInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxAssignmentInfo.Name = "groupBoxAssignmentInfo";
            groupBoxAssignmentInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxAssignmentInfo.Size = new Size(1053, 160);
            groupBoxAssignmentInfo.TabIndex = 1;
            groupBoxAssignmentInfo.TabStop = false;
            groupBoxAssignmentInfo.Text = "📋 Thông Tin Phân Ca";
            // 
            // txtAssignmentDate
            // 
            txtAssignmentDate.Enabled = false;
            txtAssignmentDate.Location = new Point(34, 87);
            txtAssignmentDate.Name = "txtAssignmentDate";
            txtAssignmentDate.Size = new Size(250, 32);
            txtAssignmentDate.TabIndex = 4;
            // 
            // lblAssignmentDate
            // 
            lblAssignmentDate.AutoSize = true;
            lblAssignmentDate.Font = new Font("Segoe UI", 10F);
            lblAssignmentDate.ForeColor = Color.FromArgb(85, 85, 85);
            lblAssignmentDate.Location = new Point(34, 53);
            lblAssignmentDate.Name = "lblAssignmentDate";
            lblAssignmentDate.Size = new Size(120, 23);
            lblAssignmentDate.TabIndex = 0;
            lblAssignmentDate.Text = "Ngày phân ca:";
            // 
            // lblApprovedBy
            // 
            lblApprovedBy.AutoSize = true;
            lblApprovedBy.Font = new Font("Segoe UI", 10F);
            lblApprovedBy.ForeColor = Color.FromArgb(85, 85, 85);
            lblApprovedBy.Location = new Point(335, 53);
            lblApprovedBy.Name = "lblApprovedBy";
            lblApprovedBy.Size = new Size(143, 23);
            lblApprovedBy.TabIndex = 2;
            lblApprovedBy.Text = "Người phê duyệt:";
            // 
            // txtApprovedBy
            // 
            txtApprovedBy.Font = new Font("Segoe UI", 10F);
            txtApprovedBy.Location = new Point(335, 87);
            txtApprovedBy.Margin = new Padding(3, 4, 3, 4);
            txtApprovedBy.Name = "txtApprovedBy";
            txtApprovedBy.ReadOnly = true;
            txtApprovedBy.Size = new Size(285, 30);
            txtApprovedBy.TabIndex = 3;
            // 
            // groupBoxShiftInfo
            // 
            groupBoxShiftInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxShiftInfo.BackColor = Color.White;
            groupBoxShiftInfo.Controls.Add(cmbShiftType);
            groupBoxShiftInfo.Controls.Add(lblShiftName);
            groupBoxShiftInfo.Controls.Add(txtShiftName);
            groupBoxShiftInfo.Controls.Add(lblStartTime);
            groupBoxShiftInfo.Controls.Add(txtStartTime);
            groupBoxShiftInfo.Controls.Add(lblEndTime);
            groupBoxShiftInfo.Controls.Add(txtEndTime);
            groupBoxShiftInfo.Controls.Add(lblExpectedHours);
            groupBoxShiftInfo.Controls.Add(txtExpectedHours);
            groupBoxShiftInfo.Controls.Add(lblIsOvernight);
            groupBoxShiftInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxShiftInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxShiftInfo.Location = new Point(34, 40);
            groupBoxShiftInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxShiftInfo.Name = "groupBoxShiftInfo";
            groupBoxShiftInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxShiftInfo.Size = new Size(1053, 187);
            groupBoxShiftInfo.TabIndex = 0;
            groupBoxShiftInfo.TabStop = false;
            groupBoxShiftInfo.Text = "🕐 Thông Tin Ca Làm";
            // 
            // cmbShiftType
            // 
            cmbShiftType.BackColor = SystemColors.Control;
            cmbShiftType.Enabled = false;
            cmbShiftType.FormattingEnabled = true;
            cmbShiftType.Location = new Point(766, 84);
            cmbShiftType.Name = "cmbShiftType";
            cmbShiftType.Size = new Size(151, 33);
            cmbShiftType.TabIndex = 10;
            // 
            // lblShiftName
            // 
            lblShiftName.AutoSize = true;
            lblShiftName.Font = new Font("Segoe UI", 10F);
            lblShiftName.ForeColor = Color.FromArgb(85, 85, 85);
            lblShiftName.Location = new Point(34, 53);
            lblShiftName.Name = "lblShiftName";
            lblShiftName.Size = new Size(62, 23);
            lblShiftName.TabIndex = 0;
            lblShiftName.Text = "Tên ca:";
            // 
            // txtShiftName
            // 
            txtShiftName.BackColor = SystemColors.Control;
            txtShiftName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtShiftName.ForeColor = SystemColors.WindowText;
            txtShiftName.Location = new Point(34, 87);
            txtShiftName.Margin = new Padding(3, 4, 3, 4);
            txtShiftName.Name = "txtShiftName";
            txtShiftName.ReadOnly = true;
            txtShiftName.Size = new Size(228, 30);
            txtShiftName.TabIndex = 1;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI", 10F);
            lblStartTime.ForeColor = Color.FromArgb(85, 85, 85);
            lblStartTime.Location = new Point(286, 53);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(104, 23);
            lblStartTime.TabIndex = 2;
            lblStartTime.Text = "Giờ bắt đầu:";
            // 
            // txtStartTime
            // 
            txtStartTime.Font = new Font("Segoe UI", 10F);
            txtStartTime.Location = new Point(286, 87);
            txtStartTime.Margin = new Padding(3, 4, 3, 4);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.ReadOnly = true;
            txtStartTime.Size = new Size(137, 30);
            txtStartTime.TabIndex = 3;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Segoe UI", 10F);
            lblEndTime.ForeColor = Color.FromArgb(85, 85, 85);
            lblEndTime.Location = new Point(446, 53);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(107, 23);
            lblEndTime.TabIndex = 4;
            lblEndTime.Text = "Giờ kết thúc:";
            // 
            // txtEndTime
            // 
            txtEndTime.Font = new Font("Segoe UI", 10F);
            txtEndTime.Location = new Point(446, 87);
            txtEndTime.Margin = new Padding(3, 4, 3, 4);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.ReadOnly = true;
            txtEndTime.Size = new Size(137, 30);
            txtEndTime.TabIndex = 5;
            // 
            // lblExpectedHours
            // 
            lblExpectedHours.AutoSize = true;
            lblExpectedHours.Font = new Font("Segoe UI", 10F);
            lblExpectedHours.ForeColor = Color.FromArgb(85, 85, 85);
            lblExpectedHours.Location = new Point(606, 53);
            lblExpectedHours.Name = "lblExpectedHours";
            lblExpectedHours.Size = new Size(123, 23);
            lblExpectedHours.TabIndex = 6;
            lblExpectedHours.Text = "Số giờ dự kiến:";
            // 
            // txtExpectedHours
            // 
            txtExpectedHours.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtExpectedHours.ForeColor = Color.FromArgb(40, 167, 69);
            txtExpectedHours.Location = new Point(606, 87);
            txtExpectedHours.Margin = new Padding(3, 4, 3, 4);
            txtExpectedHours.Name = "txtExpectedHours";
            txtExpectedHours.ReadOnly = true;
            txtExpectedHours.Size = new Size(137, 30);
            txtExpectedHours.TabIndex = 7;
            // 
            // lblIsOvernight
            // 
            lblIsOvernight.AutoSize = true;
            lblIsOvernight.Font = new Font("Segoe UI", 10F);
            lblIsOvernight.ForeColor = Color.FromArgb(85, 85, 85);
            lblIsOvernight.Location = new Point(766, 53);
            lblIsOvernight.Name = "lblIsOvernight";
            lblIsOvernight.Size = new Size(67, 23);
            lblIsOvernight.TabIndex = 8;
            lblIsOvernight.Text = "Loại ca:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 871);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(34, 20, 34, 20);
            panelButtons.Size = new Size(1143, 93);
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
            btnClose.Location = new Point(994, 20);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 53);
            btnClose.TabIndex = 3;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.FromArgb(255, 193, 7);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(68, 68, 68);
            btnEdit.Location = new Point(826, 20);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 53);
            btnEdit.TabIndex = 2;
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
            btnSave.Location = new Point(692, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 53);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ShiftDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 964);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 1011);
            Name = "ShiftDetailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi Tiết Ca Làm Việc";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxNotes.ResumeLayout(false);
            groupBoxNotes.PerformLayout();
            groupBoxWorkingHours.ResumeLayout(false);
            groupBoxWorkingHours.PerformLayout();
            groupBoxEmployeeInfo.ResumeLayout(false);
            groupBoxEmployeeInfo.PerformLayout();
            groupBoxAssignmentInfo.ResumeLayout(false);
            groupBoxAssignmentInfo.PerformLayout();
            groupBoxShiftInfo.ResumeLayout(false);
            groupBoxShiftInfo.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxShiftInfo;
        private System.Windows.Forms.Label lblShiftName;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lblExpectedHours;
        private System.Windows.Forms.TextBox txtExpectedHours;
        private System.Windows.Forms.Label lblIsOvernight;
        private System.Windows.Forms.GroupBox groupBoxAssignmentInfo;
        private System.Windows.Forms.Label lblAssignmentDate;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.GroupBox groupBoxEmployeeInfo;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.GroupBox groupBoxWorkingHours;
        private System.Windows.Forms.Label lblActualStartTime;
        private System.Windows.Forms.TextBox txtActualStartTime;
        private System.Windows.Forms.Label lblActualEndTime;
        private System.Windows.Forms.TextBox txtActualEndTime;
        private System.Windows.Forms.Label lblActualHours;
        private System.Windows.Forms.TextBox txtActualHours;
        private System.Windows.Forms.Label lblBreakTime;
        private System.Windows.Forms.TextBox txtBreakTime;
        private System.Windows.Forms.Label lblOvertimeHours;
        private System.Windows.Forms.TextBox txtOvertimeHours;
        private System.Windows.Forms.Label lblWorkingStatus;
        private System.Windows.Forms.ComboBox cmbWorkingStatus;
        private System.Windows.Forms.GroupBox groupBoxNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private Label lblPostion;
        private TextBox txtPosition;
        private ComboBox cmbShiftType;
        private DateTimePicker txtAssignmentDate;
        private Button changeEmployee;
    }
}