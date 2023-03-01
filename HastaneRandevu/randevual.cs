using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneRandevu
{
    public partial class randevual : Form
    {
        int hasta = 0;
        string mail;
        public randevual()
        {
            InitializeComponent();
        }        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-I2H6A9U\\SQLEXPRESS;Initial Catalog=randevual;Integrated Security=True; TrustServerCertificate = True");       
        private void kayitgor()
        {
            
            listView1.Items.Clear();
            baglanti.Open();           
            SqlCommand gor = new SqlCommand("Select tckimlikno,ad,soyad,tarih,bolum,hastaid From randevu where tckimlikno = '" + textBox1.Text + "'", baglanti);
            SqlDataReader oku = gor.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tckimlikno"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["bolum"].ToString());
                ekle.SubItems.Add(oku["tarih"].ToString());
                ekle.SubItems.Add(oku["hastaid"].ToString());   
                hasta = Convert.ToInt32(oku["hastaid"].ToString());
                
                listView1.Items.Add(ekle);  
            }
            baglanti.Close();
        }
        private void randevu()
        {
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("Insert into randevu(tckimlikno,ad,soyad,tarih,bolum) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "')", baglanti);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
        }
        private void randevual_Load(object sender, EventArgs e)
        {
            listView1.Columns[5].Width = 0;
            textBox1.Text = Form1.gonder;
            textBox1.Enabled = false;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select mail from giris where tckimlikno = @p2", baglanti);
            komut.Parameters.AddWithValue("@p2", textBox1.Text);
            komut.ExecuteNonQuery();
            mail = komut.ExecuteScalar().ToString();
            baglanti.Close();
            textBox4.Text = mail;
            textBox4.Enabled=false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Randevunuz Başarıyla Oluşturuldu");
            randevu();
            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("deneme.kurum@outlook.com");
            mesaj.To.Add(mail);
            mesaj.Subject=("Hastane Randevusu");
            mesaj.Body = ("Sayın " +textBox2.Text +" " + textBox3.Text + " " +  dateTimePicker1.Text + " Tarihinde " + comboBox1.Text + " Bölümünden Randevunuz Oluşturulmuştur.");

            SmtpClient a = new SmtpClient();
            a.Credentials = new System.Net.NetworkCredential("deneme.kurum@outlook.com", "deneme123456");
            a.Port = 587;
            a.Host = "smtp.office365.com";
            a.EnableSsl = true;
            object userState = mesaj;

            try
            {
                a.SendAsync(mesaj, (object)mesaj);
                MessageBox.Show("Mail Gönderilmiştir");
            }

            catch (SmtpException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }

        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }  
        private void button2_Click(object sender, EventArgs e)
        {
            kayitgor();
        }
        int hastaid = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komut2 = new SqlCommand("select hastaid from randevu where tckimlikno=@p1", baglanti);
            //komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            //komut2.ExecuteNonQuery();

            //hastaid = (int)komut2.ExecuteScalar();
            hasta = int.Parse(listView1.SelectedItems[0].SubItems[5].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            //baglanti.Close();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from randevu where hastaid=(" + hasta + ")", baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
          
        }
    }
}
