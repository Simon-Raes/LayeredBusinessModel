﻿using System;
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