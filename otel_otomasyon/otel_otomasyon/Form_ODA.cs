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
    public partial class Form_ODA : Form
    {
        public Form_ODA()
        {
            InitializeComponent();
            StyleHelper.Apply(this);
        }

        SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True"); //veri tabanında bağlanacağı yeri gözterir

        private void Form_ODA_Load(object sender, EventArgs e)
        {
            veri_getir();
        }

        public String tip, durum, numara;

        private void btn_cıkıs_Click(object sender, EventArgs e)  //çıkış tuçuna basınce eminmisin sorusu sorar
        {
            DialogResult secim = MessageBox.Show("Oda Kontrol ekranından çıkmak istediğinize emin misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_yenile_Click(object sender, EventArgs e)   //data grid i yeniler
        {
            veri_getir();
        }

        public void veri_getir() // Veritabanından veriyi gridview'e yerleştirir
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Odalar", baglantı);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            ad.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }

        private void btn_kayıt_sil_Click(object sender, EventArgs e)    //burada ist kayıt silmeden önce kullanıcıya eminmisin diye sorar
        {
            String numara = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DialogResult secim = MessageBox.Show($"Oda Numarası {numara} olan bu kaydı silmek istediğinize emin misiniz?", "KAYIT SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {                         
                kayıt_sil();
            }
        }

        void kayıt_sil()   //burada seçilen odayı veri tabanından kayıdını siler 
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Odalar WHERE oda_numarası = @no", baglantı);
            komut.Parameters.AddWithValue("@no", dataGridView1.CurrentRow.Cells[2].Value);
            komut.ExecuteNonQuery();
            baglantı.Close();
            veri_getir();
        }

        private void btn_kayıt_güncelle_Click(object sender, EventArgs e)  // kayıt güncelle butonuna basınca yapılacaklar
        {
            label5.Text = "ODA KAYDI GÜNCELLE:";           //burada kişi kayıt ekranındaki textin adını değiştirir
            lbl_kademe.Text = "1";
            String no = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim() ;   
            DialogResult secim = MessageBox.Show($"Oda Numarası {no} olan bu kaydı güncellemek istediğinize emin misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)      
            {                                               //burada kullanıcıya eminmisin diye sorar sonrada evet dersek bilgi getir metodunu çalıştırır
                bilgi_getir();
            }
        }

        void bilgi_getir()     //burada verileri yerine yerleştirmek için veri tabanından verileri çeker ve yerine yerleştirir
        {
            cb_tip.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lbl_durum.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (lbl_durum.Text.Trim() == "DOLU")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            text_oda_no.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        void bilgi_güncelle()               // buradan seçilen satırdaki verileri veri tabanında günceller
        {
            baglantı.Open();
            String sorgu = "UPDATE Odalar SET oda_tipi = @tip, oda_durumu = @durum WHERE oda_numarası = @numara";
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@tip", tip);
            komut.Parameters.AddWithValue("@durum", durum);
            komut.Parameters.AddWithValue("@numara", numara);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        void kayıt_ekle()        //burada yeni kayıt ekleyince yeni kayıt bilgilerini veri tabanına ekler 
        {
            baglantı.Open();
            String sorgu = "INSERT INTO Odalar (oda_tipi, oda_durumu, oda_numarası) VALUES (@tip, @durum, @numara)"; //sql de @ kullanıyoruz neden bilmiyorum
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@tip", tip);
            komut.Parameters.AddWithValue("@durum", durum);
            komut.Parameters.AddWithValue("@numara", numara);
            komut.ExecuteNonQuery();
            baglantı.Close();
        }

        bool no_kontrol = false;
        void numara_kontrol()   //oluşturulan yeni odanın veri tabanında oda numarasını kontrol eder  ona göre girilen oda numarasını oluşturur
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Odalar WHERE oda_numarası = @no", baglantı);
            komut.Parameters.AddWithValue("@no", numara);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                no_kontrol = true;
            }
            else
            {
                no_kontrol = false;
            }
            baglantı.Close();
        }

        private void btn_tamamla_Click(object sender, EventArgs e)
        {
            if (cb_tip.Text != "" && text_oda_no.Text != "")//text lerin içini kontrol edfer boş değilse devam eder
            {
                tip = cb_tip.Text;         //text deki ifadeleri string değerler eşitleyip tutar
                durum = lbl_durum.Text;
                numara = text_oda_no.Text;

                if (lbl_kademe.Text == "1") //kademe 1 ise bu işlemleri yapar
                {
                    bilgi_güncelle();
                    veri_getir();
                    temizle();
                }
                else          //değilse bu işlemleri yapar
                {
                    numara_kontrol();
                    if (no_kontrol == false)
                    {
                        kayıt_ekle();
                        veri_getir();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Girilen oda numarası daha önce kaydedilmiş!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen boş alanları doldurun!");
            }
        }

        void temizle()      //burada texte yazı yazıyorsa  sıfırlar eski haline çevirir 
        {
            cb_tip.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            text_oda_no.Text = "";
            lbl_kademe.Text = "0";
            label5.Text = "ODA KAYDI EKLE:";
        }

        private void text_oda_no_KeyPress(object sender, KeyPressEventArgs e)   //oda numarası kısmına harf girilemez
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void btn_yeni_kayıt_Click(object sender, EventArgs e)
        {
            label5.Text = "ODA KAYDI EKLE :";
        }

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lbl_durum.Text = "DOLU";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lbl_durum.Text = "BOS";
        }






    }
}
