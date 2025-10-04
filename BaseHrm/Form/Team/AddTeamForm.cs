using BaseHrm.Data.Service;
using BaseHrm.Utils;
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
    public partial class AddTeamForm : Form
    {
        private readonly ITeamService _teamService;

        public AddTeamForm(ITeamService teamService)
        {
            InitializeComponent();
            _teamService = teamService;
        }

        private bool ValidateTeamInput()
        {
            var errors = new List<string>();

            // Validate team name
            var teamName = nameTxtbox.Text?.Trim() ?? "";
            
            if (string.IsNullOrWhiteSpace(teamName))
            {
                errors.Add("Tên team không được để trống");
            }
            else if (teamName.Length < 2)
            {
                errors.Add("Tên team phải có ít nhất 2 ký tự");
            }
            else if (teamName.Length > 100)
            {
                errors.Add("Tên team không được quá 100 ký tự");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(teamName, @"^[a-zA-ZÀ-ỹ0-9\s\-_.]+$"))
            {
                errors.Add("Tên team chỉ được chứa chữ cái, số, khoảng trắng, dấu gạch ngang, gạch dưới và dấu chấm");
            }

            // Show validation errors if any
            if (errors.Count > 0)
            {
                this.ShowValidationSummary(errors, "Lỗi nhập tên team");
                nameTxtbox.Focus();
                return false;
            }

            return true;
        }

        public async Task AddTeam()
        {
            if (!ValidateTeamInput())
            {
                return;
            }

            try
            {
                var teamName = nameTxtbox.Text.Trim();
                
                // Check if team name already exists
                var existingTeams = await _teamService.SearchAsync(teamName);
                if (existingTeams != null && existingTeams.Any(t => 
                    string.Equals(t.Name?.Trim(), teamName, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Tên team này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nameTxtbox.Focus();
                    return;
                }

                await _teamService.CreateAsync(teamName);
                
                MessageBox.Show("Tạo team thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo team: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            await AddTeam();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await AddTeam();
        }

        private void nameTxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow Enter key to trigger save
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                _ = AddTeam();
            }
        }
    }
}
