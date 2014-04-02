using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LayeredBusinessModel.WebUI.WebServices
{
    /// <summary>
    /// Summary description for Temperature
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TemperatureService : System.Web.Services.WebService
    {
        public TemperatureService()
        {
            
        }


        [WebMethod]
        public double celciusToFahrenheit(double celcius)
        {
            return celcius * 9 / 5 + 32;
        }
    }
}
