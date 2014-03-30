using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LayeredBusinessModel.Domain;
using LayeredBusinessModel.DAO;

namespace LayeredBusinessModel.BLL
{
    public class BrewerService
    {
        private BrewerDAO brewerDAO;

        public List<Brewer> GetAll()
        {
            List<Brewer> brewerList = new List<Brewer>();
            brewerDAO = new BrewerDAO();
            brewerList = brewerDAO.getAllBrewers();
            return brewerList;
        }

        public List<Brewer> GetAllBasic()
        {
            List<Brewer> brewerList = new List<Brewer>();
            brewerDAO = new BrewerDAO();
            brewerList = brewerDAO.getAllBrewersBasics();
            return brewerList;
        }

        public Brewer getBrewerWithID(String ID)
        {
            brewerDAO = new BrewerDAO();
            return brewerDAO.getBrewerWithID(ID);
        }

        public void updateBrewer(Brewer brewer)
        {
            brewerDAO = new BrewerDAO();
            brewerDAO.updateBrewer(brewer);
        }
    }
}
