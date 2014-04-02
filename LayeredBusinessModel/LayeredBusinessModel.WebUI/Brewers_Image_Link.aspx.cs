using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LayeredBusinessModel.BLL;
using LayeredBusinessModel.Domain;

namespace LayeredBusinessModel.WebUI
{
    public partial class Brewers_Image_Link : System.Web.UI.Page
    {
        private BrewerService brewerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                brewerService = new BrewerService();
                gvBrewers.DataSource = brewerService.GetAll();
                gvBrewers.DataBind();

                //TODO: vives image toevoegen in gridview column, klik op image opent webpage
            }
        }
    }
}