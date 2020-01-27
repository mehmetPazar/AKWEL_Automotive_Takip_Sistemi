using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje1
{
    public class SirketAraci :IaracZiyareti
    {
        private string tarih;
        private string adisoyadi;
        private string ekbilgi;
        private string plaka;
        private string girisaati;
        private string cikisaati;
        private string giriskm;
        private string cikiskm;
        private int id;
        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }
        public string Adisoyadi
        {
            get { return adisoyadi; }
            set { adisoyadi = value; }
        }
        public string Ekbilgi
        {
            get { return ekbilgi; }
            set { ekbilgi = value; }
        }
        public string Plaka
        {
            get { return plaka; }
            set { plaka = value; }
        }
        public string Girisaati
        {
            get { return girisaati; }
            set { girisaati = value; }
        }
        public string Cikisaati
        {
            get { return cikisaati; }
            set { cikisaati = value; }
        }
        public string Giriskm
        {
            get { return giriskm; }
            set { giriskm = value; }
        }
        public string Cikiskm
        {
            get { return cikiskm; }
            set { cikiskm = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Giris()
        {
            return Plaka + " plakalı araç " + Tarih + " " + Girisaati + "'de giriş yaptı.";
        }
        public string Cikis()
        {
            return Plaka + " plakalı araç " + Tarih + " " + Cikisaati + "'de çıkış yaptı.";
        }
    }
}
