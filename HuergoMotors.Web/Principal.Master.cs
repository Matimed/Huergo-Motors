using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web
{
    public partial class Plantilla : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Navbar_MenuItemClick(object sender, MenuEventArgs e)
        {
            try
            {
                
                string path = ($"web{e.Item.Value}.aspx");
                Response.Redirect(path);
            }
            catch
            {}           
            
        }
    }
}