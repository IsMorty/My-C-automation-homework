using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace KayisiBank
{
    class Database
    {
        Database()
        {

        }

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        static SqlDataReader dr;
        static System.Data.DataSet ds;
        public static string SqlCon = @"Data Source=DESKTOP-R1G607U\SQLEXPRESS;Initial Catalog=KayisiBank;Integrated Security=True";
        public static string kID = "", date = "", money = "", phone = "", mail = "", birthday = "", ibankey = "", ibanmoney = "", ibanUserName = "", secenek = "", odenenBorc = "";
        public static string kira = "", okulHarci = "", krediKartiBorcu = "", elektrik = "", su = "";
        public static int moneyy = 0, ibanmoneyy = 0, secenekk = 0, odenenBorcc = 0;
        

        public static void Kayit(string username, string password, string phone, string mail, DateTime birthday)
        {
            Random rand = new Random();
            int key1 = rand.Next(1000, 9999);
            string ibankey = "TR-" + key1.ToString() + "";
            string sql = "insert into tbl_login(username, password, moneyy, date, phonenumber, mail, birthday, ibankey, krediSecenek, odenenBorc) values ('" + username + "', '" + MD5Sifrele(password) + "', 0, '" + DateTime.Now.ToString("MM/dd/yyyy") + "', '" + phone + "', '" + mail + "', '" + birthday.ToString("MM/dd/yyyy") + "' ,'" + ibankey + "', 0, 0)";
            KomutYolla(sql);
            string sql2 = "insert into tbl_odemeler(kira, okulHarci, krediKartiBorcu, elektrik, su, username) values (1400, 830, 0, 105, 30, '"+ username +"')";
            KomutYolla(sql2);
        }

        public static void Odeme(string odenecek, int miktar)
        {
            if (miktar > 0)
            {
                if (moneyy - miktar >= 0)
                {
                    string sql = "update tbl_odemeler set " + odenecek + "= 0 where username='" + Login.userSession + "'";
                    KomutYolla(sql);
                    ParaCekme(miktar);
                }
                else
                {
                    MessageBox.Show("Yeterli bakiyeniz bulunmamaktadır.");
                }
                
            }
            else
            {
                MessageBox.Show("Borcunuz bulunmamaktadır");
            }

        }

        public static void GetOdemeler()
        {
            string sorgu = "select * from tbl_odemeler where username=@user";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Login.userSession);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                kira = dr["kira"].ToString();
                okulHarci = dr["okulHarci"].ToString();
                krediKartiBorcu = dr["krediKartiBorcu"].ToString();
                elektrik = dr["elektrik"].ToString();
                su = dr["su"].ToString();
                con.Close();
            }
            else
            {
                con.Close();
            }
        }

        public static bool LoginKontrol(string username, string password)
        {
            string sorgu = "select * from tbl_login where username=@user and password=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public static void GetUserSession()
        {
            string sorgu = "select * from tbl_login where username=@user";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Login.userSession);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                kID = dr["kID"].ToString();
                money = dr["moneyy"].ToString();
                moneyy = Convert.ToInt32(money);
                date = dr["date"].ToString();
                phone = dr["phonenumber"].ToString();
                mail = dr["mail"].ToString();
                birthday = dr["birthday"].ToString();
                ibankey = dr["ibankey"].ToString();
                secenek = dr["krediSecenek"].ToString();
                secenekk = Convert.ToInt32(secenek);
                odenenBorc = dr["odenenBorc"].ToString();
                odenenBorcc = Convert.ToInt32(odenenBorc);
                con.Close();
            }
            else
            {
                con.Close();
            }
        }

        public static void UpdateOdenenBorc(int miktar, bool sifirla)
        {
            if (!sifirla)
            {
                int result = 0;
                result = odenenBorcc + miktar;
                string sql = "update tbl_login set odenenBorc=" + result + " where username='" + Login.userSession + "'";
                if (moneyy - miktar >= 0)
                    KomutYolla(sql);
            }
            else
            {
                string sql2 = "update tbl_login set odenenBorc=" + miktar + " where username='" + Login.userSession + "'";
                KomutYolla(sql2);
            }

        }

        public static void KomutYolla(string sql)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void ParaYatirma(int miktar)
        {
            int result = 0;
            result = moneyy + miktar;
            string sql = "update tbl_login set moneyy=" + result + " where username='" + Login.userSession + "'";
            KomutYolla(sql);
            //MessageBox.Show("İşleminiz başarıyla gerçekleşti.");
        }

        public static void updateKrediSecenegi(string secenek)
        {
            string sql = "update tbl_login set krediSecenek=" + secenek + " where username='" + Login.userSession + "'";
            KomutYolla(sql);
        }

        public static void ParaCekme(int miktar)
        {
            int result = 0;
            if (moneyy - miktar >= 0)
            {
                result = moneyy - miktar;
                string sql = "update tbl_login set moneyy=" + result + " where username='" + Login.userSession + "'";
                KomutYolla(sql);
                //MessageBox.Show("İşleminiz başarıyla gerçekleştirilmiştir.");
            }

        }

        public static void GetIbanUserName(string ibankey)
        {
            string sorgu = "select * from tbl_login where ibankey=@iban";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@iban", ibankey);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ibanUserName = dr["username"].ToString();
                con.Close();
            }
            else
            {
                con.Close();
            }
        }

        public static void ParaTransfer(string ibankey, int miktar)
        {
            string sorgu = "select * from tbl_login where ibankey=@iban";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@iban", ibankey);
            int result = 0, result2 = 0;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (moneyy - miktar >= 0)
                {
                    // Parayı çekme

                    result = moneyy - miktar;
                    string parayiCek = "update tbl_login set moneyy=" + result + " where username='" + Login.userSession + "'";
                    KomutYolla(parayiCek);

                    // Parayı yollama

                    ibanmoney = dr["moneyy"].ToString();
                    ibanmoneyy = Convert.ToInt32(ibanmoney);
                    result2 = ibanmoneyy + miktar;
                    string parayiYolla = "update tbl_login set moneyy=" + result2 + " where ibankey='" + ibankey + "'";
                    KomutYolla(parayiYolla);
                    con.Close();
                    MessageBox.Show("İşleminiz başarıyla gerçekleşti.");
                }
                else
                {
                    MessageBox.Show("Yeterli bakiyeniz bulunmamaktadır.");
                }
            }
            else
            {
                con.Close();
                MessageBox.Show("Yanlış iban numarası.");
            }
        }

        static public string MD5Sifrele(string sifre)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            Byte[] dizi = Encoding.UTF8.GetBytes(sifre);
            dizi = md5.ComputeHash(dizi);
            DataGrid dataGrid = new DataGrid();

            StringBuilder sb = new StringBuilder();

            foreach (Byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }

        static public string SHA256Sifrele(string sifre)
        {
            SHA256 sha256Hash = SHA256.Create();
            Byte[] dizi = Encoding.UTF8.GetBytes(sifre);
            dizi = sha256Hash.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (Byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString();
        }
    }
}



