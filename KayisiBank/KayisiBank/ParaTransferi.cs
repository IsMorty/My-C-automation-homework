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
    public partial class ParaTransferi : Form
    {
        public ParaTransferi()
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

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Sadece miktar giriniz.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
            if (textBox2.Text.Length > 5)
            {
                MessageBox.Show("En fazla 5 basamaklı miktar girebilirsiniz.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.ParaTransfer(textBox1.Text, Convert.ToInt32(textBox2.Text));
            UserPanel userPanel = new UserPanel();
            userPanel.StartPosition = FormStartPosition.CenterScreen;
            userPanel.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Database.GetIbanUserName(textBox1.Text);
            textBox3.Text = Database.ibanUserName;
            label3.Visible = false;
        }
    }
}
