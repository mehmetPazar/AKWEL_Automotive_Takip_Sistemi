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
    class SqlAmbar
    {
        SqlConnection con;
        SqlCommand cmd;

        public SqlAmbar()
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
        public List<AmbarAraci> Listele()
        {
            try
            {
                List<AmbarAraci> AmbarAraciListesi = new List<AmbarAraci>();
                cmd.CommandText = "SELECT * FROM Ambar WHERE Cikisaati ='ÇIKIŞ YAPILMADI' ";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AmbarAraci m = new AmbarAraci();
                    m.ID = Convert.ToInt32(reader[0]);
                    m.Tarih = reader[1].ToString();
                    m.Adisoyadi = reader[2].ToString();
                    m.Plaka = reader[3].ToString();
                    m.Ekbilgi = reader[4].ToString();
                    m.Girisaati = reader[5].ToString();
                    m.Cikisaati = reader[6].ToString();
                    m.Firma = reader[7].ToString();
                    AmbarAraciListesi.Add(m);
                }

                return AmbarAraciListesi;
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
        public void Ekle(AmbarAraci m)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Ambar (Tarih,Adisoyadi,Plaka,Ekbilgi,Girisaati,Firma,Cikisaati) VALUES('" + m.Tarih + "','" + m.Adisoyadi + "','" + m.Plaka + "','" + m.Ekbilgi + "','" + m.Girisaati + "','" + m.Firma + "','" + m.Cikisaati + "')";
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
        public void Guncelle(AmbarAraci m)
        {
            try
            {
                cmd.CommandText = "Update Ambar SET Cikisaati='" + m.Cikisaati + "' Where Tarih='" + m.Tarih + "'and Adisoyadi='" + m.Adisoyadi + "' and Plaka='" + m.Plaka + "' and Girisaati='" + m.Girisaati + "'and Firma='" + m.Firma + "'and ID='" + m.ID + "'and Cikisaati='ÇIKIŞ YAPILMADI'";
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

        public void Sil(AmbarAraci m)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Ambar WHERE ID='" + m.ID + "'";
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
