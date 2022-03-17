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
    public partial class KrediCekme : Form
    {
        bool selected0 = false, selected1 = false, selected2 = false;

        public KrediCekme()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel();
            userPanel.StartPosition = FormStartPosition.CenterScreen;
            userPanel.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Enabled = false;
                comboBox4.Items.Clear();
                string[] money = new string[] { "10000" };
                comboBox4.Items.AddRange(money);
            }
            else
            {
                comboBox2.Enabled = true;
                comboBox4.Items.Clear();
                string[] money = new string[] { "10000", "50000", "150000" };
                comboBox4.Items.AddRange(money);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Database.secenekk == 0)
            {
                Database.ParaYatirma(Convert.ToInt32(comboBox4.SelectedItem));
                MessageBox.Show("Kredi çekme işlemi başarıyla gerçekleşti.");
            }
            else
            {
                MessageBox.Show("Kredi borcunuzu ödemeden yeni bir kredi çekemezsiniz.");
            }
            
        }

        private void KrediCekme_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
                selected0 = true;
            else if (comboBox4.SelectedIndex == 1)
                selected1 = true;
            else if (comboBox4.SelectedIndex == 2)
                selected2 = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selected0 && comboBox3.SelectedIndex == 0)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "10.728,32 TL";
                textBox3.Text = "1.779,72 TL";
                Database.updateKrediSecenegi("1");
            }
            else if (selected0 && comboBox3.SelectedIndex == 1)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "11.333,12 TL";
                textBox3.Text = "940,26 TL";
                Database.updateKrediSecenegi("2");
            }
            else if (selected0 && comboBox3.SelectedIndex == 2)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "12.607,28 TL";
                textBox3.Text = "523,22 TL";
                Database.updateKrediSecenegi("3");
            }
            else if (selected1 && comboBox3.SelectedIndex == 0)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "53.641,60 TL";
                textBox3.Text = "8.898,60 TL";
                Database.updateKrediSecenegi("4");
            }
            else if (selected1 && comboBox3.SelectedIndex == 1)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "56.665,72 TL";
                textBox3.Text = "4.701,31 TL";
                Database.updateKrediSecenegi("5");
            }
            else if (selected1 && comboBox3.SelectedIndex == 2)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "63.035,92 TL";
                textBox3.Text = "2.616,08 TL";
                Database.updateKrediSecenegi("6");
            }
            else if (selected2 && comboBox3.SelectedIndex == 0)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "107.283,14 TL";
                textBox3.Text = "17.797,19 TL";
                Database.updateKrediSecenegi("7");
            }
            else if (selected2 && comboBox3.SelectedIndex == 1)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "113.331,32 TL";
                textBox3.Text = "9.402,61 TL";
                Database.updateKrediSecenegi("8");
            }
            else if (selected2 && comboBox3.SelectedIndex == 2)
            {
                textBox1.Text = "%1,59";
                textBox2.Text = "126.072,08 TL";
                textBox3.Text = "5.232,17 TL";
                Database.updateKrediSecenegi("9");
            }
        }
    }
}
