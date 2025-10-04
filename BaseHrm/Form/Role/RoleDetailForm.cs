using BaseHrm.Controls;
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

namespace BaseHrm
{
    public partial class RoleDetailForm : Form
    {
        private RoleWithAccountsDto _role;
        private bool _isEditMode;
        private bool _isNewRole;
        private readonly List<RolePermission> _permissions = new List<RolePermission>();

        private readonly IPermissionService _permissionService;

        public RoleDetailForm(IPermissionService permissionService, RoleWithAccountsDto? role = null, bool isEditMode = false)
        {
            InitializeComponent();

            _permissionService = permissionService ?? throw new ArgumentNullException(nameof(permissionService));

            if (role == null)
            {
                _role = new RoleWithAccountsDto
                {
                    RoleId = 0,
                    Name = string.Empty,
                    Description = string.Empty,
                    Accounts = new List<AccountDto>(),
                    RolePermissions = new List<RolePermission>()
                };
                _isNewRole = true;
            }
            else
            {
                _role = role;
                _isNewRole = false;
            }

            _isEditMode = isEditMode || _isNewRole;

            if (_role.RolePermissions != null)
                _permissions.AddRange(_role.RolePermissions);

            InitializeForm();
        }

        private void InitializeForm()
        {
            lblTitle.Text = _isEditMode ? (_isNewRole ? "Create Role" : "Edit Role") : "Role Details";
            Text = lblTitle.Text;

            btnSave.Visible = _isEditMode;
            btnAddPermission.Visible = _isEditMode;
            btnCancel.Text = _isEditMode ? "Cancel" : "Close";

            SetControlsReadOnly(!_isEditMode);
            InitializeAccountsDataGridView();
        }

        private void RoleDetailForm_Load(object sender, EventArgs e)
        {
            LoadRoleData();
            LoadPermissions();
            LoadAccounts();
        }

        private void LoadRoleData()
        {
            txtRoleId.Text = _isNewRole ? "Auto-generated" : _role.RoleId.ToString();
            txtRoleName.Text = _role.Name ?? string.Empty;
            txtDescription.Text = _role.Description ?? string.Empty;
        }

        private void InitializeAccountsDataGridView()
        {
            accountDtoBindingSource.DataSource = _role.Accounts ?? new List<AccountDto>();
            dgvAccounts.DataSource = accountDtoBindingSource;
            dgvAccounts.Refresh();
        }

        private void LoadAccounts()
        {
            accountDtoBindingSource.DataSource = _role.Accounts ?? new List<AccountDto>();
            dgvAccounts.Refresh();
        }

        private void SetControlsReadOnly(bool readOnly)
        {
            txtRoleName.ReadOnly = readOnly;
            txtDescription.ReadOnly = readOnly;
            txtRoleId.ReadOnly = true;

            var bg = readOnly ? Color.FromArgb(248, 249, 250) : Color.White;
            txtRoleName.BackColor = bg;
            txtDescription.BackColor = bg;
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

        private Panel CreatePermissionControl(RolePermission permission)
        {
            var panel = new Panel
            {
                Size = new Size(850, 80),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            // Module ComboBox
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

            // Actions CheckedListBox
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

            var txtScopeValue = new TextBox
            {
                Location = new Point(665, 12),
                Size = new Size(80, 25),
                Text = permission.ScopeValue?.ToString() ?? "",
                ReadOnly = !_isEditMode,
                PlaceholderText = "Value"
            };
            panel.Controls.Add(txtScopeValue);

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
            var permission = panel.Tag as RolePermission;
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

        private void RemovePermission(Panel panel, RolePermission permission)
        {
            _permissions.Remove(permission);
            flowLayoutPermissions.Controls.Remove(panel);
        }

        #region Validation & Save

        private bool ValidateInput()
        {
            var errorMessages = new List<string>();

            // Validate role name
            var roleName = txtRoleName.Text?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(roleName))
            {
                errorMessages.Add("Tên role không được để trống");
            }
            else if (roleName.Length < 3)
            {
                errorMessages.Add("Tên role phải có ít nhất 3 ký tự");
            }
            else if (roleName.Length > 50)
            {
                errorMessages.Add("Tên role không được quá 50 ký tự");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(roleName, @"^[a-zA-ZÀ-ỹ0-9\s\-_.]+$"))
            {
                errorMessages.Add("Tên role chỉ được chứa chữ cái, số, khoảng trắng, dấu gạch ngang, gạch dưới và dấu chấm");
            }

            // Validate description length
            var description = txtDescription.Text?.Trim() ?? "";
            if (description.Length > 500)
            {
                errorMessages.Add("Mô tả không được quá 500 ký tự");
            }

            // Validate permissions
            if (_permissions.Count == 0)
            {
                errorMessages.Add("Role phải có ít nhất một quyền");
            }
            else
            {
                for (int i = 0; i < _permissions.Count; i++)
                {
                    var permission = _permissions[i];
                    
                    // Check if permission has no actions
                    if (permission.Actions == PermissionAction.None)
                    {
                        errorMessages.Add($"Quyền {i + 1} ({permission.Module}) phải có ít nhất một hành động");
                    }

                    // Validate scope value for specific scope types
                    if (permission.ScopeType == ScopeType.Team && !permission.ScopeValue.HasValue)
                    {
                        errorMessages.Add($"Quyền {i + 1} ({permission.Module}) với phạm vi Team phải có ID team");
                    }
                    else if (permission.ScopeType == ScopeType.Team && permission.ScopeValue.HasValue && permission.ScopeValue.Value <= 0)
                    {
                        errorMessages.Add($"Quyền {i + 1} ({permission.Module}) có ID team không hợp lệ");
                    }

                    // Check for duplicate permissions (same module and scope)
                    var duplicates = _permissions.Where(p => 
                        p != permission && 
                        p.Module == permission.Module && 
                        p.ScopeType == permission.ScopeType && 
                        p.ScopeValue == permission.ScopeValue).ToList();
                    
                    if (duplicates.Any())
                    {
                        errorMessages.Add($"Có quyền trùng lặp cho module {permission.Module} với phạm vi {permission.ScopeType}");
                    }
                }

                // Check for logical conflicts
                var globalPermissions = _permissions.Where(p => p.ScopeType == ScopeType.Global).ToList();
                var restrictedPermissions = _permissions.Where(p => p.ScopeType != ScopeType.Global).ToList();

                foreach (var global in globalPermissions)
                {
                    var conflicts = restrictedPermissions.Where(r => r.Module == global.Module).ToList();
                    if (conflicts.Any())
                    {
                        errorMessages.Add($"Module {global.Module} có cả quyền Global và quyền hạn chế, điều này có thể gây xung đột");
                    }
                }
            }

            // Show validation errors
            if (errorMessages.Count > 0)
            {
                var message = "Vui lòng sửa các lỗi sau:\n\n";
                for (int i = 0; i < Math.Min(errorMessages.Count, 10); i++)
                {
                    message += $"{i + 1}. {errorMessages[i]}\n";
                }
                
                if (errorMessages.Count > 10)
                {
                    message += $"\n... và {errorMessages.Count - 10} lỗi khác";
                }

                MessageBox.Show(message, "Lỗi Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                // Focus on appropriate tab
                if (errorMessages.Any(e => e.Contains("Tên role") || e.Contains("Mô tả")))
                {
                    tabControl.SelectedTab = tabBasicInfo;
                    if (errorMessages.Any(e => e.Contains("Tên role")))
                    {
                        txtRoleName.Focus();
                    }
                }
                else if (errorMessages.Any(e => e.Contains("quyền") || e.Contains("Quyền")))
                {
                    tabControl.SelectedTab = tabPermissions;
                }

                return false;
            }

            return true;
        }

        private async Task SaveRoleAsync()
        {
            if (!ValidateInput()) return;
            Role role = new Role
            {
                RoleId = _role.RoleId,
                Name = txtRoleName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
            };
            Console.WriteLine("Permissions to save:" + _permissions.ToString());
            try
            {
                if (_isNewRole)
                {
                    Role newRole =  await _permissionService.CreateRoleAsync(role);
                    _permissions.ForEach(rp => rp.RoleId = newRole.RoleId);
                    await _permissionService.AddAndUpdateRolePermission(_permissions);
                }
                else
                {
                    await _permissionService.UpdateRoleAsync(role);
                    await _permissionService.AddAndUpdateRolePermission(_permissions);
                }
                    
                MessageBox.Show("Role saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving role: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event handlers (UI)

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            var newPermission = new RolePermission
            {
                RoleId = _role.RoleId,
                Module = ModuleName.Employee,
                Actions = PermissionAction.View,
                ScopeType = ScopeType.Global
            };

            _permissions.Add(newPermission);

            var ctrl = CreatePermissionControl(newPermission);
            flowLayoutPermissions.Controls.Add(ctrl);

            flowLayoutPermissions.ScrollControlIntoView(ctrl);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveRoleAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
