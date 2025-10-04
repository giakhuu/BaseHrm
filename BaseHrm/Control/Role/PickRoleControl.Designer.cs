namespace BaseHrm.Controls
{
    partial class PickRoleControl
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
            button2 = new Button();
            button1 = new Button();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvRoles = new DataGridView();
            roleIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rolePermissionsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            accountCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleWithAccountsDtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roleWithAccountsDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(541, 84);
            button2.Name = "button2";
            button2.Size = new Size(83, 29);
            button2.TabIndex = 10;
            button2.Text = "Chọn";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonSelect_Click;
            // 
            // button1
            // 
            button1.Location = new Point(362, 84);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "🔍Tìm";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(7, 86);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm theo tên";
            txtSearch.Size = new Size(349, 27);
            txtSearch.TabIndex = 8;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(7, 37);
            label1.Name = "label1";
            label1.Size = new Size(237, 31);
            label1.TabIndex = 7;
            label1.Text = "Chọn quyền cần thêm";
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.BackgroundColor = Color.White;
            dgvRoles.BorderStyle = BorderStyle.None;
            dgvRoles.ColumnHeadersHeight = 40;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRoles.Columns.AddRange(new DataGridViewColumn[] { roleIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, rolePermissionsDataGridViewTextBoxColumn, accountCountDataGridViewTextBoxColumn });
            dgvRoles.DataSource = roleWithAccountsDtoBindingSource;
            dgvRoles.GridColor = Color.FromArgb(233, 236, 239);
            dgvRoles.Location = new Point(7, 120);
            dgvRoles.Margin = new Padding(3, 4, 3, 4);
            dgvRoles.MultiSelect = false;
            dgvRoles.Name = "dgvRoles";
            dgvRoles.ReadOnly = true;
            dgvRoles.RowHeadersVisible = false;
            dgvRoles.RowHeadersWidth = 51;
            dgvRoles.RowTemplate.Height = 35;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(617, 384);
            dgvRoles.TabIndex = 6;
            dgvRoles.CellMouseDoubleClick += dgvRoles_CellMouseDoubleClick;
            // 
            // roleIdDataGridViewTextBoxColumn
            // 
            roleIdDataGridViewTextBoxColumn.DataPropertyName = "RoleId";
            roleIdDataGridViewTextBoxColumn.HeaderText = "Mã quyền";
            roleIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            roleIdDataGridViewTextBoxColumn.Name = "roleIdDataGridViewTextBoxColumn";
            roleIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Tên";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Mô tả";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rolePermissionsDataGridViewTextBoxColumn
            // 
            rolePermissionsDataGridViewTextBoxColumn.DataPropertyName = "RolePermissions";
            rolePermissionsDataGridViewTextBoxColumn.HeaderText = "RolePermissions";
            rolePermissionsDataGridViewTextBoxColumn.MinimumWidth = 6;
            rolePermissionsDataGridViewTextBoxColumn.Name = "rolePermissionsDataGridViewTextBoxColumn";
            rolePermissionsDataGridViewTextBoxColumn.ReadOnly = true;
            rolePermissionsDataGridViewTextBoxColumn.Visible = false;
            // 
            // accountCountDataGridViewTextBoxColumn
            // 
            accountCountDataGridViewTextBoxColumn.DataPropertyName = "AccountCount";
            accountCountDataGridViewTextBoxColumn.HeaderText = "AccountCount";
            accountCountDataGridViewTextBoxColumn.MinimumWidth = 6;
            accountCountDataGridViewTextBoxColumn.Name = "accountCountDataGridViewTextBoxColumn";
            accountCountDataGridViewTextBoxColumn.ReadOnly = true;
            accountCountDataGridViewTextBoxColumn.Visible = false;
            // 
            // roleWithAccountsDtoBindingSource
            // 
            roleWithAccountsDtoBindingSource.DataSource = typeof(Data.DTO.RoleWithAccountsDto);
            // 
            // PickRoleControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dgvRoles);
            Name = "PickRoleControl";
            Size = new Size(630, 540);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            ((System.ComponentModel.ISupportInitialize)roleWithAccountsDtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private TextBox txtSearch;
        private Label label1;
        private DataGridView dgvRoles;
        private DataGridViewTextBoxColumn roleIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rolePermissionsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn accountCountDataGridViewTextBoxColumn;
        private BindingSource roleWithAccountsDtoBindingSource;
    }
}
