using System;
using System.Drawing;
using System.Windows.Forms;

namespace otel_otomasyon
{
    public static class StyleHelper
    {
        // Modern Arayüz Renk Paleti
        public static readonly Color FormBgColor = Color.FromArgb(30, 30, 36);        // Koyu Kömür (#1E1E24)
        public static readonly Color PanelBgColor = Color.FromArgb(43, 45, 66);       // Koyu Gri/Mavi (#2B2D42)
        public static readonly Color PrimaryBtnColor = Color.FromArgb(0, 180, 216);    // Cam Göbeği (#00B4D8)
        public static readonly Color DangerBtnColor = Color.FromArgb(217, 4, 41);      // Kırmızı (#D90429)
        public static readonly Color TextColor = Color.White;                         // Beyaz
        public static readonly Color SubTextColor = Color.FromArgb(141, 153, 174);   // Açık Gri (#8D99AE)
        public static readonly Color InputBgColor = Color.FromArgb(53, 56, 80);        // Giriş Alanları (#353850)

        /// <summary>
        /// Belirtilen forma ve onun altındaki tüm kontrollere modern tasarımı uygular.
        /// </summary>
        public static void Apply(Form form)
        {
            if (form == null) return;

            form.BackColor = FormBgColor;
            form.ForeColor = TextColor;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Tüm kontrolleri gez ve biçimlendir
            StyleControlsRecursive(form.Controls);
        }

        private static void StyleControlsRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Yazı Tipini Segoe UI olarak güncelle
                float originalSize = control.Font.Size;
                FontStyle originalStyle = control.Font.Style;
                control.Font = new Font("Segoe UI", originalSize, originalStyle);

                // Kontrol tipine göre özel biçimlendirme
                if (control is Panel)
                {
                    // Üst panel veya kenarlık paneli değilse panel arka plan rengini uygula
                    if (control.Name != "ust_panel" && control.Name != "panel_border")
                    {
                        control.BackColor = PanelBgColor;
                    }
                    control.ForeColor = TextColor;
                }
                else if (control is GroupBox)
                {
                    control.ForeColor = PrimaryBtnColor; // GroupBox başlığı renkli
                    control.BackColor = Color.Transparent;
                }
                else if (control is Label)
                {
                    // Başlık etiketlerini cam göbeği yap, diğerlerini beyaz/alt metin yap
                    if (control.Font.Size > 12)
                    {
                        control.ForeColor = PrimaryBtnColor;
                    }
                    else if (control.Name.Contains("lbl_bilgilendirme") || control.Name.Contains("label_sub"))
                    {
                        control.ForeColor = SubTextColor;
                    }
                    else
                    {
                        control.ForeColor = TextColor;
                    }
                }
                else if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font(btn.Font.FontFamily, btn.Font.Size, FontStyle.Bold);

                    // Çıkış veya Silme butonlarını kırmızı yap, diğerlerini cam göbeği
                    if (btn.Name.Contains("cıkıs") || btn.Name.Contains("sil") || btn.Name.Contains("iptal"))
                    {
                        btn.BackColor = DangerBtnColor;
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 35, 60); // Hover rengi
                    }
                    else
                    {
                        btn.BackColor = PrimaryBtnColor;
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(72, 202, 228); // Hover rengi
                    }
                    btn.ForeColor = Color.White;
                    btn.Cursor = Cursors.Hand;
                }
                else if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.BackColor = InputBgColor;
                    txt.ForeColor = TextColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox)
                {
                    ComboBox cb = (ComboBox)control;
                    cb.BackColor = InputBgColor;
                    cb.ForeColor = TextColor;
                    cb.FlatStyle = FlatStyle.Flat;
                }
                else if (control is DataGridView)
                {
                    DataGridView dgv = (DataGridView)control;
                    StyleDataGridView(dgv);
                }

                // Alt kontrolleri varsa onları da tara
                if (control.HasChildren)
                {
                    StyleControlsRecursive(control.Controls);
                }
            }
        }

        private static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = PanelBgColor;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(60, 64, 91);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.EnableHeadersVisualStyles = false;

            // Hücre Stilleri
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = PanelBgColor;
            cellStyle.ForeColor = TextColor;
            cellStyle.SelectionBackColor = Color.FromArgb(0, 150, 199);
            cellStyle.SelectionForeColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle = cellStyle;

            // Kolon Başlığı Stilleri
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = PrimaryBtnColor;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            headerStyle.SelectionBackColor = PrimaryBtnColor;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;

            // Satır Yüksekliği Ayarları
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeight = 32;
        }
    }
}
