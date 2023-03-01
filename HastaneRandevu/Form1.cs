using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;

namespace HastaneRandevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string gonder;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I2H6A9U\\SQLEXPRESS;Initial Catalog=randevual;Integrated Security=True; TrustServerCertificate = True");

        private void kayit()
        {
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("Insert into giris(tckimlikno,sifre) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglanti);
            kaydet.ExecuteNonQuery();
            baglanti.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            gonder = textBox1.Text;
            SqlDataAdapter giris = new SqlDataAdapter("SELECT COUNT(*) FROM giris WHERE tckimlikno='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'", baglanti);
            DataTable dt = new DataTable();
            giris.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                randevual frm = new randevual();
                frm.Show();
            }
            else
                MessageBox.Show("Hatalý Tc Kimlik No veya Þifre");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kayit kyd = new kayit();
            kyd.Show();
            this.Hide();
            //kayit();
            //MessageBox.Show("Kayýt Baþarýlý");
        }
    }
}