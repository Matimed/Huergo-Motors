using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public partial class webLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ctUsuario.Valor == "admin" && ctPassword.Valor == "1234")
            {
                lbMsg.Text = "Sesión Iniciada";

                UsuarioDTO usuario = new UsuarioDTO();
                usuario.Id = 1;
                usuario.Username = ctUsuario.Valor;
                Session.Add("user", usuario);
                Response.Redirect("webHome.aspx");
            }
            else
            {
                lbMsg.Text = "Usuario o Contraseña Incorrecto.";
            }
        }
    }
}