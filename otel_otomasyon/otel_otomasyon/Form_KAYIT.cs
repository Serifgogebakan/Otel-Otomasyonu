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
    public partial class Form_KAYIT : Form
    {
        public Form_KAYIT()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");

        private void Form_KAYIT_Load(object sender, EventArgs e) //form başlayınca yapılacakları ayarlarız
        {
            veri_getir();  //form başlayınca gridi data gridi dolduruyor
        }


        private void btn_yenile_Click(object sender, EventArgs e) //burada yenile butonuna basınca gridviev i yeniler
        {
            veri_getir();
        }

        public void veri_getir()   //veri tabanından grid vieve veri çekmemize yarıyor
        {
            // MessageBox.Show("asdfghjk");

            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM Kullanıcılar", baglantı);  //burada veri tabanında kullanıcılara bağlanıyor 
            SqlDataAdapter ad = new SqlDataAdapter (komut);       //veri tabanı ile otomasyon arası veri aktarımı sağlar  veri çekme,silme,güncellemeekleme gibi yapılan işleri veri tabanına geri gönderir
                                                                     //
            DataTable tablo = new DataTable();
            ad.Fill(tablo);                          //Fill dataadapter ın bir özelliğidir veri tabanındaki veryi belirtilen yere yerleştirir
            dataGridView1.DataSource = tablo;            //datasource ile tablodaki veri tabanı verisi dGV e yerleştirilir

            baglantı.Close(); // veri_getir tabanı bağlantısı durdurulur yoksa veri çekmeye devam eder ve hata verir
        }



        private void btn_kayıt_sil_Click(object sender, EventArgs e)
        {
            String tc = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show($"TC KİMLİK NUMARASI {tc} OLAN BU KAYDI SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                veri_sil();        //silmek istediğine eminmisin sorusu olması lazım yapamadım
            }


        }

        void veri_sil()
        {   
           baglantı.Open();
            //SqlCommand komut = new SqlCommand("DELETE FROM Kullanıcılar Where id =@id", baglantı);  //burada veri tabanındaki id yi @id ye eşitledik
            //komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            //komut.ExecuteNonQuery();
            //baglantı.Close();

            SqlCommand komut = new SqlCommand("DELETE FROM Kullanıcılar Where tc_kimlik =@tc", baglantı);  //burada veri tabanındaki swçilen kısımdaki veriyi siler ,tc_kimlik i @tc ye eşitledik kolaylık olsun diye yoksa aşağıyada yazacaktık
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells[0].Value); //dataGridView'de seçili satırın 2.kısmındaki değer alınarak @tc'ye eşitlenir
            komut.ExecuteNonQuery();  //şartları gerçekleştirir
            baglantı.Close();   //baglantıyı sonlandırır
            veri_getir();     //buradada silindikten sonra veri tabanını çağırı
        }// Veritabanda seçilen satıradaki verileri silmemizi sağlar 

       

        private void btn_yeni_kayıt_Click(object sender, EventArgs e)
        {

            Form_kisi_kayıt frm = new Form_kisi_kayıt();
            frm.lbl_kademe.Text = "1";
            frm.Show();       //Show()  showDialog() kullanmaktan daha mantıklı

        }  //sonra bak 


        private void btn_kayıt_güncelle_Click(object sender, EventArgs e)
        {
            String tc = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("TC KİMLİK NUMARASI  " + tc + "  OLAN BU KAYIT ÜZERİNDE DEĞİŞİKLİK YAPMAK İSTEDİĞİNİZE EMİN MİSİNİZ !!!", "KAYIT GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                veri_güncelle();
            }

        }
        void veri_güncelle()
        {
            Form_kisi_kayıt frm = new Form_kisi_kayıt();
            frm.lbl_kademe.Text = "2";
            frm.text_tc_kimlik_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.text_kimlik_isim.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.text_kimlik_soyisim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.lbl_cinsiyet.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.text_kimlik_dogum_tarihi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.text_telefon_numarası.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm.text_mail_adresi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm.kullanıcıad = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm.sife = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frm.yeti = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            //if (frm.lbl_kademe.Text == "2")
            //{
            //    Form_kisi_kayıt2 frm2 = new Form_kisi_kayıt2();
            //    frm2.text_KullanıcıAdı.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            //    frm2.text_sifre.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //    frm2.lbl_yetki.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            //}
            frm.Show();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();                     //burada çıkış yaparken soru soruyor evet dersek çıkıyor
            secim = MessageBox.Show("Kayıt Kontrol Ekranını kapatmak istediğinize eminmisiniz !!", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        }

        






        ////private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        ////{
        ////    //Form_kisi_kayıt frm = new Form_kisi_kayıt();   
        ////    //frm.text_tc_kimlik_no.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        ////    //frm.text_kimlik_isim.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        ////    //frm.text_kimlik_soyisim.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        ////    //frm.lbl_cinsiyet.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        ////    //frm.text_kimlik_dogum_tarihi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        ////    //frm.text_telefon_numarası.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        ////    //frm.text_mail_adresi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        ////}
        ///*bunu data gride basınca direkt verileri eşitleyecek ve seçilen kişilerin bilgileri oraya gidecekti sıkıntı çıktı*/




    }
}
