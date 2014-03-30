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
    public partial class Beer_List_Details : System.Web.UI.Page
    {
        private BierService bierService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bierService = new BierService();

                //haal de BASISgegevens van alle bieren op
                gvBeer.DataSource = bierService.getAllBeerBasics(); 
                gvBeer.DataBind();
            }
        }

        protected void gvBeer_RowCommand(object sender, GridViewCommandEventArgs e)
        {           
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBeer.Rows[index];

            bierService = new BierService();

            //haal ALLE gegevens van 1 bier op
            Beer beer = bierService.getBeerWithID(row.Cells[0].Text);
            //resultaat in labels plaatsen
            lblName.Text = "beer name: "+beer.naam;
            lblAlcohol.Text = "beer alcohol: " + beer.alcohol;
            lblBrewer.Text = "brewer number: " + beer.brouwernr;
            lblSoort.Text = "soort: " + beer.soortnr;           
        }

               
    }
}