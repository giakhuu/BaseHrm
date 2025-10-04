using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseHrm
{
    public partial class AddTeamMemberForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITeamService _teamService;

        private readonly int _teamId; 

        private List<TeamMemberDto> _teamMembers = new List<TeamMemberDto>();
        private List<EmployeeDto> _employees = new List<EmployeeDto>();
        private List<TeamMemberDto> _existingMembers = new List<TeamMemberDto>();

        public AddTeamMemberForm(int teamId, ITeamService teamService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _teamId = teamId;
            _teamService = teamService;
            _employeeService = employeeService;

            this.Load += async (s, e) => await LoadDataAsync();
        }

        public async Task LoadDataAsync()
        {
            try
            {
                // Load all employees
                _employees = await _employeeService.SearchEmployeesAsync();
                
                // Load existing team members
                var team = await _teamService.GetByIdAsync(_teamId);
                if (team != null && team.Members != null)
                {
                    _existingMembers = team.Members.ToList();
                }

                // Filter out employees who are already members
                var availableEmployees = _employees.Where(e => 
                    !_existingMembers.Any(m => m.EmployeeId == e.EmployeeId)).ToList();

                employeeDtoBindingSource.DataSource = availableEmployees;
                employeeDataGridView.DataSource = employeeDtoBindingSource;
                employeeDataGridView.Refresh();

                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void employeeDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AddSelectedEmployee(e.RowIndex);
            }
        }

        private void AddSelectedEmployee(int rowIndex)
        {
            var row = employeeDataGridView.Rows[rowIndex];
            if (row.DataBoundItem is EmployeeDto employee)
            {
                // Check if employee is already in the list to be added
                if (_teamMembers.Any(m => m.EmployeeId == employee.EmployeeId))
                {
                    MessageBox.Show($"Nhân viên {employee.FullName} đã được thêm vào danh sách.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check if employee is already a team member
                if (_existingMembers.Any(m => m.EmployeeId == employee.EmployeeId))
                {
                    MessageBox.Show($"Nhân viên {employee.FullName} đã là thành viên của team này.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _teamMembers.Add(new TeamMemberDto
                {
                    TeamId = _teamId,          
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                });
                
                LoadTeamMember();
                UpdateUI();
            }
        }

        private void LoadTeamMember()
        {
            teamMemberBindingSource.DataSource = null;
            teamMemberBindingSource.DataSource = _teamMembers;
            teamMemberDataGridView.DataSource = teamMemberBindingSource;
            teamMemberDataGridView.Refresh();
        }

        private void UpdateUI()
        {
            // Update button text with count
            if (hopeButton1 != null)
            {
                hopeButton1.Text = _teamMembers.Count > 0 ? 
                    $"Lưu ({_teamMembers.Count} thành viên)" : "Lưu";
                hopeButton1.Enabled = _teamMembers.Count > 0;
            }
        }

        private bool ValidateMembers()
        {
            if (_teamMembers.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một nhân viên để thêm vào team.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_teamMembers.Count > 50)
            {
                MessageBox.Show("Không thể thêm quá 50 thành viên một lúc.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void hopeButton1_Click(object sender, EventArgs e)
        {
            await Save();
        }

        private async Task Save()
        {
            if (!ValidateMembers())
            {
                return;
            }

            try
            {
                var successCount = 0;
                var errorCount = 0;
                var errors = new List<string>();

                foreach (var member in _teamMembers)
                {
                    try
                    {
                        await _teamService.AddMemberAsync(_teamId, member.EmployeeId);
                        successCount++;
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        errors.Add($"Lỗi thêm {member.FullName}: {ex.Message}");
                    }
                }

                if (successCount > 0 && errorCount == 0)
                {
                    MessageBox.Show($"Thêm thành công {successCount} thành viên vào team!", 
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (successCount > 0 && errorCount > 0)
                {
                    var message = $"Thêm thành công {successCount} thành viên, {errorCount} thất bại:\n\n";
                    message += string.Join("\n", errors.Take(5)); // Show first 5 errors
                    if (errors.Count > 5)
                    {
                        message += $"\n... và {errors.Count - 5} lỗi khác";
                    }
                    
                    MessageBox.Show(message, "Hoàn thành một phần", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    var message = "Không thể thêm thành viên nào:\n\n";
                    message += string.Join("\n", errors.Take(5));
                    if (errors.Count > 5)
                    {
                        message += $"\n... và {errors.Count - 5} lỗi khác";
                    }
                    
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teamMemberDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Handle right-click to remove member
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                var row = teamMemberDataGridView.Rows[e.RowIndex];
                if (row.DataBoundItem is TeamMemberDto member)
                {
                    var result = MessageBox.Show($"Bạn có muốn xóa {member.FullName} khỏi danh sách?", 
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        _teamMembers.RemoveAll(m => m.EmployeeId == member.EmployeeId);
                        LoadTeamMember();
                        UpdateUI();
                    }
                }
            }
        }

        private void btnAddSelected_Click(object sender, EventArgs e)
        {
            if (employeeDataGridView.CurrentRow != null)
            {
                AddSelectedEmployee(employeeDataGridView.CurrentRow.Index);
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (teamMemberDataGridView.CurrentRow != null)
            {
                var row = teamMemberDataGridView.CurrentRow;
                if (row.DataBoundItem is TeamMemberDto member)
                {
                    _teamMembers.RemoveAll(m => m.EmployeeId == member.EmployeeId);
                    LoadTeamMember();
                    UpdateUI();
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (_teamMembers.Count > 0)
            {
                var result = MessageBox.Show("Bạn có muốn xóa tất cả thành viên khỏi danh sách?", 
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    _teamMembers.Clear();
                    LoadTeamMember();
                    UpdateUI();
                }
            }
        }
    }
}
