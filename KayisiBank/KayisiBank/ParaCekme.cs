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
    public partial class ParaCekme : Form
    {
        public ParaCekme()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserPanel userPanel = new UserPanel();
            userPanel.StartPosition = FormStartPosition.CenterScreen;
            userPanel.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.ParaCekme(Convert.ToInt32(textBox1.Text));
            MessageBox.Show("Paranızı almayı unutmayınız.");
            UserPanel userPanel = new UserPanel();
            userPanel.StartPosition = FormStartPosition.CenterScreen;
            userPanel.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Sadece miktar giriniz.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            if (textBox1.Text.Length > 5)
            {
                MessageBox.Show("En fazla 5 basamaklı miktar girebilirsiniz.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }
    }
}
