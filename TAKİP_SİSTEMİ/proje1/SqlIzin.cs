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
    class SqlIzin
    {
        SqlConnection con;
        SqlCommand cmd;

        public SqlIzin()
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

        public List<Izin> Listele()
        {

            try
            {
                List<Izin> Izinlilistesi = new List<Izin>();

                cmd.CommandText = "SELECT * from Izinli where Convert(INT,SUBSTRING(Tarih,1,2))=DAY(GETDATE()) and Convert(INT,SUBSTRING(Tarih,4,2))=MONTH(GETDATE()) and Convert(INT,SUBSTRING(Tarih,7,5))=YEAR(GETDATE()) and Cikisaati='GİRİŞ YAPILMADI'  union SELECT * from Izinli where Convert(INT,SUBSTRING(Tarih,1,2))=Convert(INT,SUBSTRING(Convert(varchar,GETDATE()-1,112),7,2)) and Convert(INT,SUBSTRING(Tarih,4,2))=Convert(INT,SUBSTRING(Convert(varchar,GETDATE()-1,112),5,2)) and Convert(INT,SUBSTRING(Tarih,7,5))=Convert(INT,SUBSTRING(Convert(varchar,GETDATE()-1,112),1,4)) and Cikisaati='GİRİŞ YAPILMADI'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Izin t = new Izin();
                    t.ID = Convert.ToInt32(reader[0]);
                    t.Tarih = reader[1].ToString();
                    t.Adisoyadi = reader[2].ToString();
                    t.Bolum = reader[3].ToString();
                    t.Kartno = reader[5].ToString();
                    t.Ziyaretnedeni = reader[4].ToString();
                    t.Girisaati = reader[6].ToString();
                    t.Cikisaati = reader[7].ToString();
                    Izinlilistesi.Add(t);
                }

                return Izinlilistesi;
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
        public void Ekle(Izin t)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Izinli (Tarih,Adisoyadi,Bolum,Kartno,Girisaati,Ziyaretnedeni,Cikisaati) VALUES('" + t.Tarih + "','" + t.Adisoyadi + "','" + t.Bolum + "','" + t.Kartno + "','" + t.Girisaati + "','" + t.Ziyaretnedeni + "','" + t.Cikisaati + "')";
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
        public void Guncelle(Izin t)
        {
            try
            {
                cmd.CommandText = "Update Izinli SET Cikisaati='" + t.Cikisaati + "' Where Adisoyadi='" + t.Adisoyadi + "' and Bolum='" + t.Bolum + "' and Tarih='" + t.Tarih + "'and Girisaati='" + t.Girisaati + "'and ID='" + t.ID + "'and Cikisaati='GİRİŞ YAPILMADI'";
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

        public void Sil(Izin t)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Izinli WHERE ID='" + t.ID + "'";
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
