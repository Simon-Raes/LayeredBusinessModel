using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using LayeredBusinessModel.Domain;
using System.Configuration;

namespace LayeredBusinessModel.DAO
{
    public class BierDAO
    {
        private string strSQL;
        //ga naar web.config . haal de connectionstring "beerconnection" .  
        private string sDatabaseLocatie = ConfigurationManager.ConnectionStrings["BeerConnection"].ConnectionString;
        private SqlConnection cnn;

        public List<Beer> getAllBeer()
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            List<Beer> beerList = new List<Beer>();

            SqlCommand command = new SqlCommand("SELECT * FROM bieren", cnn);
            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    beerList.Add(CreateBeer(reader));
                }

                reader.Close();
                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }
            return beerList;
        }

        public List<Beer> getAllBeerBasics()
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            List<Beer> beerList = new List<Beer>();

            SqlCommand command = new SqlCommand("SELECT biernr, naam, alcohol FROM bieren", cnn);
            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    beerList.Add(CreateBeerBasic(reader));
                }

                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }
            return beerList;
        }

        public Beer getBeerWithID(String beerID)
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            Beer beer = new Beer();

            SqlCommand command = new SqlCommand("SELECT * FROM bieren WHERE biernr = "+beerID, cnn);
            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    beer = CreateBeer(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }
            return beer;
        }


        public List<Beer> getBeersForBrewer(String brouwernr)
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            List<Beer> beerList = new List<Beer>();

            SqlParameter param = new SqlParameter("@brouwernr", brouwernr);
            strSQL = "SELECT * FROM bieren where brouwernr = @brouwernr;";
            SqlCommand command = new SqlCommand(strSQL, cnn);
            command.Parameters.AddWithValue("@brouwernr", brouwernr);

            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    beerList.Add(CreateBeer(reader));
                }

                reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }
            return beerList;
        }


        private Beer CreateBeer(SqlDataReader reader)
        {
            //gebruik van object initializer ipv constructor
            Beer beer = new Beer
            {
                beernr = Convert.ToInt32(reader["biernr"]),
                naam = Convert.ToString(reader["naam"]),
                brouwernr = Convert.ToInt32(reader["brouwernr"]),
                soortnr = Convert.ToInt32(reader["soortnr"]),
                alcohol = reader["alcohol"] == DBNull.Value ? 0 : Convert.ToInt32(reader["alcohol"])
            };
            return beer;
        }

        private Beer CreateBeerBasic(SqlDataReader reader)
        {
            //gebruik van object initializer ipv constructor
            Beer beer = new Beer
            {
                beernr = Convert.ToInt32(reader["biernr"]),
                naam = Convert.ToString(reader["naam"]),
                alcohol = reader["alcohol"] == DBNull.Value ? 0 : Convert.ToInt32(reader["alcohol"])
            };
            return beer;
        }

        

    }


}
