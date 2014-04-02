using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LayeredBusinessModel.WebUI
{
    public partial class CurrencyConverter : System.Web.UI.Page
    {
        private CurrencyService.CurrencyConvertor currencyService;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            currencyService = new CurrencyService.CurrencyConvertor();            
            Double rate = currencyService.ConversionRate(CurrencyService.Currency.EUR, CurrencyService.Currency.USD);
            try
            {
                txtDollar.Text = (rate * Double.Parse(txtEuro.Text)).ToString();
            } catch(FormatException ex)
            {
                lblError.Text = "Geen geldig nummer!";
            }
            
        }
    }
}