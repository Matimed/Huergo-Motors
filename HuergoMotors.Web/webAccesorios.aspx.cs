using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;

namespace HuergoMotors.Web
{
    public partial class webAccesorios : System.Web.UI.Page
    {
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
        private const string AM = "AMS/webAccesoriosAlta.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbMsg.Text = string.Empty;
                if (!Page.IsPostBack)   //Esta es solo la primera vez que entra a la pagina.
                {
                    txtFiltro.Text = string.Empty;
                    CargarTabla();
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void CargarTabla()
        {
            gv.DataSource = accesoriosNegocio.CargarTabla();
            gv.DataBind();
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = accesoriosNegocio.Buscar(txtFiltro.Text);
                gv.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            txtFiltro.Text = string.Empty;
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(gv.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"]);

            if (e.CommandName == "Modificar")
            {
                Response.Redirect(AM + "?id=" + id);
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    accesoriosNegocio.EliminarElemento(id);
                    CargarTabla();
                }
                catch (Exception ex)
                {
                    lbMsg.Text = ex.Message;
                }
            }
        }

        protected void btNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(AM);
        }

   
    }
}
