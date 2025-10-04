using BaseHrm.Controls;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Enums;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm
{
    public partial class AccountDetailForm : Form
    {
        private AccountDto _account;
        private bool _isEditMode;
        private bool _isNewAccount;

        private readonly IAccountService _accountService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPermissionService _permissionService;

        private BindingList<RoleWithAccountsDto> _assignedRoles = new BindingList<RoleWithAccountsDto>();
        private List<RoleWithAccountsDto> _addRoles = new List<RoleWithAccountsDto>();
        private List<AccountPermission> _permissions = new List<AccountPermission>();

        private bool _isInitializing = false;
        public AccountDetailForm
            (IAccountService accountService,
            IServiceProvider serviceProvider,
            IPermissionService permissionService,
            AccountDto? account = null,
            bool isEditMode = false
            )
        {
            _accountService = accountService;
            _serviceProvider = serviceProvider;
            _permissionService = permissionService;
            InitializeComponent();
            _account = account ?? throw new ArgumentNullException(nameof(account));
            _isEditMode = isEditMode;
            _isNewAccount = false;
            InitializeForm();
            this.Load += async (s, e) =>
            {
                await LoadRoleData();
                await LoadAccountPermissions();
                LoadPermissions();
            };
        }

        private void InitializeForm()
        {

            // Set form title and mode
            if (_isNewAccount)
            {
                lblTitle.Text = "Thêm tài khoản mới";
                this.Text = "Thêm tài khoản mới";
            }
            else if (_isEditMode)
            {
                lblTitle.Text = "Chỉnh sửa tài khoản";
                this.Text = "Chỉnh sửa tài khoản";
            }
            else
            {
                lblTitle.Text = "Thông tin tài khoản";
                this.Text = "Thông tin tài khoản";
            }

            SetControlsReadOnly(!_isEditMode);

            btnSave.Visible = _isEditMode;
            if (!_isEditMode)
            {
                btnCancel.Text = "Close";
            }
            roleWithAccountsDtoBindingSource.DataSource = _assignedRoles;
            dgvRoles.AutoGenerateColumns = true;
            dgvRoles.DataSource = roleWithAccountsDtoBindingSource;

        }

        private void SetControlsReadOnly(bool readOnly)
        {
            txtUsername.ReadOnly = readOnly;
            txtPassword.ReadOnly = readOnly;
            if (cmbRole != null)
                cmbRole.Enabled = !readOnly;
            if (chkIsMaster != null)
                chkIsMaster.Enabled = !readOnly;

            txtEmployeeId.ReadOnly = true;
            txtEmployeeName.ReadOnly = true;
            txtEmployeeEmail.ReadOnly = true;
            txtEmployeePhone.ReadOnly = true;
            txtEmployeePosition.ReadOnly = true;

            var bgColor = readOnly ? Color.FromArgb(248, 249, 250) : Color.White;
            txtUsername.BackColor = readOnly ? Color.FromArgb(248, 249, 250) : Color.White;
            txtPassword.BackColor = readOnly ? Color.FromArgb(248, 249, 250) : Color.White;
            btnAddRole.Enabled = !readOnly;
            btnAddPermission.Enabled = !readOnly;
        }

        private void AccountDetailForm_Load(object sender, EventArgs e)
        {
            LoadAccountData();
        }

        private async Task LoadAccountPermissions()
        {
            var (accountPermission, permission) = await _permissionService.GetEffectivePermissionsAsync(_account.AccountId);
            _permissions = accountPermission;
        }

        private async Task LoadRoleData()
        {
            try
            {
                var roles = await _permissionService.SearchRolesAsync(accountId: _account.AccountId);

                Action update = () =>
                {
                    _assignedRoles.RaiseListChangedEvents = false;
                    _assignedRoles.Clear();
                    foreach (var r in roles)
                        _assignedRoles.Add(r);
                    _assignedRoles.RaiseListChangedEvents = true;
                    roleWithAccountsDtoBindingSource.ResetBindings(false);
                };

                if (this.IsHandleCreated && this.InvokeRequired)
                    this.Invoke(update);
                else
                    update();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void LoadAccountData()
        {
            if (_account != null)
            {
                txtAccountId.Text = _account.AccountId.ToString();
                txtUsername.Text = _account.Username;
                txtPassword.Text = _isEditMode ? "" : "••••••••"; 
                if (cmbRole != null)
                    cmbRole.SelectedItem = _account.Role;
                if (chkIsMaster != null)
                    chkIsMaster.Checked = _account.IsMaster;
                txtLastLogin.Text = _account.LastLogin?.ToString("dd/MM/yyyy HH:mm") ?? "Never";

                txtEmployeeId.Text = _account.EmployeeId.ToString();
                txtEmployeeName.Text = _account.EmployeeFullName;
                txtEmployeeEmail.Text = _account.EmployeeEmail;
                txtEmployeePhone.Text = _account.EmployeePhone ?? "";
                txtEmployeePosition.Text = _account.EmployeePositionName ?? "";
            }

            if (_isNewAccount)
            {
                txtAccountId.Text = "Auto-generated";
                txtLastLogin.Text = "N/A";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (_isNewAccount && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for new accounts.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private async Task SaveAccount()
        {
            if (!ValidateInput())
                return;

            try
            {
                UpdateAccountDto updateAccountDto = new UpdateAccountDto
                {
                    AccountId = _account.AccountId,
                    Username = txtUsername.Text.Trim(),
                    IsMaster = chkIsMaster?.Checked ?? false,
                    NewPassword = txtPassword.Text.Trim()
                };

                await _accountService.UpdateAsync(updateAccountDto);

                foreach (var role in _addRoles)
                {
                    await _permissionService.AssignRoleToAccountAsync(_account.AccountId, role.RoleId);
                }
                ;

                await _permissionService.AddAndUpdateAccountPermission(_permissions);

                MessageBox.Show("Account saved successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving account: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAccount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var pick = _serviceProvider.GetRequiredService<PickRoleControl>();

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

            pick.RoleSelected += (role) =>
            {
                this.Invoke(new Action(() =>
                {
                    if (!_assignedRoles.Any(r => r.RoleId == role.RoleId))
                    {
                        _assignedRoles.Add(role); 
                        _addRoles.Add(role);
                        roleWithAccountsDtoBindingSource.ResetBindings(false);
                    }
                    else
                    {
                        MessageBox.Show($"Role '{role.Name}' đã được gán cho account.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }));

                popup.Close();
            };


            pick.RequestClose += () => popup.Close();


            var point = Cursor.Position;
            popup.Show(point);

            pick.Focus();
        }


        private void LoadPermissions()
        {
            flowLayoutPermissions.Controls.Clear();

            foreach (var permission in _permissions)
            {
                var permissionControl = CreatePermissionControl(permission);
                flowLayoutPermissions.Controls.Add(permissionControl);
            }
        }

        private Panel CreatePermissionControl(AccountPermission permission)
        {
            var panel = new Panel
            {
                Size = new Size(850, 80),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            var lblModule = new Label
            {
                Text = "Module:",
                Location = new Point(15, 15),
                Size = new Size(60, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            panel.Controls.Add(lblModule);

            var cmbModule = new ComboBox
            {
                Location = new Point(80, 12),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = _isEditMode
            };
            foreach (ModuleName module in Enum.GetValues<ModuleName>())
            {
                cmbModule.Items.Add(module);
            }
            cmbModule.SelectedItem = permission.Module;
            panel.Controls.Add(cmbModule);

            var lblActions = new Label
            {
                Text = "Actions:",
                Location = new Point(220, 15),
                Size = new Size(60, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            panel.Controls.Add(lblActions);

            var clbActions = new CheckedListBox
            {
                Location = new Point(285, 12),
                Size = new Size(200, 60),
                CheckOnClick = true,
                Enabled = _isEditMode
            };

            var actions = new[] { PermissionAction.View, PermissionAction.Create, PermissionAction.Edit, PermissionAction.Delete };
            foreach (var action in actions)
            {
                var index = clbActions.Items.Add(action.ToString());
                clbActions.SetItemChecked(index, (permission.Actions & action) == action);
            }
            panel.Controls.Add(clbActions);

            // Scope ComboBox
            var lblScope = new Label
            {
                Text = "Scope:",
                Location = new Point(500, 15),
                Size = new Size(50, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            panel.Controls.Add(lblScope);

            var cmbScope = new ComboBox
            {
                Location = new Point(555, 12),
                Size = new Size(100, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled = _isEditMode
            };
            foreach (ScopeType scope in Enum.GetValues<ScopeType>())
            {
                cmbScope.Items.Add(scope);
            }
            cmbScope.SelectedItem = permission.ScopeType;
            panel.Controls.Add(cmbScope);

            // Scope Value TextBox
            var txtScopeValue = new TextBox
            {
                Location = new Point(665, 12),
                Size = new Size(80, 25),
                Text = permission.ScopeValue?.ToString() ?? "",
                ReadOnly = !_isEditMode,
                PlaceholderText = "Value"
            };
            panel.Controls.Add(txtScopeValue);

            // Delete Button (only in edit mode)
            if (_isEditMode)
            {
                var btnDelete = new Button
                {
                    Text = "✕",
                    Location = new Point(755, 12),
                    Size = new Size(30, 25),
                    BackColor = Color.FromArgb(220, 53, 69),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnDelete.FlatAppearance.BorderSize = 0;
                btnDelete.Click += (s, e) => RemovePermission(panel, permission);
                panel.Controls.Add(btnDelete);
            }

            panel.Tag = permission;

            if (_isEditMode)
            {
                cmbModule.SelectedIndexChanged += (s, e) => UpdatePermissionFromControl(panel);
                clbActions.ItemCheck += (s, e) =>
                {
                    this.BeginInvoke(new Action(() => UpdatePermissionFromControl(panel)));
                };
                cmbScope.SelectedIndexChanged += (s, e) => UpdatePermissionFromControl(panel);
                txtScopeValue.TextChanged += (s, e) => UpdatePermissionFromControl(panel);
            }

            return panel;
        }
        private void UpdatePermissionFromControl(Panel panel)
        {
            var permission = panel.Tag as AccountPermission;
            if (permission == null) return;

            var cmbModule = panel.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Location.X == 80);
            var clbActions = panel.Controls.OfType<CheckedListBox>().FirstOrDefault();
            var cmbScope = panel.Controls.OfType<ComboBox>().FirstOrDefault(c => c.Location.X == 555);
            var txtScopeValue = panel.Controls.OfType<TextBox>().FirstOrDefault();

            if (cmbModule?.SelectedItem != null)
                permission.Module = (ModuleName)cmbModule.SelectedItem;

            if (clbActions != null)
            {
                permission.Actions = PermissionAction.None;
                var actions = new[] { PermissionAction.View, PermissionAction.Create, PermissionAction.Edit, PermissionAction.Delete };
                for (int i = 0; i < clbActions.Items.Count; i++)
                {
                    if (clbActions.GetItemChecked(i))
                    {
                        permission.Actions |= actions[i];
                    }
                }
            }

            if (cmbScope?.SelectedItem != null)
                permission.ScopeType = (ScopeType)cmbScope.SelectedItem;

            if (txtScopeValue != null && int.TryParse(txtScopeValue.Text, out int scopeValue))
                permission.ScopeValue = scopeValue;
            else
                permission.ScopeValue = null;
        }

        private void RemovePermission(Panel panel, AccountPermission permission)
        {
            _permissions.Remove(permission);
            flowLayoutPermissions.Controls.Remove(panel);
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            var newPermission = new AccountPermission
            {
                AccountId = _account.AccountId,
                Module = ModuleName.Employee,
                Actions = PermissionAction.View,
                ScopeType = ScopeType.Global
            };

            _permissions.Add(newPermission);

            var ctrl = CreatePermissionControl(newPermission);
            flowLayoutPermissions.Controls.Add(ctrl);

            flowLayoutPermissions.ScrollControlIntoView(ctrl);
        }
    }
}