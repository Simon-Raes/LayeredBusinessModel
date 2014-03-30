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
    public class BrewerDAO
    {

        private string strSQL;
        //ga naar web.config . haal de connectionstring "beerconnection" .  
        private string sDatabaseLocatie = ConfigurationManager.ConnectionStrings["BeerConnection"].ConnectionString;
        private SqlConnection cnn;

        public List<Brewer> getAllBrewers()
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            List<Brewer> brewerList = new List<Brewer>();

            SqlCommand command = new SqlCommand("SELECT * FROM brouwers", cnn);

            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    brewerList.Add(CreateBrewer(reader));
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
            return brewerList;
        }

        //gets only the basic info for display in dropdownlist
        public List<Brewer> getAllBrewersBasics()
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            List<Brewer> brewerList = new List<Brewer>();

            //enkel deze 2 kolommen nodig
            SqlCommand command = new SqlCommand("SELECT brouwernr, naam FROM brouwers", cnn);

            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    brewerList.Add(CreateBrewerBasic(reader));
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
            return brewerList;
        }

        public Brewer getBrewerWithID(String ID)
        {
            cnn = new SqlConnection(sDatabaseLocatie);
            Brewer brewer = null;

            SqlCommand command = new SqlCommand("SELECT * FROM brouwers WHERE brouwernr = @brouwernr", cnn);
            command.Parameters.Add(new SqlParameter("@brouwernr", ID));
            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    brewer = CreateBrewer(reader);
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
            return brewer;
        }

        public void updateBrewer(Brewer brewer)
        {
            cnn = new SqlConnection(sDatabaseLocatie);            

            SqlCommand command = new SqlCommand(
                "UPDATE Brouwers " +
                "SET naam = @naam, " +
                "adres = @adres, " +
                "postcode = @postcode, " +
                "gemeente = @gemeente, " +
                "omzet = @omzet, " +
                "longitude = @longitude, " +
                "latitude = @latitude " +
                "WHERE brouwernr = @brouwernr" , cnn);

            command.Parameters.Add(new SqlParameter("@naam", brewer.naam));
            command.Parameters.Add(new SqlParameter("@adres", brewer.adres));
            command.Parameters.Add(new SqlParameter("@postcode", brewer.postcode));
            command.Parameters.Add(new SqlParameter("@gemeente", brewer.gemeente));
            command.Parameters.Add(new SqlParameter("@omzet", brewer.omzet));
            command.Parameters.Add(new SqlParameter("@longitude", brewer.longitude));
            command.Parameters.Add(new SqlParameter("@latitude", brewer.latitude));
            command.Parameters.Add(new SqlParameter("@brouwernr", brewer.brouwernr));

            try
            {
                cnn.Open();
                SqlDataReader reader = command.ExecuteReader();

                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
            }
        }

        private Brewer CreateBrewer(SqlDataReader reader)
        {
            //gebruik van object initializer ipv constructor
            Brewer brewer = new Brewer
            {
                brouwernr = Convert.ToInt32(reader["brouwernr"]),
                naam = Convert.ToString(reader["naam"]),
                adres = Convert.ToString(reader["adres"]),
                postcode = Convert.ToString(reader["postcode"]),
                gemeente = Convert.ToString(reader["gemeente"]),
                omzet = Convert.ToString(reader["omzet"]),
                longitude = Convert.ToString(reader["longitude"]),
                latitude = Convert.ToString(reader["latitude"])

            };
            return brewer;
        }

        private Brewer CreateBrewerBasic(SqlDataReader reader)
        {
            //gebruik van object initializer ipv constructor
            Brewer brewer = new Brewer
            {
                brouwernr = Convert.ToInt32(reader["brouwernr"]),
                naam = Convert.ToString(reader["naam"]),
            };
            return brewer;
        }
    }
}
