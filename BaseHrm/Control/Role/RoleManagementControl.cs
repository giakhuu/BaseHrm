using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class RoleManagementControl : UserControl
    {
        private List<RoleWithAccountsDto> _roles = new List<RoleWithAccountsDto>();
        private List<RoleWithAccountsDto> _filteredRoles = new List<RoleWithAccountsDto>();
        private RoleWithAccountsDto? _selectedRole = null;

        private readonly IPermissionService _permissionService;
        private IServiceProvider _serviceProvider;
        private bool _suspendSelectionChanged = false;
        private bool _isLoading = false;
        private CancellationTokenSource? _loadCts;

        public RoleManagementControl(IPermissionService permissionService, IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
            lblTotalRoles.Text = "0 Quyền";
            lblTotalAccounts.Text = "0 Tài khoản được cấp quyền";
            lblSelectedRole.Text = "Chọn 1 quyền để xem các tài khoản được cấp quyền";
            _serviceProvider = serviceProvider;
        }

        private async void RoleManagementControl_Load(object sender, EventArgs e)
        {
            await SafeLoadRolesAsync();
        }
        private async Task SafeLoadRolesAsync()
        {
            _loadCts?.Cancel();
            _loadCts?.Dispose();
            _loadCts = new CancellationTokenSource();

            try
            {
                await LoadRoles(_loadCts.Token);
            }
            catch (OperationCanceledException)
            {
                // expected on rapid refresh; ignore
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRoles(CancellationToken ct = default)
        {
            if (_isLoading) return;
            _isLoading = true;
            btnRefresh.Enabled = false;
            try
            {
                var roles = await _permissionService.SearchRolesAsync(name: txtSearch.Text, ct: ct);
                if (ct.IsCancellationRequested) ct.ThrowIfCancellationRequested();

                _roles = roles ?? new List<RoleWithAccountsDto>();
                ApplyFilters();
                UpdateStatistics();
            }
            finally
            {
                _isLoading = false;
                btnRefresh.Enabled = true;
            }
        }

        private void ApplyFilters()
        {
            var searchTerm = txtSearch.Text?.Trim().ToLower() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _filteredRoles = _roles.ToList();
            }
            else
            {
                _filteredRoles = _roles
                    .Where(r => (r.Name ?? string.Empty).ToLower().Contains(searchTerm))
                    .ToList();
            }

            UpdateRolesDataGridView();
        }

        private void UpdateRolesDataGridView()
        {
            _suspendSelectionChanged = true;
            try
            {
                if (roleWithAccountsDtoBindingSource is BindingSource bs)
                {
                    bs.RaiseListChangedEvents = false;
                }

                roleWithAccountsDtoBindingSource.DataSource = _filteredRoles;

                dgvRoles.ClearSelection();

                if (dgvRoles.Rows.Count > 0)
                {
                    dgvRoles.Rows[0].Selected = true;
                    if (dgvRoles.Rows[0].Cells.Count > 0)
                        dgvRoles.CurrentCell = dgvRoles.Rows[0].Cells[0];
                }
            }
            finally
            {
                if (roleWithAccountsDtoBindingSource is BindingSource bs2)
                {
                    bs2.RaiseListChangedEvents = true;
                    bs2.ResetBindings(false);
                }

                _suspendSelectionChanged = false;

                _selectedRole = GetSelectedRole();
                if (_selectedRole != null)
                {
                    lblSelectedRole.Text = $"Quyền: {_selectedRole.Name}";
                }
                else
                {
                    lblSelectedRole.Text = "Chọn 1 quyền để xem các tài khoản được cấp quyền";
                }
                UpdateAccountsDataGridView();
            }
        }


        private void UpdateAccountsDataGridView()
        {
            accountDtoBindingSource.DataSource = _selectedRole?.Accounts ?? new List<AccountDto>();
            dgvAccounts.ClearSelection();
        }

        private void UpdateStatistics()
        {
            lblTotalRoles.Text = $"{_filteredRoles.Count} Quyền";
            var totalAccounts = _filteredRoles.Sum(r => r.Accounts?.Count ?? 0);
            lblTotalAccounts.Text = $"{totalAccounts} Tài khoản được cấp quyền";
        }

        private RoleWithAccountsDto? GetSelectedRole()
        {
            if (dgvRoles.SelectedRows != null && dgvRoles.SelectedRows.Count > 0)
            {
                var item = dgvRoles.SelectedRows[0].DataBoundItem as RoleWithAccountsDto;
                return item;
            }

            if (dgvRoles.CurrentRow != null)
            {
                var item = dgvRoles.CurrentRow.DataBoundItem as RoleWithAccountsDto;
                return item;
            }

            return null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            UpdateStatistics();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await SafeLoadRolesAsync();
        }

        private void dgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (_suspendSelectionChanged) return;
            if (_isLoading) return;

            _selectedRole = GetSelectedRole();
            if (_selectedRole != null)
            {
                lblSelectedRole.Text = $"Role: {_selectedRole.Name}";
                UpdateAccountsDataGridView();
            }
            else
            {
                lblSelectedRole.Text = "Chọn 1 quyền để xem các tài khoản được cấp quyền";
                accountDtoBindingSource.DataSource = new List<AccountDto>();
                dgvAccounts.ClearSelection();
            }
        }

        private void dgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ViewRoleDetails();
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewRoleDetails();
        }

        private void editRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRole();
        }

        private void deleteRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRole();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var detailForm = ActivatorUtilities.CreateInstance<RoleDetailForm>(_serviceProvider);
            detailForm.ShowDialog();
        }

        private void ViewRoleDetails()
        {
            var selected = GetSelectedRole();
            if (selected == null) return;
            var detailForm = ActivatorUtilities.CreateInstance<RoleDetailForm>(_serviceProvider, selected);
            detailForm.ShowDialog();

        }

        private void EditRole()
        {
            var selected = GetSelectedRole();
            if (selected == null) return;

            var detailForm = ActivatorUtilities.CreateInstance<RoleDetailForm>(_serviceProvider, selected, true);
            detailForm.ShowDialog();
        }

        private async void DeleteRole()
        {
            var selectedRole = GetSelectedRole();
            if (selectedRole == null) return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete the role '{selectedRole.Name}'?\n\nThis action cannot be undone and will affect all accounts assigned to this role.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                MessageBox.Show("Role deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await SafeLoadRolesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalAccounts_Click(object sender, EventArgs e)
        {

        }
    }
}
