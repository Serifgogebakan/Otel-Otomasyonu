using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otel_otomasyon
{
    public partial class Form_kisi_kayıt : Form
    {
        public Form_kisi_kayıt()
        {
            InitializeComponent();
        }

        private void Form_kisi_kayıt_Load(object sender, EventArgs e)
        {
            if (lbl_kademe.Text == "1")    //String olduğu için "" olacak
            {
                label1.Text = "[YENİ KAYIT EKRANI] ";
                pb_geri_form.Hide();
                ust_panel.BackColor = Color.Orange;
            }
            else if (lbl_kademe.Text == "0")
            {
                //MessageBox.Show("Kayıt Ekranına yönlendiriliyorsunuz");
            }
            else if (lbl_kademe.Text == "2")
            {
                label1.Text = "[KAYIT GÜNCELLEME EKRANI] ";
                pb_geri_form.Hide();
                ust_panel.BackColor = Color.Gray;
                //MessageBox.Show("Kayıt Güncelleme Ekranına yönlendiriliyorsunuz");
            }
            else if (lbl_kademe.Text == "3")
            {
                label1.Text = "[KAYIT GÜNCELLEME EKRANI] ";
                pb_geri_form.Hide();
                ust_panel.BackColor = Color.Gray;
                //MessageBox.Show("Kayıt Güncelleme Ekranına yönlendiriliyorsunuz");
            }
            else
            {
                MessageBox.Show("bu kademeye yetkilendirme yapılmadı");
            }
        }

        private void btn_cıkıs_Click(object sender, EventArgs e)  //form ekranını kapatır
        { 
            if (lbl_kademe.Text == "0")    //String olduğu için "" olacak
            {
                Form_giris_ekranı frm = new Form_giris_ekranı();
                frm.Show();
                this.Close();
            }
            else if (lbl_kademe.Text == "1")
            {
                this.Close();
            }
            else if (lbl_kademe.Text == "2")
            {
                this.Close();
            }
            else if (lbl_kademe.Text == "3")
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("bu kademeye yetkilendirme yapılmadı");
            }
        }

        private void pb_geri_form_Click(object sender, EventArgs e)
        {
            if (lbl_kademe.Text == "0")    //String olduğu için "" olacak
            {
                Form_giris_ekranı frm = new Form_giris_ekranı();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("bu kademeye yetkilendirme yapılmadı");
            }
        }
        
        private void btn_sonraki_adım_Click(object sender, EventArgs e)
        {
            //2.form kayıt ekranını açar
            if (lbl_kademe.Text == "0")
            {
                bilgileri_ilet();
            }
            else if (lbl_kademe.Text == "1")
            {
                bilgileri_ilet();
            }
            else if (lbl_kademe.Text == "2")
            {
                bilgileri_ilet();
            }
            else if (lbl_kademe.Text == "3")
            {
                bilgileri_ilet();
            }
            else
            {
                MessageBox.Show("bu kademeye yetkilendirme yapılmadı");
            }
        }



        String tc, isim, soyisim, dtarihi, mail, telefon, cinsiyet;
        public String kullanıcıad, sife, yeti;

        private void rb_kadın_CheckedChanged(object sender, EventArgs e) //kadınsa 0 erkekse 1
        {
                 lbl_cinsiyet.Text = "0";
        }

        private void rb_erkek_CheckedChanged(object sender, EventArgs e)//veri tabanınına cinsiyeti kaydetmek için böyle yapıyoruz 
        {
                lbl_cinsiyet.Text = "1";
        }

        void bilgileri_ilet()
        {
            // burada eğer kullanıcı herhangi adımı doldurmazsa aşağıdaki else de hata mesajı veriyor
            if (text_tc_kimlik_no.Text != "" && text_kimlik_isim.Text != "" && text_kimlik_soyisim.Text != "" &&
                text_kimlik_dogum_tarihi.Text != "" && text_mail_adresi.Text != "" && text_telefon_numarası.Text != "")
            {
                tc = text_tc_kimlik_no.Text;
                isim = text_kimlik_isim.Text.ToUpper();          //to upper ile nasıl yaılırsa yazılsın buyuk harflerle kaydediliyor
                soyisim = text_kimlik_soyisim.Text.ToUpper();
                dtarihi = text_kimlik_dogum_tarihi.Text;
                mail = text_mail_adresi.Text;
                telefon = text_telefon_numarası.Text;
                cinsiyet = lbl_cinsiyet.Text;

                Form_kisi_kayıt2 frm = new Form_kisi_kayıt2();    //2.form ekranını çağıra bilmek için nesne oluşturuyor
                frm.text_KullanıcıAdı.Text = kullanıcıad;
                frm.text_sifre.Text = sife;
                frm.text_sifre_tekrar.Text = sife;
                frm.lbl_yetki.Text = yeti;

                if (lbl_kademe.Text == "0")
                {
                    frm.lbl_kademe2.Text = "0";
                }
                else if (lbl_kademe.Text == "1")
                {
                    frm.lbl_kademe2.Text = "1";
                }
                else if (lbl_kademe.Text == "2")
                {
                    frm.lbl_kademe2.Text = "2";
                }
                else if (lbl_kademe.Text == "3")
                {
                    frm.lbl_kademe2.Text = "3";
                }

                frm.tc = tc;
                frm.isim = isim;
                frm.soyisim = soyisim;
                frm.dtarihi = dtarihi;
                frm.mail = mail;
                frm.telefon = telefon;
                frm.cinsiyet = cinsiyet;


                frm.Show();               //2. form ekranını görünür yapıyor
                this.Hide();                //ilk form ekranını gizliyor

            }
            else
            {
                MessageBox.Show("Lütfen Boş Alanları DOLDURUNUZ  !!!");
            }
        }

      

        private void btn_temizle_Click(object sender, EventArgs e)  //temizle butonuna basıldığında textin üstündeki tüm veriyi silecek şekilde ayarlıyoruz   
       {
            text_tc_kimlik_no.Text = "";
            text_kimlik_isim.Text = "";
            text_kimlik_soyisim.Text = "";
            text_kimlik_dogum_tarihi.Text = "";
            text_mail_adresi.Text = "";
            text_telefon_numarası.Text = "";
            lbl_cinsiyet.Text = "1";
            rb_erkek.Checked = true;           //cinsiyeti otomatik olarak erkek seçili olarak ayarlıyor
            rb_kadın.Checked = false;
            text_tc_kimlik_no.Focus();         //temizle butonuna bastıktan sonra otamatik olarak tc no textine tıklamadan ona yazılabilr hale geliyor

        }



       
       


        private void text_tc_kimlik_no_KeyPress(object sender, KeyPressEventArgs e)  //tc no için sadece rakam girilebilecek şekilde ayarlıyoruz
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }
        private void text_telefon_numarası_KeyPress(object sender, KeyPressEventArgs e)  //tel no için sadece rakam girilebilecek şekilde ayarlıyoruz
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }
        private void text_kimlik_isim_KeyPress(object sender, KeyPressEventArgs e)        //isimde rakam olmasın diye ayarlamalar yapıyor
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar); //isseparator ile ismler arasında boşluk bırakılabiliyor
        }
        private void text_kimlik_soyisim_KeyPress(object sender, KeyPressEventArgs e)  //soyisimde rakam olmasın diye ayarlamalar yapıyor
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar);  //isletter ile harf olup olmadığını kontrol ediyoruz harf değilse çalışmıyor
        }
        private void text_kimlik_dogum_tarihi_KeyPress(object sender, KeyPressEventArgs e)  //doğum tarihinde harf olmamalı ona göre ayarlıyoruz
        {

            if (e.KeyChar == '.')   //burada . için istisna sağlıyoruz o kullanılabiliyor  char olduğu için . tek tırnakların içine alıyoruz
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);  //isdigit ile rakam olup olmadıgığını kontrol ediyoruz
            }

        }



    }
}
