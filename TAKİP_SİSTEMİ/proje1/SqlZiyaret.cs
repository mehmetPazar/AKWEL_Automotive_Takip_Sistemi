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
    class SqlZiyaret
    {

        SqlConnection con;
        SqlCommand cmd;

        public SqlZiyaret()
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
        public List<Ziyaret> Listele()
        {
           
            try 
            {
                List<Ziyaret> ZiyaretListesi = new List<Ziyaret>();
                cmd.CommandText = "SELECT * from Ziyaretci where Cikisaati = 'ÇIKIŞ YAPILMADI'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Ziyaret k = new Ziyaret();
                    k.ID = Convert.ToInt32(reader[0]);
                    k.Tarih = reader[1].ToString();
                    k.Adisoyadi = reader[2].ToString();
                    k.Bolum = reader[3].ToString();
                    k.Ziyaretsebebi = reader[4].ToString();
                    k.Kartno = reader[5].ToString();
                    k.Girisaati = reader[6].ToString();
                    k.Cikisaati = reader[7].ToString();
                    ZiyaretListesi.Add(k);
                }

                return ZiyaretListesi;
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
        public void Ekle(Ziyaret k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Ziyaretci (Tarih,Adisoyadi,Bolum,Ziyaretnedeni,Kartno,Girisaati,Cikisaati) VALUES('" + k.Tarih + "','" + k.Adisoyadi + "','" + k.Bolum + "','" + k.Ziyaretsebebi + "','" + k.Kartno + "','" + k.Girisaati + "','" + k.Cikisaati + "')";
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
        public void Guncelle(Ziyaret k)
        {
            try
            {
                cmd.CommandText = "Update Ziyaretci SET Cikisaati='" + k.Cikisaati + "' Where Adisoyadi='" + k.Adisoyadi + "' and Bolum='" + k.Bolum + "' and Kartno='" + k.Kartno + "'and Girisaati='" + k.Girisaati + "'and ID='" + k.ID + "'and Cikisaati='ÇIKIŞ YAPILMADI'";
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
        public void Sil(Ziyaret k)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Ziyaretci WHERE ID='" + k.ID + "'";
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
