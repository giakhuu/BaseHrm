namespace BaseHrm.Controls
{ 
    partial class TeamManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            addTeamButton = new Button();
            searchTextBox = new TextBox();
            searchLabel = new Label();
            titleLabel = new Label();
            mainPanel = new Panel();
            splitContainer = new SplitContainer();
            teamsPanel = new Panel();
            teamsListView = new ListView();
            teamNameColumn = new ColumnHeader();
            memberCountColumn = new ColumnHeader();
            createdDateColumn = new ColumnHeader();
            teamContextMenu = new ContextMenuStrip(components);
            viewDetailsMenuItem = new ToolStripMenuItem();
            editTeamMenuItem = new ToolStripMenuItem();
            deleteTeamMenuItem = new ToolStripMenuItem();
            teamsLabel = new Label();
            membersPanel = new Panel();
            membersListView = new ListView();
            memberNameColumn = new ColumnHeader();
            memberJoinAtColumn = new ColumnHeader();
            memberIsLeaderColumn = new ColumnHeader();
            membersLabel = new Label();
            addTeamMembers = new ToolStripMenuItem();
            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            teamsPanel.SuspendLayout();
            teamContextMenu.SuspendLayout();
            membersPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(addTeamButton);
            headerPanel.Controls.Add(searchTextBox);
            headerPanel.Controls.Add(searchLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(34, 27, 34, 27);
            headerPanel.Size = new Size(1531, 133);
            headerPanel.TabIndex = 0;
            // 
            // addTeamButton
            // 
            addTeamButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addTeamButton.BackColor = Color.FromArgb(52, 152, 219);
            addTeamButton.Cursor = Cursors.Hand;
            addTeamButton.FlatAppearance.BorderSize = 0;
            addTeamButton.FlatStyle = FlatStyle.Flat;
            addTeamButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            addTeamButton.ForeColor = Color.White;
            addTeamButton.Location = new Point(1349, 40);
            addTeamButton.Margin = new Padding(3, 4, 3, 4);
            addTeamButton.Name = "addTeamButton";
            addTeamButton.Size = new Size(149, 53);
            addTeamButton.TabIndex = 3;
            addTeamButton.Text = "➕ Thêm Team";
            addTeamButton.UseVisualStyleBackColor = false;
            addTeamButton.Click += AddTeamButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Font = new Font("Segoe UI", 11F);
            searchTextBox.Location = new Point(629, 47);
            searchTextBox.Margin = new Padding(3, 4, 3, 4);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Nhập tên team để tìm kiếm...";
            searchTextBox.Size = new Size(685, 32);
            searchTextBox.TabIndex = 2;
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Font = new Font("Segoe UI", 11F);
            searchLabel.ForeColor = Color.FromArgb(73, 80, 87);
            searchLabel.Location = new Point(526, 51);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(118, 25);
            searchLabel.TabIndex = 1;
            searchLabel.Text = "🔍 Tìm kiếm:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(52, 58, 64);
            titleLabel.Location = new Point(34, 33);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(345, 54);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "👥 Quản lý Team";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(248, 249, 250);
            mainPanel.Controls.Add(splitContainer);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 133);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(34, 27, 34, 40);
            mainPanel.Size = new Size(1531, 1047);
            mainPanel.TabIndex = 1;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(34, 27);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(teamsPanel);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(membersPanel);
            splitContainer.Size = new Size(1463, 980);
            splitContainer.SplitterDistance = 731;
            splitContainer.SplitterWidth = 9;
            splitContainer.TabIndex = 0;
            // 
            // teamsPanel
            // 
            teamsPanel.BackColor = Color.White;
            teamsPanel.Controls.Add(teamsListView);
            teamsPanel.Controls.Add(teamsLabel);
            teamsPanel.Dock = DockStyle.Fill;
            teamsPanel.Location = new Point(0, 0);
            teamsPanel.Margin = new Padding(3, 4, 3, 4);
            teamsPanel.Name = "teamsPanel";
            teamsPanel.Padding = new Padding(23, 27, 23, 27);
            teamsPanel.Size = new Size(731, 980);
            teamsPanel.TabIndex = 0;
            // 
            // teamsListView
            // 
            teamsListView.Columns.AddRange(new ColumnHeader[] { teamNameColumn, memberCountColumn, createdDateColumn });
            teamsListView.ContextMenuStrip = teamContextMenu;
            teamsListView.Dock = DockStyle.Fill;
            teamsListView.Font = new Font("Segoe UI", 10F);
            teamsListView.FullRowSelect = true;
            teamsListView.GridLines = true;
            teamsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            teamsListView.Location = new Point(23, 80);
            teamsListView.Margin = new Padding(3, 4, 3, 4);
            teamsListView.MultiSelect = false;
            teamsListView.Name = "teamsListView";
            teamsListView.Size = new Size(685, 873);
            teamsListView.TabIndex = 1;
            teamsListView.UseCompatibleStateImageBehavior = false;
            teamsListView.View = View.Details;
            teamsListView.SelectedIndexChanged += TeamsListView_SelectedIndexChanged;
            teamsListView.MouseClick += TeamsListView_MouseClick;
            // 
            // teamNameColumn
            // 
            teamNameColumn.Text = "Tên Team";
            teamNameColumn.Width = 250;
            // 
            // memberCountColumn
            // 
            memberCountColumn.Text = "Số thành viên";
            memberCountColumn.Width = 120;
            // 
            // createdDateColumn
            // 
            createdDateColumn.Text = "Ngày tạo";
            createdDateColumn.Width = 150;
            // 
            // teamContextMenu
            // 
            teamContextMenu.Font = new Font("Segoe UI", 10F);
            teamContextMenu.ImageScalingSize = new Size(20, 20);
            teamContextMenu.Items.AddRange(new ToolStripItem[] { viewDetailsMenuItem, editTeamMenuItem, deleteTeamMenuItem, addTeamMembers });
            teamContextMenu.Name = "teamContextMenu";
            teamContextMenu.Size = new Size(233, 144);
            // 
            // viewDetailsMenuItem
            // 
            viewDetailsMenuItem.Name = "viewDetailsMenuItem";
            viewDetailsMenuItem.Size = new Size(210, 28);
            viewDetailsMenuItem.Text = "👁️ Xem chi tiết";
            viewDetailsMenuItem.Click += ViewDetailsMenuItem_Click;
            // 
            // editTeamMenuItem
            // 
            editTeamMenuItem.Name = "editTeamMenuItem";
            editTeamMenuItem.Size = new Size(210, 28);
            editTeamMenuItem.Text = "✏️ Chỉnh sửa";
            editTeamMenuItem.Click += EditTeamMenuItem_Click;
            // 
            // deleteTeamMenuItem
            // 
            deleteTeamMenuItem.Name = "deleteTeamMenuItem";
            deleteTeamMenuItem.Size = new Size(210, 28);
            deleteTeamMenuItem.Text = "🗑️ Xóa team";
            deleteTeamMenuItem.Click += DeleteTeamMenuItem_Click;
            // 
            // teamsLabel
            // 
            teamsLabel.Dock = DockStyle.Top;
            teamsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            teamsLabel.ForeColor = Color.FromArgb(52, 58, 64);
            teamsLabel.Location = new Point(23, 27);
            teamsLabel.Name = "teamsLabel";
            teamsLabel.Size = new Size(685, 53);
            teamsLabel.TabIndex = 0;
            teamsLabel.Text = "📋 Danh sách Team";
            teamsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // membersPanel
            // 
            membersPanel.BackColor = Color.White;
            membersPanel.Controls.Add(membersListView);
            membersPanel.Controls.Add(membersLabel);
            membersPanel.Dock = DockStyle.Fill;
            membersPanel.Location = new Point(0, 0);
            membersPanel.Margin = new Padding(3, 4, 3, 4);
            membersPanel.Name = "membersPanel";
            membersPanel.Padding = new Padding(23, 27, 23, 27);
            membersPanel.Size = new Size(723, 980);
            membersPanel.TabIndex = 0;
            // 
            // membersListView
            // 
            membersListView.Columns.AddRange(new ColumnHeader[] { memberNameColumn, memberJoinAtColumn, memberIsLeaderColumn });
            membersListView.Dock = DockStyle.Fill;
            membersListView.Font = new Font("Segoe UI", 10F);
            membersListView.FullRowSelect = true;
            membersListView.GridLines = true;
            membersListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            membersListView.Location = new Point(23, 80);
            membersListView.Margin = new Padding(3, 4, 3, 4);
            membersListView.MultiSelect = false;
            membersListView.Name = "membersListView";
            membersListView.Size = new Size(677, 873);
            membersListView.TabIndex = 1;
            membersListView.UseCompatibleStateImageBehavior = false;
            membersListView.View = View.Details;
            // 
            // memberNameColumn
            // 
            memberNameColumn.Text = "Tên nhân viên";
            memberNameColumn.Width = 200;
            // 
            // memberJoinAtColumn
            // 
            memberJoinAtColumn.Text = "Ngày vào";
            memberJoinAtColumn.Width = 150;
            // 
            // memberIsLeaderColumn
            // 
            memberIsLeaderColumn.Text = "Leader";
            memberIsLeaderColumn.Width = 200;
            // 
            // membersLabel
            // 
            membersLabel.Dock = DockStyle.Top;
            membersLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            membersLabel.ForeColor = Color.FromArgb(52, 58, 64);
            membersLabel.Location = new Point(23, 27);
            membersLabel.Name = "membersLabel";
            membersLabel.Size = new Size(677, 53);
            membersLabel.TabIndex = 0;
            membersLabel.Text = "👨‍💼 Thành viên Team";
            membersLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // addTeamMembers
            // 
            addTeamMembers.Name = "addTeamMembers";
            addTeamMembers.Size = new Size(232, 28);
            addTeamMembers.Text = "👤Thêm thành viên";
            addTeamMembers.Click += addTeamMembers_Click;
            // 
            // TeamManagementControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TeamManagementControl";
            Size = new Size(1531, 1180);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            teamsPanel.ResumeLayout(false);
            teamContextMenu.ResumeLayout(false);
            membersPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel teamsPanel;
        private System.Windows.Forms.Label teamsLabel;
        private System.Windows.Forms.ListView teamsListView;
        private System.Windows.Forms.ColumnHeader teamNameColumn;
        private System.Windows.Forms.ColumnHeader memberCountColumn;
        private System.Windows.Forms.ColumnHeader createdDateColumn;
        private System.Windows.Forms.Panel membersPanel;
        private System.Windows.Forms.Label membersLabel;
        private System.Windows.Forms.ListView membersListView;
        private System.Windows.Forms.ColumnHeader memberNameColumn;
        private System.Windows.Forms.ColumnHeader memberJoinAtColumn;
        private System.Windows.Forms.ColumnHeader memberIsLeaderColumn;
        private System.Windows.Forms.ContextMenuStrip teamContextMenu;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTeamMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTeamMenuItem;
        private ToolStripMenuItem addTeamMembers;
    }
}