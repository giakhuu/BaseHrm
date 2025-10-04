using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
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
    public partial class EmployeeInfoForm : Form
    {
        private readonly int _employeeId;
        private EmployeeDto? _employee;
        private readonly IEmployeeService _employeeService;
        private readonly IServiceProvider _provider;

        public EmployeeInfoForm(int employeeId, EmployeeDto? employee, IEmployeeService employeeService, IServiceProvider provider)
        {
            InitializeComponent();
            _employeeId = employeeId;
            _employee = employee;
            _employeeService = employeeService;
            _provider = provider;

            this.Shown += async (s, e) => await EmployeeInfoForm_ShownAsync();
        }

        private async Task EmployeeInfoForm_ShownAsync()
        {
            try
            {
                if (_employee == null && _employeeId > 0)
                {
                    _employee = await _employeeService.GetByIdAsync(_employeeId);
                }

                PopulateFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thông tin nhân viên: {ex.Message}");
            }
        }

        private void PopulateFields()
        {
            if (_employee == null) return;

            txtEmployeeId.Text = _employee.EmployeeId.ToString();
            txtFirstName.Text = _employee.FirstName ?? string.Empty;
            txtLastName.Text = _employee.LastName ?? string.Empty;
            txtEmail.Text = _employee.Email ?? string.Empty;
            txtPhone.Text = _employee.Phone ?? string.Empty;
            txtAddress.Text = _employee.Address ?? string.Empty;
            cmbGender.Text = _employee.Gender ?? string.Empty;

            if (_employee.HireDate > dtpHireDate.MinDate && _employee.HireDate < dtpHireDate.MaxDate)
            {
                dtpHireDate.Value = _employee.HireDate;
            }
            else
            {
                dtpHireDate.Value = dtpHireDate.MinDate;
            }

            txtMaxHoursPerDay.Text = _employee.MaxHoursPerDay.ToString();
            txtMaxHoursPerMonth.Text = _employee.MaxHoursPerMonth.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditEmployee();
        }

        private async void EditEmployee()
        {
            var positionService = _provider.GetRequiredService<IPositionService>();
            var editForm = new AddEmployeeForm(_employeeService, positionService, _employee);
            if (editForm.ShowDialog() == DialogResult.OK) 
            {
                _employee = await _employeeService.GetByIdAsync(_employeeId);
                PopulateFields();
            }
        }
    }

}
