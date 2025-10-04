using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
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

namespace BaseHrm.Controls
{
    public partial class PickShiftAssignmentControl : UserControl
    {
        private readonly IShiftService _shiftService;
        private readonly IServiceProvider _serviceProvider;

        private List<ShiftTypeDto>? _shiftTypes;
        private List<ShiftAssignmentDto>? _shiftAssignments;


        private EmployeeDto? _selectedEmployee;

        public event Action<ShiftAssignmentDto>? ShiftAsignmentSelected;
        public event Action? RequestClose;

        public ShiftAssignmentDto? SelectedShiftAsignment { get; private set; }

        private bool _isInitialLoad = true;
        public PickShiftAssignmentControl(IShiftService shiftService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _shiftService = shiftService;
            _serviceProvider = serviceProvider;
            this.Load += async (s, e) =>
            {
                await LoadShiftType();
                await LoadShiftAssignments();
                _isInitialLoad = false;
            };

        }

        private async Task LoadShiftType()
        {
            _shiftTypes = await _shiftService.GetAllShiftTypesAsync();

            var placeholder = new ShiftTypeDto
            {
                ShiftTypeId = 0,   
                Name = "--chọn loại ca--"
            };

            var listWithPlaceholder = _shiftTypes.ToList();
            listWithPlaceholder.Insert(0, placeholder);

            cmbShiftFilter.DisplayMember = "Name";
            cmbShiftFilter.ValueMember = "ShiftTypeId";
            cmbShiftFilter.DataSource = listWithPlaceholder;

            cmbShiftFilter.SelectedIndex = 0; 
        }


        private async Task LoadShiftAssignments()
        {
            try
            {
                var selectedType = cmbShiftFilter.SelectedItem as ShiftTypeDto;
                if (selectedType == null) return;

                int? shiftTypeId = null;
                if (selectedType.ShiftTypeId != 0)
                {
                    shiftTypeId = selectedType.ShiftTypeId;
                }

                _shiftAssignments = await _shiftService.QueryAssignmentsAsync(
                    dateFrom: dtpFromDate.Value,
                    dateTo: dtpToDate.Value,
                    shiftTypeId: shiftTypeId,
                    employeeId: _selectedEmployee?.EmployeeId
                );

                Console.WriteLine($"Đã load {_shiftAssignments.Count}");

                shiftAssignmentDtoBindingSource.DataSource = _shiftAssignments;
                dgvShiftAssignments.DataSource = shiftAssignmentDtoBindingSource;
                dgvShiftAssignments.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load: {ex.Message}");
            }
        }




        private async void button1_Click(object sender, EventArgs e)
        {
            var _employeeService = (IEmployeeService)_serviceProvider.GetService(typeof(IEmployeeService));
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

            pick.EmployeeSelected += async (emp) =>
            {
                this.Invoke(new Action(async () =>
                {
                    _selectedEmployee = emp;
                    txtEmployee.Text = emp.FullName;
                    await LoadShiftAssignments();
                }));
                popup.Close();
            };

            pick.RequestClose += () => popup.Close();

            var point = Cursor.Position;
            popup.Show(point);

            pick.Focus();
        }

        private async void cmbShiftFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;
            await LoadShiftAssignments();
        }

        private async void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;

            await LoadShiftAssignments();
        }

        private async void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;
            await LoadShiftAssignments();
        }

        private async void btnDelEmployee_Click(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;
            if (_selectedEmployee == null) return;
            _selectedEmployee = null;
            txtEmployee.Text = "";
            await LoadShiftAssignments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var current = shiftAssignmentDtoBindingSource.Current as ShiftAssignmentDto;
            if (current != null)
            {
                SelectedShiftAsignment = current;
                ShiftAsignmentSelected?.Invoke(current);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 ca làm.", "Chọn ca làm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvShiftAssignments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvShiftAssignments.Rows.Count) return;

            var row = dgvShiftAssignments.Rows[e.RowIndex];
            if (row?.DataBoundItem is ShiftAssignmentDto shiftAssignment)
            {
                SelectedShiftAsignment = shiftAssignment;
                ShiftAsignmentSelected?.Invoke(shiftAssignment);
            }
        }
    }
}
