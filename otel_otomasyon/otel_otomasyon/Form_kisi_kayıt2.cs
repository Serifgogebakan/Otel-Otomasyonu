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
    public partial class Form_kisi_kayıt2 : Form
    {
        public Form_kisi_kayıt2()
        {
            InitializeComponent();
            StyleHelper.Apply(this);
        }

        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");  //burada veri tabanı nesnesi oluşturuyoruz


        private void Form_kisi_kayıt2_Load(object sender, EventArgs e)
        {
            if (lbl_kademe2.Text == "1")
            {
                pb_geri_form.Hide();
                label1.Text = "YENİ KAYIT EKRANI";
                ust_panel.BackColor = Color.Orange;
            }
            else if (lbl_kademe2.Text == "3")
            {
                label1.Text = "[KAYIT GÜNCELLEME EKRANI] ";
                pb_geri_form.Hide();
                ust_panel.BackColor = Color.Gray;
                groupBox8.Visible = false;
            }
            else if (lbl_kademe2.Text == "2" )
            {
                label1.Text = "[KAYIT GÜNCELLEME EKRANI] ";
                pb_geri_form.Hide();
                ust_panel.BackColor = Color.Gray;
                if(lbl_yetki.Text.Trim() == "1")
                {
                    rb_yetkili.Checked = true;
                }
                else
                {
                    rb_kisi.Checked = true;
                }
            }
        }


        public String tc, isim, soyisim, dtarihi, mail, telefon, cinsiyet;
        public String kullanıcıadı, sifre, sifre_tekrar, yetkiler;


        private void pb_geri_form_Click(object sender, EventArgs e)
        {
            if (lbl_kademe2.Text == "0")
            {
                Form_kisi_kayıt frm = new Form_kisi_kayıt();
                frm.Show();   //ilk formu açıyor
                this.Close(); //form ekranını kapatıyor
            }
            else
            {

            }
        }


        private void rb_kisi_CheckedChanged(object sender, EventArgs e)
        {
            lbl_yetki.Text = "0";
        }
        private void rb_yetkili_CheckedChanged(object sender, EventArgs e)
        {
            lbl_yetki.Text = "1";
        }
              


        private void btn_cıkıs_Click(object sender, EventArgs e)  //form çerçeve sitilinde, çerçeve olmadığından benim eklediğim butona basınca çıkış yapmasını sağlıyor
        {
            if (lbl_kademe2.Text == "0")    //String olduğu için "" olacak
            {
                Application.Exit();
            }
            else if (lbl_kademe2.Text == "1")
            {
                this.Close();
            }
            else if (lbl_kademe2.Text == "2")
            {
                this.Close();
            }
            else if (lbl_kademe2.Text == "3")
            {
                this.Close();
            }

        }

        private void btn_temizle_Click(object sender, EventArgs e)  //temizle tuşuna tıklayınca yazılı ifadeleri siler
        {

            text_KullanıcıAdı.Text = "";
            text_sifre.Text = "";
            text_sifre_tekrar.Text = "";
            rb_kisi.Checked = true;
            text_KullanıcıAdı.Focus();     //ifadeler temizlendikten sonra otomatik olarak kullanıcı girilebilir şekilde bekliyor

        }



        bool tc_kontrol = false;
        bool kullanıcı_adı_kontrol = false;

        // TC Kimlik numarasının veri tabanında olup olmadığını kontrol eder
        void kimlik_kontrol()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kullanıcılar WHERE tc_kimlik=@p1 ", baglantı);
            komut.Parameters.AddWithValue("@p1", tc);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                tc_kontrol = true;  // Kayıt mevcut
            }
            else
            {
                tc_kontrol = false; // Kayıt yok
            }
            baglantı.Close();
        }

        // Kullanıcı adının veri tabanında olup olmadığını kontrol eder
        void kullanıcı_kontrol()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Kullanıcılar WHERE kullanıcı_ad =@p1 ", baglantı);
            komut.Parameters.AddWithValue("@p1", kullanıcıadı);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                kullanıcı_adı_kontrol = true;  // Kullanıcı adı mevcut
            }
            else
            {
                kullanıcı_adı_kontrol = false; // Kullanıcı adı yok
            }
            baglantı.Close();
        }

        void kayıt_tamamlama()
        {
            try
            {
                // Veritabanı bağlantısını açıyoruz
                baglantı.Open();
                // INSERT INTO sorgusu - Değişkenler için parametreleri kullanıyoruz
                string girdiler = "INSERT INTO Kullanıcılar (tc_kimlik, isim, soyisim, cinsiyet, dogum_tarihi, tel_no, mail_adresi, kullanıcı_ad, sifre, yetki) " +
                                  "VALUES (@tc, @isim, @soyisim, @cinsiyet, @dtarihi, @telefon, @mail, @kullanıcıadı, @sifre, @yetkiler)";
                SqlCommand komut = new SqlCommand(girdiler, baglantı);

                komut.Parameters.AddWithValue("@tc", tc); // 'tc' formdaki değişkeni temsil eder
                komut.Parameters.AddWithValue("@isim", isim);
                komut.Parameters.AddWithValue("@soyisim", soyisim);
                komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                komut.Parameters.AddWithValue("@dtarihi", dtarihi);
                komut.Parameters.AddWithValue("@telefon", telefon);
                komut.Parameters.AddWithValue("@mail", mail);
                komut.Parameters.AddWithValue("@kullanıcıadı", kullanıcıadı);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@yetkiler", yetkiler);
                // Sorgu çalıştırılıyor
                komut.ExecuteNonQuery();
                // Bağlantı kapatılıyor
                baglantı.Close();
                // Kullanıcıya başarılı mesajı gösteriliyor
                MessageBox.Show("KAYIT İŞLEMİNİZ BAŞARIYLA GERÇEKLEŞTİRİLMİŞTİR.");
            }
            catch (Exception ex)
            {
                // Hata olursa kullanıcıya hata mesajı gösteriliyor
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }


        }


        void kayıt_güncelleme()
        {
            baglantı.Open();
            String girdiler = "UPDATE Kullanıcılar SET isim=@isim,soyisim=@soyisim,cinsiyet=@cinsiyet,dogum_tarihi=@dtarihi,tel_no=@telefon,mail_adresi=@mail,kullanıcı_ad =@kullanıcıadı,sifre=@sifre,yetki=@yetkiler WHERE tc_kimlik=@tc ";
            SqlCommand komut = new SqlCommand(girdiler, baglantı);  //baglantı veri tabanının yerini gözteriyor / girdiler ilede eğer insert var ise veri tabanına veri kaydetmeye çalışıyoruz

            //ikiside aynı olması lazım yoksa veritabanına gitmiyor form ekkanındaki string değerleri yazacağız veri tabanındaki değil gibi duruyor
            komut.Parameters.AddWithValue("@isim", isim);                    //girdiler kısmında ilk kısım veritabanındaki isimler valuesten sonraki kısım formun içindeki string kısım
            komut.Parameters.AddWithValue("@soyisim", soyisim);
            komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            komut.Parameters.AddWithValue("@dtarihi", dtarihi);
            komut.Parameters.AddWithValue("@telefon", telefon);
            komut.Parameters.AddWithValue("@mail", mail);
            komut.Parameters.AddWithValue("@kullanıcıadı", kullanıcıadı);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Parameters.AddWithValue("@yetkiler", yetkiler);
            komut.Parameters.AddWithValue("@tc", tc);


            komut.ExecuteNonQuery();                                      //veri tabanı sorgusunu çalıştımamıza yarıyor olmazsa olmaz
            baglantı.Close();                                      //veri tabanı bağlantısını sonlandırıyor
            MessageBox.Show("KAYIT GÜNCELLEME İŞLEMİNİZ BAŞARIYLA GERÇEKLEŞTİRİLMİŞTİR.");

        }



        // Tamamla butonuna tıklandığında doğrulama işlemlerini yapar ve kaydı tamamlar ya da günceller
        private void btn_tamamla_Click(object sender, EventArgs e)
        {
            if (text_KullanıcıAdı.Text != "" && text_sifre.Text != "" && text_sifre_tekrar.Text != "")
            {
                if (text_sifre.Text == text_sifre_tekrar.Text)   // Şifreler uyuşuyorsa
                {
                    kullanıcıadı = text_KullanıcıAdı.Text;
                    sifre = text_sifre.Text;
                    yetkiler = lbl_yetki.Text;

                    if (lbl_kademe2.Text == "3")
                    {
                        DialogResult secim = MessageBox.Show("BU KAYIT ÜZERİNDE YAPTIĞINIZ DEĞİŞİKLİKLERİ ONAYLIYORMUSUNUZ !!!", "KAYIT GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (secim == DialogResult.Yes)
                        {
                            kayıt_güncelleme();
                            MessageBox.Show("VERİLERİNİZ BAŞARIYLA GÜNCELLENMİŞTİR, GİRİŞ EKRANINA YÖNLENDİRİLİYORSUNUZ.");
                            this.Close();
                            Form_giris_ekranı frm = new Form_giris_ekranı();
                            frm.Show();
                        }
                    }
                    else if (lbl_kademe2.Text == "2")
                    {
                        DialogResult secim = MessageBox.Show("BU KAYIT ÜZERİNDE YAPTIĞINIZ DEĞİŞİKLİKLERİ ONAYLIYORMUSUNUZ !!!", "KAYIT GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (secim == DialogResult.Yes)
                        {
                            kayıt_güncelleme();
                            this.Close();
                        }
                    }
                    else // Yeni Kayıt Ekleme (kademe 0 veya 1)
                    {
                        kimlik_kontrol();       // TC kimlik kontrolü
                        kullanıcı_kontrol();    // Kullanıcı adı kontrolü

                        if (tc_kontrol == false && kullanıcı_adı_kontrol == false)
                        {
                            if (lbl_kademe2.Text == "0")
                            {
                                kayıt_tamamlama();
                                Form_giris_ekranı frm = new Form_giris_ekranı();
                                frm.Show();
                                this.Close();
                            }
                            else if (lbl_kademe2.Text == "1")
                            {
                                kayıt_tamamlama();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("GİRİLEN TC KİMLİK NUMARASI VEYA KULLANICI ADI ZATEN KULLANILMAKTADIR !");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Girilen Şifreler Aynı Olmak Zorundadır !");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz !");
            }
        }





    }
}
