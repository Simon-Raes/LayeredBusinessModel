using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LayeredBusinessModel.BLL;

namespace LayeredBusinessModel.WebUI
{
    public partial class DeleteRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BierService beerService = new BierService();
                gvBeer.DataSource = beerService.GetAll();
                gvBeer.DataBind();
            }            
        }

        protected void gvBeer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnDelete = (Button)e.Row.Cells[0].Controls[1];
                btnDelete.OnClientClick = "return confirm('Ben je zeker?');";
            }
        }

        protected void gvBeer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string nr = gvBeer.Rows[e.RowIndex].Cells[1].Text;
            //invoke method service layer
        }
    }
}