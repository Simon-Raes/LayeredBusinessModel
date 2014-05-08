using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LayeredBusinessModel.BLL;
using LayeredBusinessModel.Domain;
using System.Data;


namespace LayeredBusinessModel.WebUI
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BierService bierService = new BierService();
                gvBeer.DataSource = bierService.GetAll();
                gvBeer.DataBind();
            }
        }

        protected void gvBeer_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvBeer_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            BierService bierService = new BierService();
            Beer bier = bierService.getBeerWithID(gvBeer.Rows[e.NewSelectedIndex].Cells[1].Text);

            DataTable bieren = new DataTable();

            if (Session["bestelbieren"] == null)
            {
                bieren.Columns.Add("biernr");
                bieren.Columns.Add("naam");
                bieren.Columns.Add("aantal");

            }
            else
            {
                bieren = (DataTable)Session["bestelbieren"];
            }
            DataRow dr = bieren.NewRow();
            dr[0] = bier.biernr;
            dr[1] = bier.naam;
            dr[2] = 1;
            bieren.Rows.Add(dr);
            Session["bestelbieren"] = bieren;

        }

        #region shoppingcart

        protected int[] AantalArray
        {
            get { return new int[] { 1, 2, 3, 4, 5 }; }
        }

        #endregion

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ((DataTable)Session["bestelbieren"]).Rows[e.RowIndex].Delete();


            if (((DataTable)Session["bestelbieren"]).Rows.Count == 0)
            {
                Session["bestelbieren"] = null;
                lblCart.Text = "Er bevinden zich geen items in uw cart";
                gvCart.DataSource = null;
                gvCart.DataBind();
                btnBestellen.Visible = false;
            }
            else
            {
                gvCart.DataSource = Session["bestelbieren"];
                gvCart.DataBind();
            }
            ModalPopupExtender1.Show();

        }

        protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCart.DataSource = Session["bestelbieren"];
            gvCart.EditIndex = e.NewEditIndex;
            gvCart.DataBind();
            ModalPopupExtender1.Show();
        }

        protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int aantal = Convert.ToInt16(((DropDownList)gvCart.Rows[e.RowIndex].FindControl("ddlAmount")).SelectedValue);
            ((DataTable)Session["bestelbieren"]).Rows[e.RowIndex]["Aantal"] = aantal;

            gvCart.DataSource = Session["bestelbieren"];
            gvCart.EditIndex = -1;
            gvCart.DataBind();
            ModalPopupExtender1.Show();
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            if (Session["bestelbieren"] == null)
            {
                lblCart.Text = "Cart is empty";
                btnBestellen.Visible = false;
            }
            else
            {
                gvCart.DataSource = Session["bestelbieren"];
                gvCart.DataBind();
            }
            ModalPopupExtender1.Show();
        }
    }
}