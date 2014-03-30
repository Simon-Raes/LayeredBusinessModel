using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LayeredBusinessModel.Domain;
using LayeredBusinessModel.DAO;

namespace LayeredBusinessModel.BLL
{
    public class BierService
    {
        private BierDAO bierDAO;

        public List<Beer> GetAll()
        {
            List<Beer> beerList = new List<Beer>();
            bierDAO = new BierDAO();
            beerList = bierDAO.getAllBeer();
            return beerList;
        }

        public List<Beer> getBeersForBrewer(String number)
        {
            List<Beer> beerList = new List<Beer>();
            bierDAO = new BierDAO();
            beerList = bierDAO.getBeersForBrewer(number);
            return beerList;
        }

        public List<Beer> getAllBeerBasics()
        {
            List<Beer> beerList = new List<Beer>();
            bierDAO = new BierDAO();
            beerList = bierDAO.getAllBeerBasics();
            return beerList;
        }

        public Beer getBeerWithID(String id)
        {
            bierDAO = new BierDAO();
            return bierDAO.getBeerWithID(id);   
        }
    }
    
}
