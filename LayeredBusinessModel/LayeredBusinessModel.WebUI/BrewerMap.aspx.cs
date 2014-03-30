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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BrewerService brewerService = new BrewerService();
                gvBrewers.DataSource = brewerService.GetAll();
                gvBrewers.DataBind();
            }
        }

        protected void gvBrewers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBrewers.Rows[index];
            String brewerID = row.Cells[1].Text;

            latFld.Value = "sdmfkqs";
        }
    }
}