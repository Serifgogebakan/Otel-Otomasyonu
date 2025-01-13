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
    public partial class Form_kullanıcı_menu : Form
    {
        private string kullanıcıAdı;

        public Form_kullanıcı_menu(string kullanıcıAdı)
        {
            InitializeComponent();
            this.kullanıcıAdı = kullanıcıAdı;
        }
        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");

        public String musteri
        {
            get { return kullanıcıAdı; }  // Kullanıcı adını döndürüyoruz
        }
        String tcKimlik;

        private void Form_kullanıcı_menu_Load(object sender, EventArgs e)
        {
            lbl_kul_ad.Text =  kullanıcıAdı;
            if (Rezervasyon_kontrol(tcKimlik))
            {
                lbl_bilgilendirme.Text = $"SAYIN {kullanıcıAdı} REZERVASYON KAYDINIZ MEVCUTTUR !!! ";
            }
            else
            {
                lbl_bilgilendirme.Text = $"SAYIN {kullanıcıAdı} REZERVASYON KAYDINIZ BULUNMAMAKTADIR !!! ";
            }
        }


        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();                     //burada çıkış yaparken soru soruyor evet dersek çıkıyor
            secim = MessageBox.Show("Kullanıcı Menüsünü kapatmak istediğinize eminmisiniz !!", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btn_kullanıcı_ayar_Click(object sender, EventArgs e)
        {
            Form_klnc_ayar frm = new Form_klnc_ayar(kullanıcıAdı);
            frm.Show();
            this.Close();
        }

       

        private void btn_kullanıcı_rezerv_Click(object sender, EventArgs e)
        {
            Form_klnc_rezervasyon frm = new Form_klnc_rezervasyon(kullanıcıAdı);
            this.Close();
            frm.Show();
            
        }



             void tcGetir()    //bu kısım kullanıcı adından kayıtlı olan tc numarasını fetiriyor
             {
                baglantı.Open();
                // Kullanıcı adına göre TC kimlik numarasını almak için SQL sorgusu
                SqlCommand komut = new SqlCommand("SELECT tc_kimlik FROM Kullanıcılar WHERE kullanıcı_ad = @musteri", baglantı);
                komut.Parameters.AddWithValue("@musteri", musteri);  // Kullanıcı adı parametresi
                // Sorguyu çalıştırıyoruz ve TC'yi alıyoruz
                object tcResult = komut.ExecuteScalar();
                // Eğer sonuç null değilse, TC numarasını kullanıyoruz
                if (tcResult != null)
                {
                    tcKimlik = tcResult.ToString();  // TC kimlik numarasını alıyoruz ve String'e atıyoruz
                    //MessageBox.Show("Kullanıcıya ait TC Kimlik Numarası: " + tcKimlik);                     //çalışıyormu diye kontrol etmek için
                }
             }



        private bool Rezervasyon_kontrol(string tcKimlik)
        {
            try
            {
                baglantı.Open();
                SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Rezervasyon WHERE tc_kimlik = @tcKimlik", baglantı);
                komut.Parameters.AddWithValue("@tcKimlik", tcKimlik);
                int indeks = (int)komut.ExecuteScalar(); // Sorguyu çalıştırıp, kayıt sayısını alıyoruz
                return indeks > 0; // Eğer kayıt varsa, true döndürür
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                baglantı.Close();
            }
        }


    }
}
