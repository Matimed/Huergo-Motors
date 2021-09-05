using HuergoMotors.Negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web
{
    public partial class webVendedores : System.Web.UI.Page
    {
        VendedoresNegocio vendedoresNegocio = new VendedoresNegocio();
        private const string AM = "AMS/webVendedoresAlta.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbMsg.Text = string.Empty;
                if (!Page.IsPostBack)
                {
                    ucBuscador.Filtro.Text = string.Empty;
                    CargarTabla();
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = vendedoresNegocio.Buscar(ucBuscador.Filtro.Text);
                gv.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void CargarTabla()
        {
            gv.DataSource = vendedoresNegocio.CargarTabla();
            gv.DataBind();
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
                    vendedoresNegocio.EliminarElemento(id);
                    CargarTabla();
                }
                catch (Exception ex)
                {
                    lbMsg.Text = ex.Message;
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(AM);
        }


        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            ucBuscador.Filtro.Text = string.Empty;
        }

    }
}