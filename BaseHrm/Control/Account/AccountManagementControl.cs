using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm.Controls
{
    public partial class AccountManagementControl : UserControl
    {
        private List<AccountDto> _accounts = new List<AccountDto>();
        private List<AccountDto> _filteredAccounts = new List<AccountDto>();

        private readonly IAccountService _accountService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPositionService _positionService;
        private readonly IPermissionService _permissionService;
        private readonly IAuthService _authService;

        private int? _currentAccountId;
        private bool _isMasterAccount;
        private readonly Dictionary<(PermissionAction action, ScopeType scope, int? scopeValue), bool> _permCache
            = new Dictionary<(PermissionAction, ScopeType, int?), bool>();

        public AccountManagementControl(
            IAccountService accountService,
            IServiceProvider serviceProvider,
            IPositionService positionService,
            IPermissionService permissionService,
            IAuthService authService
        )
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            
            InitializeComponent();
            this.Load += async (s, e) =>
            {
                await InitializeIdentityAsync();
                await SetupPermissions();
                await InitializeDataGridView();
                await InitializeFilters();
            };
        }

        private async Task InitializeIdentityAsync()
        {
            try
            {
                var info = _authService.GetUserInfoFromToken();
                _currentAccountId = info.AccountId;
                _isMasterAccount = info.IsMaster;
                _permCache.Clear();
            }
            catch
            {
                _currentAccountId = null;
                _isMasterAccount = false;
            }
        }

        private async Task SetupPermissions()
        {
            if (_isMasterAccount) return;

            // Kiểm tra quyền và ẩn/hiện các nút
            bool canCreate = await HasPermissionAsync(PermissionAction.Create);
            bool canView = await HasPermissionAsync(PermissionAction.View);
            bool canEdit = await HasPermissionAsync(PermissionAction.Edit);
            bool canDelete = await HasPermissionAsync(PermissionAction.Delete);

            btnAddAccount.Visible = canCreate;
            
            // Setup context menu permissions
            viewDetailsToolStripMenuItem.Enabled = canView;
            editAccountToolStripMenuItem.Enabled = canEdit;
            deleteAccountToolStripMenuItem.Enabled = canDelete;
        }

        private async Task<bool> HasPermissionAsync(PermissionAction action, int? targetAccountId = null)
        {
            if (_isMasterAccount) return true;
            if (!_currentAccountId.HasValue) return false;

            var key = (action, ScopeType.Global, (int?)null);
            if (!_permCache.TryGetValue(key, out bool globalAllowed))
            {
                globalAllowed = await _permissionService.HasPermissionAsync(_currentAccountId.Value, ModuleName.Account, action, ScopeType.Global);
                _permCache[key] = globalAllowed;
            }
            if (globalAllowed) return true;

            // Kiểm tra quyền Self - chỉ được thao tác với account của chính mình
            if (targetAccountId.HasValue && _currentAccountId.HasValue && targetAccountId.Value == _currentAccountId.Value)
            {
                var selfKey = (action, ScopeType.Self, (int?)null);
                if (!_permCache.TryGetValue(selfKey, out bool selfAllowed))
                {
                    selfAllowed = await _permissionService.HasPermissionAsync(_currentAccountId.Value, ModuleName.Account, action, ScopeType.Self);
                    _permCache[selfKey] = selfAllowed;
                }
                if (selfAllowed) return true;
            }

            return false;
        }

        private async Task<bool> CanPerformOnAccount(AccountDto account, PermissionAction action)
        {
            return await HasPermissionAsync(action, account.AccountId);
        }

        private async Task InitializeDataGridView()
        {
            if (_isMasterAccount || (_currentAccountId.HasValue && await HasPermissionAsync(PermissionAction.View)))
            {
                _accounts = await _accountService.SearchAsync();
            }
            else
            {
                // Chỉ load account của chính mình nếu có quyền Self
                if (_currentAccountId.HasValue && await HasPermissionAsync(PermissionAction.View, _currentAccountId.Value))
                {
                    var myAccount = await _accountService.GetByIdAsync(_currentAccountId.Value);
                    _accounts = myAccount != null ? new List<AccountDto> { myAccount } : new List<AccountDto>();
                }
                else
                {
                    _accounts = new List<AccountDto>();
                }
            }

            accountDtoBindingSource.DataSource = _accounts;
            dgvAccounts.DataSource = accountDtoBindingSource;
            dgvAccounts.Refresh();
        }

        private async Task InitializeFilters()
        {
            var positions = await _positionService.GetAllAsync();
            positions.Insert(0, new PositionDto { PositionId = 0, Name = "Tất cả" });
            cmbRole.DataSource = null;
            cmbRole.DataSource = positions;
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "Name";
            cmbRole.SelectedIndex = 0;
        }

        private void AccountManagementControl_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            try
            {
                ApplyFilters();
                UpdateAccountCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            _filteredAccounts = _accounts.Where(account =>
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var searchTerm = txtSearch.Text.ToLower();
                    if (!account.Username.ToLower().Contains(searchTerm) &&
                        !account.EmployeeFullName.ToLower().Contains(searchTerm))
                    {
                        return false;
                    }
                }

                if (cmbRole.SelectedIndex > 0)
                {
                    var selectedPosition = cmbRole.SelectedItem as PositionDto;
                    Console.WriteLine($"{selectedPosition.Name} == {account.EmployeePositionName}");
                    if (selectedPosition != null &&
                        !string.Equals(account.EmployeePositionName, selectedPosition.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
                return true;
            }).ToList();
            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            accountDtoBindingSource.DataSource = _filteredAccounts;
            dgvAccounts.DataSource = accountDtoBindingSource;
            dgvAccounts.Refresh();
        }

        private void UpdateAccountCount()
        {
            lblTotalAccounts.Text = $"{_filteredAccounts.Count} trong {_accounts.Count} tài khoản";
        }

        private AccountDto? GetSelectedAccount()
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                return dgvAccounts.SelectedRows[0].DataBoundItem as AccountDto;
            }
            return null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            UpdateAccountCount();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            UpdateAccountCount();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            UpdateAccountCount();
        }

        private void chkShowMasterOnly_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            UpdateAccountCount();
        }

        private async void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (!await HasPermissionAsync(PermissionAction.Create))
            {
                MessageBox.Show("Bạn không có quyền tạo tài khoản mới.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var addForm = _serviceProvider.GetRequiredService<AddAccountForm>();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                await InitializeDataGridView();
                LoadAccounts();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await InitializeDataGridView();
            LoadAccounts();
        }

        private async void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedAccount = GetSelectedAccount();
                if (selectedAccount != null && await CanPerformOnAccount(selectedAccount, PermissionAction.View))
                {
                    ViewAccountDetails();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền xem chi tiết tài khoản này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedAccount = GetSelectedAccount();
            if (selectedAccount != null)
            {
                if (await CanPerformOnAccount(selectedAccount, PermissionAction.View))
                {
                    ViewAccountDetails();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền xem chi tiết tài khoản này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedAccount = GetSelectedAccount();
            if (selectedAccount != null)
            {
                if (await CanPerformOnAccount(selectedAccount, PermissionAction.Edit))
                {
                    EditAccount();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền chỉnh sửa tài khoản này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedAccount = GetSelectedAccount();
            if (selectedAccount != null)
            {
                if (await CanPerformOnAccount(selectedAccount, PermissionAction.Delete))
                {
                    DeleteAccount();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền xóa tài khoản này.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ViewAccountDetails()
        {
            var selectedAccount = GetSelectedAccount();
            if (selectedAccount != null)
            {
                var detailForm = ActivatorUtilities.CreateInstance<AccountDetailForm>(_serviceProvider, selectedAccount);
                detailForm.ShowDialog();
            }
        }

        private void EditAccount()
        {
            var selectedAccount = GetSelectedAccount();
            if (selectedAccount != null)
            {
                var detailForm = ActivatorUtilities.CreateInstance<AccountDetailForm>(_serviceProvider, selectedAccount, true);
                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAccounts(); 
                }
            }
        }

        private async void DeleteAccount()
        {
            var selectedAccount = GetSelectedAccount();
            if (selectedAccount != null)
            {
                var confirmResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa tài khoản '{selectedAccount.Username}'?",
                    "Xác nhận xóa tài khoản",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        bool success = await _accountService.DeleteAsync(selectedAccount.AccountId);
                        if (success)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await InitializeDataGridView();
                            LoadAccounts();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa tài khoản này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}