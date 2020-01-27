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
    class SqlMudur
    {
        SqlConnection con;
        SqlCommand cmd;

        public SqlMudur()
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
        public void Ekle(Mudur p)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Mudur (Tarih,Adisoyadi,Girisaati) VALUES('" + p.Tarih + "','" + p.Adisoyadi + "','" + p.Girisaati+"')";
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
        public int Sorgu(string m,string l)
        {
            int k=0;
            try
            {
                cmd.CommandText = "select count(*) from mudur where Tarih='"+ m +"' and Adisoyadi='"+l+"'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   k = Convert.ToInt32(reader[0]);
                    
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


    }
}
