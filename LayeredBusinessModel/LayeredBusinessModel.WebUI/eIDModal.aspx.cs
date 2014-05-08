using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LayeredBusinessModel.WebUI
{
    public partial class eIDModal : System.Web.UI.Page
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
            imgPhoto.ImageUrl = getImage(curInfo.Picture);
            EID_Read1.Visible = false;
        }

        public void EID_Read1_onReadEIDDeniedByUser()
        {
            //user clicked no in permissions request pop-up
        }

        protected void btnReadEid_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show(); //show panel
            EID_Read1.Visible = true;
        }

        public string getImage(byte[] img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String(img);
        }

        //private Image byteArrayToImage(byte[] byteArrayIn)
        //{
            //MemoryStream ms = new MemoryStream(byteArrayIn);
            //Image returnImage = Image.FromStream(ms);
            //return returnImage;
        //}
    }
}