using MRA_Client.Model;
using MRA_Client.Controller;
using System;
using System.Windows.Forms;

namespace MRA_Client {
    public partial class Login : Form {
        public Login() {
            InitializeComponent();
            textBoxRoll.Text = "TE0320";
            textBoxPassword.Text = "123";
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            string roll = textBoxRoll.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            Account account = LoginController.GetAccount(roll, password);
            if (account == null) {
                MessageBox.Show("Incorrect your roll or password!!!", "Confirm...");
            } else {
                this.Hide();
                new GradeManagement(account).Show();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e) {
            this.Dispose();
        }
    }
}
