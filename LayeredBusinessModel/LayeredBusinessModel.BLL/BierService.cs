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

        public void saveBeer(Beer bier)
        {
            bierDAO = new BierDAO();
            bierDAO.saveBeer(bier);
        }

        public List<Beer> GetAll()
        {
            List<Beer> beerList = new List<Beer>();
            bierDAO = new BierDAO();
            beerList = bierDAO.getAllBeer();
            return beerList;
        }

        public List<Beer> getBeersMatchingName(String name)
        {
            bierDAO = new BierDAO();
            return bierDAO.getBeersMatchingName(name);
        }

        public List<Beer> getBierSorting(String name, String searchText)
        {
            bierDAO = new BierDAO();
            return bierDAO.getBierSorting(name, searchText);
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
