using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LayeredBusinessModel.WebUI
{
    public partial class Voetballers : System.Web.UI.Page
    {
        private CountryService.CountryInfoService cs;
        private CountryCurrency.CountryInformationService currencyService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ListOfCountryNamesByName ( ) As ArrayOftCountryCodeAndName
                //Returns a list of all stored counties ordered by country name 
                cs = new CountryService.CountryInfoService();
                CountryService.tCountryCodeAndName[] countries = cs.ListOfCountryNamesByName();

                List<ListItem> listItems = new List<ListItem>();
                listItems.Add(new ListItem("Select a country"));

                for (int i = 0; i < countries.Length; i++)
                {
                    listItems.Add(new ListItem(countries[i].sName));
                }

                ddlCountries.DataSource = listItems;
                ddlCountries.DataBind();
            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            currencyService = new CountryCurrency.CountryInformationService();
            txtCurrency.Text = currencyService.GetCurrencyNameByCountry(ddlCountries.SelectedValue);
        }
    }
}