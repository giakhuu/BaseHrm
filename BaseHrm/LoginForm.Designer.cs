namespace BaseHrm
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel4 = new ReaLTaiizor.Controls.Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            closeBtn = new ReaLTaiizor.Controls.Button();
            minimizeBtn = new ReaLTaiizor.Controls.Button();
            panel1 = new Panel();
            labelStatus = new ReaLTaiizor.Controls.CrownLabel();
            loginRememberCheckbox = new ReaLTaiizor.Controls.FoxCheckBoxEdit();
            tooglePasswordBtn = new PictureBox();
            loginBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            skyLabel2 = new ReaLTaiizor.Controls.SkyLabel();
            passwordTxtBox = new ReaLTaiizor.Controls.AloneTextBox();
            skyLabel1 = new ReaLTaiizor.Controls.SkyLabel();
            usrnameTxtBox = new ReaLTaiizor.Controls.AloneTextBox();
            nightLabel1 = new ReaLTaiizor.Controls.NightLabel();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            panel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tooglePasswordBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(34, 110, 207);
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Dock = DockStyle.Top;
            panel4.EdgeColor = Color.FromArgb(19, 54, 101);
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(1280, 35);
            panel4.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panel4.TabIndex = 6;
            panel4.Text = "panel4";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(closeBtn);
            flowLayoutPanel1.Controls.Add(minimizeBtn);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(1163, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(117, 35);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.Transparent;
            closeBtn.BorderColor = Color.Transparent;
            closeBtn.EnteredBorderColor = Color.Transparent;
            closeBtn.EnteredColor = Color.Transparent;
            closeBtn.Font = new Font("Microsoft Sans Serif", 12F);
            closeBtn.Image = (Image)resources.GetObject("closeBtn.Image");
            closeBtn.ImageAlign = ContentAlignment.MiddleCenter;
            closeBtn.InactiveColor = Color.Transparent;
            closeBtn.Location = new Point(59, 0);
            closeBtn.Margin = new Padding(0);
            closeBtn.Name = "closeBtn";
            closeBtn.PressedBorderColor = Color.Red;
            closeBtn.PressedColor = Color.Red;
            closeBtn.Size = new Size(58, 35);
            closeBtn.TabIndex = 7;
            closeBtn.TextAlignment = StringAlignment.Center;
            closeBtn.Click += closeBtn_Click;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.Transparent;
            minimizeBtn.BorderColor = Color.Transparent;
            minimizeBtn.EnteredBorderColor = Color.Transparent;
            minimizeBtn.EnteredColor = Color.Transparent;
            minimizeBtn.Font = new Font("Microsoft Sans Serif", 12F);
            minimizeBtn.Image = (Image)resources.GetObject("minimizeBtn.Image");
            minimizeBtn.ImageAlign = ContentAlignment.MiddleCenter;
            minimizeBtn.InactiveColor = Color.Transparent;
            minimizeBtn.Location = new Point(1, 0);
            minimizeBtn.Margin = new Padding(0);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.PressedBorderColor = Color.Red;
            minimizeBtn.PressedColor = Color.Red;
            minimizeBtn.Size = new Size(58, 35);
            minimizeBtn.TabIndex = 8;
            minimizeBtn.TextAlignment = StringAlignment.Center;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelStatus);
            panel1.Controls.Add(loginRememberCheckbox);
            panel1.Controls.Add(tooglePasswordBtn);
            panel1.Controls.Add(loginBtn);
            panel1.Controls.Add(skyLabel2);
            panel1.Controls.Add(passwordTxtBox);
            panel1.Controls.Add(skyLabel1);
            panel1.Controls.Add(usrnameTxtBox);
            panel1.Controls.Add(nightLabel1);
            panel1.Controls.Add(bigLabel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(616, 685);
            panel1.TabIndex = 7;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.ForeColor = Color.DimGray;
            labelStatus.Location = new Point(0, 665);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(82, 20);
            labelStatus.TabIndex = 21;
            labelStatus.Text = "Đăng nhập";
            // 
            // loginRememberCheckbox
            // 
            loginRememberCheckbox.BackColor = Color.Transparent;
            loginRememberCheckbox.BorderColor = Color.FromArgb(200, 200, 200);
            loginRememberCheckbox.Checked = false;
            loginRememberCheckbox.DisabledBorderColor = Color.FromArgb(230, 230, 230);
            loginRememberCheckbox.DisabledTextColor = Color.FromArgb(166, 178, 190);
            loginRememberCheckbox.EnabledCalc = true;
            loginRememberCheckbox.Font = new Font("Segoe UI", 10F);
            loginRememberCheckbox.ForeColor = Color.FromArgb(66, 78, 90);
            loginRememberCheckbox.HoverBorderColor = Color.FromArgb(44, 156, 218);
            loginRememberCheckbox.Location = new Point(67, 448);
            loginRememberCheckbox.Name = "loginRememberCheckbox";
            loginRememberCheckbox.Size = new Size(223, 26);
            loginRememberCheckbox.TabIndex = 20;
            loginRememberCheckbox.Text = "Lưu thông tin đăng nhập";
            // 
            // tooglePasswordBtn
            // 
            tooglePasswordBtn.Image = (Image)resources.GetObject("tooglePasswordBtn.Image");
            tooglePasswordBtn.Location = new Point(490, 382);
            tooglePasswordBtn.Name = "tooglePasswordBtn";
            tooglePasswordBtn.Size = new Size(39, 33);
            tooglePasswordBtn.SizeMode = PictureBoxSizeMode.Zoom;
            tooglePasswordBtn.TabIndex = 19;
            tooglePasswordBtn.TabStop = false;
            tooglePasswordBtn.Click += pictureBox3_Click;
            // 
            // loginBtn
            // 
            loginBtn.BorderColor = Color.FromArgb(220, 223, 230);
            loginBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            loginBtn.DangerColor = Color.FromArgb(245, 108, 108);
            loginBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            loginBtn.Font = new Font("Segoe UI", 12F);
            loginBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            loginBtn.InfoColor = Color.FromArgb(144, 147, 153);
            loginBtn.Location = new Point(67, 492);
            loginBtn.Name = "loginBtn";
            loginBtn.PrimaryColor = Color.FromArgb(64, 158, 255);
            loginBtn.Size = new Size(417, 64);
            loginBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            loginBtn.TabIndex = 18;
            loginBtn.Text = "Đăng nhập";
            loginBtn.TextColor = Color.White;
            loginBtn.WarningColor = Color.FromArgb(230, 162, 60);
            loginBtn.Click += hopeRoundButton1_Click;
            // 
            // skyLabel2
            // 
            skyLabel2.AutoSize = true;
            skyLabel2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyLabel2.ForeColor = Color.FromArgb(27, 94, 137);
            skyLabel2.Location = new Point(67, 337);
            skyLabel2.Name = "skyLabel2";
            skyLabel2.Size = new Size(97, 28);
            skyLabel2.TabIndex = 17;
            skyLabel2.Text = "Password";
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.BackColor = Color.Transparent;
            passwordTxtBox.EnabledCalc = true;
            passwordTxtBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTxtBox.ForeColor = Color.FromArgb(34, 110, 207);
            passwordTxtBox.Location = new Point(67, 368);
            passwordTxtBox.MaxLength = 32767;
            passwordTxtBox.MultiLine = false;
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.ReadOnly = false;
            passwordTxtBox.Size = new Size(417, 59);
            passwordTxtBox.TabIndex = 16;
            passwordTxtBox.TextAlign = HorizontalAlignment.Left;
            passwordTxtBox.UseSystemPasswordChar = true;
            passwordTxtBox.TextChanged += aloneTextBox2_TextChanged;
            // 
            // skyLabel1
            // 
            skyLabel1.AutoSize = true;
            skyLabel1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyLabel1.ForeColor = Color.FromArgb(27, 94, 137);
            skyLabel1.Location = new Point(67, 223);
            skyLabel1.Name = "skyLabel1";
            skyLabel1.Size = new Size(104, 28);
            skyLabel1.TabIndex = 15;
            skyLabel1.Text = "Username";
            skyLabel1.Click += skyLabel1_Click;
            // 
            // usrnameTxtBox
            // 
            usrnameTxtBox.BackColor = Color.Transparent;
            usrnameTxtBox.EnabledCalc = true;
            usrnameTxtBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usrnameTxtBox.ForeColor = Color.FromArgb(34, 110, 207);
            usrnameTxtBox.Location = new Point(67, 254);
            usrnameTxtBox.MaxLength = 32767;
            usrnameTxtBox.MultiLine = false;
            usrnameTxtBox.Name = "usrnameTxtBox";
            usrnameTxtBox.ReadOnly = false;
            usrnameTxtBox.Size = new Size(417, 59);
            usrnameTxtBox.TabIndex = 14;
            usrnameTxtBox.TextAlign = HorizontalAlignment.Left;
            usrnameTxtBox.UseSystemPasswordChar = false;
            usrnameTxtBox.TextChanged += usrnameTxtBox_TextChanged;
            // 
            // nightLabel1
            // 
            nightLabel1.AutoSize = true;
            nightLabel1.BackColor = Color.Transparent;
            nightLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nightLabel1.ForeColor = Color.FromArgb(64, 64, 64);
            nightLabel1.Location = new Point(67, 141);
            nightLabel1.Name = "nightLabel1";
            nightLabel1.Size = new Size(417, 56);
            nightLabel1.TabIndex = 12;
            nightLabel1.Text = "Chào mừng bạn đã trở lại công ty, hãy tiếp tục\r\ncông việc quản lý của mình nào.";
            // 
            // bigLabel2
            // 
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = Color.Transparent;
            bigLabel2.Font = new Font("Segoe UI Semibold", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = Color.Black;
            bigLabel2.Location = new Point(55, 74);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(235, 57);
            bigLabel2.TabIndex = 11;
            bigLabel2.Text = "Đăng nhập";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(684, 228);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(560, 416);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(778, 97);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 87);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI Semibold", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.Black;
            bigLabel1.Location = new Point(884, 109);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(214, 57);
            bigLabel1.TabIndex = 10;
            bigLabel1.Text = "Công ty A";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(bigLabel1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "fLogin";
            panel4.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tooglePasswordBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.Panel panel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.Button closeBtn;
        private ReaLTaiizor.Controls.Button minimizeBtn;
        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.NightLabel nightLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.AloneTextBox usrnameTxtBox;
        private ReaLTaiizor.Controls.SkyLabel skyLabel2;
        private ReaLTaiizor.Controls.AloneTextBox passwordTxtBox;
        private ReaLTaiizor.Controls.SkyLabel skyLabel1;
        private ReaLTaiizor.Controls.HopeRoundButton loginBtn;
        private PictureBox tooglePasswordBtn;
        private ReaLTaiizor.Controls.FoxCheckBoxEdit loginRememberCheckbox;
        private ReaLTaiizor.Controls.CrownLabel labelStatus;
    }
}