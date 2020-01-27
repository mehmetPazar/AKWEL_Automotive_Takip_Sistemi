using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje1
{
    class SqlHurda
    {
        SqlConnection con;
        SqlCommand cmd;

        public SqlHurda()
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
        public List<HurdaAracı> Listele()
        {
            try
            {
                List<HurdaAracı> HurdaAraciListesi = new List<HurdaAracı>();
                cmd.CommandText = "SELECT * FROM Hurda WHERE Cikisaati ='ÇIKIŞ YAPILMADI' ";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HurdaAracı m = new HurdaAracı();
                    m.ID = Convert.ToInt32(reader[0]);
                    m.Tarih = reader[1].ToString();
                    m.Adisoyadi = reader[2].ToString();
                    m.Plaka = reader[3].ToString();
                    m.Ekbilgi = reader[4].ToString();
                    m.Girisaati = reader[5].ToString();
                    m.Cikisaati = reader[6].ToString();
                    m.Firma = reader[7].ToString();
                    HurdaAraciListesi.Add(m);
                }

                return HurdaAraciListesi;
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

        public void Ekle(HurdaAracı m)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Hurda (Tarih,Adisoyadi,Plaka,Ekbilgi,Girisaati,Firma,Cikisaati) VALUES('" + m.Tarih + "','" + m.Adisoyadi + "','" + m.Plaka + "','" + m.Ekbilgi + "','" + m.Girisaati + "','" + m.Firma + "','" + m.Cikisaati + "')";
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

        public void Guncelle(HurdaAracı m)
        {
            try
            {
                cmd.CommandText = "Update Hurda SET Cikisaati='" + m.Cikisaati + "' Where Tarih='" + m.Tarih + "'and Adisoyadi='" + m.Adisoyadi + "' and Plaka='" + m.Plaka + "' and Girisaati='" + m.Girisaati + "'and Firma='" + m.Firma + "'and ID='" + m.ID + "'and Cikisaati='ÇIKIŞ YAPILMADI'";
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

        public void Sil(HurdaAracı m)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Hurda WHERE ID='" + m.ID + "'";
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
