namespace BaseHrm.Controls
{
    partial class PickTeamControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTeams;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.BindingSource teamDtoBindingSource;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvTeams = new DataGridView();
            teamDtoBindingSource = new BindingSource(components);
            txtSearch = new TextBox();
            buttonSelect = new Button();
            lblStatus = new Label();
            teamIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            leaderDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdAtDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTeams).BeginInit();
            ((System.ComponentModel.ISupportInitialize)teamDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvTeams
            // 
            dgvTeams.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTeams.AutoGenerateColumns = false;
            dgvTeams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeams.Columns.AddRange(new DataGridViewColumn[] { teamIdDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, leaderDataGridViewTextBoxColumn, createdAtDataGridViewTextBoxColumn });
            dgvTeams.DataSource = teamDtoBindingSource;
            dgvTeams.Location = new Point(14, 56);
            dgvTeams.Margin = new Padding(3, 4, 3, 4);
            dgvTeams.Name = "dgvTeams";
            dgvTeams.RowHeadersWidth = 51;
            dgvTeams.Size = new Size(640, 400);
            dgvTeams.TabIndex = 0;
            dgvTeams.CellMouseDoubleClick += dgvTeams_CellMouseDoubleClick;
            // 
            // teamDtoBindingSource
            // 
            teamDtoBindingSource.DataSource = typeof(Data.DTO.TeamDto);
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(14, 16);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(457, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // buttonSelect
            // 
            buttonSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelect.Location = new Point(480, 16);
            buttonSelect.Margin = new Padding(3, 4, 3, 4);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(86, 31);
            buttonSelect.TabIndex = 2;
            buttonSelect.Text = "Ch?n";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(14, 467);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 3;
            // 
            // teamIdDataGridViewTextBoxColumn
            // 
            teamIdDataGridViewTextBoxColumn.DataPropertyName = "TeamId";
            teamIdDataGridViewTextBoxColumn.HeaderText = "TeamId";
            teamIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            teamIdDataGridViewTextBoxColumn.Name = "teamIdDataGridViewTextBoxColumn";
            teamIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // leaderDataGridViewTextBoxColumn
            // 
            leaderDataGridViewTextBoxColumn.DataPropertyName = "Leader";
            leaderDataGridViewTextBoxColumn.HeaderText = "Leader";
            leaderDataGridViewTextBoxColumn.MinimumWidth = 6;
            leaderDataGridViewTextBoxColumn.Name = "leaderDataGridViewTextBoxColumn";
            leaderDataGridViewTextBoxColumn.Width = 125;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            createdAtDataGridViewTextBoxColumn.HeaderText = "CreatedAt";
            createdAtDataGridViewTextBoxColumn.MinimumWidth = 6;
            createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            createdAtDataGridViewTextBoxColumn.Width = 125;
            // 
            // PickTeamControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStatus);
            Controls.Add(buttonSelect);
            Controls.Add(txtSearch);
            Controls.Add(dgvTeams);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PickTeamControl";
            Size = new Size(667, 507);
            ((System.ComponentModel.ISupportInitialize)dgvTeams).EndInit();
            ((System.ComponentModel.ISupportInitialize)teamDtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridViewTextBoxColumn teamIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leaderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
    }
}
