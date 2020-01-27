using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje1
{
    class Mudur
    {
        private string tarih;
        private string adisoyadi;
        private string girisaati;
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
        public string Girisaati
        {
            get { return girisaati; }
            set { girisaati = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Giris()
        {
            return Adisoyadi +" "+Girisaati+ " giriş yaptı.";
        }
    }
}
