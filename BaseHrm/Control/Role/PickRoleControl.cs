using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class PickRoleControl : UserControl
    {
        private readonly IPermissionService _permissionService;
        private List<RoleWithAccountsDto> _roles = new List<RoleWithAccountsDto>();

        public event Action<RoleWithAccountsDto>? RoleSelected;

        public event Action? RequestClose;

        public RoleWithAccountsDto? SelectedRole { get; private set; }

        public PickRoleControl(IPermissionService roleService)
        {
            InitializeComponent();
            _permissionService = roleService ?? throw new ArgumentNullException(nameof(roleService));

            this.Load += async (s, e) => await LoadRolesAsync();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) RequestClose?.Invoke();
            };
        }

        private async Task LoadRolesAsync()
        {
            var q = txtSearch.Text?.Trim() ?? string.Empty;
            try
            {
                _roles = (await _permissionService.SearchRolesAsync(q)) ?? new List<RoleWithAccountsDto>();
            }
            catch
            {
                _roles = new List<RoleWithAccountsDto>();
            }

            roleWithAccountsDtoBindingSource.DataSource = _roles;
            dgvRoles.DataSource = roleWithAccountsDtoBindingSource;
            dgvRoles.Refresh();
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadRolesAsync();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            var current = roleWithAccountsDtoBindingSource.Current as RoleWithAccountsDto;
            if (current != null)
            {
                SelectedRole = current;
                RoleSelected?.Invoke(current);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 role.", "Chọn role", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvRoles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRoles.Rows.Count) return;

            var row = dgvRoles.Rows[e.RowIndex];
            if (row?.DataBoundItem is RoleWithAccountsDto role)
            {
                SelectedRole = role;
                RoleSelected?.Invoke(role);
            }
        }
    }
}
