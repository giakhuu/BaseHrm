namespace BaseHrm
{
    partial class AddEmployeeForm
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
            numMaxHoursPerMonth = new NumericUpDown();
            lblMaxHoursPerDay = new Label();
            numMaxHoursPerDay = new NumericUpDown();
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
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxWorkInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxHoursPerMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxHoursPerDay).BeginInit();
            groupBoxContactInfo.SuspendLayout();
            groupBoxPersonalInfo.SuspendLayout();
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
            lblFormTitle.Size = new Size(302, 41);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "➕ Thêm Nhân Viên";
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
            groupBoxWorkInfo.Controls.Add(numMaxHoursPerMonth);
            groupBoxWorkInfo.Controls.Add(lblMaxHoursPerDay);
            groupBoxWorkInfo.Controls.Add(numMaxHoursPerDay);
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
            // numMaxHoursPerMonth
            // 
            numMaxHoursPerMonth.DecimalPlaces = 2;
            numMaxHoursPerMonth.Font = new Font("Segoe UI", 10F);
            numMaxHoursPerMonth.Location = new Point(491, 207);
            numMaxHoursPerMonth.Margin = new Padding(3, 4, 3, 4);
            numMaxHoursPerMonth.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numMaxHoursPerMonth.Name = "numMaxHoursPerMonth";
            numMaxHoursPerMonth.Size = new Size(286, 30);
            numMaxHoursPerMonth.TabIndex = 10;
            numMaxHoursPerMonth.Value = new decimal(new int[] { 160, 0, 0, 0 });
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
            // numMaxHoursPerDay
            // 
            numMaxHoursPerDay.DecimalPlaces = 2;
            numMaxHoursPerDay.Font = new Font("Segoe UI", 10F);
            numMaxHoursPerDay.Location = new Point(491, 133);
            numMaxHoursPerDay.Margin = new Padding(3, 4, 3, 4);
            numMaxHoursPerDay.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numMaxHoursPerDay.Name = "numMaxHoursPerDay";
            numMaxHoursPerDay.Size = new Size(286, 30);
            numMaxHoursPerDay.TabIndex = 8;
            numMaxHoursPerDay.Value = new decimal(new int[] { 8, 0, 0, 0 });
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
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
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
            txtAddress.PlaceholderText = "Nhập địa chỉ...";
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
            txtPhone.PlaceholderText = "Nhập số điện thoại...";
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
            txtEmail.PlaceholderText = "Nhập email...";
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
            lblGender.TabIndex = 7;
            lblGender.Text = "Giới tính:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cmbGender.Location = new Point(743, 207);
            cmbGender.Margin = new Padding(3, 4, 3, 4);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(182, 31);
            cmbGender.TabIndex = 8;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 10F);
            lblDateOfBirth.ForeColor = Color.FromArgb(85, 85, 85);
            lblDateOfBirth.Location = new Point(491, 173);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(90, 23);
            lblDateOfBirth.TabIndex = 5;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Font = new Font("Segoe UI", 10F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(491, 207);
            dtpDateOfBirth.Margin = new Padding(3, 4, 3, 4);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(228, 30);
            dtpDateOfBirth.TabIndex = 6;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F);
            lblLastName.ForeColor = Color.FromArgb(85, 85, 85);
            lblLastName.Location = new Point(491, 100);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(40, 23);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Tên:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(491, 133);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Nhập tên...";
            txtLastName.Size = new Size(434, 30);
            txtLastName.TabIndex = 4;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F);
            lblFirstName.ForeColor = Color.FromArgb(85, 85, 85);
            lblFirstName.Location = new Point(34, 100);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(36, 23);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "Họ:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(34, 133);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "Nhập họ...";
            txtFirstName.Size = new Size(434, 30);
            txtFirstName.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 787);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(34, 20, 34, 20);
            panelButtons.Size = new Size(1029, 93);
            panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(870, 20);
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
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(744, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 53);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 880);
            Controls.Add(panelMain);
            Controls.Add(panelButtons);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1026, 864);
            Name = "AddEmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Nhân Viên";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxWorkInfo.ResumeLayout(false);
            groupBoxWorkInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxHoursPerMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxHoursPerDay).EndInit();
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
        private System.Windows.Forms.NumericUpDown numMaxHoursPerDay;
        private System.Windows.Forms.Label lblMaxHoursPerMonth;
        private System.Windows.Forms.NumericUpDown numMaxHoursPerMonth;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}