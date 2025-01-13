namespace otel_otomasyon
{
    partial class Form_ODA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ODA));
            this.lbl_kademe = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_tip = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_durum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_tamamla = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.text_oda_no = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_yeni_kayıt = new System.Windows.Forms.Button();
            this.btn_kayıt_sil = new System.Windows.Forms.Button();
            this.btn_yenile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cıkıs = new System.Windows.Forms.Button();
            this.btn_kayıt_güncelle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_kademe
            // 
            this.lbl_kademe.AutoSize = true;
            this.lbl_kademe.Location = new System.Drawing.Point(398, 549);
            this.lbl_kademe.Name = "lbl_kademe";
            this.lbl_kademe.Size = new System.Drawing.Size(16, 17);
            this.lbl_kademe.TabIndex = 38;
            this.lbl_kademe.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cb_tip);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lbl_durum);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btn_tamamla);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.text_oda_no);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(833, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 613);
            this.panel2.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "ODA KAYDI EKLE:";
            // 
            // cb_tip
            // 
            this.cb_tip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_tip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_tip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cb_tip.FormattingEnabled = true;
            this.cb_tip.Items.AddRange(new object[] {
            "Tek",
            "Çift",
            "Aile"});
            this.cb_tip.Location = new System.Drawing.Point(41, 112);
            this.cb_tip.Name = "cb_tip";
            this.cb_tip.Size = new System.Drawing.Size(198, 28);
            this.cb_tip.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "ODA TİPİ :";
            // 
            // lbl_durum
            // 
            this.lbl_durum.AutoSize = true;
            this.lbl_durum.Location = new System.Drawing.Point(126, 224);
            this.lbl_durum.Name = "lbl_durum";
            this.lbl_durum.Size = new System.Drawing.Size(47, 17);
            this.lbl_durum.TabIndex = 25;
            this.lbl_durum.Text = "DOLU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "ODA DURUMU :";
            // 
            // btn_tamamla
            // 
            this.btn_tamamla.BackColor = System.Drawing.Color.Green;
            this.btn_tamamla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tamamla.FlatAppearance.BorderSize = 0;
            this.btn_tamamla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_tamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tamamla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_tamamla.ForeColor = System.Drawing.Color.White;
            this.btn_tamamla.Location = new System.Drawing.Point(213, 354);
            this.btn_tamamla.Name = "btn_tamamla";
            this.btn_tamamla.Size = new System.Drawing.Size(109, 39);
            this.btn_tamamla.TabIndex = 24;
            this.btn_tamamla.Text = "TAMAMLA";
            this.btn_tamamla.UseVisualStyleBackColor = false;
            this.btn_tamamla.Click += new System.EventHandler(this.btn_tamamla_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(62, 195);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 28);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "DOLU";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // text_oda_no
            // 
            this.text_oda_no.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_oda_no.Cursor = System.Windows.Forms.Cursors.Hand;
            this.text_oda_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.text_oda_no.Location = new System.Drawing.Point(40, 296);
            this.text_oda_no.MaxLength = 4;
            this.text_oda_no.Name = "text_oda_no";
            this.text_oda_no.Size = new System.Drawing.Size(178, 28);
            this.text_oda_no.TabIndex = 23;
            this.text_oda_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_oda_no_KeyPress);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(170, 195);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(69, 28);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.Text = "BOŞ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(36, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "ODA NUMARASI :";
            // 
            // btn_yeni_kayıt
            // 
            this.btn_yeni_kayıt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(45)))));
            this.btn_yeni_kayıt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_yeni_kayıt.FlatAppearance.BorderSize = 0;
            this.btn_yeni_kayıt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btn_yeni_kayıt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yeni_kayıt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yeni_kayıt.ForeColor = System.Drawing.Color.White;
            this.btn_yeni_kayıt.Image = ((System.Drawing.Image)(resources.GetObject("btn_yeni_kayıt.Image")));
            this.btn_yeni_kayıt.Location = new System.Drawing.Point(303, 583);
            this.btn_yeni_kayıt.Name = "btn_yeni_kayıt";
            this.btn_yeni_kayıt.Size = new System.Drawing.Size(190, 83);
            this.btn_yeni_kayıt.TabIndex = 37;
            this.btn_yeni_kayıt.Text = "ODA  KAYIT EKLE";
            this.btn_yeni_kayıt.UseVisualStyleBackColor = false;
            this.btn_yeni_kayıt.Click += new System.EventHandler(this.btn_yeni_kayıt_Click);
            // 
            // btn_kayıt_sil
            // 
            this.btn_kayıt_sil.BackColor = System.Drawing.Color.Maroon;
            this.btn_kayıt_sil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_kayıt_sil.FlatAppearance.BorderSize = 0;
            this.btn_kayıt_sil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_kayıt_sil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kayıt_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kayıt_sil.ForeColor = System.Drawing.Color.White;
            this.btn_kayıt_sil.Image = ((System.Drawing.Image)(resources.GetObject("btn_kayıt_sil.Image")));
            this.btn_kayıt_sil.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_kayıt_sil.Location = new System.Drawing.Point(27, 583);
            this.btn_kayıt_sil.Name = "btn_kayıt_sil";
            this.btn_kayıt_sil.Size = new System.Drawing.Size(190, 83);
            this.btn_kayıt_sil.TabIndex = 35;
            this.btn_kayıt_sil.Text = "ODA KAYDI SİL";
            this.btn_kayıt_sil.UseVisualStyleBackColor = false;
            this.btn_kayıt_sil.Click += new System.EventHandler(this.btn_kayıt_sil_Click);
            // 
            // btn_yenile
            // 
            this.btn_yenile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_yenile.BackgroundImage")));
            this.btn_yenile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_yenile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_yenile.FlatAppearance.BorderSize = 0;
            this.btn_yenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_yenile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_yenile.Location = new System.Drawing.Point(370, 467);
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.Size = new System.Drawing.Size(70, 68);
            this.btn_yenile.TabIndex = 33;
            this.btn_yenile.UseVisualStyleBackColor = true;
            this.btn_yenile.Click += new System.EventHandler(this.btn_yenile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(750, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(27, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "ODA BİLGİLERİ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(27, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 363);
            this.panel1.TabIndex = 32;
            // 
            // btn_cıkıs
            // 
            this.btn_cıkıs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(60)))));
            this.btn_cıkıs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cıkıs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cıkıs.FlatAppearance.BorderSize = 0;
            this.btn_cıkıs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_cıkıs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cıkıs.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cıkıs.ForeColor = System.Drawing.Color.White;
            this.btn_cıkıs.Location = new System.Drawing.Point(1118, 12);
            this.btn_cıkıs.Name = "btn_cıkıs";
            this.btn_cıkıs.Size = new System.Drawing.Size(48, 46);
            this.btn_cıkıs.TabIndex = 8;
            this.btn_cıkıs.Text = "X";
            this.btn_cıkıs.UseVisualStyleBackColor = false;
            this.btn_cıkıs.Click += new System.EventHandler(this.btn_cıkıs_Click);
            // 
            // btn_kayıt_güncelle
            // 
            this.btn_kayıt_güncelle.BackColor = System.Drawing.Color.SaddleBrown;
            this.btn_kayıt_güncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_kayıt_güncelle.BackgroundImage")));
            this.btn_kayıt_güncelle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kayıt_güncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_kayıt_güncelle.FlatAppearance.BorderSize = 0;
            this.btn_kayıt_güncelle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_kayıt_güncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kayıt_güncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_kayıt_güncelle.ForeColor = System.Drawing.Color.White;
            this.btn_kayıt_güncelle.Location = new System.Drawing.Point(598, 583);
            this.btn_kayıt_güncelle.Name = "btn_kayıt_güncelle";
            this.btn_kayıt_güncelle.Size = new System.Drawing.Size(190, 83);
            this.btn_kayıt_güncelle.TabIndex = 34;
            this.btn_kayıt_güncelle.Text = "ODA KAYDI GÜNCELLE";
            this.btn_kayıt_güncelle.UseVisualStyleBackColor = false;
            this.btn_kayıt_güncelle.Click += new System.EventHandler(this.btn_kayıt_güncelle_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(64)))), ((int)(((byte)(45)))));
            this.panel3.Controls.Add(this.btn_cıkıs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1178, 67);
            this.panel3.TabIndex = 31;
            // 
            // Form_ODA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 680);
            this.Controls.Add(this.lbl_kademe);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_yeni_kayıt);
            this.Controls.Add(this.btn_kayıt_sil);
            this.Controls.Add(this.btn_yenile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_kayıt_güncelle);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ODA";
            this.Text = "Form_ODA";
            this.Load += new System.EventHandler(this.Form_ODA_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_kademe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_tip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_durum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_tamamla;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox text_oda_no;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_yeni_kayıt;
        private System.Windows.Forms.Button btn_kayıt_sil;
        private System.Windows.Forms.Button btn_yenile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cıkıs;
        private System.Windows.Forms.Button btn_kayıt_güncelle;
        private System.Windows.Forms.Panel panel3;
    }
}