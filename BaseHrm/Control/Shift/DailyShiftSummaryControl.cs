using BaseHrm.Data.DTO;
using BaseHrm.Data.Models;
using BaseHrm.Data.Service;
using BaseHrm.Reports;
using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace BaseHrm.Controls
{
    public partial class DailyShiftSummaryControl : UserControl
    {
        private readonly IShiftService _shiftService;
        private readonly IServiceProvider _serviceProvider;

        private List<ShiftTypeDto>? _shiftTypes;
        private List<ShiftAssignmentDto>? _shiftAssignments;

        private ShiftAssignmentDto? _selectedShift;

        private EmployeeDto? _selectedEmployee;
        private TeamDto? _selectedTeam;

        private bool _isInitialLoad = true;
        public DailyShiftSummaryControl(IShiftService shiftService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _shiftService = shiftService;
            _serviceProvider = serviceProvider;
            this.Load += async (s, e) =>
            {
                await LoadShiftType();
                await LoadShiftAssignments();
                LoadPanelSummaryCards();
                UpdateCharts();
                _isInitialLoad = false;
            };
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFromDate.Value = firstDayOfMonth;

        }

        private void LoadPanelSummaryCards()
        {
            if (_shiftAssignments == null)
            {
                lblTotalHoursValue.Text = "0.00";
                lblTotalEmployeesValue.Text = "0";
                lblTotalShiftsValue.Text = "0";
                lblAverageHoursValue.Text = "0.00";
                return;
            }

            lblTotalHoursValue.Text = _shiftAssignments.Sum(sa => sa.ExpectedHours).ToString("F2");
            lblTotalEmployeesValue.Text = _shiftAssignments.Select(sa => sa.EmployeeId).Distinct().Count().ToString();
            lblTotalShiftsValue.Text = _shiftAssignments.Count.ToString();
            lblAverageHoursValue.Text = (_shiftAssignments.Count > 0 ? _shiftAssignments.Average(sa => sa.ExpectedHours) : 0).ToString("F2");
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
                    employeeId: _selectedEmployee?.EmployeeId,
                    teamId: _selectedTeam?.TeamId
                );

                Helper.PrintJson(_shiftAssignments);

                shiftAssignmentDtoBindingSource.DataSource = _shiftAssignments;
                dgvShiftAssignments.DataSource = shiftAssignmentDtoBindingSource;
                dgvShiftAssignments.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load: {ex.Message}");
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await refresh();
        }

        private async Task refresh()
        {
            await LoadShiftAssignments();
            UpdateCharts();
            LoadPanelSummaryCards();
        }

        private async void shiftInfo_Click(object sender, EventArgs e)
        {
            using (var shiftDetailForm = new ShiftDetailForm(_selectedShift?.ShiftAssignmentId ?? 0, _shiftService, _serviceProvider))
            {
                var result = shiftDetailForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    await LoadShiftAssignments();
                }
            }
        }


        private void dgvShiftAssignments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvShiftAssignments.ClearSelection();
            dgvShiftAssignments.Rows[e.RowIndex].Selected = true;

            int colIndex = e.ColumnIndex >= 0 ? e.ColumnIndex : 0;
            dgvShiftAssignments.CurrentCell = dgvShiftAssignments.Rows[e.RowIndex].Cells[colIndex];

            if (dgvShiftAssignments.Rows[e.RowIndex].DataBoundItem is ShiftAssignmentDto shiftAssignment)
            {
                _selectedShift = shiftAssignment;
            }
            if (e.Button == MouseButtons.Right)
            {
                shiftContextMenu.Show(Cursor.Position);
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
                    await refresh();
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
            await refresh();
        }

        private async void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;
            await refresh();
        }

        private async void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;
            await refresh();
        }

        private async void btnDelEmployee_Click(object sender, EventArgs e)
        {
            if (_isInitialLoad) return;
            if (_selectedEmployee == null) return;
            _selectedEmployee = null;
            txtEmployee.Text = "";
            await refresh();
        }

        private void UpdateCharts()
        {
            var pltLine = formsPlot1.Plot;
            pltLine.Clear();

            if (_shiftAssignments == null || _shiftAssignments.Count == 0)
            {
                formsPlot1.Refresh();
                formsPlot2.Refresh();
                return;
            }

            var daily = _shiftAssignments
            .GroupBy(s => s.Date.Date)
            .OrderBy(g => g.Key)
            .Select(g => new { Date = g.Key, Count = g.Count() })
            .ToArray();


            if (daily.Length > 0)
            {
                double[] xs = daily.Select(d => d.Date.ToOADate()).ToArray();
                double[] ys = daily.Select(d => (double)d.Count).ToArray();
                var scatter = pltLine.Add.Scatter(xs, ys);
                scatter.LegendText = "Số ca";
                scatter.MarkerSize = 5;

                pltLine.Axes.DateTimeTicksBottom();


                pltLine.Title("Số ca theo ngày");
                pltLine.XLabel("Ngày");
                pltLine.YLabel("Số ca");

                pltLine.Axes.SetLimits(
                    left: xs.First() - 0.5,
                    right: xs.Last() + 0.5
                );
            }


            formsPlot1.Refresh();

            var pltBar = formsPlot2.Plot;
            pltBar.Clear();


            var byShift = _shiftAssignments
            .GroupBy(s => s.ShiftTypeName)
            .Select(g => new { Name = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ToArray();


            if (byShift.Length > 0)
            {
                double[] values = byShift.Select(b => (double)b.Count).ToArray();
                double[] positions = Enumerable.Range(0, values.Length).Select(i => (double)i).ToArray();


                var bar = pltBar.Add.Bars(positions, values);


                pltBar.Axes.SetLimits(left: -0.5, right: positions.Length - 0.5);
                var bottomAxis = pltBar.Axes.Bottom;
                double[] tickPositions = positions;
                string[] tickLabels = byShift.Select(b => b.Name ?? "").ToArray();
                bottomAxis.SetTicks(tickPositions, tickLabels);


                pltBar.Title("Số ca theo loại ca");
                pltBar.XLabel("Loại ca");
                pltBar.YLabel("Số ca");
            }


            formsPlot2.Refresh();
        }

        private async void btnExportReport_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date;
            string selectedPath = "";
            var t = new Thread((ThreadStart)(() =>
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                sfd.Title = "Chọn đường dẫn lưu báo cáo";
                sfd.FileName = "BaoCaoCaLam.xlsx";
                if (sfd.ShowDialog() == DialogResult.Cancel)
                    return;

                selectedPath = sfd.FileName;
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            Console.WriteLine(value: selectedPath);
            btnExportReport.Enabled = false;

            var shiftAssignmentCopy = (_shiftAssignments ?? new List<ShiftAssignmentDto>()).ToList();
            string reportTitle = $"Báo Cáo Ca Làm Từ {from:dd/MM/yyyy} Đến {to:dd/MM/yyyy}";
            if (selectedPath == "")
            {
                btnExportReport.Enabled = true;
                return;
            }
            await Task.Run(() =>
            {
                var exporter = new ShiftAssignmentReportExporter();
                exporter.ExportToExcel(shiftAssignmentCopy, selectedPath!, reportTitle, from, to);
            });

            MessageBox.Show("Báo cáo đã được xuất thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnExportReport.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var _employeeService = (ITeamService)_serviceProvider.GetService(typeof(ITeamService));
            var pick = new PickTeamControl(_employeeService);

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

            pick.TeamSelected += async (emp) =>
            {
                this.Invoke(new Action(async () =>
                {
                    _selectedTeam = emp;
                    textBox1.Text = emp.Name;
                    await refresh();
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
