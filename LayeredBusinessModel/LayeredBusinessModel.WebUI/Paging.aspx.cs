using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LayeredBusinessModel.BLL;

namespace LayeredBusinessModel.WebUI
{
    public partial class Paging : System.Web.UI.Page
    {
        private BierService bierService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                bierService = new BierService();
                gvBrewers.DataSource = bierService.GetAll();
                gvBrewers.DataBind();
            }
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bierService = new BierService();
            //check if the user has sorted before
            if (Session["sortColumn"]==null)
            {
                gvBrewers.DataSource = bierService.getBeersMatchingName(txtSearch.Text);
            }
            else
            {
                gvBrewers.DataSource = bierService.getBierSorting(Session["sortColumn"].ToString(), txtSearch.Text);
            }
            
            gvBrewers.PageIndex = e.NewPageIndex;
            gvBrewers.DataBind();
        }

        protected void gvBrewers_Sorting(object sender, GridViewSortEventArgs e)
        {
            bierService = new BierService();
            //store the sort column in the session
            Session["sortColumn"] = e.SortExpression;
            gvBrewers.DataSource = bierService.getBierSorting(e.SortExpression, txtSearch.Text);
            gvBrewers.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bierService = new BierService();
            gvBrewers.DataSource = bierService.getBeersMatchingName(txtSearch.Text);
            gvBrewers.DataBind();
        }
    }
}