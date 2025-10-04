using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using BaseHrm.Data.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class PickTeamControl : UserControl
    {
        private readonly ITeamService _teamService;
        private readonly IPermissionService? _permissionService;
        private readonly IAuthService? _authService;
        private readonly ILogger<PickTeamControl>? _logger;
        private List<TeamDto> _teams = new List<TeamDto>();

        // Permission related fields
        private int? _currentAccountId;
        private bool _isMasterAccount;
        private int? _currentEmployeeId;

        public event Action<TeamDto>? TeamSelected;
        public event Action? RequestClose;
        public TeamDto? SelectedTeam { get; private set; }

        // Property to filter teams based on specific criteria (optional)
        public Func<TeamDto, bool>? TeamFilter { get; set; }

        // Property to restrict to specific teamIds (optional)
        public List<int>? RestrictToTeamIds { get; set; }

        public PickTeamControl(
            ITeamService teamService,
            IPermissionService? permissionService = null,
            IAuthService? authService = null,
            ILogger<PickTeamControl>? logger = null)
        {
            InitializeComponent();
            _teamService = teamService ?? throw new ArgumentNullException(nameof(teamService));
            _permissionService = permissionService;
            _authService = authService;
            _logger = logger;

            this.Load += async (s, e) => 
            {
                await InitializePermissionsAsync();
                await LoadTeamsAsync();
            };

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) RequestClose?.Invoke();
            };
        }

        #region Permission Management

        private async Task InitializePermissionsAsync()
        {
            try
            {
                if (_authService != null)
                {
                    var userInfo = _authService.GetUserInfoFromToken();
                    _currentAccountId = userInfo.AccountId;
                    _isMasterAccount = userInfo.IsMaster;
                    _currentEmployeeId = userInfo.EmployeeId;

                    _logger?.LogDebug("PickTeamControl initialized - AccountId: {AccountId}, IsMaster: {IsMaster}, EmployeeId: {EmployeeId}",
                        _currentAccountId, _isMasterAccount, _currentEmployeeId);
                }
                else
                {
                    _logger?.LogWarning("AuthService not available - permission filtering disabled");
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error initializing permissions");
            }
        }

        private async Task<bool> HasPermissionToViewTeamsAsync()
        {
            if (_isMasterAccount) return true;
            if (_permissionService == null || !_currentAccountId.HasValue)
            {
                _logger?.LogWarning("Permission services not available - allowing access");
                return true; // Backward compatibility
            }
            try
            {
                bool hasAnyPermission = await _permissionService.HasModuleAccessAsync(
                    _currentAccountId.Value, ModuleName.Team, PermissionAction.View);
                _logger?.LogDebug("User has team view access: {HasAccess}", hasAnyPermission);
                return hasAnyPermission;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error checking team view permission");
                return true; // Fail-safe
            }
        }

        #endregion

        #region Team Loading and Filtering

        private async Task LoadTeamsAsync()
        {
            try
            {
                if (!await HasPermissionToViewTeamsAsync())
                {
                    _logger?.LogWarning("User does not have permission to view teams");
                    _teams = new List<TeamDto>();
                    UpdateDataSource();
                    return;
                }
                var searchQuery = txtSearch.Text?.Trim() ?? string.Empty;
                _logger?.LogDebug("Loading teams with search query: '{SearchQuery}'", searchQuery);
                var allTeams = await _teamService.SearchAsync(searchQuery) ?? new List<TeamDto>();
                _logger?.LogDebug("Retrieved {Count} teams from service", allTeams.Count);
                _teams = ApplyAdditionalFilters(allTeams);
                _logger?.LogDebug("After additional filtering: {Count} teams", _teams.Count);
                UpdateDataSource();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error loading teams");
                _teams = new List<TeamDto>();
                UpdateDataSource();
                MessageBox.Show("L?i t?i danh sách team. Vui lòng th? l?i.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<TeamDto> ApplyAdditionalFilters(List<TeamDto> teams)
        {
            var filteredTeams = teams.AsEnumerable();
            if (RestrictToTeamIds?.Any() == true)
            {
                filteredTeams = filteredTeams.Where(team => RestrictToTeamIds.Contains(team.TeamId));
                _logger?.LogDebug("Applied team restriction to teams: {TeamIds}", string.Join(", ", RestrictToTeamIds));
            }
            if (TeamFilter != null)
            {
                filteredTeams = filteredTeams.Where(TeamFilter);
                _logger?.LogDebug("Applied custom team filter");
            }
            return filteredTeams.OrderBy(team => team.Name).ToList();
        }

        private void UpdateDataSource()
        {
            try
            {
                teamDtoBindingSource.DataSource = _teams;
                dgvTeams.DataSource = teamDtoBindingSource;
                dgvTeams.Refresh();
                UpdateTeamCountLabel();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating data source");
            }
        }

        private void UpdateTeamCountLabel()
        {
            try
            {
                var statusLabel = this.Controls.Find("lblStatus", true).FirstOrDefault() as Label;
                if (statusLabel != null)
                {
                    statusLabel.Text = _teams.Any() 
                        ? $"Tìm th?y {_teams.Count} team" : "Không tìm th?y team nào";
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating team count label");
            }
        }

        #endregion

        #region Event Handlers

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadTeamsAsync();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in search text changed handler");
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                var current = teamDtoBindingSource.Current as TeamDto;
                if (current != null)
                {
                    SelectedTeam = current;
                    _logger?.LogDebug("Team selected: {TeamId} - {Name}", current.TeamId, current.Name);
                    TeamSelected?.Invoke(current);
                }
                else
                {
                    MessageBox.Show("Vui lòng ch?n 1 team.", "Ch?n team", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in select button click handler");
                MessageBox.Show("L?i khi ch?n team. Vui lòng th? l?i.", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvTeams_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvTeams.Rows.Count) return;
                var row = dgvTeams.Rows[e.RowIndex];
                if (row?.DataBoundItem is TeamDto team)
                {
                    SelectedTeam = team;
                    _logger?.LogDebug("Team double-clicked: {TeamId} - {Name}", team.TeamId, team.Name);
                    TeamSelected?.Invoke(team);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in double click handler");
            }
        }

        #endregion

        #region Public Methods

        public async Task RefreshAsync()
        {
            await LoadTeamsAsync();
        }

        public void FocusSearch()
        {
            txtSearch.Focus();
        }

        public async Task ClearSearchAsync()
        {
            txtSearch.Text = "";
            await LoadTeamsAsync();
        }

        public async Task RestrictToTeamsAsync(List<int> teamIds)
        {
            RestrictToTeamIds = teamIds;
            await LoadTeamsAsync();
        }

        public async Task ApplyFilterAsync(Func<TeamDto, bool> filter)
        {
            TeamFilter = filter;
            await LoadTeamsAsync();
        }

        public async Task ClearFiltersAsync()
        {
            RestrictToTeamIds = null;
            TeamFilter = null;
            await LoadTeamsAsync();
        }

        #endregion
    }
}
