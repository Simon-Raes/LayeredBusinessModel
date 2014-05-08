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
    public partial class Update : System.Web.UI.Page
    {
        private BierService bierService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                bierService = new BierService();
                gvUpdate.DataSource = bierService.GetAll();
                gvUpdate.DataBind();
            }
        }

        protected void gvUpdate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            bierService = new BierService();
            gvUpdate.DataSource = bierService.GetAll();
            gvUpdate.EditIndex = e.NewEditIndex;
            gvUpdate.DataBind();
        }

        protected void gvUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int biernr = Convert.ToInt16(gvUpdate.Rows[e.RowIndex].Cells[1].Text);

            String naam = ((TextBox)(gvUpdate.Rows[e.RowIndex].Cells[2].Controls[0])).Text;

            int brouwernr = Convert.ToInt16(gvUpdate.Rows[e.RowIndex].Cells[3].Text);
            int soortnr = Convert.ToInt16(gvUpdate.Rows[e.RowIndex].Cells[4].Text);
            int alcohol = Convert.ToInt16(gvUpdate.Rows[e.RowIndex].Cells[5].Text);

            Beer bier = new Beer
            {
                biernr = biernr,
                naam = naam,
                brouwernr = brouwernr,
                soortnr = soortnr,
                alcohol = alcohol
            };
            bierService = new BierService();
            bierService.saveBeer(bier);

            //update gridview
            gvUpdate.DataSource = bierService.GetAll();
            gvUpdate.EditIndex = -1;
            gvUpdate.DataBind();
        }

        protected void gvUpdate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            bierService = new BierService();
            gvUpdate.DataSource = bierService.GetAll();
            gvUpdate.EditIndex = -1;
            gvUpdate.DataBind();
        }
    }
}