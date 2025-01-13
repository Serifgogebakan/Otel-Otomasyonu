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
    public partial class Form_klnc_rezervasyon : Form
    {
        private string kullanıcıAdı;
        public Form_klnc_rezervasyon(String kullanıcıAdı)
        {
            InitializeComponent();
            this.kullanıcıAdı = kullanıcıAdı;
            
        }

        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");

        private void Form_klnc_rezervasyon_Load(object sender, EventArgs e)
        {
            veri_getir();
        }

        public String musteri
        {
            get { return kullanıcıAdı; }  // Kullanıcı adını döndürüyoruz
        }
        String tcKimlik;

        void tcGetir()    //bu kısım kullanıcı adından kayıtlı olan tc numarasını fetiriyor
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglantı.Close();
            }
        }

        void veri_getir()
        {
            try
            {
                tcGetir();
                baglantı.Open();
                // TC kimlik numarasına göre kullanıcıyı çekmek için SQL sorgusu
                SqlCommand komut = new SqlCommand("SELECT * FROM Rezervasyon WHERE tc_kimlik = @tcKimlik", baglantı);
                komut.Parameters.AddWithValue("@tcKimlik", tcKimlik);  // TC kimlik parametresi
                SqlDataAdapter ad = new SqlDataAdapter(komut);  // Veritabanı ile otomasyon arası veri aktarımı sağlar
                DataTable tablo = new DataTable();
                ad.Fill(tablo);  // Veriyi tabloya aktarıyoruz
                // DataGridView'e veriyi aktarıyoruz
                dataGridView1.DataSource = tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message); 
            }
            finally
            { 
                baglantı.Close();
            }
        } 
        private void cb_tip_SelectedIndexChanged(object sender, EventArgs e)  // combo boxa  seçilen ifadeye göre BOŞ odaları kayıt eder
        {
            String veri = cb_tip.Text.Trim(); //oda tipinin verisini tutan kısım
            //MessageBox.Show(veri);

            SqlCommand komut = new SqlCommand("SELECT * FROM Odalar", baglantı);  
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
        }


        void kayıt_ekle() //veri tabanına girilen verileri kayıt eder 
        {
            // İlk olarak rezervasyonu veritabanına ekliyoruz
            baglantı.Open();
            String sorgu = "INSERT INTO Rezervasyon (tc_kimlik, oda_no, oda_tipi, giris_tarihi, cıkıs_tarihi) VALUES (@tcKimlik, @no, @tip, @giris, @cıkıs)";
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@tcKimlik", tcKimlik);
            komut.Parameters.AddWithValue("@no", no);
            komut.Parameters.AddWithValue("@tip", tip);
            komut.Parameters.AddWithValue("@giris", giris);
            komut.Parameters.AddWithValue("@cıkıs", cıkıs);
            komut.ExecuteNonQuery();
            // Odanın durumunu "DOLU" olarak güncelliyoruz
            String updateRoomStatusQuery = "UPDATE Odalar SET oda_durumu = 'DOLU' WHERE oda_numarası = @no";
            SqlCommand updateRoomStatusCommand = new SqlCommand(updateRoomStatusQuery, baglantı);
            updateRoomStatusCommand.Parameters.AddWithValue("@no", no);
            updateRoomStatusCommand.ExecuteNonQuery();

            baglantı.Close();
        }



        String tip, no, tc, giris, cıkıs;
       
        private void btn_tamamla_Click(object sender, EventArgs e)
        {
            //veri_getir();

            if (cb_tip.Text.Trim() != "" && comboBox1.Text.Trim() != "")
            {
                tip = cb_tip.Text.Trim();
                no = comboBox1.Text.Trim();
                //tc = tcKimlik;
                giris = dtp_giris.Value.ToString("dd/MM/yyyy");   //ifaedeyi gün ay yıl şeklinde tutar
                cıkıs = dtp_cıkıs.Value.ToString("dd/MM/yyyy");

                if (lbl_secenek.Text == "0")
                {
                    kayıt_ekle();
                    veri_getir();
                     temizle();
                    MessageBox.Show("KAYIT İŞLEMİ BAŞARILI !!");
                }
                else if (lbl_secenek.Text == "1")   //lblseçenek 1 ise güncelleme işlemi yapar
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

            MessageBox.Show(tip + no + tc + giris + cıkıs);    // çalışıyormu diye kontrol etmek için
        }


        private void btn_kayıt_güncelle_Click(object sender, EventArgs e)       //kayıt güncellemeden önce kullanıcıya sorar
        {
            String tc = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("TC KİMLİK NUMARASI  " + tc + "  OLAN BU REZERVASYONDA DEĞİŞİKLİK YAPMAK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                veri_yerlestir();
            }
            lbl_secenek.Text = "1";    //evet derserk seçenek textini 1 e eşitle
        }

        void veri_yerlestir()             //seçilen verileri yerine yerleştirir
        {
            cb_tip.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dtp_giris.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dtp_cıkıs.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btn_yenile_Click(object sender, EventArgs e)
        {
          veri_getir();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();                     //burada çıkış yaparken soru soruyor evet dersek çıkıyor
            secim = MessageBox.Show("Bu Kısımdan Çıkmak İstediğinize eminmisiniz !!", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
                Form_kullanıcı_menu frm = new Form_kullanıcı_menu(musteri);
                frm.Show();
            }
        }

        

        void bilgi_güncelle()        //seçilen verileri günceller yenileri ile değiştirir
        {
            baglantı.Open();
            String sorgu = "UPDATE Rezervasyon SET oda_no = @no, oda_tipi = @tip, giris_tarihi = @giris, cıkıs_tarihi = @cıkıs WHERE tc_kimlik =@tcKimlik";
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@tcKimlik", tcKimlik);
            komut.Parameters.AddWithValue("@no", no);
            komut.Parameters.AddWithValue("@tip", tip);
            komut.Parameters.AddWithValue("@giris", giris);
            komut.Parameters.AddWithValue("@cıkıs", cıkıs);
            komut.ExecuteNonQuery();
            // Odanın durumunu "DOLU"ya güncelliyoruz
            String updateRoomStatusQuery = "UPDATE Odalar SET oda_durumu = 'DOLU' WHERE oda_numarası = @no";
            SqlCommand updateRoomStatusCommand = new SqlCommand(updateRoomStatusQuery, baglantı);     //Dolu ifadeyi boş ile değiştirir oda veri tabanında boş olarak gözükür
            updateRoomStatusCommand.Parameters.AddWithValue("@no", no);
            updateRoomStatusCommand.ExecuteNonQuery();
            baglantı.Close();
        }


        private void btn_kayıt_sil_Click(object sender, EventArgs e)   //butona basınca soru sorar evet dersek veri sil metodunu calısır 
        {
            String tc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show($" BU REZARVASYON KAYDINI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                veri_sil();        //silmek istediğine eminmisin sorusu olması lazım yapamadım
            }
        }
        void veri_sil()
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("DELETE FROM Rezervasyon Where tc_kimlik = @tc", baglantı);      //data gridde  seçilen ifadeyi veri tabanından siler 
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

        void temizle()
        {
            comboBox1.Text = "";
            cb_tip.Text = "";
            dtp_giris.Value = DateTime.Now;  // Resets to current date
            dtp_cıkıs.Value = DateTime.Now;  // Resets to current date
            lbl_secenek.Text = "0";
        }


    }
}
