using BaseHrm.Controls;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using BaseHrm.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm
{
    public partial class AddAccountForm : Form
    {
        private EmployeeDto? _selectedEmployee;

        private readonly IServiceProvider _serviceProvider;
        private readonly IAccountService _accountService;

        public AddAccountForm(
            IAccountService accountService,
            IServiceProvider serviceProvider
        )
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            InitializeComponent();
            ValidateForm();
        }

        private void ValidateForm()
        {
            btnSave.Enabled = !string.IsNullOrWhiteSpace(txtUsername.Text)
                && !string.IsNullOrWhiteSpace(txtPassword.Text)
                && !string.IsNullOrWhiteSpace(txtConfirmPassword.Text)
                && _selectedEmployee != null;
        }

        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private async Task<bool> ValidateInputAsync()
        {
            var errors = new List<string>();

            // Validate using ValidationHelper
            var accountErrors = ValidationHelper.ValidateAccountData(
                txtUsername.Text?.Trim() ?? "",
                txtPassword.Text ?? "",
                txtConfirmPassword.Text ?? ""
            );

            errors.AddRange(accountErrors);

            // Check if username already exists
            try
            {
                var existingAccount = await _accountService.GetByUsernameAsync(txtUsername.Text?.Trim() ?? "");
                if (existingAccount != null)
                {
                    errors.Add("Username này đã tồn tại. Vui lòng chọn username khác");
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Lỗi kiểm tra username: {ex.Message}");
            }

            // Employee validation
            if (_selectedEmployee == null)
            {
                errors.Add("Hãy chọn nhân viên để liên kết với tài khoản");
            }
            else
            {
                // Check if employee already has an account
                try
                {
                    var existingAccounts = await _accountService.SearchAsync(employeeId: _selectedEmployee.EmployeeId);
                    if (existingAccounts != null && existingAccounts.Any())
                    {
                        errors.Add($"Nhân viên {_selectedEmployee.FullName} đã có tài khoản. Vui lòng chọn nhân viên khác");
                    }
                }
                catch (Exception ex)
                {
                    errors.Add($"Lỗi kiểm tra nhân viên: {ex.Message}");
                }
            }

            // Show validation errors if any
            if (errors.Count > 0)
            {
                this.ShowDetailedValidationErrors(errors, "Lỗi tạo tài khoản");
                
                // Focus on appropriate field
                if (errors.Any(e => e.Contains("Username")))
                {
                    txtUsername.Focus();
                }
                else if (errors.Any(e => e.Contains("Mật khẩu")))
                {
                    txtPassword.Focus();
                }
                else if (errors.Any(e => e.Contains("nhân viên")))
                {
                    btnSelectEmployee.Focus();
                }
                
                return false;
            }

            return true;
        }

        private bool HasValidPasswordStrength(string password)
        {
            return ValidationHelper.IsValidPassword(password);
        }

        private async Task SaveAccount()
        {
            if (!await ValidateInputAsync())
                return;

            try
            {
                CreateAccountDto createAccountDto = new CreateAccountDto
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    EmployeeId = _selectedEmployee!.EmployeeId
                };

                await _accountService.CreateAsync(createAccountDto);

                MessageBox.Show("Tạo tài khoản thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo tài khoản: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectEmployee_Click(object sender, EventArgs e)
        {
            var pick = _serviceProvider.GetRequiredService<PickEmployeeControl>();

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

            pick.EmployeeSelected += (emp) =>
            {
                this.Invoke(new Action(() =>
                {
                    _selectedEmployee = emp;
                    txtEmployeeId.Text = emp.EmployeeId.ToString();
                    txtEmployeeName.Text = emp.FullName;
                    txtEmployeePosition.Text = emp.Position ?? "N/A";
                    txtEmployeeEmail.Text = emp.Email;
                    txtEmployeePhone.Text = emp.Phone;
                    ValidateForm();
                }));

                popup.Close();
            };

            pick.RequestClose += () => popup.Close();

            var point = Cursor.Position;
            popup.Show(point);

            pick.Focus();
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

        private void txtChangeValidate_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }
    }
}