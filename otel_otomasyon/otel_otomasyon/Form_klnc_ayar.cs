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
    public partial class Form_klnc_ayar : Form
    {
        private string kullanıcıAdı;

        public Form_klnc_ayar(String kullanıcıAdı)
        {   
            InitializeComponent();
            this.kullanıcıAdı = kullanıcıAdı;
            StyleHelper.Apply(this);
        }

        SqlConnection baglantı = new SqlConnection ("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");

        String tc, isim, soyisim, dtarihi, mail, telefon, cinsiyet;



        private void Form_klnc_ayar_Load(object sender, EventArgs e)
        { 
            veri_getir();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            Form_kullanıcı_menu frm = new Form_kullanıcı_menu(kullanıcıAdı);
            this.Close();
            frm.Show();
            
        }

        public String musteri
        {
            get { return kullanıcıAdı; }  // Kullanıcı adını döndürüyoruz
        }



        private void btn_kayıt_sil_Click(object sender, EventArgs e)     //kullanıcıya 2 kere soruyor 2 kere evet derse kullanıcı kaydını siliyor
        {

            DialogResult secim = new DialogResult();
            secim = MessageBox.Show(" BU KAYDI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                DialogResult secim2 = new DialogResult();
            secim2 = MessageBox.Show(" BU KAYDI SİLERSENİZ BİRDAHA BU HESAPTAN GİRİŞ YAPAMAYACAKSINIZ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim2 == DialogResult.Yes)
            {
                   // MessageBox.Show("meerhaba");
                veri_sil();        
            }
            }



            
        }


        void veri_sil()
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Kullanıcılar Where kullanıcı_ad = @musteri", baglantı);  //burada veri tabanındaki swçilen kısımdaki veriyi siler ,tc_kimlik i @tc ye eşitledik kolaylık olsun diye yoksa aşağıyada yazacaktık
            komut.Parameters.AddWithValue("@musteri", musteri); //dataGridView'de seçili satırın 2.kısmındaki değer alınarak @tc'ye eşitlenir
            komut.ExecuteNonQuery();  //şartları gerçekleştirir
            baglantı.Close();   //baglantıyı sonlandırır
            MessageBox.Show("KAYDINIZ BAŞARIYLA SİLİNDİ GİRİŞ EKRANINA YÖNLENDİRİLİYORSUNUZ");
            Form_giris_ekranı frm = new Form_giris_ekranı();
            frm.Show();
        }// Veritabanda seçilen satıradaki verileri silmemizi sağlar 



       


        private void btn_kayıt_güncelle_Click(object sender, EventArgs e)
        {

            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("BU KAYIT ÜZERİNDE DEĞİŞİKLİK YAPMAK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                Kayıt_ilet();
                //veri_güncelle();
                veri_getir();
            }

        }

        void veri_getir()
        {
           // MessageBox.Show(musteri);
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kullanıcılar WHERE kullanıcı_ad = @musteri ", baglantı); // Kullanıcı bilgilerini almak için sorgu yapıyoruz
            komut.Parameters.AddWithValue("@musteri", musteri);
            SqlDataReader oku = komut.ExecuteReader(); // Veriyi çekiyoruz
            if (oku.Read())
            { 
                lbl_tc.Text = oku["tc_kimlik"].ToString();
                lbl_ad.Text = oku["isim"].ToString();
                lbl_soyad.Text = oku["soyisim"].ToString();
               lbl_c.Text = oku["cinsiyet"].ToString();
                lbl_dt.Text = oku["dogum_tarihi"].ToString();
                lbl_telno.Text = oku["tel_no"].ToString();
               lbl_mail.Text = oku["mail_adresi"].ToString();
                String k_adı = oku["kullanıcı_ad"].ToString();
                String sirfe = oku["sifre"].ToString();
                String yetkim = oku["yetki"].ToString();
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı.");
            }

            oku.Close();    //datareader ı durdurur
            baglantı.Close();  
        }



        void Kayıt_ilet()
        {
            try
            {
                // Veritabanı bağlantısını açıyoruz
                baglantı.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Kullanıcılar WHERE kullanıcı_ad = @musteri", baglantı);
                komut.Parameters.AddWithValue("@musteri", musteri);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    // Formu oluşturuyoruz
                    Form_kisi_kayıt frm = new Form_kisi_kayıt();
                    frm.lbl_kademe.Text = "3";  // Kademe bilgisini ayarlıyoruz
                    // Verileri forma aktarıyoruz
                    frm.text_tc_kimlik_no.Text = lbl_tc.Text;
                    frm.text_kimlik_isim.Text = lbl_ad.Text;
                    frm.text_kimlik_soyisim.Text = lbl_soyad.Text;
                    frm.lbl_cinsiyet.Text = lbl_c.Text;
                    frm.text_kimlik_dogum_tarihi.Text = lbl_dt.Text;
                    frm.text_telefon_numarası.Text = lbl_telno.Text;
                    frm.text_mail_adresi.Text = lbl_mail.Text ;
                    frm.kullanıcıad = oku["kullanıcı_ad"].ToString();
                    //// Ekstra bilgiler
                    frm.sife = oku["sifre"].ToString();
                    frm.yeti = oku["yetki"].ToString();
                    frm.Show();
                    this.Close(); // Ayar formunu kapatıyoruz
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                }
                oku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı her durumda kapatıyoruz
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }
            }




        }



    }
}
