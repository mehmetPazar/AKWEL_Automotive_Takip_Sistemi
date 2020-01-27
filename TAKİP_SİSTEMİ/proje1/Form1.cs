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
using DGVPrinterHelper;

namespace proje1
{
    
    public partial class AkwelTakipSistemi : Form
    {        
        SqlZiyaret Sz = new SqlZiyaret();
        SqlAmbar Sa = new SqlAmbar();
        SqlMudur Sm = new SqlMudur();
        SqlSirket Ss = new SqlSirket();
        SqlIzin Si =new SqlIzin();
        Sqlcikti Sc = new Sqlcikti();
        SqlHurda Sh = new SqlHurda();
        int l = 0;
        string a ;
        string b ;
        string c ;
        string k = DateTime.Now.ToLongDateString();
        int Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
        int Height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
        public AkwelTakipSistemi()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            SidePanel.Height = ZiyaretciG.Height;
            SidePanel.Top = ZiyaretciG.Top;
            timer1.Enabled = true;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = false;
            IzinlerGirisi.Visible = false;
            MudurGirisi.Visible = false;
            SirketAraciGiris.Visible = false;
            CiktiAlma.Visible = false;
            //
            /*CmbMudur.Items.Add("ARAL ALKAN");
            CmbMudur.Items.Add("BENER ALADAĞLI");
            CmbMudur.Items.Add("CAVİDE KORUK");
            CmbMudur.Items.Add("CUMA CERAN");
            CmbMudur.Items.Add("ERSİN ALTUN");
            CmbMudur.Items.Add("ESER GİRGİNER");
            CmbMudur.Items.Add("FERDİ AKINCI");
            CmbMudur.Items.Add("HACER KALE");
            CmbMudur.Items.Add("HAKKI CESUR");
            CmbMudur.Items.Add("İLYAS KAYGISIZ");
            CmbMudur.Items.Add("KÖKSAL İCİK");
            CmbMudur.Items.Add("MEHMET DEMİR");
            CmbMudur.Items.Add("ŞÜKRÜ GÜNGÖRDÜ");
            CmbMudur.Items.Add("UĞUR FERE");
            CmbMudur.Items.Add("YILDIRAY DEMİRCİ");
            CmbMudur.Items.Add("AYKUT DÜNDAR");
            CmbMudur.Items.Add("MURAL MARAL");
            CmbMudur.Items.Add("MURAT ERŞEN");
            CmbMudur.Items.Add("METİN TOPYÜREK");*/

            Sc.Listele7(CmbMudur);


            CmbMudur.SelectedIndex = 0;

            /*cmbPlaka.Items.Add("16 GA 523 (5)");
            cmbPlaka.Items.Add("16 BPH 07 (4)");
            cmbPlaka.Items.Add("16 JIG 47 (8)");
            cmbPlaka.Items.Add("16 JIG 48 (9)");
            cmbPlaka.Items.Add("16 JIJ 30    ");
            cmbPlaka.Items.Add("16 BVM 75   ");
            cmbPlaka.Items.Add("16 BCT 24   ");*/

            Sc.Listele8(cmbPlaka);
            Sc.Listele9(cmbSorguPlaka);

            cmbSorguPlaka.SelectedIndex = 0;
            cmbPlaka.SelectedIndex = 0;

            cmbGorevli.Items.Add("İZİNLİ");
            cmbGorevli.Items.Add("GOREVLİ");
            cmbGorevli.SelectedIndex = 0;


            cmbSecim.Items.Add("ZİYARETÇİ/İZİNLİ/GÖREVLİ");
            cmbSecim.Items.Add("AMBAR ARAÇ GİRİŞİ");
            cmbSecim.Items.Add("ŞİRKET ARAÇ ÇIKIŞI");
            cmbSecim.Items.Add("HURDA ARAÇ GİRİŞİ");
            cmbSecim.Items.Add("MÜDÜR GİRİŞİ");
            cmbSecim.SelectedIndex = 1;

            cmbSorgu.Items.Add("AMBAR ARACI SORGU");
            cmbSorgu.Items.Add("ŞİRKET ARACI SORGU");
            cmbSorgu.Items.Add("MÜDÜR GİRİŞ SORGU");
            cmbSorgu.SelectedIndex = 0;

            /*cmbSorguPlaka.Items.Add("16 GA 523 (5)");
            cmbSorguPlaka.Items.Add("16 BPH 07 (4)");
            cmbSorguPlaka.Items.Add("16 JIG 47 (8)");
            cmbSorguPlaka.Items.Add("16 JIG 48 (9)");
            cmbSorguPlaka.Items.Add("16 JIJ 30    ");
            cmbSorguPlaka.Items.Add("16 BVM 75   ");
            cmbSorguPlaka.Items.Add("16 BCT 24   ");*/

            

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            label56.Location = new Point((209 + ((Width - 567) / 2)), 100);
            label7.Location = new Point((209 + ((Width - 864) / 2)), (Height - 110));
            label57.Location = new Point((209 + ((Width - 974) / 2)), (Height - 80));
            label58.Location = new Point((209 + ((Width - 435) / 2)), (Height - 50));
            TakipSistemi.Location = new Point((335 + ((Width - 836) / 2)), 15);
        }
        void ListeleZiyaret()
        {
            dgvZiyaretciGirisi.DataSource = Sz.Listele();
        }
        void Listelecikti(string x, string y, string z)
        {
            dgvCikti.DataSource = Sc.Listele(x, y, z);
        }
        void ListeleAmbar()
        {
            dgvAmbarGiris.DataSource = Sa.Listele();
        }
        void ListeleSirket()
        {
            dgvSirketAraci.DataSource = Ss.Listele();
        }
        void ListeleIzin()
        {
            dgvIzinlerGiris.DataSource = Si.Listele();
        }
        void ListeleHurda()
        {
            dgvHurdaGiris.DataSource = Sh.Listele();
        }
        void ListeleIzin1(string x, string y, string z)
        {
            dgvMudur.DataSource = Sc.Listele1(x, y, z);
        }
        void ListeleIzin2(string x, string y, string z)
        {
            dgvAmbar.DataSource = Sc.Listele2(x, y, z);
        }
        void ListeleIzin3(string x, string y, string z)
        {
            dgvSirket.DataSource = Sc.Listele3(x, y, z);
        }
        void ListeleIzin4(string x, string y, string z, string k)
        {
            dgvSorguAmbar.DataSource = Sc.Listele4(x, y, z, k);
        }
        void ListeleIzin5(string x, string y, string z, string k)
        {
            dgvSorguSirket.DataSource = Sc.Listele5(x, y, z, k);
        }
        void ListeleIzin6(string x, string y, string z)
        {
            dgvSorguMudur.DataSource = Sc.Listele6(x, y, z);
        }
        void ListeleIzin7(string x, string y, string z)
        {
            dgvHurda.DataSource = Sc.Listele10(x, y, z);
        }
        public void Temizle(GroupBox gr)
        {
            foreach (Control c in gr.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    c.Text = "";

                }
            }            
        }
        private void Kapatma_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Programı Kapatmak istiyor musunuz?","KAPATMA EKRANI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(cevap== DialogResult.Yes)
                Application.Exit();  

        }

        private void Facebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/akwelautomotive/"); 
        }

        private void Twitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/akwelautomotive");
        }

        private void Contact_Click(object sender, EventArgs e)
        {
            Bilgilendirme f2 = new Bilgilendirme();
            f2.ShowDialog();

            this.Show();
        }

        private void Linkedin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/company/akwel/");
        }

        private void AmbarG_Click(object sender, EventArgs e)
        {
            dgvAmbarGiris.AutoGenerateColumns = false;
            dgvHurdaGiris.Visible = false;
            dgvAmbarGiris.Visible = true;
            SidePanel.Height = AmbarG.Height;
            SidePanel.Top = AmbarG.Top;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = true;
            IzinlerGirisi.Visible = false;
            MudurGirisi.Visible = false;
            SirketAraciGiris.Visible = false;
            CiktiAlma.Visible = false;         
            AmbarSaatGirisi.Enabled = false;
            AmbarSaatCikisi.Enabled = false;
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(Mudurgiris);
            Temizle(groupBox2); 
            cmbMudurGiris.Checked = false;
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            ZiyaretSaat.Checked = false;
            cbSirketAraciCikis.Checked = false;
            cbSirketAraciGiris.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            AmbarGirisi.Location = new Point((209 + ((Width - 1087) / 2)), (68 + ((Height - 470) / 2)));
            ListeleAmbar();
            l = 0;
        }

        private void ZiyaretciG_Click(object sender, EventArgs e)
        {
            dgvZiyaretciGirisi.AutoGenerateColumns = false;
            SidePanel.Height = ZiyaretciG.Height;
            SidePanel.Top = ZiyaretciG.Top;
            ZiyaretciGirisi.Visible = true;
            AmbarGirisi.Visible = false;
            IzinlerGirisi.Visible = false;
            MudurGirisi.Visible = false;
            SirketAraciGiris.Visible = false;
            ZiyaretciSaat.Enabled = false;
            ZiyaretciSaatCikis.Enabled = false;
            CiktiAlma.Visible = false;
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(Ambargiris);
            Temizle(Ambarcikis);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(Mudurgiris);
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            Temizle(groupBox2); 
            cmbMudurGiris.Checked = false;
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            cbSirketAraciCikis.Checked = false;
            cbSirketAraciGiris.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            ZiyaretSaat.Checked = false;
            ZiyaretciGirisi.Location = new Point((209 + ((Width - 1113) / 2)), (68 + ((Height - 485) / 2)));

            ListeleZiyaret();
            l = 0;
        }

        private void Izinler_Click(object sender, EventArgs e)
        {
            dgvIzinlerGiris.AutoGenerateColumns = false;
            SidePanel.Height = Izinler.Height;
            SidePanel.Top = Izinler.Top;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = false;
            IzinlerGirisi.Visible = true;
            MudurGirisi.Visible = false;
            SirketAraciGiris.Visible = false;
            CiktiAlma.Visible = false;
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            Temizle(Ambargiris);
            Temizle(Ambarcikis);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(Mudurgiris);
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(groupBox2); 
            IzinSaatCikisi.Enabled = false;
            IzinSaatGirisi.Enabled = false;
            cmbMudurGiris.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            ZiyaretSaat.Checked = false;
            cbSirketAraciCikis.Checked = false;
            cbSirketAraciGiris.Checked = false;
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            IzinlerGirisi.Location = new Point((209 + ((Width - 1141) / 2)), (68 + ((Height - 459) / 2)));
            ListeleIzin();
            l = 0;
        }

        private void Cikti_Click(object sender, EventArgs e)
        {
            dgvCikti.AutoGenerateColumns = false;      
            dgvMudur.AutoGenerateColumns = false;
            dgvAmbar.AutoGenerateColumns = false;
            dgvSirket.AutoGenerateColumns = false;
            dgvHurda.AutoGenerateColumns = false;
            dgvSorguMudur.AutoGenerateColumns = false;
            dgvSorguSirket.AutoGenerateColumns = false;
            dgvSorguAmbar.AutoGenerateColumns = false;
            dgvAmbar.Visible = false;
            dgvMudur.Visible = false;
            dgvCikti.Visible = true;
            SidePanel.Height = Cikti.Height;
            SidePanel.Top = Cikti.Top;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = false;
            IzinlerGirisi.Visible = false;
            SirketAraciGiris.Visible = false;
            MudurGirisi.Visible = false;
            CiktiAlma.Visible = true;
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(Ambargiris);
            Temizle(Ambarcikis);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(Mudurgiris);
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            cmbMudurGiris.Checked = false;
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            ZiyaretSaat.Checked = false;
            SorguFirma.Visible = false;
            cmbSorguPlaka.Visible=false;
            CiktiAlma.Location = new Point((209 + ((Width - 1159) / 2)), (68 + ((Height - 544) / 2)));
            Temizle(CiktiAlma);
            l = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SirketAraciG_Click(object sender, EventArgs e)
        {
            dgvSirketAraci.AutoGenerateColumns = false;

            SidePanel.Height = SirketAraciG.Height;
            SidePanel.Top = SirketAraciG.Top;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = false;
            IzinlerGirisi.Visible = false;
            MudurGirisi.Visible = false;
            CiktiAlma.Visible = false;
            SirketAraciGiris.Visible = true;
            SirketAraciCikisi.Enabled = false;
            SirketAraciGirisi.Enabled = false;
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(Ambargiris);
            Temizle(Ambarcikis);
            Temizle(Mudurgiris);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(groupBox2); 
            cmbMudurGiris.Checked = false;
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            ZiyaretSaat.Checked = false;
            cbSirketAraciCikis.Checked = false;
            cbSirketAraciGiris.Checked = false;            
            SirketAraciGiris.Location = new Point((209 + ((Width - 1099) / 2)), (68 + ((Height - 493) / 2)));
            ListeleSirket();
            l = 0;
        }

        private void MudurG_Click(object sender, EventArgs e)
        {
            SidePanel.Height = MudurG.Height;
            SidePanel.Top = MudurG.Top;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = false;
            IzinlerGirisi.Visible = false;
            MudurGirisi.Visible = true;
            SirketAraciGiris.Visible = false;
            MudurGiriss.Enabled = false;
            CiktiAlma.Visible = false;
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(Ambargiris);
            Temizle(Ambarcikis);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(Mudurgiris);
            Temizle(groupBox2); 
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            cbSirketAraciCikis.Checked = false;
            cbSirketAraciGiris.Checked = false;
            ZiyaretSaat.Checked = false;
            cmbMudurGiris.Checked = false;
            MudurGirisi.Location = new Point((209 + ((Width - 583) / 2)), (68 + ((Height - 271) / 2)));
            l = 0;
        }
        private void ZiyaretciGirisButon_Click(object sender, EventArgs e)
        {
            int flag = 0;

            if (String.IsNullOrEmpty(ZiyaretciAdiSoyadi.Text) || String.IsNullOrEmpty(ZiyaretKisim.Text))
            {
                MessageBox.Show("* İLE GÖSTERİLEN KISIMLARI DOLDURUNUZ!");
                flag++;
            }
            if (flag == 0)
            {
                Ziyaret yeniziyaret = new Ziyaret();

                yeniziyaret.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                yeniziyaret.Adisoyadi = ZiyaretciAdiSoyadi.Text.ToUpper();
                yeniziyaret.Bolum = ZiyaretKisim.Text.ToUpper();
                yeniziyaret.Kartno = ZiyaretciKartID.Text.ToUpper();
                if (ZiyaretSaat.Checked == true)
                {
                    if (ZiyaretciSaat.Text == "")
                        yeniziyaret.Girisaati = DateTime.Now.ToShortTimeString();
                    else
                        yeniziyaret.Girisaati = ZiyaretciSaat.Text;
                }
                else
                {
                    yeniziyaret.Girisaati = DateTime.Now.ToShortTimeString();
                }
                yeniziyaret.Ziyaretsebebi = ZiyaretciSebebi.Text.ToUpper();
                yeniziyaret.Cikisaati = "ÇIKIŞ YAPILMADI";
                MessageBox.Show(yeniziyaret.Giris());
                Sz.Ekle(yeniziyaret);
                ListeleZiyaret();
            }
            flag = 0;
            Temizle(ZiyaretciGiris);
            ZiyaretSaat.Checked = false;
        }
        private void ZiyaretciCikisButon_Click(object sender, EventArgs e)
        {

            DialogResult cevap = MessageBox.Show("Ziyaretçi çıkışı yapılsın mı?", "ZİYARETÇİ ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Ziyaret silinecekkisi = new Ziyaret();
                silinecekkisi = (Ziyaret)dgvZiyaretciGirisi.CurrentRow.DataBoundItem;

                if (ZiyaretSaatCikis.Checked == true)
                {
                    if (ZiyaretciSaatCikis.Text == "")
                        silinecekkisi.Cikisaati = "ÇIKIŞ YAPILMADI";
                    else
                        silinecekkisi.Cikisaati = ZiyaretciSaatCikis.Text;
                }
                else
                {
                    silinecekkisi.Cikisaati = DateTime.Now.ToShortTimeString();
                }
                Sz.Guncelle(silinecekkisi);
                ListeleZiyaret();
            }


            Temizle(ZiyaretciCikis);
            ZiyaretSaatCikis.Checked = false;
            timer1.Enabled = true;



        }
        private void AracCikis_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (String.IsNullOrEmpty(SirketAraciSahibi.Text))
            {
                MessageBox.Show("* İLE GÖSTERİLEN KISIMLARI DOLDURUNUZ!");
                flag++;
            }
            if (flag == 0)
            {
                if (cmbPlaka.Text != "")
                {
                    SirketAraci sirketaracicikis = new SirketAraci();
                    sirketaracicikis.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                    sirketaracicikis.Adisoyadi = SirketAraciSahibi.Text.ToUpper();
                    sirketaracicikis.Plaka = cmbPlaka.SelectedItem.ToString();
                    if (cbSirketAraciCikis.Checked == true)
                    {
                        if (SirketAraciCikisi.Text == "")
                            sirketaracicikis.Cikisaati = DateTime.Now.ToShortTimeString();
                        else
                            sirketaracicikis.Cikisaati = SirketAraciCikisi.Text;
                    }
                    else
                    {
                        sirketaracicikis.Cikisaati = DateTime.Now.ToShortTimeString();
                    }
                    sirketaracicikis.Ekbilgi = SirketAraciBilgi.Text.ToUpper();
                    sirketaracicikis.Girisaati = "GİRİŞ YAPILMADI";


                    MessageBox.Show(sirketaracicikis.Cikis());
                    sirketaracicikis.Cikiskm = Ss.Sorgu(sirketaracicikis).ToString();
                    sirketaracicikis.Giriskm = sirketaracicikis.Cikiskm;
                    Ss.Ekle(sirketaracicikis);
                    ListeleSirket();
                    foreach (Control c in cmbPlaka.Controls)
                    {
                        if (c is ComboBox)
                        {
                            c.Text = "";
                        }
                    }
                }
            }

            flag = 0;
            Temizle(Sirketaracicikis);
            cbSirketAraciCikis.Checked = false;
        }

        private void AmbarGirisiButon_Click(object sender, EventArgs e)
        {
            if(l==0)
            {
                int flag = 0;
                if (String.IsNullOrEmpty(AmbarAdiSoyadi.Text) || String.IsNullOrEmpty(AmbarPlaka.Text) || String.IsNullOrEmpty(AmbarFirmaAdi.Text))
                {
                    MessageBox.Show("* İLE GÖSTERİLEN KISIMLARI DOLDURUNUZ!");
                    flag++;
                }
                if (flag == 0)
                {
                    AmbarAraci yeniaziyaret = new AmbarAraci();
                    yeniaziyaret.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                    yeniaziyaret.Adisoyadi = AmbarAdiSoyadi.Text.ToUpper();
                    yeniaziyaret.Plaka = AmbarPlaka.Text.ToUpper();
                    yeniaziyaret.Ekbilgi = AmbarEkBilgi.Text.ToUpper();
                    yeniaziyaret.Firma = AmbarFirmaAdi.Text.ToUpper();
                    yeniaziyaret.Cikisaati = "ÇIKIŞ YAPILMADI";
                    if (AmbarSaatGiris.Checked == true)
                    {
                        if (AmbarSaatGirisi.Text == "")
                            yeniaziyaret.Girisaati = DateTime.Now.ToShortTimeString();
                        else
                            yeniaziyaret.Girisaati = AmbarSaatGirisi.Text;
                    }
                    else
                    {
                        yeniaziyaret.Girisaati = DateTime.Now.ToShortTimeString();
                    }

                    MessageBox.Show(yeniaziyaret.Giris());
                    Sa.Ekle(yeniaziyaret);
                    ListeleAmbar();
                }
                flag = 0;
                Temizle(Ambargiris);
                AmbarSaatGiris.Checked = false;
            }
            else
            {
                int flag = 0;
                if (String.IsNullOrEmpty(AmbarAdiSoyadi.Text) || String.IsNullOrEmpty(AmbarPlaka.Text) || String.IsNullOrEmpty(AmbarFirmaAdi.Text))
                {
                    MessageBox.Show("* İLE GÖSTERİLEN KISIMLARI DOLDURUNUZ!");
                    flag++;
                }
                if (flag == 0)
                {
                    HurdaAracı yenihaziyaret = new HurdaAracı();
                    yenihaziyaret.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                    yenihaziyaret.Adisoyadi = AmbarAdiSoyadi.Text.ToUpper();
                    yenihaziyaret.Plaka = AmbarPlaka.Text.ToUpper();
                    yenihaziyaret.Ekbilgi = AmbarEkBilgi.Text.ToUpper();
                    yenihaziyaret.Firma = AmbarFirmaAdi.Text.ToUpper();
                    yenihaziyaret.Cikisaati = "ÇIKIŞ YAPILMADI";
                    if (AmbarSaatGiris.Checked == true)
                    {
                        if (AmbarSaatGirisi.Text == "")
                            yenihaziyaret.Girisaati = DateTime.Now.ToShortTimeString();
                        else
                            yenihaziyaret.Girisaati = AmbarSaatGirisi.Text;
                    }
                    else
                    {
                        yenihaziyaret.Girisaati = DateTime.Now.ToShortTimeString();
                    }

                    MessageBox.Show(yenihaziyaret.Giris());
                    Sh.Ekle(yenihaziyaret);
                    ListeleHurda();
                }
                flag = 0;
                Temizle(Ambargiris);
                AmbarSaatGiris.Checked = false;
            }
            
            
        }

        private void AmbarCikisButon_Click(object sender, EventArgs e)
        {
            if (l == 0)
            {
                DialogResult cevap = MessageBox.Show("Araç çıkışı yapılsın mı?", "ARAÇ ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    AmbarAraci silinecekarac = new AmbarAraci();
                    silinecekarac = (AmbarAraci)dgvAmbarGiris.CurrentRow.DataBoundItem;
                    if (AmbarSaatCikis.Checked == true)
                    {
                        if (AmbarSaatCikisi.Text == "")
                            silinecekarac.Cikisaati = "ÇIKIŞ YAPILMADI";
                        else
                            silinecekarac.Cikisaati = AmbarSaatCikisi.Text;
                    }
                    else
                    {
                        silinecekarac.Cikisaati = DateTime.Now.ToShortTimeString();
                    }
                    Sa.Guncelle(silinecekarac);
                    ListeleAmbar();
                }

                Temizle(Ambarcikis);
                AmbarSaatCikis.Checked = false;
                timer1.Enabled = true;

            }
            else
            {
                DialogResult cevap = MessageBox.Show("Araç çıkışı yapılsın mı?", "ARAÇ ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    HurdaAracı silinecekarac = new HurdaAracı();
                    silinecekarac = (HurdaAracı)dgvHurdaGiris.CurrentRow.DataBoundItem;
                    if (AmbarSaatCikis.Checked == true)
                    {
                        if (AmbarSaatCikisi.Text == "")
                            silinecekarac.Cikisaati = "ÇIKIŞ YAPILMADI";
                        else
                            silinecekarac.Cikisaati = AmbarSaatCikisi.Text;
                    }
                    else
                    {
                        silinecekarac.Cikisaati = DateTime.Now.ToShortTimeString();
                    }
                    Sh.Guncelle(silinecekarac);
                    ListeleHurda();
                }

                Temizle(Ambarcikis);
                AmbarSaatCikis.Checked = false;
                timer1.Enabled = true;

            }
        }

        private void IzinlerCikisButon_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (String.IsNullOrEmpty(IzinlerAdiSoyadi.Text))
            {
                MessageBox.Show("* İLE GÖSTERİLEN KISIMLARI DOLDURUNUZ!");
                flag++;
            }
            if (flag == 0)
            {
                if (cmbGorevli.Text != "")
                {
                    Izin yenizin = new Izin();
                    yenizin.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                    yenizin.Adisoyadi = IzinlerAdiSoyadi.Text.ToUpper();
                    yenizin.Ziyaretnedeni = IzinÇıkışSebebi.Text.ToUpper();
                    yenizin.Bolum = cmbGorevli.SelectedItem.ToString();
                    if (IzinliSaatCikis.Checked == true)
                    {
                        if (IzinSaatCikisi.Text == "")
                            yenizin.Girisaati = yenizin.Girisaati = DateTime.Now.ToShortTimeString();
                        else
                            yenizin.Girisaati = IzinSaatCikisi.Text;
                    }
                    else
                    {
                        yenizin.Girisaati = DateTime.Now.ToShortTimeString();
                    }
                    yenizin.Cikisaati = "GİRİŞ YAPILMADI";
                    MessageBox.Show(yenizin.Cikis());
                    Si.Ekle(yenizin);
                    ListeleIzin();
                }
                else
                {
                    DialogResult cevap = MessageBox.Show("Lütfen seçim yapınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            flag = 0;
            IzinliSaatCikis.Checked = false;
            Temizle(Izinlercikis);


        }

        private void IzinlerGirisButon_Click(object sender, EventArgs e)
        {

            DialogResult cevap = MessageBox.Show("İzinli girişi yapılsın mı?", "İZİNLİ GİRİŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                Izin izinlikisi = new Izin();
                izinlikisi = (Izin)dgvIzinlerGiris.CurrentRow.DataBoundItem;
                if (IzinliSaatGiris.Checked == true)
                {
                    if (IzinSaatGirisi.Text == "")
                        izinlikisi.Cikisaati = "GİRİŞ YAPILMADI";
                    else
                        izinlikisi.Cikisaati = IzinSaatGirisi.Text;
                }
                else
                {
                    izinlikisi.Cikisaati = DateTime.Now.ToShortTimeString();
                }
                Si.Guncelle(izinlikisi);
                ListeleIzin();
            }

            Temizle(Izinlergiris);
            IzinliSaatGiris.Checked = false;
            timer1.Enabled = true;
            
        }

        private void ZiyaretciAdiSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void ZiyaretKisim_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void ZiyaretciCikisAdiSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void IzinlerAdiSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void IzinliGirisAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void AmbarAdiSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void SireketAraciKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SireketAraciKmm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void AracGiris_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Araç girişi yapılsın mı?", "ARAÇ GİRİŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SirketAraci sirketaracicikis = new SirketAraci();
                sirketaracicikis = (SirketAraci)dgvSirketAraci.CurrentRow.DataBoundItem;

                if (cbSirketAraciGiris.Checked == true)
                {
                    if (SirketAraciGirisi.Text == "")
                        sirketaracicikis.Girisaati = DateTime.Now.ToShortTimeString();
                    else
                        sirketaracicikis.Girisaati = SirketAraciGirisi.Text;
                }
                else
                {
                    sirketaracicikis.Girisaati = DateTime.Now.ToShortTimeString();
                }
                if (SireketAraciKm.Text == "")
                    sirketaracicikis.Giriskm = sirketaracicikis.Cikiskm;
                else
                    sirketaracicikis.Giriskm = SireketAraciKm.Text;

                Ss.Guncelle(sirketaracicikis);
                ListeleSirket();
            }

            Temizle(Sirketaracigiri);
            cbSirketAraciGiris.Checked = false;
            timer1.Enabled = true;
        }

        private void MudurGirisButon_Click(object sender, EventArgs e)
        {
            Mudur mudurgiris = new Mudur();
            mudurgiris.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
            mudurgiris.Adisoyadi = CmbMudur.SelectedItem.ToString();

            if (0 == Sm.Sorgu(mudurgiris.Tarih, CmbMudur.SelectedItem.ToString()))
            {
                if (cmbMudurGiris.Checked == true)
                {
                    if (MudurGiriss.Text == "")
                        mudurgiris.Girisaati = DateTime.Now.ToShortTimeString();
                    else
                        mudurgiris.Girisaati = MudurGiriss.Text;
                }
                else
                {
                    mudurgiris.Girisaati = DateTime.Now.ToShortTimeString();

                }
                Sm.Ekle(mudurgiris);
                MessageBox.Show(mudurgiris.Giris());
            }
            else
            {
                DialogResult cevap = MessageBox.Show("Girişini yapmak istediğiniz müdürün daha önce girişi yapıldı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbMudurGiris.Checked = false;
            Temizle(Mudurgiris);
        }

        private void ZiyaretSaat_CheckedChanged(object sender, EventArgs e)
        {
            if (ZiyaretSaat.Checked == true)
            {
                ZiyaretciSaat.Enabled = true;               
            }
            else
                ZiyaretciSaat.Enabled = false;
        }

        private void ZiyaretSaatCikis_CheckedChanged(object sender, EventArgs e)
        {
            if (ZiyaretSaatCikis.Checked == true)
            {
                ZiyaretciSaatCikis.Enabled = true;
            }
            else
                ZiyaretciSaatCikis.Enabled = false;
        }

        private void IzinliSaatGiris_CheckedChanged(object sender, EventArgs e)
        {
            if (IzinliSaatGiris.Checked == true)
            {
                IzinSaatGirisi.Enabled = true;
            }
            else
                IzinSaatGirisi.Enabled = false;
        }
        private void IzinliSaatCikis_CheckedChanged(object sender, EventArgs e)
        {
            if (IzinliSaatCikis.Checked == true)
            {
                IzinSaatCikisi.Enabled = true;
            }
            else
                IzinSaatCikisi.Enabled = false;
        }

        private void cmbMudurGiris_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbMudurGiris.Checked == true)
            {
                MudurGiriss.Enabled = true;
            }
            else
                MudurGiriss.Enabled = false;
        }

        private void AmbarSaatGiris_CheckedChanged(object sender, EventArgs e)
        {
            if (AmbarSaatGiris.Checked == true)
            {
                AmbarSaatGirisi.Enabled = true;
            }
            else
                AmbarSaatGirisi.Enabled = false;
        }

        private void AmbarSaatCikis_CheckedChanged(object sender, EventArgs e)
        {
            if (AmbarSaatCikis.Checked == true)
            {
                AmbarSaatCikisi.Enabled = true;
            }
            else
                AmbarSaatCikisi.Enabled = false;
        }

        private void cbSirketAraciCikis_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSirketAraciCikis.Checked == true)
            {
                SirketAraciCikisi.Enabled = true;
            }
            else
                SirketAraciCikisi.Enabled = false;
        }

        private void cbSirketAraciGiris_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSirketAraciGiris.Checked == true)
            {
                SirketAraciGirisi.Enabled = true;
            }
            else
                SirketAraciGirisi.Enabled = false;
        }
        private void CiktiAl_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            Mudur p = new Mudur();

            string[] parcala;

            parcala = (dtpCikti.Value.ToString("dd/MM/yyyy")).Split('.');

            a = parcala[0];
            b = parcala[1];
            c = parcala[2];

            if (cmbSecim.SelectedItem.ToString() == "ZİYARETÇİ/İZİNLİ/GÖREVLİ")
            {
                Listelecikti(a, b, c);
                printer.Title = "ZİYARETÇİ/İZİNLİ/GÖREVLİ GİRİŞ/ÇIKIŞ LİSTESİ";
                printer.SubTitle = string.Format("Tarih: {0}", (dtpCikti.Value.ToString("dd/MM/yyyy")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "AKWEL";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvCikti);
            }
            else if (cmbSecim.SelectedItem.ToString() == "MÜDÜR GİRİŞİ")
            {
                ListeleIzin1(a, b, c);
                int flag = 0;
                for (int i = 0; i < CmbMudur.Items.Count; i++)
                {
                    for (int j = 0; j < dgvMudur.RowCount; j++)
                    {

                        if (dgvMudur.Rows[j].Cells[1].Value.ToString() == CmbMudur.Items[i].ToString())
                        {
                            flag++;
                        }
                    }
                    if (flag == 0)
                    {
                        p.Tarih = DateTime.Now.Date.ToString().TrimEnd('0', ':');
                        p.Adisoyadi = CmbMudur.Items[i].ToString();
                        p.Girisaati = "GİRİŞ YAPILMADI";
                        Sc.Ekle(p);
                    }
                    flag = 0;
                }
                ListeleIzin1(a, b, c);
                printer.Title = "MÜDÜR GİRİŞİ LİSTESİ";
                printer.SubTitle = string.Format("Date: {0}", (dtpCikti.Value.ToString("dd/MM/yyyy")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "AKWEL";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvMudur);
            }
            else if (cmbSecim.SelectedItem.ToString() == "AMBAR ARAÇ GİRİŞİ")
            {
                ListeleIzin2(a, b, c);
                printer.Title = "AMBAR ARAÇ GİRİŞİ LİSTESİ";
                printer.SubTitle = string.Format("Date: {0}", (dtpCikti.Value.ToString("dd/MM/yyyy")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "AKWEL";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvAmbar);
            }
            else if (cmbSecim.SelectedItem.ToString() == "ŞİRKET ARAÇ ÇIKIŞI")
            {
                ListeleIzin3(a, b, c);
                printer.Title = "ŞİRKET ARACI ÇIKIŞI LİSTESİ";
                printer.SubTitle = string.Format("Date: {0}", (dtpCikti.Value.ToString("dd/MM/yyyy")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "AKWEL";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvSirket);
            }
            else if (cmbSecim.SelectedItem.ToString() == "HURDA ARAÇ GİRİŞİ")
            {
                ListeleIzin7(a, b, c);
                printer.Title = "HURDA ARAÇ GİRİŞİ LİSTESİ";
                printer.SubTitle = string.Format("Date: {0}", (dtpCikti.Value.ToString("dd/MM/yyyy")));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "AKWEL";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dgvHurda);
            }

        }

        private void cmbSecim_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (cmbSecim.SelectedItem.ToString() == "ZİYARETÇİ/İZİNLİ/GÖREVLİ")
            {                        
                dgvCikti.Visible = true;
                dgvAmbar.Visible = false;
                dgvMudur.Visible = false;
                dgvSirket.Visible = false;
                dgvHurda.Visible = false;
            }
            else if (cmbSecim.SelectedItem.ToString() == "MÜDÜR GİRİŞİ")
            {           
                dgvMudur.Visible = true;
                dgvAmbar.Visible = false;
                dgvCikti.Visible = false;
                dgvSirket.Visible = false;
                dgvHurda.Visible = false;
            }
            else if (cmbSecim.SelectedItem.ToString() == "AMBAR ARAÇ GİRİŞİ")
            {                
                dgvAmbar.Visible = true;
                dgvMudur.Visible = false;
                dgvCikti.Visible = false;
                dgvSirket.Visible = false;
                dgvHurda.Visible = false;
            }
            else if (cmbSecim.SelectedItem.ToString() == "ŞİRKET ARAÇ ÇIKIŞI")
            {                
                dgvAmbar.Visible = false;
                dgvMudur.Visible = false;
                dgvCikti.Visible = false;
                dgvSirket.Visible = true;
                dgvHurda.Visible = false;
            }
            else if (cmbSecim.SelectedItem.ToString() == "HURDA ARAÇ GİRİŞİ")
            {
                dgvAmbar.Visible = false;
                dgvMudur.Visible = false;
                dgvCikti.Visible = false;
                dgvSirket.Visible = false;
                dgvHurda.Visible = true;
            }
        }

        private void PlakaSorgu_Click(object sender, EventArgs e)
        {
            if (cmbSorgu.SelectedItem.ToString() == "AMBAR ARACI SORGU")
            {
                string[] parcala;

                parcala = (dtpSorgu.Value.ToString("dd/MM/yyyy")).Split('.');
                a = parcala[0];
                b = parcala[1];
                c = parcala[2];
                string firma = SorguFirma.Text.ToUpper();
                ListeleIzin4(a, b, c, firma);

            }
            if (cmbSorgu.SelectedItem.ToString() == "ŞİRKET ARACI SORGU")
            {
                string[] parcala;

                parcala = (dtpSorgu.Value.ToString("dd/MM/yyyy")).Split('.');

                a = parcala[0];
                b = parcala[1];
                c = parcala[2];

                string plaka = cmbSorguPlaka.SelectedItem.ToString();
                ListeleIzin5(a, b, c, plaka);
                Temizle(groupBox2);
            }
            if (cmbSorgu.SelectedItem.ToString() == "MÜDÜR GİRİŞ SORGU")
            {
                string[] parcala;

                parcala = (dtpSorgu.Value.ToString("dd/MM/yyyy")).Split('.');

                a = parcala[0];
                b = parcala[1];
                c = parcala[2];

                ListeleIzin6(a, b, c);
                Temizle(groupBox2);
            }
        }

        private void cmbSorgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSorgu.SelectedItem.ToString() == "AMBAR ARACI SORGU")
            {
                cmbSorguPlaka.Visible = false;
                SorguFirma.Visible = true;
                dgvSorguAmbar.Visible = true;
                dgvSorguSirket.Visible = false;
                dgvSorguMudur.Visible = false;
                label60.Visible = true;
                label60.Text = "FİRMA ADI:";
                Temizle(groupBox2); 
            }
            else if (cmbSorgu.SelectedItem.ToString() == "ŞİRKET ARACI SORGU")
            {
                SorguFirma.Visible = false;
                cmbSorguPlaka.Visible = true;
                dgvSorguAmbar.Visible = false;
                dgvSorguSirket.Visible = true;
                dgvSorguMudur.Visible = false;
                label60.Visible = true;
                label60.Text = "PLAKA:";
                Temizle(groupBox2); 
            }
            else if (cmbSorgu.SelectedItem.ToString() == "MÜDÜR GİRİŞ SORGU")
            {
                SorguFirma.Visible = false;
                cmbSorguPlaka.Visible = false;
                dgvSorguAmbar.Visible = false;
                dgvSorguSirket.Visible = false;
                label60.Visible = false;
                dgvSorguMudur.Visible = true;
                Temizle(groupBox2);
            }

        }

        private void TusaBasinca(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Up)
                SendKeys.Send("+{TAB}");
        }

        private void ziyaretcikayitsil_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "KAYIT SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Ziyaret silinecekkisi = new Ziyaret();
                silinecekkisi = (Ziyaret)dgvZiyaretciGirisi.CurrentRow.DataBoundItem;
                Sz.Sil(silinecekkisi);
                ListeleZiyaret();
            }
            timer1.Enabled = true;
        }

        private void izinlikayitsil_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "KAYIT SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Izin silinecekkisi = new Izin();
                silinecekkisi = (Izin)dgvIzinlerGiris.CurrentRow.DataBoundItem;
                Si.Sil(silinecekkisi);
                ListeleIzin();
            }
            timer1.Enabled = true;
        }

        private void sirketaracisill_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "KAYIT SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SirketAraci silinecekkisi = new SirketAraci();
                silinecekkisi = (SirketAraci)dgvSirketAraci.CurrentRow.DataBoundItem;
                Ss.Sil(silinecekkisi);
                ListeleSirket();
            }
            timer1.Enabled = true;
        }

        private void ambararacisil_Click(object sender, EventArgs e)
        {
            if(l==0)
            { 
                DialogResult cevap = MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "KAYIT SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    AmbarAraci silinecekkisi = new AmbarAraci();
                    silinecekkisi = (AmbarAraci)dgvAmbarGiris.CurrentRow.DataBoundItem;
                    Sa.Sil(silinecekkisi);
                    ListeleAmbar();
                }
                timer1.Enabled = true;
            }
            else
            {
                DialogResult cevap = MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "KAYIT SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    HurdaAracı silinecekkisi = new HurdaAracı();
                    silinecekkisi = (HurdaAracı)dgvHurdaGiris.CurrentRow.DataBoundItem;
                    Sh.Sil(silinecekkisi);
                    ListeleHurda();
                }
                timer1.Enabled = true;
            }
        }

        private void RenkDegistir(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.FromArgb(94, 136, 158);
        }

        private void NormalRenk(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.BackColor = Color.Empty;
        }

        private void sadecesayivenokta(object sender, KeyPressEventArgs e)
        {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ':';         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListeleZiyaret();
            ListeleSirket();
            ListeleAmbar();
            ListeleIzin();
            ListeleHurda();
        }

        private void timerdurar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void HurdaG_Click(object sender, EventArgs e)
        {
            dgvHurdaGiris.AutoGenerateColumns = false;
            dgvAmbarGiris.Visible = false;
            dgvHurdaGiris.Visible = true;
            SidePanel.Height = HurdaG.Height;
            SidePanel.Top = HurdaG.Top;
            ZiyaretciGirisi.Visible = false;
            AmbarGirisi.Visible = true;
            IzinlerGirisi.Visible = false;
            MudurGirisi.Visible = false;
            SirketAraciGiris.Visible = false;
            CiktiAlma.Visible = false;
            AmbarSaatGirisi.Enabled = false;
            AmbarSaatCikisi.Enabled = false;
            Temizle(ZiyaretciGiris);
            Temizle(ZiyaretciCikis);
            Temizle(Izinlercikis);
            Temizle(Izinlergiris);
            Temizle(Sirketaracicikis);
            Temizle(Sirketaracigiri);
            Temizle(Mudurgiris);
            Temizle(groupBox2);
            cmbMudurGiris.Checked = false;
            IzinliSaatGiris.Checked = false;
            IzinliSaatCikis.Checked = false;
            ZiyaretSaatCikis.Checked = false;
            ZiyaretSaat.Checked = false;
            cbSirketAraciCikis.Checked = false;
            cbSirketAraciGiris.Checked = false;
            AmbarSaatCikis.Checked = false;
            AmbarSaatGiris.Checked = false;
            AmbarGirisi.Location = new Point((209 + ((Width - 1087) / 2)), (68 + ((Height - 470) / 2)));
            ListeleHurda();
            l = 1;
        }
    }
}
    