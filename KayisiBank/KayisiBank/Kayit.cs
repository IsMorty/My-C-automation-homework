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
    public partial class Kayit : Form
    {
        bool contrl1 = false, contrl2 = false, contrl3 = false, contrl4 = false;

        public Kayit()
        {
            InitializeComponent();
        }

        private void Kayit_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Kullanıcı adı alanı boş bırakılamaz!");
                contrl1 = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
                contrl1 = true;
            }

            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Şifre alanı boş bırakılamaz!");
                contrl2 = false;

            }
            else if(textBox2.Text.Length < 5)
            {
                errorProvider1.SetError(textBox2, "Şifrenizin uzunluğu en az 5 karakter olabilir!");
                contrl2 = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
                contrl2 = true;
            }

            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Telefon alanı boş bırakılamaz!");
                contrl3 = false;
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
                contrl3 = true;
            }

            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Telefon alanı boş bırakılamaz!");
                contrl4 = false;
            }
            else
            {
                errorProvider1.SetError(textBox4, "");
                contrl4 = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label3.Visible = false;
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Sadece numara giriniz.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
            if (textBox3.Text.Length > 10)
            {
                MessageBox.Show("Numaranızı başında 0 olmadan 10 haneli yazınız.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (contrl1 && contrl2 && contrl3 && contrl4)
            {
                Database.Kayit(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker2.Value);
                MessageBox.Show("Başarıyla kayıt oldunuz.");
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
                MessageBox.Show("Lütfen uyarıları okuyun.");
        }
    }
}
