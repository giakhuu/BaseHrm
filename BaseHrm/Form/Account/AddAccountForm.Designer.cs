namespace BaseHrm
{
    partial class AddAccountForm
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
            lblTitle = new Label();
            panelMain = new Panel();
            groupBoxEmployee = new GroupBox();
            groupBox1 = new GroupBox();
            txtEmployeePosition = new TextBox();
            lblEmployeePosition = new Label();
            txtEmployeePhone = new TextBox();
            lblEmployeePhone = new Label();
            txtEmployeeEmail = new TextBox();
            lblEmployeeEmail = new Label();
            txtEmployeeName = new TextBox();
            lblEmployeeName = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeId = new Label();
            btnSelectEmployee = new Button();
            lblEmployeeSelection = new Label();
            groupBoxAccount = new GroupBox();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            groupBoxEmployee.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxAccount.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(46, 204, 113);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(23, 20, 23, 20);
            panelHeader.Size = new Size(800, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(292, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👤➕Thêm tài khoản";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 249, 250);
            panelMain.Controls.Add(groupBoxEmployee);
            panelMain.Controls.Add(groupBoxAccount);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 80);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(23, 27, 23, 27);
            panelMain.Size = new Size(800, 640);
            panelMain.TabIndex = 1;
            // 
            // groupBoxEmployee
            // 
            groupBoxEmployee.BackColor = Color.White;
            groupBoxEmployee.Controls.Add(groupBox1);
            groupBoxEmployee.Controls.Add(btnSelectEmployee);
            groupBoxEmployee.Controls.Add(lblEmployeeSelection);
            groupBoxEmployee.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxEmployee.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxEmployee.Location = new Point(23, 293);
            groupBoxEmployee.Margin = new Padding(3, 4, 3, 4);
            groupBoxEmployee.Name = "groupBoxEmployee";
            groupBoxEmployee.Padding = new Padding(17, 20, 17, 20);
            groupBoxEmployee.Size = new Size(754, 293);
            groupBoxEmployee.TabIndex = 1;
            groupBoxEmployee.TabStop = false;
            groupBoxEmployee.Text = "Employee Assignment";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEmployeePosition);
            groupBox1.Controls.Add(lblEmployeePosition);
            groupBox1.Controls.Add(txtEmployeePhone);
            groupBox1.Controls.Add(lblEmployeePhone);
            groupBox1.Controls.Add(txtEmployeeEmail);
            groupBox1.Controls.Add(lblEmployeeEmail);
            groupBox1.Controls.Add(txtEmployeeName);
            groupBox1.Controls.Add(lblEmployeeName);
            groupBox1.Controls.Add(txtEmployeeId);
            groupBox1.Controls.Add(lblEmployeeId);
            groupBox1.Location = new Point(23, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(711, 152);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "👤Thông tin nhân viên";
            // 
            // txtEmployeePosition
            // 
            txtEmployeePosition.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeePosition.Font = new Font("Segoe UI", 9F);
            txtEmployeePosition.Location = new Point(554, 42);
            txtEmployeePosition.Margin = new Padding(3, 4, 3, 4);
            txtEmployeePosition.Name = "txtEmployeePosition";
            txtEmployeePosition.ReadOnly = true;
            txtEmployeePosition.Size = new Size(148, 27);
            txtEmployeePosition.TabIndex = 19;
            // 
            // lblEmployeePosition
            // 
            lblEmployeePosition.AutoSize = true;
            lblEmployeePosition.Font = new Font("Segoe UI", 9F);
            lblEmployeePosition.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeePosition.Location = new Point(485, 46);
            lblEmployeePosition.Name = "lblEmployeePosition";
            lblEmployeePosition.Size = new Size(64, 20);
            lblEmployeePosition.TabIndex = 18;
            lblEmployeePosition.Text = "Chức vụ:";
            // 
            // txtEmployeePhone
            // 
            txtEmployeePhone.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeePhone.Font = new Font("Segoe UI", 9F);
            txtEmployeePhone.Location = new Point(371, 89);
            txtEmployeePhone.Margin = new Padding(3, 4, 3, 4);
            txtEmployeePhone.Name = "txtEmployeePhone";
            txtEmployeePhone.ReadOnly = true;
            txtEmployeePhone.Size = new Size(171, 27);
            txtEmployeePhone.TabIndex = 17;
            // 
            // lblEmployeePhone
            // 
            lblEmployeePhone.AutoSize = true;
            lblEmployeePhone.Font = new Font("Segoe UI", 9F);
            lblEmployeePhone.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeePhone.Location = new Point(314, 93);
            lblEmployeePhone.Name = "lblEmployeePhone";
            lblEmployeePhone.Size = new Size(39, 20);
            lblEmployeePhone.TabIndex = 16;
            lblEmployeePhone.Text = "SĐT:";
            // 
            // txtEmployeeEmail
            // 
            txtEmployeeEmail.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeeEmail.Font = new Font("Segoe UI", 9F);
            txtEmployeeEmail.Location = new Point(62, 89);
            txtEmployeeEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeEmail.Name = "txtEmployeeEmail";
            txtEmployeeEmail.ReadOnly = true;
            txtEmployeeEmail.Size = new Size(228, 27);
            txtEmployeeEmail.TabIndex = 15;
            // 
            // lblEmployeeEmail
            // 
            lblEmployeeEmail.AutoSize = true;
            lblEmployeeEmail.Font = new Font("Segoe UI", 9F);
            lblEmployeeEmail.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeEmail.Location = new Point(8, 93);
            lblEmployeeEmail.Name = "lblEmployeeEmail";
            lblEmployeeEmail.Size = new Size(49, 20);
            lblEmployeeEmail.TabIndex = 14;
            lblEmployeeEmail.Text = "Email:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeeName.Font = new Font("Segoe UI", 9F);
            txtEmployeeName.Location = new Point(234, 42);
            txtEmployeeName.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(228, 27);
            txtEmployeeName.TabIndex = 13;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 9F);
            lblEmployeeName.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeName.Location = new Point(176, 46);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(35, 20);
            lblEmployeeName.TabIndex = 12;
            lblEmployeeName.Text = "Tên:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.BackColor = Color.FromArgb(248, 249, 250);
            txtEmployeeId.Font = new Font("Segoe UI", 9F);
            txtEmployeeId.Location = new Point(62, 42);
            txtEmployeeId.Margin = new Padding(3, 4, 3, 4);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(91, 27);
            txtEmployeeId.TabIndex = 11;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 9F);
            lblEmployeeId.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeId.Location = new Point(17, 46);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(27, 20);
            lblEmployeeId.TabIndex = 10;
            lblEmployeeId.Text = "ID:";
            // 
            // btnSelectEmployee
            // 
            btnSelectEmployee.BackColor = Color.FromArgb(52, 152, 219);
            btnSelectEmployee.FlatAppearance.BorderSize = 0;
            btnSelectEmployee.FlatStyle = FlatStyle.Flat;
            btnSelectEmployee.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectEmployee.ForeColor = Color.White;
            btnSelectEmployee.Location = new Point(293, 40);
            btnSelectEmployee.Margin = new Padding(3, 4, 3, 4);
            btnSelectEmployee.Name = "btnSelectEmployee";
            btnSelectEmployee.Size = new Size(171, 47);
            btnSelectEmployee.TabIndex = 1;
            btnSelectEmployee.Text = "Select Employee";
            btnSelectEmployee.UseVisualStyleBackColor = false;
            btnSelectEmployee.Click += btnSelectEmployee_Click;
            // 
            // lblEmployeeSelection
            // 
            lblEmployeeSelection.AutoSize = true;
            lblEmployeeSelection.Font = new Font("Segoe UI", 9F);
            lblEmployeeSelection.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmployeeSelection.Location = new Point(23, 53);
            lblEmployeeSelection.Name = "lblEmployeeSelection";
            lblEmployeeSelection.Size = new Size(248, 20);
            lblEmployeeSelection.TabIndex = 0;
            lblEmployeeSelection.Text = "Select an employee for this account:";
            // 
            // groupBoxAccount
            // 
            groupBoxAccount.BackColor = Color.White;
            groupBoxAccount.Controls.Add(txtConfirmPassword);
            groupBoxAccount.Controls.Add(lblConfirmPassword);
            groupBoxAccount.Controls.Add(txtPassword);
            groupBoxAccount.Controls.Add(lblPassword);
            groupBoxAccount.Controls.Add(txtUsername);
            groupBoxAccount.Controls.Add(lblUsername);
            groupBoxAccount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxAccount.ForeColor = Color.FromArgb(52, 73, 94);
            groupBoxAccount.Location = new Point(23, 27);
            groupBoxAccount.Margin = new Padding(3, 4, 3, 4);
            groupBoxAccount.Name = "groupBoxAccount";
            groupBoxAccount.Padding = new Padding(17, 20, 17, 20);
            groupBoxAccount.Size = new Size(754, 240);
            groupBoxAccount.TabIndex = 0;
            groupBoxAccount.TabStop = false;
            groupBoxAccount.Text = "Thông tin tài khoản";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.Location = new Point(160, 143);
            txtConfirmPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(548, 27);
            txtConfirmPassword.TabIndex = 5;
            txtConfirmPassword.TextChanged += txtChangeValidate_TextChanged;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F);
            lblConfirmPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPassword.Location = new Point(23, 147);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(130, 20);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(137, 96);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(571, 27);
            txtPassword.TabIndex = 3;
            txtPassword.TextChanged += txtChangeValidate_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblPassword.Location = new Point(23, 100);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(137, 49);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(571, 27);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtChangeValidate_TextChanged;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.ForeColor = Color.FromArgb(73, 80, 87);
            lblUsername.Location = new Point(23, 53);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 640);
            panelButtons.Margin = new Padding(3, 4, 3, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(800, 80);
            panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(551, 20);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(91, 47);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(666, 20);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(91, 47);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // AddAccountForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            ClientSize = new Size(800, 720);
            Controls.Add(panelButtons);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddAccountForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add New Account";
            Load += AddAccountForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            groupBoxEmployee.ResumeLayout(false);
            groupBoxEmployee.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxAccount.ResumeLayout(false);
            groupBoxAccount.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.GroupBox groupBoxAccount;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.GroupBox groupBoxEmployee;
        private System.Windows.Forms.Label lblEmployeeSelection;
        private System.Windows.Forms.Button btnSelectEmployee;
        private System.Windows.Forms.Panel panelButtons;
        private GroupBox groupBox1;
        private TextBox txtEmployeePosition;
        private Label lblEmployeePosition;
        private TextBox txtEmployeePhone;
        private Label lblEmployeePhone;
        private TextBox txtEmployeeEmail;
        private Label lblEmployeeEmail;
        private TextBox txtEmployeeName;
        private Label lblEmployeeName;
        private TextBox txtEmployeeId;
        private Label lblEmployeeId;
        private Button btnCancel;
        private Button btnSave;
    }
}