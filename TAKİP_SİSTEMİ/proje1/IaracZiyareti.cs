using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1
{
    public interface IaracZiyareti
    {
        string Tarih { get; set; }
        string Adisoyadi { get; set; }
        string Ekbilgi { get; set; }
        string Plaka { get; set; }
        string Girisaati { get; set; }
        string Cikisaati { get; set; }
        int ID { get; set; }

        string Giris();
        string Cikis();
    }
}
