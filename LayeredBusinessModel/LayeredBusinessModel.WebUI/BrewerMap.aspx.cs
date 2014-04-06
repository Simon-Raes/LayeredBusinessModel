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
    public partial class BrewerMap : System.Web.UI.Page
    {
        private BrewerService brewerService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                brewerService = new BrewerService();
                gvBrewers.DataSource = brewerService.GetAll();
                gvBrewers.DataBind();
            }
        }

        protected void gvBrewers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //get selected brewer
            brewerService = new BrewerService();            
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBrewers.Rows[index];
            String brewerID = row.Cells[2].Text; //hardcode cell number!
            Brewer brewer = brewerService.getBrewerWithID(brewerID);

            if (e.CommandName == "Select")
            {    
                //update brewer, store lat and long
                brewer.latitude = latFld.Value;
                brewer.longitude = lngFld.Value;                
            }
            else if (e.CommandName == "Clear")
            {
                //update brewer, remove lat and long
                brewer.latitude = "";
                brewer.longitude = "";
            }

            //save updated brewer to database
            brewerService.updateBrewer(brewer);

            //update gridview
            gvBrewers.DataSource = brewerService.GetAll();
            gvBrewers.DataBind();
            
        }

        //handle page changing event
        protected void gvBrewers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBrewers.PageIndex = e.NewPageIndex;
            brewerService = new BrewerService();
            gvBrewers.DataSource = brewerService.GetAll();
            gvBrewers.DataBind();
        }
    }
}