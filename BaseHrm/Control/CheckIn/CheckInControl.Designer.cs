namespace BaseHrm.Controls
{
    partial class CheckInControl
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
            pnlShiftInfo = new Panel();
            txtAttendanceStatus = new TextBox();
            label1 = new Label();
            txtCheckOut = new TextBox();
            lblEndTime = new Label();
            txtCheckIn = new TextBox();
            lblStartTime = new Label();
            txtShiftEnd = new TextBox();
            lblShiftName = new Label();
            txtShiftStart = new TextBox();
            txtShiftName = new TextBox();
            lblCurrentTime = new Label();
            btnCheckAttendance = new Button();
            lblLastCheck = new Label();
            label2 = new Label();
            label3 = new Label();
            pnlShiftInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlShiftInfo
            // 
            pnlShiftInfo.BackColor = Color.FromArgb(240, 240, 240);
            pnlShiftInfo.Controls.Add(label3);
            pnlShiftInfo.Controls.Add(label2);
            pnlShiftInfo.Controls.Add(txtAttendanceStatus);
            pnlShiftInfo.Controls.Add(label1);
            pnlShiftInfo.Controls.Add(txtCheckOut);
            pnlShiftInfo.Controls.Add(lblEndTime);
            pnlShiftInfo.Controls.Add(txtCheckIn);
            pnlShiftInfo.Controls.Add(lblStartTime);
            pnlShiftInfo.Controls.Add(txtShiftEnd);
            pnlShiftInfo.Controls.Add(lblShiftName);
            pnlShiftInfo.Controls.Add(txtShiftStart);
            pnlShiftInfo.Controls.Add(txtShiftName);
            pnlShiftInfo.Dock = DockStyle.Top;
            pnlShiftInfo.Location = new Point(0, 0);
            pnlShiftInfo.Margin = new Padding(11, 13, 11, 13);
            pnlShiftInfo.Name = "pnlShiftInfo";
            pnlShiftInfo.Padding = new Padding(11, 13, 11, 13);
            pnlShiftInfo.Size = new Size(1175, 194);
            pnlShiftInfo.TabIndex = 0;
            // 
            // txtAttendanceStatus
            // 
            txtAttendanceStatus.Location = new Point(814, 158);
            txtAttendanceStatus.Name = "txtAttendanceStatus";
            txtAttendanceStatus.ReadOnly = true;
            txtAttendanceStatus.Size = new Size(200, 27);
            txtAttendanceStatus.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 13);
            label1.Name = "label1";
            label1.Size = new Size(469, 45);
            label1.TabIndex = 3;
            label1.Text = "Ca làm ngày 0 tháng 0, 2025:";
            // 
            // txtCheckOut
            // 
            txtCheckOut.Location = new Point(814, 116);
            txtCheckOut.Name = "txtCheckOut";
            txtCheckOut.ReadOnly = true;
            txtCheckOut.Size = new Size(200, 27);
            txtCheckOut.TabIndex = 14;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Segoe UI", 10F);
            lblEndTime.Location = new Point(11, 158);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(152, 23);
            lblEndTime.TabIndex = 2;
            lblEndTime.Text = "Thời gian kết thúc:";
            // 
            // txtCheckIn
            // 
            txtCheckIn.Location = new Point(814, 78);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.ReadOnly = true;
            txtCheckIn.Size = new Size(200, 27);
            txtCheckIn.TabIndex = 13;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Segoe UI", 10F);
            lblStartTime.Location = new Point(11, 116);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(149, 23);
            lblStartTime.TabIndex = 1;
            lblStartTime.Text = "Thời gian bắt đầu:";
            // 
            // txtShiftEnd
            // 
            txtShiftEnd.Location = new Point(169, 157);
            txtShiftEnd.Name = "txtShiftEnd";
            txtShiftEnd.ReadOnly = true;
            txtShiftEnd.Size = new Size(200, 27);
            txtShiftEnd.TabIndex = 12;
            // 
            // lblShiftName
            // 
            lblShiftName.AutoSize = true;
            lblShiftName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblShiftName.Location = new Point(11, 74);
            lblShiftName.Name = "lblShiftName";
            lblShiftName.Size = new Size(118, 28);
            lblShiftName.TabIndex = 0;
            lblShiftName.Text = "Tên ca làm:";
            // 
            // txtShiftStart
            // 
            txtShiftStart.Location = new Point(166, 116);
            txtShiftStart.Name = "txtShiftStart";
            txtShiftStart.ReadOnly = true;
            txtShiftStart.Size = new Size(200, 27);
            txtShiftStart.TabIndex = 11;
            // 
            // txtShiftName
            // 
            txtShiftName.Location = new Point(135, 75);
            txtShiftName.Name = "txtShiftName";
            txtShiftName.ReadOnly = true;
            txtShiftName.Size = new Size(200, 27);
            txtShiftName.TabIndex = 10;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.Anchor = AnchorStyles.None;
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            lblCurrentTime.ForeColor = Color.FromArgb(0, 120, 215);
            lblCurrentTime.Location = new Point(512, 178);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(0, 106);
            lblCurrentTime.TabIndex = 1;
            lblCurrentTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCheckAttendance
            // 
            btnCheckAttendance.Anchor = AnchorStyles.None;
            btnCheckAttendance.BackColor = Color.FromArgb(0, 120, 215);
            btnCheckAttendance.FlatAppearance.BorderSize = 0;
            btnCheckAttendance.FlatStyle = FlatStyle.Flat;
            btnCheckAttendance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckAttendance.ForeColor = Color.White;
            btnCheckAttendance.Location = new Point(512, 178);
            btnCheckAttendance.Margin = new Padding(3, 4, 3, 4);
            btnCheckAttendance.Name = "btnCheckAttendance";
            btnCheckAttendance.Size = new Size(229, 67);
            btnCheckAttendance.TabIndex = 2;
            btnCheckAttendance.Text = "Check In/Out";
            btnCheckAttendance.UseVisualStyleBackColor = false;
            btnCheckAttendance.Click += btnCheckAttendance_Click;
            // 
            // lblLastCheck
            // 
            lblLastCheck.Anchor = AnchorStyles.None;
            lblLastCheck.AutoSize = true;
            lblLastCheck.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblLastCheck.ForeColor = Color.Gray;
            lblLastCheck.Location = new Point(512, 178);
            lblLastCheck.Name = "lblLastCheck";
            lblLastCheck.Size = new Size(0, 23);
            lblLastCheck.TabIndex = 3;
            lblLastCheck.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(673, 78);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 16;
            label2.Text = "Check In:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(673, 116);
            label3.Name = "label3";
            label3.Size = new Size(114, 28);
            label3.TabIndex = 17;
            label3.Text = "Check Out:";
            // 
            // CheckInControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lblLastCheck);
            Controls.Add(btnCheckAttendance);
            Controls.Add(lblCurrentTime);
            Controls.Add(pnlShiftInfo);
            Margin = new Padding(0);
            Name = "CheckInControl";
            Size = new Size(1175, 507);
            Load += CheckInControl_Load;
            Resize += CheckInControl_Resize;
            pnlShiftInfo.ResumeLayout(false);
            pnlShiftInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlShiftInfo;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Button btnCheckAttendance;
        private System.Windows.Forms.Label lblLastCheck;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblShiftName;
        private Label label1;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.TextBox txtShiftStart;
        private System.Windows.Forms.TextBox txtShiftEnd;
        private System.Windows.Forms.TextBox txtCheckIn;
        private System.Windows.Forms.TextBox txtCheckOut;
        private System.Windows.Forms.TextBox txtAttendanceStatus;
        private Label label3;
        private Label label2;
    }
}