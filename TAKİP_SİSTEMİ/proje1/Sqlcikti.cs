using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace proje1
{
    class Sqlcikti
    {
        SqlConnection con;
        SqlCommand cmd;

        public Sqlcikti()
        {
            Baglan();
        }
        public void Baglan()
        {
            try
            {
                //con = new SqlConnection("Data Source=10.22.7.241,1433;Network Library=DBMSSOCN;Initial Catalog=ZiyaretciTakipS;User Id=userr;Password=12345");
                con = new SqlConnection("Data Source=.;Initial Catalog=ZiyaretciTakipS;Integrated Security=True");
                cmd = new SqlCommand();
                cmd.Connection = con;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        public List<Ziyaret> Listele(string a,string b,string c)
        {

            try
            {
                List<Ziyaret> ZiyaretCikti = new List<Ziyaret>();
                cmd.CommandText = "select* from ziyaretcizinlif('" + a + "','"+ b + "','"+ c + "') Order by Convert(INT,REPLACE(GİRİSAATİ,':','0')) asc";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ziyaret s = new Ziyaret();
                    
                    s.Tarih = reader[0].ToString();
                    s.Kartno = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Bolum = reader[3].ToString();
                    s.Ziyaretsebebi = reader[4].ToString();
                    s.Girisaati = reader[5].ToString();
                    s.Cikisaati = reader[6].ToString();


                    ZiyaretCikti.Add(s);
                }

                return ZiyaretCikti;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public List<Mudur> Listele1(string a, string b, string c)
        {

            try
            {
                List<Mudur> Mudurcikti = new List<Mudur>();
                cmd.CommandText = "select* from müdürf('" + a + "','" + b + "','" + c + "')";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mudur s = new Mudur();

                        s.Tarih = reader[0].ToString();
                        s.Adisoyadi = reader[1].ToString();
                        s.Girisaati = reader[2].ToString();
                        Mudurcikti.Add(s);

                }

                return Mudurcikti;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public List<AmbarAraci> Listele2(string a, string b, string c)
        {

            try
            {
                List<AmbarAraci> Ambarcikti = new List<AmbarAraci>();
                cmd.CommandText = "select* from ambarcikisf('" + a + "','" + b + "','" + c + "') Order by Convert(INT,REPLACE(GİRİŞSAATI,':','0')) asc";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AmbarAraci s = new AmbarAraci();

                    s.Tarih = reader[0].ToString();
                    s.Plaka = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Firma = reader[3].ToString();
                    s.Ekbilgi = reader[4].ToString();
                    s.Girisaati = reader[5].ToString();
                    s.Cikisaati = reader[6].ToString();
                    Ambarcikti.Add(s);

                }

                return Ambarcikti;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public void Ekle(Mudur p)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Mudur (Tarih,Adisoyadi,Girisaati) VALUES('" + p.Tarih + "','" + p.Adisoyadi + "','" + p.Girisaati + "')";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        public List<SirketAraci> Listele3(string a, string b, string c)
        {

            try
            {
                List<SirketAraci> Sirketaracicikti = new List<SirketAraci>();
                cmd.CommandText = "select* from sirketaracif('" + a + "','" + b + "','" + c + "') Order by Convert(INT,REPLACE(CIKISAATİ,':','0')) asc";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SirketAraci s = new SirketAraci();

                    s.Tarih = reader[0].ToString();
                    s.Plaka = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Ekbilgi = reader[3].ToString();
                    s.Cikisaati = reader[4].ToString();
                    s.Cikiskm = reader[5].ToString();
                    s.Girisaati = reader[6].ToString();
                    s.Giriskm = reader[7].ToString();
                    Sirketaracicikti.Add(s);

                }

                return Sirketaracicikti;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<AmbarAraci> Listele4(string a, string b, string c ,string firma)
        {

            try
            {
                List<AmbarAraci> Ambararacisorgu = new List<AmbarAraci>();
                cmd.CommandText = "select * from ambarplakas('" + a + "','" + b + "','" + c + "','" + firma + "') Order by Convert(INT,REPLACE(GİRİŞSAATI,':','0')) asc";                
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AmbarAraci s = new AmbarAraci();

                    s.Tarih = reader[0].ToString();
                    s.Plaka = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Ekbilgi = reader[4].ToString();
                    s.Firma = reader[3].ToString();
                    s.Girisaati = reader[5].ToString();
                    s.Cikisaati = reader[6].ToString();
                    Ambararacisorgu.Add(s);

                }

                return Ambararacisorgu;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public List<SirketAraci> Listele5(string a, string b, string c, string plaka)
        {

            try
            {
                List<SirketAraci> Sirketaracisorgu = new List<SirketAraci>();
                cmd.CommandText = "select * from sirketplakas('" + a + "','" + b + "','" + c + "','" + plaka + "') Order by Convert(INT,REPLACE(CIKISAATİ,':','0')) asc";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SirketAraci s = new SirketAraci();

                    s.Tarih = reader[0].ToString();
                    s.Plaka = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Ekbilgi = reader[3].ToString();
                    s.Cikisaati = reader[4].ToString();
                    s.Cikiskm = reader[5].ToString();
                    s.Girisaati = reader[6].ToString();
                    s.Giriskm = reader[7].ToString();
                    Sirketaracisorgu.Add(s);

                }

                return Sirketaracisorgu;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<Mudur> Listele6(string a, string b, string c)
        {

            try
            {
                List<Mudur> Mudursorgu = new List<Mudur>();
                cmd.CommandText = "select * from mudurs('" + a + "','" + b + "','" + c + "')";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mudur s = new Mudur();

                    s.Tarih = reader[0].ToString();
                    s.Adisoyadi = reader[1].ToString();
                    s.Girisaati = reader[2].ToString();               
                    Mudursorgu.Add(s);

                }

                return Mudursorgu;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public ComboBox Listele7(ComboBox c)
        {

            try
            {
                
                cmd.CommandText = "SELECT * FROM Mudurler";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.Items.Add(reader["AdiSoyadi"]);

                }

                return c;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public ComboBox Listele8(ComboBox c)
        {

            try
            {

                cmd.CommandText = "SELECT * FROM Araclar";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.Items.Add(reader["Plaka"]);

                }

                return c;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public ComboBox Listele9(ComboBox c)
        {

            try
            {

                cmd.CommandText = "SELECT * FROM Araclar";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.Items.Add(reader["Plaka"]);

                }

                return c;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<HurdaAracı> Listele10(string a, string b, string c)
        {

            try
            {
                List<HurdaAracı> Hurdacikti = new List<HurdaAracı>();
                cmd.CommandText = "select* from hurdacikisf('" + a + "','" + b + "','" + c + "') Order by Convert(INT,REPLACE(GİRİŞSAATI,':','0')) asc";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HurdaAracı s = new HurdaAracı();

                    s.Tarih = reader[0].ToString();
                    s.Plaka = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Firma = reader[3].ToString();
                    s.Ekbilgi = reader[4].ToString();
                    s.Girisaati = reader[5].ToString();
                    s.Cikisaati = reader[6].ToString();
                    Hurdacikti.Add(s);

                }

                return Hurdacikti;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

    }

}
