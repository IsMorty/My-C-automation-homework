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
    public partial class Odemeler : Form
    {

        public Odemeler()
        {
            InitializeComponent();
        }

        private void Odemeler_Load(object sender, EventArgs e)
        {
            textBox1.Text = Database.kira;
            textBox2.Text = Database.okulHarci;
            textBox3.Text = Database.krediKartiBorcu;
            textBox4.Text = Database.elektrik;
            textBox5.Text = Database.su;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.Odeme("kira", Convert.ToInt32(Database.kira));
            Database.GetOdemeler();
            textBox1.Text = Database.kira;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.Odeme("okulHarci", Convert.ToInt32(Database.okulHarci));
            Database.GetOdemeler();
            textBox2.Text = Database.okulHarci;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.Odeme("krediKartiBorcu", Convert.ToInt32(Database.krediKartiBorcu));
            Database.GetOdemeler();
            textBox3.Text = Database.krediKartiBorcu;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Database.Odeme("elektrik", Convert.ToInt32(Database.elektrik));
            Database.GetOdemeler();
            textBox4.Text = Database.elektrik;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Database.Odeme("su", Convert.ToInt32(Database.su));
            Database.GetOdemeler();
            textBox5.Text = Database.su;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel();
            userPanel.StartPosition = FormStartPosition.CenterScreen;
            userPanel.Show();
            this.Hide();
        }
    }
}
