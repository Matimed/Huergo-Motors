using System;
using System.Web.UI.WebControls;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public partial class Plantilla : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                lbUsuario.Text = ((UsuarioDTO)Session["user"]).Username;
            }
            else
            {
                Response.Redirect("webLogin.aspx");
            }
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