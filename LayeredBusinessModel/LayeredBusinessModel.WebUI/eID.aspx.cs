using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LayeredBusinessModel.WebUI
{
    public partial class eID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EID_Read1.LoadEIDPersonalData = true;
            EID_Read1.Visible = true;

            //data read
            EID_Read1.EIDRead += new Arcabase.EID.SDK.Web.dlgEIDRead(EID_Reader_onEIDRead);
            //permissions denied
            EID_Read1.ReadEIDDeniedByUser += new Arcabase.EID.SDK.Web.dlgReadEIDDeniedByUser(EID_Read1_onReadEIDDeniedByUser);
        }

        public void EID_Reader_onEIDRead(Arcabase.EID.SDK.Data.EidInfo curInfo)
        {
            ltName.Text = curInfo.LastName + " " + curInfo.FirstName;
            EID_Read1.Visible = false;
        }

        public void EID_Read1_onReadEIDDeniedByUser()
        {
            //user clicked no in permissions request pop-up
        }

        protected void btnReadEid_Click(object sender, EventArgs e)
        {
            EID_Read1.Visible = true;  
        }
    }
}