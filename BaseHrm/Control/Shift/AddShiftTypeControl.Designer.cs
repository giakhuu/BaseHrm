using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    partial class AddShiftTypeControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            dgvShiftType = new DataGridView();
            shiftTypeDtoBindingSource = new BindingSource(components);
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            btnClear = new Button();
            btnSave = new Button();
            txtPayMultiplier = new TextBox();
            lblPayMuti = new Label();
            txtShiftTypeName = new TextBox();
            lblShiftTypeName = new Label();
            shiftTypeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            payMultiplierDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShiftType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shiftTypeDtoBindingSource).BeginInit();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Blue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1531, 106);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(260, 54);
            label1.TabIndex = 0;
            label1.Text = "Thêm loại ca";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(1531, 847);
            panel2.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvShiftType);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 148);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(23, 20, 23, 20);
            panel4.Size = new Size(1531, 699);
            panel4.TabIndex = 1;
            // 
            // dgvShiftType
            // 
            dgvShiftType.AllowUserToAddRows = false;
            dgvShiftType.AllowUserToDeleteRows = false;
            dgvShiftType.AutoGenerateColumns = false;
            dgvShiftType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShiftType.BackgroundColor = Color.FromArgb(233, 236, 239);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvShiftType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvShiftType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShiftType.Columns.AddRange(new DataGridViewColumn[] { shiftTypeIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, payMultiplierDataGridViewTextBoxColumn });
            dgvShiftType.DataSource = shiftTypeDtoBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvShiftType.DefaultCellStyle = dataGridViewCellStyle2;
            dgvShiftType.Dock = DockStyle.Fill;
            dgvShiftType.GridColor = Color.FromArgb(233, 236, 239);
            dgvShiftType.Location = new Point(23, 20);
            dgvShiftType.Name = "dgvShiftType";
            dgvShiftType.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvShiftType.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvShiftType.RowHeadersVisible = false;
            dgvShiftType.RowHeadersWidth = 51;
            dgvShiftType.Size = new Size(1485, 659);
            dgvShiftType.TabIndex = 0;
            // 
            // shiftTypeDtoBindingSource
            // 
            shiftTypeDtoBindingSource.DataSource = typeof(Data.DTO.ShiftTypeDto);
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(23, 20, 23, 20);
            panel3.Size = new Size(1531, 148);
            panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtPayMultiplier);
            groupBox1.Controls.Add(lblPayMuti);
            groupBox1.Controls.Add(txtShiftTypeName);
            groupBox1.Controls.Add(lblShiftTypeName);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(23, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1485, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "📅Thêm loại ca";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Red;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(1327, 29);
            btnClear.Name = "btnClear";
            btnClear.Padding = new Padding(10, 4, 10, 4);
            btnClear.Size = new Size(120, 56);
            btnClear.TabIndex = 5;
            btnClear.Text = "✖️Xóa";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1183, 29);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(10, 4, 10, 4);
            btnSave.Size = new Size(138, 56);
            btnSave.TabIndex = 4;
            btnSave.Text = "💾Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtPayMultiplier
            // 
            txtPayMultiplier.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPayMultiplier.Location = new Point(738, 46);
            txtPayMultiplier.Name = "txtPayMultiplier";
            txtPayMultiplier.PlaceholderText = "Nhập hệ số lương";
            txtPayMultiplier.Size = new Size(420, 30);
            txtPayMultiplier.TabIndex = 3;
            txtPayMultiplier.KeyPress += txtPayMultiplier_KeyPress;
            // 
            // lblPayMuti
            // 
            lblPayMuti.AutoSize = true;
            lblPayMuti.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPayMuti.Location = new Point(613, 49);
            lblPayMuti.Name = "lblPayMuti";
            lblPayMuti.Size = new Size(106, 23);
            lblPayMuti.TabIndex = 2;
            lblPayMuti.Text = "Hệ số lương:";
            // 
            // txtShiftTypeName
            // 
            txtShiftTypeName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtShiftTypeName.Location = new Point(134, 46);
            txtShiftTypeName.Name = "txtShiftTypeName";
            txtShiftTypeName.PlaceholderText = "Nhập tên loại ca";
            txtShiftTypeName.Size = new Size(420, 30);
            txtShiftTypeName.TabIndex = 1;
            // 
            // lblShiftTypeName
            // 
            lblShiftTypeName.AutoSize = true;
            lblShiftTypeName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShiftTypeName.Location = new Point(34, 49);
            lblShiftTypeName.Name = "lblShiftTypeName";
            lblShiftTypeName.Size = new Size(94, 23);
            lblShiftTypeName.TabIndex = 0;
            lblShiftTypeName.Text = "Tên loại ca:";
            // 
            // shiftTypeIdDataGridViewTextBoxColumn
            // 
            shiftTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ShiftTypeId";
            shiftTypeIdDataGridViewTextBoxColumn.HeaderText = "Mã loại ca";
            shiftTypeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            shiftTypeIdDataGridViewTextBoxColumn.Name = "shiftTypeIdDataGridViewTextBoxColumn";
            shiftTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Tên loại ca";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // payMultiplierDataGridViewTextBoxColumn
            // 
            payMultiplierDataGridViewTextBoxColumn.DataPropertyName = "PayMultiplier";
            payMultiplierDataGridViewTextBoxColumn.HeaderText = "Hệ số lương";
            payMultiplierDataGridViewTextBoxColumn.MinimumWidth = 6;
            payMultiplierDataGridViewTextBoxColumn.Name = "payMultiplierDataGridViewTextBoxColumn";
            payMultiplierDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AddShiftTypeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F);
            Name = "AddShiftTypeControl";
            Size = new Size(1531, 953);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShiftType).EndInit();
            ((System.ComponentModel.ISupportInitialize)shiftTypeDtoBindingSource).EndInit();
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private GroupBox groupBox1;
        private Label lblShiftTypeName;
        private TextBox txtShiftTypeName;
        private Button btnSave;
        private TextBox txtPayMultiplier;
        private Label lblPayMuti;
        private Button btnClear;
        private Panel panel4;
        private DataGridView dgvShiftType;
        private BindingSource shiftTypeDtoBindingSource;
        private DataGridViewTextBoxColumn shiftTypeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn payMultiplierDataGridViewTextBoxColumn;
    }
}