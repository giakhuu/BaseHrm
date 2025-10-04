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
    public partial class LoginForm : Form
    {
        private readonly IAuthService _auth;
        private readonly IServiceProvider _provider;
        public LoginForm(IAuthService auth, IServiceProvider provider)
        {
            InitializeComponent();
            _auth = auth;
            _provider = provider;
        }

        private void hopeTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void aloneTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void skyLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.passwordTxtBox.UseSystemPasswordChar = !this.passwordTxtBox.UseSystemPasswordChar;
        }

        private void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            _ = DoLoginAsync();
        }

        private void usrnameTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task DoLoginAsync()
        {
            var user = usrnameTxtBox.Text.Trim();
            var pass = passwordTxtBox.Text;

            labelStatus.Text = "Đang xác thực...";
            loginBtn.Enabled = false;

            var (Success, Error, Token) = await _auth.AuthenticateAsync(user, pass, true);
            if (Success)
            {
                labelStatus.Text = "Đăng nhập thành công!";
                // Open main form
                var main = (Form)_provider.GetService(typeof(Test))!;
                this.Hide();
                main.FormClosed += (s, e) => this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show(Error);
                labelStatus.Text = Error ?? "Đăng nhập thất bại.";
                loginBtn.Enabled = true;
            }
        }

    }
}
