using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje1
{
    public class Ziyaret : IzinZiyaret
    {
        private string tarih;
        private string adisoyadi;
        private string bolum;
        private string kartno;
        private string girisaati;
        private string cikisaati;
        private string ziyaretsebebi;
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
        public string Bolum
        {
            get { return bolum; }
            set { bolum = value; }
        }
        public string Kartno
        {
            get { return kartno; }
            set { kartno = value; }
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
        public string Ziyaretsebebi
        {
            get { return ziyaretsebebi; }
            set { ziyaretsebebi = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Cikis()
        {
            return Adisoyadi + "  " + tarih + " " + Cikisaati + "'de çıkış yaptı.";
        }
        public string Giris()
        {
            return Adisoyadi + "  " + tarih + " " + Girisaati + "'de giriş yaptı.";
        }
    }
}
