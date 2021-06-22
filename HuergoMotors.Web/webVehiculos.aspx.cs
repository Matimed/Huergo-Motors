using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;

namespace HuergoMotors.Web
{
    public partial class Vehiculos : System.Web.UI.Page
    {
        VehiculosNegocio vehiculosNegocio = new VehiculosNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                lbMsg.Text = string.Empty;

                if (!Page.IsPostBack)
                {
                    //Esta es solo la primera vez que entra a la pagina.
                    txtFiltro.Text = string.Empty;
                    CargarTabla();
                }
                else
                {
                    //Esto es en cada postback
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
                //O puedo pasar el ID por QueryString.
                Response.Redirect("AMS/webVehiculosAlta.aspx?id=" + id);

            }
            else if (e.CommandName == "Eliminar")
            {
                //--
            }

        }
    }
}