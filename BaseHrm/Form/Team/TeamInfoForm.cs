using BaseHrm.Data.DTO;
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
    public partial class TeamInfoForm : Form
    {
        private TeamDto _team;
        private List<EmployeeDto>? _members;
        private EmployeeDto? _selectedMember;
        private readonly ITeamService _teamService;
        private readonly IEmployeeService _employeeService;
        public TeamInfoForm(TeamDto team, ITeamService teamService, IEmployeeService employeeService, bool isEditing)
        {
            InitializeComponent();
            _team = team;
            _teamService = teamService;
            _employeeService = employeeService;
            if (isEditing) {
                btnEdit.Visible = false;
                SetEditMode(true);
            }
            else
            {
                btnEdit.Visible = true;
                SetEditMode(false);
            }
            this.Load += TeamInfoForm_Load; 
        }

        private async void TeamInfoForm_Load(object? sender, EventArgs e)
        {
            await LoadTeamInfo();
        }

        private async Task LoadTeamInfo()
        {
            txtTeamId.Text = _team.TeamId.ToString();

            txtTeamName.Text = _team.Name;
            var descProp = _team.GetType().GetProperty("Description");
            if (descProp != null)
            {
                var descVal = descProp.GetValue(_team);
                txtTeamDescription.Text = descVal?.ToString() ?? "";
            }
            else
            {
                txtTeamDescription.Text = "";
            }

            txtLeaderName.Text = _team.Leader != null ? $"{_team.Leader.FirstName} {_team.Leader.LastName}" : "N/A";
            txtLeaderEmployeeId.Text = _team.Leader?.EmployeeId.ToString() ?? "N/A";
            txtLeaderPhone.Text = _team.Leader?.Phone ?? "N/A";
            txtLeaderEmail.Text = _team.Leader?.Email ?? "N/A";

            var members = await Task.Run(() => _employeeService.GetByTeamAsync(_team.TeamId));
            _members = members ?? new List<EmployeeDto>();

            if (_members != null)
            {
                lblMemberCount.Text = $"Tổng số thành viên: {_members.Count}";
                employeeDtoBindingSource.DataSource = _members;
                dgvMembers.DataSource = employeeDtoBindingSource;
                dgvMembers.Refresh();
            }
        }
        private void SetEditMode(bool editing)
        {
            txtTeamName.ReadOnly = !editing;
            txtTeamDescription.ReadOnly = !editing;

            btnSave.Enabled = editing;         
            btnAddMember.Enabled = editing;     
            btnRemoveMember.Enabled = editing;

            btnEdit.Enabled = !editing;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
            txtTeamName.Focus();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var nameProp = _team.GetType().GetProperty("Name");
                if (nameProp != null && nameProp.CanWrite)
                {
                    nameProp.SetValue(_team, txtTeamName.Text);
                }
                var descProp = _team.GetType().GetProperty("Description");
                if (descProp != null && descProp.CanWrite)
                {
                    descProp.SetValue(_team, txtTeamDescription.Text);
                }

                await _teamService.UpdateAsync(_team.TeamId, _team.Name);
                MessageBox.Show($"Lưu Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
            finally
            {
                DialogResult = DialogResult.OK;
                this.Close();
                SetEditMode(false);
            }
        }

        private async void btnAddMember_Click(object sender, EventArgs e)
        {
            var addMemberForm = new AddTeamMemberForm(_team.TeamId, _teamService, _employeeService);
            if (addMemberForm.ShowDialog() == DialogResult.OK)
            {
                await LoadTeamInfo();
            }
        }

        private async void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Vui lòng chọn thành viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa nhân viên '{_selectedMember.FullName}' khỏi team?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _teamService.RemoveMemberAsync(_team.TeamId, _selectedMember.EmployeeId);
                    MessageBox.Show("Đã xóa nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await LoadTeamInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvMembers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            dgvMembers.ClearSelection();
            dgvMembers.Rows[e.RowIndex].Selected = true;

            if (dgvMembers.Rows[e.RowIndex].DataBoundItem is EmployeeDto member)
            {
                _selectedMember = member;
            }
            else
            {
                _selectedMember = null;
            }

            if (e.Button == MouseButtons.Right)
            {
                employeeContextMenuStrip.Show(Cursor.Position);
            }
        }

        private async void addLeader_Click(object sender, EventArgs e)
        {
            if (_selectedMember == null)
            {
                MessageBox.Show("Vui lòng chọn thành viên để chỉ định làm leader.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                    $"Bạn có chắc muốn nhân viên '{_selectedMember.FullName}' thành Leader?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await _teamService.SetLeaderAsync(_team.TeamId, _selectedMember.EmployeeId);
                _team = await _teamService.GetByIdAsync(_team.TeamId);
                await LoadTeamInfo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
