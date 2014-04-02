using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LayeredBusinessModel.WebUI.WebServices;

namespace LayeredBusinessModel.WebUI
{
    public partial class Temperature : System.Web.UI.Page
    {
        private TemperatureService tempService;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            tempService = new TemperatureService();

            double celc = Double.Parse(txtCelcius.Text);

            lblFahrenheit.Text = tempService.celciusToFahrenheit(celc).ToString()+"°F";
            
               

        }
    }
}