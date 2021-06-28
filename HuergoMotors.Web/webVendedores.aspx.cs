using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;

namespace HuergoMotors.Web
{
    public partial class Vendedores : Page
    {
        VendedoresNegocio vendedoresNegocio = new VendedoresNegocio();
        private const string Backpage = "index.aspx";
        private const string AM = "AMS/webVendedoresAlta.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbMsg.Text = string.Empty;
                if (!Page.IsPostBack)
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
                gvVendedores.DataSource = vendedoresNegocio.Buscar(txtFiltro.Text);
                gvVendedores.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void CargarTabla()
        {
            gvVendedores.DataSource = vendedoresNegocio.CargarTabla();
            gvVendedores.DataBind();
        }

        protected void gvVendedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(gvVendedores.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["Id"]);

            if (e.CommandName == "Modificar")
            {
                Response.Redirect(AM + "?id=" + id);
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    vendedoresNegocio.EliminarElemento(id);
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

        protected void btRecargar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            txtFiltro.Text = string.Empty;
        }
    }
}