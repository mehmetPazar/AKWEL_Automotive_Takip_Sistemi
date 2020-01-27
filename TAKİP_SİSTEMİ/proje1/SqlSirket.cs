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
    class SqlSirket
    {
        SqlConnection con;
        SqlCommand cmd;

        public SqlSirket()
        {
            Baglan();
        }
        public void Baglan()
        {
            try
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=ZiyaretciTakipS;Integrated Security=True");
                cmd = new SqlCommand();
                cmd.Connection = con;
            }
            catch (Exception e)
            {
                
                MessageBox.Show(e.Message);
            }
            
        }
        public List<SirketAraci> Listele()
        {

            try
            {
                List<SirketAraci> SirketAraciListesi = new List<SirketAraci>();
                cmd.CommandText = "SELECT * FROM Sirket WHERE Girisaati= 'GİRİŞ YAPILMADI'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SirketAraci s = new SirketAraci();
                    s.ID = Convert.ToInt32(reader[0]);
                    s.Tarih = reader[1].ToString();
                    s.Adisoyadi = reader[2].ToString();
                    s.Plaka = reader[3].ToString();
                    s.Ekbilgi= reader[4].ToString();
                    s.Cikisaati = reader[5].ToString();
                    s.Girisaati = reader[6].ToString();
                    s.Giriskm = reader[7].ToString();
                    s.Cikiskm = reader[8].ToString();
                    
                    SirketAraciListesi.Add(s);
                }

                return SirketAraciListesi;
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
        public void Ekle(SirketAraci s)
        {
            try
            {

                cmd.CommandText = "INSERT INTO Sirket (Tarih,Adisoyadi,Plaka,Istikamet,Cikisaati,Girisaati,Cikiskm,Giriskm) VALUES('" + s.Tarih + "','" + s.Adisoyadi + "','" + s.Plaka + "','" + s.Ekbilgi + "','" + s.Cikisaati + "','" + s.Girisaati + "','" + s.Cikiskm + "','" + s.Giriskm + "')";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        public void Guncelle(SirketAraci s)
        {
            try
            {
                cmd.CommandText = "Update Sirket SET Girisaati='" + s.Girisaati + "',Giriskm='" + s.Giriskm + "' Where ID='" + s.ID + "'and Tarih='" + s.Tarih + "'and Adisoyadi='" + s.Adisoyadi + "' and Plaka='" + s.Plaka + "' and Istikamet='" + s.Ekbilgi + "'and Cikisaati='" + s.Cikisaati + "'and Girisaati='GİRİŞ YAPILMADI'";
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
        public int Sorgu(SirketAraci s)
        {
            int k=0;
            try
            {
                cmd.CommandText = "Select Plaka, Giriskm From Sirket Where ID IN(select TOP 1 Max(ID) from Sirket where Plaka = '" + s.Plaka + "')  group by Plaka,Giriskm";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   k = Convert.ToInt32(reader[1]);
                    
                }

                return k;
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

        public void Sil(SirketAraci s)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Sirket WHERE ID='" + s.ID + "'";
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

    }
}
