namespace otel_otomasyon
{
    partial class Form_kisi_kayıt2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_kisi_kayıt2));
            this.lbl_kademe2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rb_yetkili = new System.Windows.Forms.RadioButton();
            this.rb_kisi = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_tamamla = new System.Windows.Forms.Button();
            this.btn_temizle = new System.Windows.Forms.Button();
            this.text_sifre_tekrar = new System.Windows.Forms.TextBox();
            this.lbl_yetki = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.text_KullanıcıAdı = new System.Windows.Forms.TextBox();
            this.text_sifre = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pb_geri_form = new System.Windows.Forms.PictureBox();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ust_panel = new System.Windows.Forms.Panel();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_geri_form)).BeginInit();
            this.ust_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_kademe2
            // 
            this.lbl_kademe2.AutoSize = true;
            this.lbl_kademe2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kademe2.Location = new System.Drawing.Point(641, 102);
            this.lbl_kademe2.Name = "lbl_kademe2";
            this.lbl_kademe2.Size = new System.Drawing.Size(18, 20);
            this.lbl_kademe2.TabIndex = 29;
            this.lbl_kademe2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Görev Seçiniz:";
            // 
            // rb_yetkili
            // 
            this.rb_yetkili.AutoSize = true;
            this.rb_yetkili.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_yetkili.ForeColor = System.Drawing.Color.Black;
            this.rb_yetkili.Location = new System.Drawing.Point(309, 23);
            this.rb_yetkili.Name = "rb_yetkili";
            this.rb_yetkili.Size = new System.Drawing.Size(90, 29);
            this.rb_yetkili.TabIndex = 1;
            this.rb_yetkili.Text = "Yetkili";
            this.rb_yetkili.UseVisualStyleBackColor = true;
            this.rb_yetkili.CheckedChanged += new System.EventHandler(this.rb_yetkili_CheckedChanged);
            // 
            // rb_kisi
            // 
            this.rb_kisi.AutoSize = true;
            this.rb_kisi.Checked = true;
            this.rb_kisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_kisi.ForeColor = System.Drawing.Color.Black;
            this.rb_kisi.Location = new System.Drawing.Point(175, 23);
            this.rb_kisi.Name = "rb_kisi";
            this.rb_kisi.Size = new System.Drawing.Size(117, 29);
            this.rb_kisi.TabIndex = 0;
            this.rb_kisi.TabStop = true;
            this.rb_kisi.Text = "Personel";
            this.rb_kisi.UseVisualStyleBackColor = true;
            this.rb_kisi.CheckedChanged += new System.EventHandler(this.rb_kisi_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.rb_yetkili);
            this.groupBox8.Controls.Add(this.rb_kisi);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(26, 251);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(412, 63);
            this.groupBox8.TabIndex = 27;
            this.groupBox8.TabStop = false;
            // 
            // btn_tamamla
            // 
            this.btn_tamamla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_tamamla.FlatAppearance.BorderSize = 0;
            this.btn_tamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tamamla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_tamamla.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_tamamla.Location = new System.Drawing.Point(382, 405);
            this.btn_tamamla.Name = "btn_tamamla";
            this.btn_tamamla.Size = new System.Drawing.Size(365, 65);
            this.btn_tamamla.TabIndex = 26;
            this.btn_tamamla.Text = "TAMAMLA";
            this.btn_tamamla.UseVisualStyleBackColor = false;
            this.btn_tamamla.Click += new System.EventHandler(this.btn_tamamla_Click);
            // 
            // btn_temizle
            // 
            this.btn_temizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btn_temizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_temizle.FlatAppearance.BorderSize = 0;
            this.btn_temizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_temizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_temizle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_temizle.Location = new System.Drawing.Point(26, 405);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(285, 65);
            this.btn_temizle.TabIndex = 25;
            this.btn_temizle.Text = "TEMİZLE";
            this.btn_temizle.UseVisualStyleBackColor = false;
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // text_sifre_tekrar
            // 
            this.text_sifre_tekrar.Location = new System.Drawing.Point(179, 0);
            this.text_sifre_tekrar.MaxLength = 50;
            this.text_sifre_tekrar.Name = "text_sifre_tekrar";
            this.text_sifre_tekrar.Size = new System.Drawing.Size(187, 30);
            this.text_sifre_tekrar.TabIndex = 0;
            // 
            // lbl_yetki
            // 
            this.lbl_yetki.AutoSize = true;
            this.lbl_yetki.Location = new System.Drawing.Point(280, 317);
            this.lbl_yetki.Name = "lbl_yetki";
            this.lbl_yetki.Size = new System.Drawing.Size(16, 17);
            this.lbl_yetki.TabIndex = 28;
            this.lbl_yetki.Text = "0";
            this.lbl_yetki.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.text_sifre_tekrar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(336, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 40);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ŞİFRE (tekrar):";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.text_KullanıcıAdı);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.Location = new System.Drawing.Point(26, 121);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(393, 47);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "KULLANICI ADI :";
            // 
            // text_KullanıcıAdı
            // 
            this.text_KullanıcıAdı.Location = new System.Drawing.Point(199, 0);
            this.text_KullanıcıAdı.MaxLength = 50;
            this.text_KullanıcıAdı.Name = "text_KullanıcıAdı";
            this.text_KullanıcıAdı.Size = new System.Drawing.Size(179, 30);
            this.text_KullanıcıAdı.TabIndex = 0;
            // 
            // text_sifre
            // 
            this.text_sifre.Location = new System.Drawing.Point(102, 0);
            this.text_sifre.MaxLength = 50;
            this.text_sifre.Name = "text_sifre";
            this.text_sifre.Size = new System.Drawing.Size(188, 30);
            this.text_sifre.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.text_sifre);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(26, 195);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 40);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ŞİFRE :";
            // 
            // pb_geri_form
            // 
            this.pb_geri_form.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_geri_form.Image = ((System.Drawing.Image)(resources.GetObject("pb_geri_form.Image")));
            this.pb_geri_form.Location = new System.Drawing.Point(3, 5);
            this.pb_geri_form.Name = "pb_geri_form";
            this.pb_geri_form.Size = new System.Drawing.Size(50, 50);
            this.pb_geri_form.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_geri_form.TabIndex = 19;
            this.pb_geri_form.TabStop = false;
            this.pb_geri_form.Click += new System.EventHandler(this.pb_geri_form_Click);
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(55)))), ((int)(((byte)(64)))));
            this.btn_cıkıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cıkıs.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cıkıs.FlatAppearance.BorderSize = 0;
            this.btn_cıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cıkıs.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cıkıs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cıkıs.Location = new System.Drawing.Point(771, 0);
            this.btn_cıkıs.Name = "btn_cıkıs";
            this.btn_cıkıs.Size = new System.Drawing.Size(58, 58);
            this.btn_cıkıs.TabIndex = 12;
            this.btn_cıkıs.Text = "X";
            this.btn_cıkıs.UseVisualStyleBackColor = false;
            this.btn_cıkıs.Click += new System.EventHandler(this.btn_cıkıs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "KULLANICI KAYIT EKRANI";
            // 
            // ust_panel
            // 
            this.ust_panel.BackColor = System.Drawing.Color.Turquoise;
            this.ust_panel.Controls.Add(this.pb_geri_form);
            this.ust_panel.Controls.Add(this.btn_cıkıs);
            this.ust_panel.Controls.Add(this.label1);
            this.ust_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ust_panel.Location = new System.Drawing.Point(0, 0);
            this.ust_panel.Name = "ust_panel";
            this.ust_panel.Size = new System.Drawing.Size(829, 58);
            this.ust_panel.TabIndex = 21;
            // 
            // Form_kisi_kayıt2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 510);
            this.Controls.Add(this.lbl_kademe2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btn_tamamla);
            this.Controls.Add(this.btn_temizle);
            this.Controls.Add(this.lbl_yetki);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ust_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_kisi_kayıt2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_kisi_kayıt2";
            this.Load += new System.EventHandler(this.Form_kisi_kayıt2_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_geri_form)).EndInit();
            this.ust_panel.ResumeLayout(false);
            this.ust_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_kademe2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rb_yetkili;
        private System.Windows.Forms.RadioButton rb_kisi;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_tamamla;
        private System.Windows.Forms.Button btn_temizle;
        public System.Windows.Forms.TextBox text_sifre_tekrar;
        public System.Windows.Forms.Label lbl_yetki;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.TextBox text_KullanıcıAdı;
        public System.Windows.Forms.TextBox text_sifre;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pb_geri_form;
        private System.Windows.Forms.Button btn_cıkıs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ust_panel;
    }
}