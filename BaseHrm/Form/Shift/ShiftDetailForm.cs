using BaseHrm.Controls;
using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
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
    public partial class ShiftDetailForm : Form
    {
        private readonly IShiftService _shiftService;
        private readonly IServiceProvider _serviceProvider;
        private ShiftAssignmentDto? _shiftAssignment;
        private List<ShiftTypeDto>? _shiftTypes;
        private int _shiftId;

        private bool _isEditMode = false;
        public ShiftDetailForm(int shiftId, IShiftService shiftService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _shiftService = shiftService;
            _shiftId = shiftId;
            _serviceProvider = serviceProvider;
            this.Load += async (s, e) =>
             {
                 await LoadShiftDetail();
                 LoadForm();
             };

        }

        private async Task LoadShiftDetail()
        {
            _shiftAssignment = await _shiftService.GetAssignmentByIdAsync(_shiftId);
            _shiftTypes = await _shiftService.GetAllShiftTypesAsync();

        }

        private void LoadForm()
        {
            txtShiftName.Text = _shiftAssignment?.ShiftName ?? "";
            txtStartTime.Text = _shiftAssignment?.ShiftStart.ToString() ?? "";
            txtEndTime.Text = _shiftAssignment?.ShiftEnd.ToString() ?? "";
            txtExpectedHours.Text = _shiftAssignment?.ExpectedHours.ToString() ?? "";
            cmbShiftType.DataSource = _shiftTypes;
            cmbShiftType.DisplayMember = "Name";
            cmbShiftType.ValueMember = "ShiftTypeId";

            if (_shiftAssignment != null && _shiftTypes != null && !string.IsNullOrEmpty(_shiftAssignment.ShiftTypeName))
            {
                var match = _shiftTypes.FirstOrDefault(x => x.Name == _shiftAssignment.ShiftTypeName);
                if (match != null)
                {
                    cmbShiftType.SelectedValue = match.ShiftTypeId;
                }
            }

            txtAssignmentDate.Format = DateTimePickerFormat.Custom;
            txtAssignmentDate.CustomFormat = "dd/MM/yyyy";
            if (_shiftAssignment != null)
            {
                txtAssignmentDate.Value = _shiftAssignment.Date;
            }
            txtApprovedBy.Text = _shiftAssignment?.ApproverName ?? "N/A";

            txtEmployeeId.Text = _shiftAssignment?.EmployeeId.ToString() ?? "";
            txtEmployeeName.Text = _shiftAssignment?.EmployeeFullName ?? "";
            txtEmail.Text = _shiftAssignment?.EmployeeEmail ?? "N/A";
            txtPhone.Text = _shiftAssignment?.EmployeePhone ?? "N/A";
            txtPosition.Text = _shiftAssignment?.EmployeePosition ?? "N/A";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isEditMode = true;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            txtShiftName.BackColor = Color.White;
            txtShiftName.ForeColor = Color.Blue;
            txtShiftName.ReadOnly = false;
            txtStartTime.BackColor = Color.White;
            txtStartTime.ForeColor = Color.Blue;
            txtStartTime.ReadOnly = false;
            txtEndTime.BackColor = Color.White;
            txtEndTime.ForeColor = Color.Blue;
            txtEndTime.ReadOnly = false;
            txtAssignmentDate.BackColor = Color.White;
            txtAssignmentDate.ForeColor = Color.Blue;
            txtAssignmentDate.Enabled = true;

            cmbShiftType.Enabled = true;
            cmbShiftType.BackColor = Color.White;

            changeEmployee.Visible = true;
            changeEmployee.Enabled = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_shiftAssignment == null)
            {
                MessageBox.Show("No shift assignment data to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _shiftAssignment.ShiftName = txtShiftName.Text;
                if (TimeSpan.TryParse(txtStartTime.Text, out var startTime))
                    _shiftAssignment.ShiftStart = startTime;
                if (TimeSpan.TryParse(txtEndTime.Text, out var endTime))
                    _shiftAssignment.ShiftEnd = endTime;
                var duration = _shiftAssignment.ShiftEnd - _shiftAssignment.ShiftStart;
                _shiftAssignment.ExpectedHours = (decimal)duration.TotalHours;
                _shiftAssignment.Date = txtAssignmentDate.Value;


                await _shiftService.UpdateShiftAsync(
                    new ShiftDto
                    {
                        ShiftId = _shiftAssignment.ShiftId,
                        Name = _shiftAssignment.ShiftName,
                        StartTime = _shiftAssignment.ShiftStart,
                        EndTime = _shiftAssignment.ShiftEnd,
                        ExpectedHours = _shiftAssignment.ExpectedHours,
                        ShiftTypeId = cmbShiftType.SelectedValue != null ? (int)cmbShiftType.SelectedValue : 0
                    });
                await _shiftService.UpdateAssignmentAsync(_shiftAssignment);
                MessageBox.Show("Shift updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving shift: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void changeEmployee_Click(object sender, EventArgs e)
        {
            var _employeeService = (IEmployeeService?)_serviceProvider.GetService(typeof(IEmployeeService));
            if (_employeeService == null)
            {
                MessageBox.Show("Employee service not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pick = new PickEmployeeControl(_employeeService);

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
                    if (_shiftAssignment == null) return;

                    Console.WriteLine($"Selected Employee: {emp.EmployeeId} - {emp.FirstName} {emp.LastName}");
                    _shiftAssignment.EmployeeId = emp.EmployeeId;
                    _shiftAssignment.EmployeeFirstName = emp.FirstName;
                    _shiftAssignment.EmployeeLastName = emp.LastName;
                    _shiftAssignment.EmployeeEmail = emp.Email;
                    _shiftAssignment.EmployeePhone = emp.Phone;
                    _shiftAssignment.EmployeePosition = emp.Position;


                    LoadForm();
                }));

                popup.Close();
            };

            pick.RequestClose += () => popup.Close();

            var point = Cursor.Position; 
            popup.Show(point);

            pick.Focus();
        }
    }
}
