using BaseHrm;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class TeamManagementControl : UserControl
    {
        private List<TeamDto> allTeams = new List<TeamDto>();
        private List<TeamMemberDto> allEmployees = new List<TeamMemberDto>();

        private readonly ITeamService _teamService;
        private readonly IEmployeeService _employeeService;
        private readonly IPermissionService _permissionService;
        private readonly IAuthService _authService;

        private int? _currentAccountId;
        private int? _currentEmployeeId;
        private bool _isMasterAccount;
        private readonly Dictionary<(PermissionAction action, ScopeType scope, int? scopeValue), bool> _permCache
            = new Dictionary<(PermissionAction, ScopeType, int?), bool>();

        public TeamManagementControl(ITeamService teamService, IEmployeeService employeeService, IPermissionService permissionService, IAuthService authService)
        {
            _teamService = teamService;
            _employeeService = employeeService;
            _permissionService = permissionService;
            _authService = authService;
            InitializeComponent();
            this.Load += TeamManagementControl_Load;
            ApplyModernStyling();
        }

        private async void TeamManagementControl_Load(object? sender, EventArgs e)
        {
            await InitializeIdentityAsync();
            await InitializeData();
            await SetupPermissions();
            LoadTeams();
        }

        private async Task InitializeIdentityAsync()
        {
            try
            {
                var info = _authService.GetUserInfoFromToken();
                _currentAccountId = info.AccountId;
                _isMasterAccount = info.IsMaster;
                _currentEmployeeId = info.EmployeeId;
                _permCache.Clear();
            }
            catch
            {
                _currentAccountId = null;
                _isMasterAccount = false;
                _currentEmployeeId = null;
            }
        }

        private async Task SetupPermissions()
        {
            if (_isMasterAccount) return;

            // Kiểm tra quyền và ẩn/hiện các nút
            bool canCreate = await HasPermissionAsync(PermissionAction.Create);
            addTeamButton.Visible = canCreate;

            // Kiểm tra quyền context menu
            await UpdateContextMenuPermissions();
        }

        private async Task UpdateContextMenuPermissions()
        {
            if (_isMasterAccount) return;

            bool canView = await HasPermissionAsync(PermissionAction.View);
            bool canEdit = await HasPermissionAsync(PermissionAction.Edit);
            bool canDelete = await HasPermissionAsync(PermissionAction.Delete);

            viewDetailsMenuItem.Enabled = canView;
            editTeamMenuItem.Enabled = canEdit;
            deleteTeamMenuItem.Enabled = canDelete;
            addTeamMembers.Enabled = canEdit; // Thêm thành viên cần quyền Edit
        }

        private async Task<bool> HasPermissionAsync(PermissionAction action, int? teamId = null)
        {
            if (_isMasterAccount) return true;
            if (!_currentAccountId.HasValue) return false;

            var key = (action, ScopeType.Global, (int?)null);
            if (!_permCache.TryGetValue(key, out bool globalAllowed))
            {
                globalAllowed = await _permissionService.HasPermissionAsync(_currentAccountId.Value, ModuleName.Team, action, ScopeType.Global);
                _permCache[key] = globalAllowed;
            }
            if (globalAllowed) return true;

            // Kiểm tra quyền trên team cụ thể
            if (teamId.HasValue)
            {
                var teamKey = (action, ScopeType.Team, teamId);
                if (!_permCache.TryGetValue(teamKey, out bool teamAllowed))
                {
                    teamAllowed = await _permissionService.HasPermissionAsync(_currentAccountId.Value, ModuleName.Team, action, ScopeType.Team, teamId.Value);
                    _permCache[teamKey] = teamAllowed;
                }
                if (teamAllowed) return true;

                // Kiểm tra quyền OwnTeam - nếu user là leader của team này
                var ownTeamKey = (action, ScopeType.OwnTeam, teamId);
                if (!_permCache.TryGetValue(ownTeamKey, out bool ownTeamAllowed))
                {
                    ownTeamAllowed = await _permissionService.HasPermissionAsync(_currentAccountId.Value, ModuleName.Team, action, ScopeType.OwnTeam, teamId.Value);
                    _permCache[ownTeamKey] = ownTeamAllowed;
                }
                if (ownTeamAllowed) return true;
            }

            return false;
        }

        private async Task<bool> CanPerformOnTeam(TeamDto team, PermissionAction action)
        {
            return await HasPermissionAsync(action, team.TeamId);
        }

        private async Task InitializeData()
        {
            // Chỉ load teams mà user có quyền xem
            if (_isMasterAccount)
            {
                allTeams = await _teamService.SearchAsync(searchTextBox.Text.Trim());
            }
            else if (_currentAccountId.HasValue)
            {
                // Kiểm tra quyền global trước
                bool hasGlobalView = await HasPermissionAsync(PermissionAction.View);
                if (hasGlobalView)
                {
                    allTeams = await _teamService.SearchAsync(searchTextBox.Text.Trim());
                }
                else
                {
                    // Chỉ load teams mà user có quyền
                    var allTeamsTemp = await _teamService.SearchAsync(searchTextBox.Text.Trim());
                    allTeams = new List<TeamDto>();
                    
                    foreach (var team in allTeamsTemp)
                    {
                        if (await CanPerformOnTeam(team, PermissionAction.View))
                        {
                            allTeams.Add(team);
                        }
                    }
                }
            }
            else
            {
                allTeams = new List<TeamDto>();
            }
        }

        private void LoadTeams()
        {
            teamsListView.Items.Clear();

            foreach (var team in allTeams)
            {
                var memberCount = team.Members.Count;
                var item = new ListViewItem(team.Name);
                item.SubItems.Add(memberCount.ToString());
                item.SubItems.Add(team.CreatedAt.ToString("dd/MM/yyyy"));
                item.Tag = team;

                teamsListView.Items.Add(item);
            }

            membersListView.Items.Clear();
            membersLabel.Text = "👨‍💼 Thành viên Team";
        }

        private void LoadTeamMembers(int teamId)
        {
            membersListView.Items.Clear();

            var selectedTeam = allTeams.FirstOrDefault(t => t.TeamId == teamId);

            var teamMembers = selectedTeam.Members;

            if (selectedTeam != null)
            {
                membersLabel.Text = $"👨‍💼 Thành viên Team: {selectedTeam.Name} ({teamMembers.Count} người)";
            }

            foreach (var member in teamMembers)
            {
                var item = new ListViewItem(member.FullName);
                item.SubItems.Add(member.JoinedAt.ToString("dd/MM/yyyy"));
                item.SubItems.Add(member.IsLeader.ToString());
                item.Tag = member;

                membersListView.Items.Add(item);
            }
        }

        private async void SearchTextBox_TextChanged(object? sender, EventArgs e)
        {
            await InitializeData();
            LoadTeams();
        }

        private void TeamsListView_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (teamsListView.SelectedItems.Count > 0)
            {
                var selectedTeam = (TeamDto)teamsListView.SelectedItems[0].Tag;
                LoadTeamMembers(selectedTeam.TeamId);
            }
        }

        private async void TeamsListView_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = teamsListView.HitTest(e.Location);
                if (hitTest.Item != null)
                {
                    hitTest.Item.Selected = true;
                    var selectedTeam = (TeamDto)hitTest.Item.Tag;
                    
                    // Cập nhật quyền cho context menu cho team cụ thể
                    bool canView = await CanPerformOnTeam(selectedTeam, PermissionAction.View);
                    bool canEdit = await CanPerformOnTeam(selectedTeam, PermissionAction.Edit);
                    bool canDelete = await CanPerformOnTeam(selectedTeam, PermissionAction.Delete);

                    viewDetailsMenuItem.Enabled = canView;
                    editTeamMenuItem.Enabled = canEdit;
                    deleteTeamMenuItem.Enabled = canDelete;
                    addTeamMembers.Enabled = canEdit;

                    teamContextMenu.Show(teamsListView, e.Location);
                }
            }
        }

        private async void AddTeamButton_Click(object? sender, EventArgs e)
        {
            if (!await HasPermissionAsync(PermissionAction.Create))
            {
                MessageBox.Show("Bạn không có quyền tạo team mới.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addTeamForm = new AddTeamForm(_teamService);
            if (addTeamForm.ShowDialog() == DialogResult.OK)
            {
                await InitializeData();
                LoadTeams();
            }
        }

        private async void ViewDetailsMenuItem_Click(object? sender, EventArgs e)
        {
            if (teamsListView.SelectedItems.Count > 0)
            {
                var selectedTeam = (TeamDto)teamsListView.SelectedItems[0].Tag;
                
                if (!await CanPerformOnTeam(selectedTeam, PermissionAction.View))
                {
                    MessageBox.Show("Bạn không có quyền xem chi tiết team này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var teamInfoForm = new TeamInfoForm(selectedTeam, _teamService, _employeeService, false);
                if (teamInfoForm.ShowDialog() == DialogResult.OK)
                {
                    await InitializeData();
                    LoadTeams();
                }
            }
        }

        private async void EditTeamMenuItem_Click(object? sender, EventArgs e)
        {
            if (teamsListView.SelectedItems.Count > 0)
            {
                var selectedTeam = (TeamDto)teamsListView.SelectedItems[0].Tag;
                
                if (!await CanPerformOnTeam(selectedTeam, PermissionAction.Edit))
                {
                    MessageBox.Show("Bạn không có quyền chỉnh sửa team này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var teamInfoForm = new TeamInfoForm(selectedTeam, _teamService, _employeeService, true);
                if (teamInfoForm.ShowDialog() == DialogResult.OK)
                {
                    await InitializeData();
                    LoadTeams();
                }
            }
        }

        private async void DeleteTeamMenuItem_Click(object? sender, EventArgs e)
        {
            if (teamsListView.SelectedItems.Count > 0)
            {
                var selectedTeam = (TeamDto)teamsListView.SelectedItems[0].Tag;
                
                if (!await CanPerformOnTeam(selectedTeam, PermissionAction.Delete))
                {
                    MessageBox.Show("Bạn không có quyền xóa team này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var memberCount = allEmployees.Count(emp => emp.TeamId == selectedTeam.TeamId);

                string message = memberCount > 0
                    ? $"Team '{selectedTeam.Name}' có {memberCount} thành viên.\nBạn có chắc chắn muốn xóa team này không?"
                    : $"Bạn có chắc chắn muốn xóa team '{selectedTeam.Name}' không?";

                var result = MessageBox.Show(message, "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await _teamService.DeleteAsync(selectedTeam.TeamId);
                        await InitializeData();
                        LoadTeams();
                        MessageBox.Show($"Team '{selectedTeam.Name}' đã được xóa!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa team: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void addTeamMembers_Click(object sender, EventArgs e)
        {
            if (teamsListView.SelectedItems.Count == 0) return;

            var selectedTeam = (TeamDto)teamsListView.SelectedItems[0].Tag;
            
            if (!await CanPerformOnTeam(selectedTeam, PermissionAction.Edit))
            {
                MessageBox.Show("Bạn không có quyền thêm thành viên vào team này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addMemberForm = new AddTeamMemberForm(selectedTeam.TeamId, _teamService, _employeeService);
            if (addMemberForm.ShowDialog() == DialogResult.OK)
            {
                await InitializeData();
                LoadTeams();
            }
        }

        private void ApplyModernStyling()
        {
            teamsListView.BackColor = Color.White;
            teamsListView.ForeColor = Color.FromArgb(52, 58, 64);
            teamsListView.BorderStyle = BorderStyle.None;

            membersListView.BackColor = Color.White;
            membersListView.ForeColor = Color.FromArgb(52, 58, 64);
            membersListView.BorderStyle = BorderStyle.None;

            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.BackColor = Color.White;
            searchTextBox.ForeColor = Color.FromArgb(52, 58, 64);

            // Add hover effect to add button
            addTeamButton.MouseEnter += (s, e) => addTeamButton.BackColor = Color.FromArgb(64, 164, 231);
            addTeamButton.MouseLeave += (s, e) => addTeamButton.BackColor = Color.FromArgb(52, 152, 219);
        }
    }
}