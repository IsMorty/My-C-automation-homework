using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KayisiBank
{
    public partial class Login : Form
    {
        public static string userSession = "";
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Database.LoginKontrol(usernameBox.Text, Database.MD5Sifrele(passwordBox.Text)))
            {
                userSession = usernameBox.Text;
                Database.GetUserSession();
                MessageBox.Show("Giriş başarılı.");
                UserPanel userPanel = new UserPanel();
                userPanel.StartPosition = FormStartPosition.CenterScreen;
                userPanel.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Hatalı kullanıcı adı veya şifre.");

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit();
            kayit.StartPosition = FormStartPosition.CenterScreen;
            kayit.Show();
            this.Hide();
            //this.Close();
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
