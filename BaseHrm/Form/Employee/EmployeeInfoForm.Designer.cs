namespace BaseHrm
{
    partial class EmployeeInfoForm
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
            groupBoxWorkInfo = new GroupBox();
            lblMaxHoursPerMonth = new Label();
            txtMaxHoursPerMonth = new TextBox();
            lblMaxHoursPerDay = new Label();
            txtMaxHoursPerDay = new TextBox();
            lblPosition = new Label();
            cmbPosition = new ComboBox();
            lblHireDate = new Label();
            dtpHireDate = new DateTimePicker();
            lblStatus = new Label();
            chkIsActive = new CheckBox();
            groupBoxContactInfo = new GroupBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            groupBoxPersonalInfo = new GroupBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblEmployeeId = new Label();
            txtEmployeeId = new TextBox();
            panelButtons = new Panel();
            btnClose = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxWorkInfo.SuspendLayout();
            groupBoxContactInfo.SuspendLayout();
            groupBoxPersonalInfo.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(51, 122, 183);
            panelHeader.Controls.Add(lblFormTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(1029, 93);
            panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(23, 27);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(317, 41);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Thông Tin Nhân Viên";
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(groupBoxWorkInfo);
            panelMain.Controls.Add(groupBoxContactInfo);
            panelMain.Controls.Add(groupBoxPersonalInfo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 93);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(34, 40, 34, 40);
            panelMain.Size = new Size(1029, 694);
            panelMain.TabIndex = 1;
            // 
            // groupBoxWorkInfo
            // 
            groupBoxWorkInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxWorkInfo.BackColor = Color.White;
            groupBoxWorkInfo.Controls.Add(lblMaxHoursPerMonth);
            groupBoxWorkInfo.Controls.Add(txtMaxHoursPerMonth);
            groupBoxWorkInfo.Controls.Add(lblMaxHoursPerDay);
            groupBoxWorkInfo.Controls.Add(txtMaxHoursPerDay);
            groupBoxWorkInfo.Controls.Add(lblPosition);
            groupBoxWorkInfo.Controls.Add(cmbPosition);
            groupBoxWorkInfo.Controls.Add(lblHireDate);
            groupBoxWorkInfo.Controls.Add(dtpHireDate);
            groupBoxWorkInfo.Controls.Add(lblStatus);
            groupBoxWorkInfo.Controls.Add(chkIsActive);
            groupBoxWorkInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxWorkInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxWorkInfo.Location = new Point(34, 520);
            groupBoxWorkInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxWorkInfo.Name = "groupBoxWorkInfo";
            groupBoxWorkInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxWorkInfo.Size = new Size(939, 267);
            groupBoxWorkInfo.TabIndex = 2;
            groupBoxWorkInfo.TabStop = false;
            groupBoxWorkInfo.Text = "📋 Thông Tin Công Việc";
            // 
            // lblMaxHoursPerMonth
            // 
            lblMaxHoursPerMonth.AutoSize = true;
            lblMaxHoursPerMonth.Font = new Font("Segoe UI", 10F);
            lblMaxHoursPerMonth.ForeColor = Color.FromArgb(85, 85, 85);
            lblMaxHoursPerMonth.Location = new Point(491, 173);
            lblMaxHoursPerMonth.Name = "lblMaxHoursPerMonth";
            lblMaxHoursPerMonth.Size = new Size(166, 23);
            lblMaxHoursPerMonth.TabIndex = 9;
            lblMaxHoursPerMonth.Text = "Giờ tối đa/tháng (h):";
            // 
            // txtMaxHoursPerMonth
            // 
            txtMaxHoursPerMonth.Font = new Font("Segoe UI", 10F);
            txtMaxHoursPerMonth.Location = new Point(491, 207);
            txtMaxHoursPerMonth.Margin = new Padding(3, 4, 3, 4);
            txtMaxHoursPerMonth.Name = "txtMaxHoursPerMonth";
            txtMaxHoursPerMonth.ReadOnly = true;
            txtMaxHoursPerMonth.Size = new Size(285, 30);
            txtMaxHoursPerMonth.TabIndex = 10;
            // 
            // lblMaxHoursPerDay
            // 
            lblMaxHoursPerDay.AutoSize = true;
            lblMaxHoursPerDay.Font = new Font("Segoe UI", 10F);
            lblMaxHoursPerDay.ForeColor = Color.FromArgb(85, 85, 85);
            lblMaxHoursPerDay.Location = new Point(491, 100);
            lblMaxHoursPerDay.Name = "lblMaxHoursPerDay";
            lblMaxHoursPerDay.Size = new Size(158, 23);
            lblMaxHoursPerDay.TabIndex = 7;
            lblMaxHoursPerDay.Text = "Giờ tối đa/ngày (h):";
            // 
            // txtMaxHoursPerDay
            // 
            txtMaxHoursPerDay.Font = new Font("Segoe UI", 10F);
            txtMaxHoursPerDay.Location = new Point(491, 133);
            txtMaxHoursPerDay.Margin = new Padding(3, 4, 3, 4);
            txtMaxHoursPerDay.Name = "txtMaxHoursPerDay";
            txtMaxHoursPerDay.ReadOnly = true;
            txtMaxHoursPerDay.Size = new Size(285, 30);
            txtMaxHoursPerDay.TabIndex = 8;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Font = new Font("Segoe UI", 10F);
            lblPosition.ForeColor = Color.FromArgb(85, 85, 85);
            lblPosition.Location = new Point(34, 173);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(76, 23);
            lblPosition.TabIndex = 5;
            lblPosition.Text = "Chức vụ:";
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.Enabled = false;
            cmbPosition.Font = new Font("Segoe UI", 10F);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(34, 207);
            cmbPosition.Margin = new Padding(3, 4, 3, 4);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(399, 31);
            cmbPosition.TabIndex = 6;
            // 
            // lblHireDate
            // 
            lblHireDate.AutoSize = true;
            lblHireDate.Font = new Font("Segoe UI", 10F);
            lblHireDate.ForeColor = Color.FromArgb(85, 85, 85);
            lblHireDate.Location = new Point(34, 100);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(119, 23);
            lblHireDate.TabIndex = 3;
            lblHireDate.Text = "Ngày vào làm:";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Enabled = false;
            dtpHireDate.Font = new Font("Segoe UI", 10F);
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(34, 133);
            dtpHireDate.Margin = new Padding(3, 4, 3, 4);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(228, 30);
            dtpHireDate.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(85, 85, 85);
            lblStatus.Location = new Point(34, 53);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Trạng thái:";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Enabled = false;
            chkIsActive.Font = new Font("Segoe UI", 10F);
            chkIsActive.ForeColor = Color.FromArgb(40, 167, 69);
            chkIsActive.Location = new Point(137, 53);
            chkIsActive.Margin = new Padding(3, 4, 3, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(114, 27);
            chkIsActive.TabIndex = 2;
            chkIsActive.Text = "Hoạt động";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // groupBoxContactInfo
            // 
            groupBoxContactInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxContactInfo.BackColor = Color.White;
            groupBoxContactInfo.Controls.Add(lblAddress);
            groupBoxContactInfo.Controls.Add(txtAddress);
            groupBoxContactInfo.Controls.Add(lblPhone);
            groupBoxContactInfo.Controls.Add(txtPhone);
            groupBoxContactInfo.Controls.Add(lblEmail);
            groupBoxContactInfo.Controls.Add(txtEmail);
            groupBoxContactInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxContactInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxContactInfo.Location = new Point(34, 320);
            groupBoxContactInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxContactInfo.Name = "groupBoxContactInfo";
            groupBoxContactInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxContactInfo.Size = new Size(939, 187);
            groupBoxContactInfo.TabIndex = 1;
            groupBoxContactInfo.TabStop = false;
            groupBoxContactInfo.Text = "📞 Thông Tin Liên Hệ";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F);
            lblAddress.ForeColor = Color.FromArgb(85, 85, 85);
            lblAddress.Location = new Point(34, 100);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(66, 23);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(34, 133);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(891, 30);
            txtAddress.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.FromArgb(85, 85, 85);
            lblPhone.Location = new Point(491, 53);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(115, 23);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(606, 53);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(319, 30);
            txtPhone.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmail.Location = new Point(34, 53);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(91, 53);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(365, 30);
            txtEmail.TabIndex = 2;
            // 
            // groupBoxPersonalInfo
            // 
            groupBoxPersonalInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxPersonalInfo.BackColor = Color.White;
            groupBoxPersonalInfo.Controls.Add(lblGender);
            groupBoxPersonalInfo.Controls.Add(cmbGender);
            groupBoxPersonalInfo.Controls.Add(lblDateOfBirth);
            groupBoxPersonalInfo.Controls.Add(dtpDateOfBirth);
            groupBoxPersonalInfo.Controls.Add(lblLastName);
            groupBoxPersonalInfo.Controls.Add(txtLastName);
            groupBoxPersonalInfo.Controls.Add(lblFirstName);
            groupBoxPersonalInfo.Controls.Add(txtFirstName);
            groupBoxPersonalInfo.Controls.Add(lblEmployeeId);
            groupBoxPersonalInfo.Controls.Add(txtEmployeeId);
            groupBoxPersonalInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxPersonalInfo.ForeColor = Color.FromArgb(68, 68, 68);
            groupBoxPersonalInfo.Location = new Point(34, 40);
            groupBoxPersonalInfo.Margin = new Padding(3, 4, 3, 4);
            groupBoxPersonalInfo.Name = "groupBoxPersonalInfo";
            groupBoxPersonalInfo.Padding = new Padding(23, 27, 23, 27);
            groupBoxPersonalInfo.Size = new Size(939, 267);
            groupBoxPersonalInfo.TabIndex = 0;
            groupBoxPersonalInfo.TabStop = false;
            groupBoxPersonalInfo.Text = "👤 Thông Tin Cá Nhân";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F);
            lblGender.ForeColor = Color.FromArgb(85, 85, 85);
            lblGender.Location = new Point(743, 173);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(79, 23);
            lblGender.TabIndex = 9;
            lblGender.Text = "Giới tính:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Enabled = false;
            cmbGender.Font = new Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cmbGender.Location = new Point(743, 207);
            cmbGender.Margin = new Padding(3, 4, 3, 4);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(182, 31);
            cmbGender.TabIndex = 10;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 10F);
            lblDateOfBirth.ForeColor = Color.FromArgb(85, 85, 85);
            lblDateOfBirth.Location = new Point(491, 173);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(90, 23);
            lblDateOfBirth.TabIndex = 7;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Enabled = false;
            dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(491, 207);
            dtpDateOfBirth.Margin = new Padding(3, 4, 3, 4);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(228, 30);
            dtpDateOfBirth.TabIndex = 8;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F);
            lblLastName.ForeColor = Color.FromArgb(85, 85, 85);
            lblLastName.Location = new Point(491, 100);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(40, 23);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "Tên:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(491, 133);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.ReadOnly = true;
            txtLastName.Size = new Size(434, 30);
            txtLastName.TabIndex = 6;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F);
            lblFirstName.ForeColor = Color.FromArgb(85, 85, 85);
            lblFirstName.Location = new Point(263, 100);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(36, 23);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "Họ:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(263, 133);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.ReadOnly = true;
            txtFirstName.Size = new Size(205, 30);
            txtFirstName.TabIndex = 4;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 10F);
            lblEmployeeId.ForeColor = Color.FromArgb(85, 85, 85);
            lblEmployeeId.Location = new Point(34, 100);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(118, 23);
            lblEmployeeId.TabIndex = 1;
            lblEmployeeId.Text = "Mã nhân viên:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtEmployeeId.ForeColor = Color.FromArgb(51, 122, 183);
            txtEmployeeId.Location = new Point(34, 133);
            txtEmployeeId.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(205, 30);
            txtEmployeeId.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnEdit);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 787);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(34, 20, 34, 20);
            panelButtons.Size = new Size(1029, 93);
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
            btnClose.Location = new Point(870, 20);
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
            btnEdit.Location = new Point(744, 20);
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
            btnSave.Location = new Point(618, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 53);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // EmployeeInfoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 880);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1026, 864);
            Name = "EmployeeInfoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông Tin Nhân Viên";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxWorkInfo.ResumeLayout(false);
            groupBoxWorkInfo.PerformLayout();
            groupBoxContactInfo.ResumeLayout(false);
            groupBoxContactInfo.PerformLayout();
            groupBoxPersonalInfo.ResumeLayout(false);
            groupBoxPersonalInfo.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxPersonalInfo;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.GroupBox groupBoxContactInfo;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox groupBoxWorkInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblHireDate;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblMaxHoursPerDay;
        private System.Windows.Forms.TextBox txtMaxHoursPerDay;
        private System.Windows.Forms.Label lblMaxHoursPerMonth;
        private System.Windows.Forms.TextBox txtMaxHoursPerMonth;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
    }
}