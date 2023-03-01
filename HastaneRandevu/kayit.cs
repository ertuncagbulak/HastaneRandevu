using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        public static string mail;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I2H6A9U\\SQLEXPRESS;Initial Catalog=randevual;Integrated Security=True; TrustServerCertificate = True");
        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("Insert into giris(tckimlikno,sifre,mail) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarılı");
            mail = textBox3.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
