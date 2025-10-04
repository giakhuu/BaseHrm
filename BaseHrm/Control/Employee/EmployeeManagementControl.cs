using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class EmployeeManagementControl : UserControl
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        private readonly IServiceProvider _provider;
        private readonly IPermissionService _permissionService;
        private readonly IAuthService _authService;

        private List<EmployeeDto> _employees = new List<EmployeeDto>();
        private List<PositionDto> _positions = new List<PositionDto>();
        private bool _initialFlag = false;

        private EmployeeDto? _selectedEmployee;
        private TeamDto? _currentTeam = null;

        private readonly Dictionary<(PermissionAction action, ScopeType scope, int? scopeValue), bool> _permCache
            = new Dictionary<(PermissionAction, ScopeType, int?), bool>();

        private int? _currentAccountId;
        private int? _currentEmployeeId;
        private bool _isMasterAccount;
        private bool _isResetting = false;

        public EmployeeManagementControl(
            IEmployeeService employeeService,
            IServiceProvider provider,
            IPositionService positionService,
            IPermissionService permissionService,
            IAuthService authService)
        {
            InitializeComponent();

            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            this.Load += async (s, e) =>
            {
                await InitializeIdentityAsync();
                await LoadPositon();
                await LoadEmployeesAsync();
                InitializeGenderFilter();
                _initialFlag = true;
            };

            menuItemEdit.Click += async (s, e) => await MenuEdit_ClickAsync(s, e);
            menuItemDelete.Click += async (s, e) => await MenuDelete_ClickAsync(s, e);
            menuItemViewDetails.Click += (s, e) => MenuView_Click(s, e);

            dgvEmployees.CellMouseDown += DgvEmployees_CellMouseDown;
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

        private void InitializeGenderFilter()
        {
            var genders = new List<string> { "Tất cả", "Nam", "Nữ" };
            cmbFilterGender.DataSource = null;
            cmbFilterGender.DataSource = genders;
            cmbFilterGender.SelectedIndex = 0;
            cmbFilterGender.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async Task LoadPositon()
        {
            try
            {
                _positions = await _positionService.GetAllAsync();
                _positions.Insert(0, new PositionDto { PositionId = 0, Name = "Tất cả" });
                cmbFilterPosition.DataSource = null;
                cmbFilterPosition.DataSource = _positions;
                cmbFilterPosition.DisplayMember = "Name";
                cmbFilterPosition.ValueMember = "PositionId";
                cmbFilterPosition.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LoadPosition error: {ex.Message}");
            }
        }

        private async Task LoadEmployeesAsync()
        {
            string? selectedGender = null;
            if (cmbFilterGender.SelectedIndex > 0)
                selectedGender = cmbFilterGender.Text;

            int? positionId = null;
            if (cmbFilterPosition.SelectedValue is int pos && pos != 0)
                positionId = pos;

            int? teamId = _currentTeam?.TeamId;

            try
            {
                _employees = await _employeeService.SearchEmployeesAsync(
                    name: txtSearch.Text.Trim(),
                    email: txtFilterEmail.Text.Trim(),
                    gender: selectedGender,
                    positionId: positionId,
                    teamId: teamId
                ) ?? new List<EmployeeDto>();
                employeeDtoBindingSource.DataSource = new BindingList<EmployeeDto>(_employees);
                dgvEmployees.DataSource = employeeDtoBindingSource;
                dgvEmployees.Refresh();

                lblEmployeeCount.Text = $"Tổng số nhân viên: {_employees.Count}";

                _permCache.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEmployees_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.Button == MouseButtons.Right)
            {
                dgvEmployees.ClearSelection();
                dgvEmployees.Rows[e.RowIndex].Selected = true;

                int colIndex = e.ColumnIndex >= 0 ? e.ColumnIndex : 0;
                dgvEmployees.CurrentCell = dgvEmployees.Rows[e.RowIndex].Cells[colIndex];

                if (dgvEmployees.Rows[e.RowIndex].DataBoundItem is EmployeeDto employee)
                {
                    _selectedEmployee = employee;

                    _ = UpdateContextMenuStateAsync(employee);
                }
            }
        }

        private async Task UpdateContextMenuStateAsync(EmployeeDto emp)
        {
            if (emp == null)
                return;

            bool canView = await CanPerformOnEmployeeAsync(emp, PermissionAction.View);
            bool canEdit = await CanPerformOnEmployeeAsync(emp, PermissionAction.Edit);
            bool canDelete = await CanPerformOnEmployeeAsync(emp, PermissionAction.Delete);

            if (this.IsHandleCreated && this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    menuItemViewDetails.Enabled = canView;
                    menuItemEdit.Enabled = canEdit;
                    menuItemDelete.Enabled = canDelete;
                }));
            }
            else
            {
                menuItemViewDetails.Enabled = canView;
                menuItemEdit.Enabled = canEdit;
                menuItemDelete.Enabled = canDelete;
            }
        }
        private async Task<bool> CanPerformOnEmployeeAsync(EmployeeDto emp, PermissionAction action)
        {
            if (_isMasterAccount) return true;

            if (!_currentAccountId.HasValue) return false;
            int acctId = _currentAccountId.Value;

            var globalKey = (action, ScopeType.Global, (int?)null);
            if (!_permCache.TryGetValue(globalKey, out bool globalAllowed))
            {
                globalAllowed = await _permissionService.HasPermissionAsync(acctId, ModuleName.Employee, action, ScopeType.Global);
                _permCache[globalKey] = globalAllowed;
            }
            if (globalAllowed) return true;

            var teamIds = emp.TeamIds ?? new List<int>();
            foreach (var t in teamIds)
            {
                var k = (action, ScopeType.Team, (int?)t);
                if (!_permCache.TryGetValue(k, out bool allowed))
                {
                    allowed = await _permissionService.HasPermissionAsync(acctId, ModuleName.Employee, action, ScopeType.Team, t);
                    _permCache[k] = allowed;
                }
                if (allowed) return true;
            }

            if (_currentEmployeeId.HasValue && _currentEmployeeId.Value == emp.EmployeeId)
            {
                var selfKey = (action, ScopeType.Self, (int?)null);
                if (!_permCache.TryGetValue(selfKey, out bool selfAllowed))
                {
                    selfAllowed = await _permissionService.HasPermissionAsync(acctId, ModuleName.Employee, action, ScopeType.Self);
                    _permCache[selfKey] = selfAllowed;
                }
                if (selfAllowed) return true;
            }

            EmployeeDto currentEmployee = await _employeeService.GetByIdAsync(_currentEmployeeId ?? 0);
            var _currentTeamIds = currentEmployee?.TeamIds ?? new List<int>();
            var ownTeamKey = (action, ScopeType.OwnTeam, (int?)null);
            if (!_permCache.TryGetValue(ownTeamKey, out bool ownTeamAllowed))
            {
                ownTeamAllowed = await _permissionService.HasPermissionAsync(acctId, ModuleName.Employee, action, ScopeType.OwnTeam);
                _permCache[ownTeamKey] = ownTeamAllowed;
            }
            if (ownTeamAllowed && _currentTeamIds.Any(id => teamIds.Contains(id)))
            {
                return true;
            }

            return false;
        }

        #region Menu actions (Edit / Delete / View)

        private async Task MenuEdit_ClickAsync(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool canEdit = await CanPerformOnEmployeeAsync(_selectedEmployee, PermissionAction.Edit);
            if (!canEdit)
            {
                MessageBox.Show("Bạn không có quyền sửa nhân viên này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // open Edit dialog (reuse your AddEmployeeForm)
            var positionService = _provider.GetRequiredService<IPositionService>();
            var editForm = new AddEmployeeForm(_employeeService, positionService, _selectedEmployee);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployeesAsync();
            }
        }

        private async Task MenuDelete_ClickAsync(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool canDelete = await CanPerformOnEmployeeAsync(_selectedEmployee, PermissionAction.Delete);
            if (!canDelete)
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {_selectedEmployee.FullName}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            bool success = await _employeeService.DeleteAsync(_selectedEmployee.EmployeeId);
            if (!success)
            {
                MessageBox.Show("Xóa nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Xóa nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadEmployeesAsync();
        }

        private void MenuView_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var infoForm = new EmployeeInfoForm(_selectedEmployee.EmployeeId, _selectedEmployee, _employeeService, _provider);
            infoForm.ShowDialog();
        }

        #endregion

        #region Filters & UI events

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_isResetting) return;
            await LoadEmployeesAsync();
        }

        private async void cmbFilterPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isResetting) return;
            if (_initialFlag)
                await LoadEmployeesAsync();
        }

        private async void cmbFilterGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isResetting) return;
            if (_initialFlag)
                await LoadEmployeesAsync();
        }

        private async void btnApplyFilters_Click(object sender, EventArgs e)
        {
            if (_isResetting) return;
            await LoadEmployeesAsync();
        }

        private async void btnClearFilters_Click(object sender, EventArgs e)
        {
            _isResetting = true;
            txtSearch.Text = "";
            txtFilterEmail.Text = "";
            cmbFilterGender.SelectedIndex = 0;
            cmbFilterPosition.SelectedIndex = 0;
            _currentTeam = null;
            txtTeamSearch.Text = "--Chọn Team";
            await LoadEmployeesAsync();
            _isResetting = false;
        }

        private async void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var positionService = _provider.GetRequiredService<IPositionService>();
            var addForm = new AddEmployeeForm(_employeeService, positionService);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadEmployeesAsync();
            }
        }

        private async void btnPickTeam_Click(object sender, EventArgs e)
        {
            var teamService = _provider.GetRequiredService<ITeamService>();
            var pick = new PickTeamControl(teamService);
            var host = new ToolStripControlHost(pick)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
            };
            var popup = new ToolStripDropDown
            {
                AutoClose = true,
                DropShadowEnabled = true
            };
            popup.Items.Add(host);
            pick.TeamSelected += async (team) =>
            {
                this.Invoke(new Action(async () =>
                {
                    _currentTeam = team;
                    txtTeamSearch.Text = team.Name;
                    await LoadEmployeesAsync();
                }));
                popup.Close();
            };
            pick.RequestClose += () => popup.Close();
            var point = Cursor.Position;
            popup.Show(point);
            pick.Focus();
        }

        #endregion


        private async void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (_isResetting) return;
            await LoadEmployeesAsync();
        }

    }
}
