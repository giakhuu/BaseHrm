using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class PickEmployeeControl : UserControl
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPermissionService? _permissionService;
        private readonly IAuthService? _authService;
        private readonly ILogger<PickEmployeeControl>? _logger;
        private List<EmployeeDto> _employees = new List<EmployeeDto>();

        // Permission related fields
        private int? _currentAccountId;
        private bool _isMasterAccount;
        private int? _currentEmployeeId;

        public event Action<EmployeeDto>? EmployeeSelected;
        public event Action? RequestClose;
        public EmployeeDto? SelectedEmployee { get; private set; }

        // Property to filter employees based on specific criteria (optional)
        public Func<EmployeeDto, bool>? EmployeeFilter { get; set; }

        // Property to restrict to specific teams (optional)
        public List<int>? RestrictToTeamIds { get; set; }

        public PickEmployeeControl(
            IEmployeeService employeeService,
            IPermissionService? permissionService = null,
            IAuthService? authService = null,
            ILogger<PickEmployeeControl>? logger = null)
        {
            InitializeComponent();
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _permissionService = permissionService;
            _authService = authService;
            _logger = logger;

            this.Load += async (s, e) => 
            {
                await InitializePermissionsAsync();
                await LoadEmployeesAsync();
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

                    _logger?.LogDebug("PickEmployeeControl initialized - AccountId: {AccountId}, IsMaster: {IsMaster}, EmployeeId: {EmployeeId}",
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

        private async Task<bool> HasPermissionToViewEmployeesAsync()
        {
            if (_isMasterAccount) return true;
            
            if (_permissionService == null || !_currentAccountId.HasValue)
            {
                _logger?.LogWarning("Permission services not available - allowing access");
                return true; // Backward compatibility
            }

            try
            {
                // Check if user has any permission to view employees
                bool hasAnyPermission = await _permissionService.HasModuleAccessAsync(
                    _currentAccountId.Value, ModuleName.Employee, PermissionAction.View);

                _logger?.LogDebug("User has employee view access: {HasAccess}", hasAnyPermission);
                return hasAnyPermission;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error checking employee view permission");
                return true; // Fail-safe
            }
        }

        #endregion

        #region Employee Loading and Filtering

        private async Task LoadEmployeesAsync()
        {
            try
            {
                // Check if user has permission to view employees
                if (!await HasPermissionToViewEmployeesAsync())
                {
                    _logger?.LogWarning("User does not have permission to view employees");
                    _employees = new List<EmployeeDto>();
                    UpdateDataSource();
                    return;
                }

                var searchQuery = txtSearch.Text?.Trim() ?? string.Empty;
                _logger?.LogDebug("Loading employees with search query: '{SearchQuery}'", searchQuery);

                // Load employees from service (this already applies permission filtering)
                var allEmployees = await _employeeService.SearchEmployeesAsync(searchQuery) ?? new List<EmployeeDto>();
                _logger?.LogDebug("Retrieved {Count} employees from service", allEmployees.Count);

                // Apply additional filters
                _employees = ApplyAdditionalFilters(allEmployees);
                _logger?.LogDebug("After additional filtering: {Count} employees", _employees.Count);

                UpdateDataSource();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error loading employees");
                _employees = new List<EmployeeDto>();
                UpdateDataSource();
                
                MessageBox.Show("Lỗi tải danh sách nhân viên. Vui lòng thử lại.", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<EmployeeDto> ApplyAdditionalFilters(List<EmployeeDto> employees)
        {
            var filteredEmployees = employees.AsEnumerable();

            // Apply team restriction if specified
            if (RestrictToTeamIds?.Any() == true)
            {
                filteredEmployees = filteredEmployees.Where(emp => 
                    emp.TeamIds?.Any(teamId => RestrictToTeamIds.Contains(teamId)) == true);
                
                _logger?.LogDebug("Applied team restriction to teams: {TeamIds}", string.Join(", ", RestrictToTeamIds));
            }

            // Apply custom employee filter if specified
            if (EmployeeFilter != null)
            {
                filteredEmployees = filteredEmployees.Where(EmployeeFilter);
                _logger?.LogDebug("Applied custom employee filter");
            }

            // Filter out inactive employees by default
            filteredEmployees = filteredEmployees.Where(emp => emp.IsActive);

            return filteredEmployees.OrderBy(emp => emp.FullName).ToList();
        }

        private void UpdateDataSource()
        {
            try
            {
                employeeDtoBindingSource.DataSource = _employees;
                dgvEmployees.DataSource = employeeDtoBindingSource;
                dgvEmployees.Refresh();

                // Update UI feedback
                UpdateEmployeeCountLabel();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating data source");
            }
        }

        private void UpdateEmployeeCountLabel()
        {
            try
            {
                // Add a status label if it exists in the designer
                var statusLabel = this.Controls.Find("lblStatus", true).FirstOrDefault() as Label;
                if (statusLabel != null)
                {
                    statusLabel.Text = _employees.Any() 
                        ? $"Tìm thấy {_employees.Count} nhân viên"
                        : "Không tìm thấy nhân viên nào";
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error updating employee count label");
            }
        }

        #endregion

        #region Event Handlers

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadEmployeesAsync();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in search text changed handler");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var current = employeeDtoBindingSource.Current as EmployeeDto;
                if (current != null)
                {
                    SelectedEmployee = current;
                    _logger?.LogDebug("Employee selected: {EmployeeId} - {FullName}", current.EmployeeId, current.FullName);
                    EmployeeSelected?.Invoke(current);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn 1 nhân viên.", "Chọn nhân viên", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in select button click handler");
                MessageBox.Show("Lỗi khi chọn nhân viên. Vui lòng thử lại.", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEmployees_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvEmployees.Rows.Count) return;

                var row = dgvEmployees.Rows[e.RowIndex];
                if (row?.DataBoundItem is EmployeeDto emp)
                {
                    SelectedEmployee = emp;
                    _logger?.LogDebug("Employee double-clicked: {EmployeeId} - {FullName}", emp.EmployeeId, emp.FullName);
                    EmployeeSelected?.Invoke(emp);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error in double click handler");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Refresh the employee list
        /// </summary>
        public async Task RefreshAsync()
        {
            await LoadEmployeesAsync();
        }

        /// <summary>
        /// Set focus to search textbox
        /// </summary>
        public void FocusSearch()
        {
            txtSearch.Focus();
        }

        /// <summary>
        /// Clear search and reload all employees
        /// </summary>
        public async Task ClearSearchAsync()
        {
            txtSearch.Text = "";
            await LoadEmployeesAsync();
        }

        /// <summary>
        /// Restrict visible employees to specific teams
        /// </summary>
        public async Task RestrictToTeamsAsync(List<int> teamIds)
        {
            RestrictToTeamIds = teamIds;
            await LoadEmployeesAsync();
        }

        /// <summary>
        /// Apply custom filter to employees
        /// </summary>
        public async Task ApplyFilterAsync(Func<EmployeeDto, bool> filter)
        {
            EmployeeFilter = filter;
            await LoadEmployeesAsync();
        }

        /// <summary>
        /// Clear all filters and reload
        /// </summary>
        public async Task ClearFiltersAsync()
        {
            RestrictToTeamIds = null;
            EmployeeFilter = null;
            await LoadEmployeesAsync();
        }

        #endregion
    }
}
