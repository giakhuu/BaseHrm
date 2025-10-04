using BaseHrm.Data.DTO;
using BaseHrm.Data.Service;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BaseHrm.Controls
{
    public partial class AddShiftTypeControl : UserControl
    {
        IShiftService _shiftService;

        public AddShiftTypeControl(IShiftService shiftService)
        {
            InitializeComponent();
            _shiftService = shiftService;

            this.Load += async (s, e) => await LoadShiftType();
        }


        private async Task LoadShiftType()
        {
            var shiftTypes = await _shiftService.GetAllShiftTypesAsync();
            shiftTypeDtoBindingSource.DataSource = shiftTypes;
            dgvShiftType.DataSource = shiftTypeDtoBindingSource;
            dgvShiftType.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtShiftTypeName.Clear();
            txtPayMultiplier.Clear();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await AddShiftType();
            await LoadShiftType();
        }

        private async Task AddShiftType()
        {
            await _shiftService.CreateShiftTypeAsync(new ShiftTypeDto
            {
                Name = txtShiftTypeName.Text.Trim(),
                PayMultiplier = decimal.Parse(txtPayMultiplier.Text.Trim())
            });
        }

        private void txtPayMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            char decimalSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSep)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == decimalSep && tb.Text.Contains(decimalSep))
            {
                e.Handled = true;
            }
        }
    }
}