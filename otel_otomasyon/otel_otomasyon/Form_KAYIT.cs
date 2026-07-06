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

        // Seçili satırdaki kullanıcı kaydını veritabanından siler
        void veri_sil()
        {   
            baglantı.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Kullanıcılar Where tc_kimlik =@tc", baglantı);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells[0].Value);
            komut.ExecuteNonQuery();
            baglantı.Close();
            veri_getir(); // Silme işleminden sonra verileri yeniler
        }

       

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

            frm.Show();
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Kayıt Kontrol Ekranını kapatmak istediğinize emin misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
