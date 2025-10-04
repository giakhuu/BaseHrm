namespace BaseHrm
{
    partial class AddTeamForm
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
            controlBox1 = new ReaLTaiizor.Controls.ControlBox();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            skyLabel2 = new ReaLTaiizor.Controls.SkyLabel();
            nameTxtbox = new ReaLTaiizor.Controls.AloneTextBox();
            addBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            button1 = new Button();
            SuspendLayout();
            // 
            // controlBox1
            // 
            controlBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            controlBox1.BackColor = Color.White;
            controlBox1.CloseHoverColor = Color.FromArgb(230, 17, 35);
            controlBox1.DefaultLocation = true;
            controlBox1.EnableHoverHighlight = true;
            controlBox1.EnableMaximizeButton = true;
            controlBox1.EnableMinimizeButton = true;
            controlBox1.ForeColor = Color.FromArgb(155, 155, 155);
            controlBox1.Location = new Point(708, 18);
            controlBox1.MaximizeHoverColor = Color.FromArgb(74, 74, 74);
            controlBox1.MinimizeHoverColor = Color.FromArgb(63, 63, 65);
            controlBox1.Name = "controlBox1";
            controlBox1.Size = new Size(90, 25);
            controlBox1.TabIndex = 43;
            controlBox1.Text = "controlBox1";
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 25F);
            bigLabel1.ForeColor = Color.FromArgb(80, 80, 80);
            bigLabel1.Location = new Point(40, 36);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(238, 57);
            bigLabel1.TabIndex = 44;
            bigLabel1.Text = "Thêm Team";
            bigLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // skyLabel2
            // 
            skyLabel2.AutoSize = true;
            skyLabel2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyLabel2.ForeColor = Color.FromArgb(27, 94, 137);
            skyLabel2.Location = new Point(54, 112);
            skyLabel2.Name = "skyLabel2";
            skyLabel2.Size = new Size(98, 28);
            skyLabel2.TabIndex = 48;
            skyLabel2.Text = "Tên Team";
            // 
            // nameTxtbox
            // 
            nameTxtbox.BackColor = Color.Transparent;
            nameTxtbox.EnabledCalc = true;
            nameTxtbox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTxtbox.ForeColor = Color.FromArgb(34, 110, 207);
            nameTxtbox.Location = new Point(54, 143);
            nameTxtbox.MaxLength = 32767;
            nameTxtbox.MultiLine = false;
            nameTxtbox.Name = "nameTxtbox";
            nameTxtbox.ReadOnly = false;
            nameTxtbox.Size = new Size(705, 59);
            nameTxtbox.TabIndex = 47;
            nameTxtbox.TextAlign = HorizontalAlignment.Left;
            nameTxtbox.UseSystemPasswordChar = false;
            // 
            // addBtn
            // 
            addBtn.BorderColor = Color.FromArgb(220, 223, 230);
            addBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            addBtn.DangerColor = Color.FromArgb(245, 108, 108);
            addBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            addBtn.Font = new Font("Segoe UI", 12F);
            addBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            addBtn.InfoColor = Color.FromArgb(144, 147, 153);
            addBtn.Location = new Point(469, 228);
            addBtn.Name = "addBtn";
            addBtn.PrimaryColor = Color.FromArgb(64, 158, 255);
            addBtn.Size = new Size(290, 50);
            addBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            addBtn.TabIndex = 49;
            addBtn.Text = "Xác nhận";
            addBtn.TextColor = Color.White;
            addBtn.WarningColor = Color.FromArgb(230, 162, 60);
            addBtn.Click += addBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(158, 258);
            button1.Name = "button1";
            button1.Size = new Size(0, 0);
            button1.TabIndex = 50;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddTeamForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 333);
            Controls.Add(button1);
            Controls.Add(addBtn);
            Controls.Add(skyLabel2);
            Controls.Add(nameTxtbox);
            Controls.Add(bigLabel1);
            Controls.Add(controlBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddTeamForm";
            Text = "AddTeam";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.ControlBox controlBox1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.SkyLabel skyLabel2;
        private ReaLTaiizor.Controls.AloneTextBox nameTxtbox;
        private ReaLTaiizor.Controls.HopeRoundButton addBtn;
        private ReaLTaiizor.Controls.HopeRoundButton lostAcceptButton1;
        private Button button1;
    }
}