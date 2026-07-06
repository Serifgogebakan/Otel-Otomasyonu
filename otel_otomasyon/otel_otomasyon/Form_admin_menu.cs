using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace otel_otomasyon
{
    public partial class Form_admin_menu : Form
    {
        public Form_admin_menu()
        {
            InitializeComponent();
            StyleHelper.Apply(this);
        }

        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();                     //burada çıkış yaparken soru soruyor evet dersek çıkıyor
            secim = MessageBox.Show("Programı kapatmak istediğinize eminmisiniz !!", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_kayıt_Click(object sender, EventArgs e) //Kayıt formunu açar
        {
            Form_KAYIT frm = new Form_KAYIT();
            frm.Show();
        }

        private void btn_oda_Click(object sender, EventArgs e) //Oda formunu açar
        {
            Form_ODA frm = new Form_ODA();
            frm.Show();
        }

        private void btn_rezervasyon_Click(object sender, EventArgs e) //rezervassyon formunu açar
        {
            Form_REZERVASYON frm = new Form_REZERVASYON();
            frm.Show();
        }

        private void Form_admin_menu_Load(object sender, EventArgs e)  //form yüklenince yapması gerekenleri yapar
        {
            toplam_sayı();
        }

        void toplam_sayı()// burada ana admin ekranı açılınca sayıları görmek için yazdığımız labelleri dolduran kısım
        {
            try
            {
                // Veritabanı bağlantısını açıyoruz
                baglantı.Open();

                // Rezervasyon tablosunun sayısını alıyoruz
                SqlCommand komutRezervasyon = new SqlCommand("SELECT COUNT(*) FROM Rezervasyon", baglantı);
                SqlDataReader okuRezervasyon = komutRezervasyon.ExecuteReader();
                if (okuRezervasyon.Read())
                {
                    int rezervasyonSayisi = okuRezervasyon.GetInt32(0);
                    lbl_rv.Text = rezervasyonSayisi.ToString(); // Rezervasyon sayısını ilgili label'a yazdırıyoruz
                }
                okuRezervasyon.Close(); // Reader'ı kapatıyoruz

                // Odalar tablosunun sayısını alıyoruz
                SqlCommand komutOdalar = new SqlCommand("SELECT COUNT(*) FROM Odalar", baglantı);
                SqlDataReader okuOdalar = komutOdalar.ExecuteReader();
                if (okuOdalar.Read())
                {
                    int odalarSayisi = okuOdalar.GetInt32(0);
                    lbl_oda.Text = odalarSayisi.ToString(); // Odalar sayısını ilgili label'a yazdırıyoruz
                }
                okuOdalar.Close(); // Reader'ı kapatıyoruz

                // Kullanıcılar tablosundan etkisi 0 olanların sayısını alıyoruz
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Kullanıcılar WHERE yetki = 0", baglantı);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                        int Sayı = oku.GetInt32(0);
                        lbl_kln.Text = Sayı.ToString(); // Musteriler sayısını ilgili label'a yazdırıyoruz  
                }
                oku.Close(); // Reader'ı kapatıyoruz
                baglantı.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }






    }
}

