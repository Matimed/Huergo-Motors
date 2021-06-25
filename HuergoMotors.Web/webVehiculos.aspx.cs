using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;

namespace HuergoMotors.Web
{
    public partial class Vehiculos : Page
    {
        VehiculosNegocio vehiculosNegocio = new VehiculosNegocio();
        private const string Backpage = "index.aspx";
        private const string AM = "AMS/webVehiculosAlta.aspx";

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

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gvVehiculos.DataSource = vehiculosNegocio.Buscar(txtFiltro.Text);
                gvVehiculos.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void CargarTabla()
        {
            gvVehiculos.DataSource = vehiculosNegocio.CargarTabla();
            gvVehiculos.DataBind();
        }

        protected void btRecargar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            txtFiltro.Text = string.Empty;
        }

        protected void gvVehiculos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(gvVehiculos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"]);

            if (e.CommandName == "Modificar")
            {
                Response.Redirect(AM + "?id=" + id);
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    vehiculosNegocio.EliminarElemento(id);
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

        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }
    }
}