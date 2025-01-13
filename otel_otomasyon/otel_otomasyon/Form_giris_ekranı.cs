using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace otel_otomasyon
{
    public partial class Form_giris_ekranı : DevExpress.XtraEditors.XtraForm
    {
        public Form_giris_ekranı()
        {
            InitializeComponent();
        }
         SqlConnection baglantı = new SqlConnection("Data Source=GOGEBAKAN;Initial Catalog=otomasyon_otel_VT;Integrated Security=True");

        public String kullanıcıAdı;

        private void btn_cıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_goster_gizle_Click(object sender, EventArgs e)//şifre gizleme özelliği
        {
            if (text_sifre.PasswordChar == '*')   //eğer şifre gizli yani * ise 
            {
                text_sifre.PasswordChar = '\0';   //burada şifre * ise tekrar text halini görünür yapar
            }
            else
            {
                text_sifre.PasswordChar = '*';   //burada eğer şifre * değilse butona basınca her karakteri * yapar 
            }
            //passwordChar textbox özelliğiymiş  passwordcharla (char tek karakter tutuyor) her karakteri '*'ile değiştire biliyoruz
            //ve  \0 ile de tekrar eski haline getirebiliyoruz       
        }


        public String yetkinlik;
        void giris_kontrol()
        {
            if (text_KullanıcıAdı.Text != "" && text_sifre.Text != "")
            {
                baglantı.Open();                      //burada veri tabanına bağlanıp girilen ifade veri tabanındakiyle eşleşiyorsa devam ediyor yoksa else ifadesi çalışıyor
                SqlCommand komut = new SqlCommand("SELECT * FROM Kullanıcılar WHERE kullanıcı_ad = @p1 AND sifre = @p2 ", baglantı);
                komut.Parameters.AddWithValue("@p1", text_KullanıcıAdı.Text);
                komut.Parameters.AddWithValue("@p2", text_sifre.Text);
                kullanıcıAdı = text_KullanıcıAdı.Text;
                SqlDataReader oku = komut.ExecuteReader();    //bu kısmı not et  //komut metnini okuyor okuya eşitliyor gibi

                //MessageBox.Show("Giriş İşlemi Yapılıyor");
                if (oku.Read())                             // ne işe yaradığına bak
                {
                    yetkinlik = oku["yetki"].ToString().Trim();        //***not***              //bu oku.read dan sonra yazılmalı yoksa hata veriyor
                    //MessageBox.Show(yetkinlik); //deneme amaçlı
                    MessageBox.Show("GİRİŞ YAPILIYOR ! LÜTFEN BEKLEYİNİZ !!");    //Trim(); olmazsa açılmıyor ,trim gereksiz boşlukları siliyor

                    switch (yetkinlik)
                    {
                        case "1":
                            Form_admin_menu frmAdmin = new Form_admin_menu();
                            frmAdmin.Show();
                            this.Hide();
                            break;

                        case "0":
                            Form_kullanıcı_menu frmKullanıcı = new Form_kullanıcı_menu(kullanıcıAdı);
                            frmKullanıcı.Show();
                            frmKullanıcı.lbl_kul_ad.Text = text_KullanıcıAdı.Text;
                            this.Hide();

                            
                           

                            break;

                        default:
                            MessageBox.Show("Yetkinlik değeri geçersiz!");
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Böyle Bir Kayıt Bulunmamaktadır !! Lütfen Tekrar Deneyiniz !!!");
                }
                baglantı.Close();
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurunuz");
            }
        
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            giris_kontrol();
        }



        private void lbl_kayıt_ol_Click(object sender, EventArgs e)
        {

            Form_kisi_kayıt frm = new Form_kisi_kayıt();
            frm.Show();   //ilk formu açıyor
            this.Hide(); //form ekranını kapatıyor    //giriş formunu gizliyor
        }

       

        private void lbl_kayıt_ol_MouseMove(object sender, MouseEventArgs e) //kayıt ol tuşunun üstünde gelince rengi yeşil yapıyor
        {
            lbl_kayıt_ol.ForeColor = System.Drawing.Color.Green;
        }

        private void lbl_kayıt_ol_MouseLeave(object sender, EventArgs e)//kayıt ol tuşundan çekilince eski rengine çeviriyor
        {
            lbl_kayıt_ol.ForeColor = System.Drawing.Color.White;
        }





        //void yetki_getir()
        //{
        //    baglantı.Open();
        //    OleDbCommand komut = new OleDbCommand("SELECT * FROM Kullanıcılar WHERE kullanıcı_ad = @p1 ", baglantı);
        //    komut.Parameters.AddWithValue("@p1", text_KullanıcıAdı.Text);  // burada lbl ın textindeki veriyi vt da sorgular eşleşirse o satırı tutar
        //    OleDbDataReader oku = komut.ExecuteReader();  //eşleeşn satırdan sorgu yapar veri çekebilmemizi sağlar   

        //    //MessageBox.Show("Giriş İşlemi Yapılıyor");  //çalışıyormu diye kontrol etmek için

        //    if (oku.Read())     //lbl kullanıcı textindeki satırdaki verileri burada böyle çekiyoruz
        //    {
        //       yetkinlik = oku["yetki"].ToString();  //vt daki kullanıcını tc sini labele eşitler      

        //        //burada yetki 1 ise admin 0 ise personal yazsın onu yapmam lazım
        //    }
        //    baglantı.Close();
        //}

        //private void lbl_kayıt_ol_Click(object sender, EventArgs e)//kayıt olma ekranını açar ve giriş formunu gizeler
        //{
        //    Form_kisi_kayıt frm = new Form_kisi_kayıt();
        //    frm.Show();   //ilk formu açıyor
        //    this.Hide(); //form ekranını kapatıyor    //giriş formunu gizliyor
        //}
    }  
    }
  
