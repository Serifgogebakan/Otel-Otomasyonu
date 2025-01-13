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
    public partial class Form_REZERVASYON : Form  //kullanıcılar tablosundan yetki 0 sa ona göre kayıt ekleme özelliği getirilebilir
    {
        public Form_REZERVASYON()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");


        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();                     //burada çıkış yaparken soru soruyor evet dersek çıkıyor
            secim = MessageBox.Show("Rezervasyon kısmından çıkmak istediğinize eminmisiniz !!", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        } 
        private void btn_yenile_Click(object sender, EventArgs e)  //yenile butonuna basınca verileri data gride doldurur
        {
            veri_getir();
        }


        private void Form_REZERVASYON_Load(object sender, EventArgs e) //form yüklenince verileri doldurur
        {
            veri_getir();
        }


        void veri_getir()  //veri tabanındaki verileri getirir
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM Rezervasyon", baglantı);  //burada veri tabanında kullanıcılara bağlanıyor 
            SqlDataAdapter ad = new SqlDataAdapter(komut);       //veri tabanı ile otomasyon arası veri aktarımı sağlar  veri çekme,silme,güncellemeekleme gibi yapılan işleri veri tabanına geri gönderir                                                
            DataTable tablo = new DataTable();
            ad.Fill(tablo);                          //Fill dataadapter ın bir özelliğidir veri tabanındaki veryi belirtilen yere yerleştirir
            dataGridView1.DataSource = tablo;            //datasource ile tablodaki veri tabanı verisi dGV e yerleştirilir
            baglantı.Close(); // veri_getir tabanı bağlantısı durdurulur yoksa veri çekmeye devam eder ve hata verir
        }


        private void cb_tip_SelectedIndexChanged(object sender, EventArgs e)  // combo boxa  seçilen ifadeye göre BOŞ odaları kayıt eder
        {
            String veri = cb_tip.Text.Trim(); //oda tipinin verisini tutan kısım
            //MessageBox.Show(veri);

            SqlCommand komut = new SqlCommand("SELECT * FROM Odalar", baglantı);  //bu kullanım şeklini ilk kez gördüm not et
            baglantı.Open();   //veri tabanına bağlanır 
            SqlDataReader oku = komut.ExecuteReader(); //veri tabanında verileri tek tek arar 
            comboBox1.Items.Clear();

            while (oku.Read())
            {
                if (oku["oda_durumu"].ToString().Trim() == "BOS" && oku["oda_tipi"].ToString().Trim() == veri)//******///****//***//****
                {
                    comboBox1.Items.Add(oku["oda_numarası"]);
                }
            }


            baglantı.Close();
            //MessageBox.Show(comboBox1.Text.Trim());
        }


        private void btn_kayıt_sil_Click(object sender, EventArgs e)   //butona basınca soru sorar evet dersek veri sil metodunu calısır 
        {
            String tc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show($"TC KİMLİK NUMARASI {tc} OLAN BU REZARVASYONU SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                veri_sil();        //silmek istediğine eminmisin sorusu olması lazım yapamadım
            }
        }


        void veri_sil()
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Rezervasyon Where tc_kimlik = @tc", baglantı);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells[0].Value);
            komut.ExecuteNonQuery();

            // Rezervasyon silindikten sonra odanın durumunu "BOS" olarak güncelliyoruz
            String updateRoomStatusQuery = "UPDATE Odalar SET oda_durumu = 'BOS' WHERE oda_numarası = @no";
            SqlCommand updateRoomStatusCommand = new SqlCommand(updateRoomStatusQuery, baglantı);
            updateRoomStatusCommand.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[1].Value); // Oda numarasını alıyoruz
            updateRoomStatusCommand.ExecuteNonQuery();

            baglantı.Close();
            veri_getir(); // Verileri tekrar getiriyoruz
        }// Veritabanda seçilen satıradaki verileri silmemizi sağlar 


        void kayıt_ekle() //veri tabanına girilen verileri kayıt eder 
        {
            // İlk olarak rezervasyonu veritabanına ekliyoruz
            baglantı.Open();
            String sorgu = "INSERT INTO Rezervasyon (tc_kimlik, oda_no, oda_tipi, giris_tarihi, cıkıs_tarihi) VALUES (@tc, @no, @tip, @giris, @cıkıs)";
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@tc", tc);
            komut.Parameters.AddWithValue("@no", no);
            komut.Parameters.AddWithValue("@tip", tip);
            komut.Parameters.AddWithValue("@giris", giris);
            komut.Parameters.AddWithValue("@cıkıs", cıkıs);
            komut.ExecuteNonQuery();

            // Odanın durumunu "DOLU" olarak güncelliyoruz
            String updateRoomStatusQuery = "UPDATE Odalar SET oda_durumu = 'DOLU' WHERE oda_numarası = @no"; //burada seçilen boş odayı veri tabanında Dolu olarak değiştiriyoruz
            SqlCommand updateRoomStatusCommand = new SqlCommand(updateRoomStatusQuery, baglantı);
            updateRoomStatusCommand.Parameters.AddWithValue("@no", no);
            updateRoomStatusCommand.ExecuteNonQuery();

            baglantı.Close();
        }

        String tip, no, tc, giris, cıkıs;

        private void btn_tamamla_Click(object sender, EventArgs e)   //tamala tuşuna basılca bu işlemleri yapıyor
        {   
            if(text_tc.Text != "" && cb_tip.Text.Trim() != "" && comboBox1.Text.Trim() != "" ) //eğer belirtilen ifadeler boş değil ise
            {
                tip = cb_tip.Text.Trim();
                no = comboBox1.Text.Trim();
                tc = text_tc.Text;
                giris = dtp_giris.Value.ToString("dd/MM/yyyy");     //seçtiğimiz ifadeleri String  değerlere eşitler  
                cıkıs = dtp_cıkıs.Value.ToString("dd/MM/yyyy");

                if(lbl_secenek.Text == "0")  //burada eğer kayıt işlemi yapılacaksa olacakları gözteriyor
                {
                kayıt_ekle();
                veri_getir();
                temizle();
                    MessageBox.Show("KAYIT İŞLEMİ BAŞARILI !!");
                }
                else if (lbl_secenek.Text == "1")  //eğer güncelleme işlemi yapılcaksa  bu aşamalar gerçekleşir
                {
                    veri_yerlestir();
                    bilgi_güncelle();
                    veri_getir();
                    temizle();
                    MessageBox.Show("GÜNCELLEME İŞLEMİ BAŞARIYLA GERÇEKLEŞTİRİLDİ !!");

                }
               
            }
            else
            {
                MessageBox.Show("LÜTFEN BOŞ OLAN ALANLARI DOLDURUNUZ !!!");
            }
           
           // MessageBox.Show(tip + no + tc + giris + cıkıs ); çalışıyormu diye kontrol etmek için
        }

       

        private void btn_kayıt_güncelle_Click(object sender, EventArgs e)   //güncelle butonuna basınca yapılacaklar
        { 
            String tc = dataGridView1.CurrentRow.Cells[0].Value.ToString();     //seçilen ifadeni data gridteki 0.Sütundaki ifadeyi tc ye eşitler

            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("TC KİMLİK NUMARASI  " + tc + "  OLAN BU REZERVASYONDA DEĞİŞİKLİK YAPMAK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                veri_yerlestir();    //burada kullanıcıya seçenek sunar evet derser verileri yerlerine yerleştirir ve lbl_seceneği 1 yapar
            }
            lbl_secenek.Text = "1";
            
        }

        void veri_yerlestir()
        {   
            text_tc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();     // burada seçilen satırdaki ifadeleri yerlerine yerleştirir
            cb_tip.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtp_giris.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dtp_cıkıs.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();    
        }

        void bilgi_güncelle()       //burada tc kimliğe göre veri yerleştiririz
        {
            baglantı.Open();
            String sorgu = "UPDATE Rezervasyon SET oda_no = @no, oda_tipi = @tip, giris_tarihi = @giris, cıkıs_tarihi = @cıkıs WHERE tc_kimlik = @tc";
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@tc", tc);
            komut.Parameters.AddWithValue("@no", no);
            komut.Parameters.AddWithValue("@tip", tip);
            komut.Parameters.AddWithValue("@giris", giris);
            komut.Parameters.AddWithValue("@cıkıs", cıkıs);
            komut.ExecuteNonQuery();

            // Odanın durumunu "DOLU"ya güncelliyoruz
            String updateRoomStatusQuery = "UPDATE Odalar SET oda_durumu = 'DOLU' WHERE oda_numarası = @no";
            SqlCommand updateRoomStatusCommand = new SqlCommand(updateRoomStatusQuery, baglantı);
            updateRoomStatusCommand.Parameters.AddWithValue("@no", no);                                //burada ise oda durumunu Dolu olarak güncelleriz
            updateRoomStatusCommand.ExecuteNonQuery();

            baglantı.Close();
        }


        void temizle()       //burası ise kullanılacağı yeri temizler diğer işleme hazırlar
        {
            text_tc.Text = "";
            comboBox1.Text = "";
            cb_tip.Text = "";
            dtp_giris.Value = DateTime.Now;  
            dtp_cıkıs.Value = DateTime.Now;  //bu idfadede tarihi sıfırlar ve şuanki tarihe eşitler
            lbl_secenek.Text = "0";

        }

        private void text_tc_KeyPress(object sender, KeyPressEventArgs e)   //burası tc kısmına harf girilmesini engeller
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);

        }



    }
}
