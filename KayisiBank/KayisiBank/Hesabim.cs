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
    public partial class Hesabim : Form
    {
        public Hesabim()
        {
            InitializeComponent();
        }

        private void Hesabim_Load(object sender, EventArgs e)
        {
            textBox1.Text = Login.userSession;
            textBox2.Text = Database.moneyy.ToString();
            textBox3.Text = Database.ibankey;
            textBox4.Text = Database.phone;
            textBox5.Text = Database.mail;
            textBox6.Text = Database.date;
            textBox7.Text = Database.birthday;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel();
            userPanel.StartPosition = FormStartPosition.CenterScreen;
            userPanel.Show();
            this.Close();
        }
    }
}
