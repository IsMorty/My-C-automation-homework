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
    public partial class UserPanel : Form
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Database.GetUserSession();
            Hesabim hesabim = new Hesabim();
            hesabim.StartPosition = FormStartPosition.CenterScreen;
            hesabim.Show();
            this.Hide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ParaYatirma paraYatirma = new ParaYatirma();
            paraYatirma.StartPosition = FormStartPosition.CenterScreen;
            paraYatirma.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParaCekme paraCekme = new ParaCekme();
            paraCekme.StartPosition = FormStartPosition.CenterScreen;
            paraCekme.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ParaTransferi paraTransferi = new ParaTransferi();
            paraTransferi.StartPosition = FormStartPosition.CenterScreen;
            paraTransferi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Database.GetOdemeler();
            Odemeler odemeler = new Odemeler();
            odemeler.StartPosition = FormStartPosition.CenterScreen;
            odemeler.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KrediCekme krediCekme = new KrediCekme();
            krediCekme.StartPosition = FormStartPosition.CenterScreen;
            krediCekme.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (Database.secenekk)
            {
                case 1:
                    Database.ParaCekme(1779);
                    Database.UpdateOdenenBorc(1779, false);
                    if (Database.odenenBorcc >= 10728)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 2:
                    Database.ParaCekme(940);
                    Database.UpdateOdenenBorc(940, false);
                    if (Database.odenenBorcc >= 11333)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 3:
                    Database.ParaCekme(523);
                    Database.UpdateOdenenBorc(523, false);
                    if (Database.odenenBorcc >= 12607)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 4:
                    Database.ParaCekme(8898);
                    Database.UpdateOdenenBorc(8898, false);
                    if (Database.odenenBorcc >= 8898)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 5:
                    Database.ParaCekme(4701);
                    Database.UpdateOdenenBorc(4701, false);
                    if (Database.odenenBorcc >= 56665)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 6:
                    Database.ParaCekme(2616);
                    Database.UpdateOdenenBorc(2616, false);
                    if (Database.odenenBorcc >= 63035)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 7:
                    Database.ParaCekme(17797);
                    Database.UpdateOdenenBorc(17797, false);
                    if (Database.odenenBorcc >= 107283)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 8:
                    Database.ParaCekme(9402);
                    Database.UpdateOdenenBorc(9402, false);
                    if (Database.odenenBorcc >= 113331)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
                case 9:
                    Database.ParaCekme(5232);
                    Database.UpdateOdenenBorc(5232, false);
                    if (Database.odenenBorcc >= 126072)
                    {
                        Database.updateKrediSecenegi("0");
                        Database.GetUserSession();
                        MessageBox.Show("Kredi borcunuz kalmamıştır bizi tercih ettiğiniz için teşekkür ederiz.");
                    }
                    break;
            }
            //Database.ParaCekme();
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            Database.GetUserSession();
            if (Database.secenekk > 0)
                timer1.Start();
            else if (Database.secenekk == 0)
            {
                timer1.Stop();
                Database.UpdateOdenenBorc(0, true);
            }
                
        }
    }
}
