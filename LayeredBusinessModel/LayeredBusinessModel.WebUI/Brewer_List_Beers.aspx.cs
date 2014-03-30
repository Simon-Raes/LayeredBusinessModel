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
    public partial class BeerList : System.Web.UI.Page
    {

        private BrewerService brewerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            //dropdownlist enkel bij de eerste page-load opvullen
            if (!Page.IsPostBack)
            {
                brewerService = new BrewerService();

                ddBrewers.DataSource = brewerService.GetAllBasic();

                //dit zijn de namen van de klassevariabelen, niet van de tabel!
                ddBrewers.DataTextField = "naam";
                ddBrewers.DataValueField = "brouwernr";

                ddBrewers.DataBind();
                ddBrewers.Items.Insert(0, new ListItem("Selecteer een brouwer", ""));
            }

        }

        protected void ddBrewers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //don't execute query for first empty listitem
            if (ddBrewers.SelectedIndex != 0)
            {
                BierService bierService = new BierService();

                gvBeer.DataSource = bierService.getBeersForBrewer(ddBrewers.SelectedItem.Value);
                gvBeer.DataBind();
            }

        }
    }
}