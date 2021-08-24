using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;

namespace HuergoMotors.Web
{

    public partial class webClientes : Page
    {
        ClientesNegocio clientesNegocio = new ClientesNegocio();
        private const string Backpage = "index.aspx";
        private const string AM = "AMS/webClientesAlta.aspx";

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

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void CargarTabla()
        {
            gvClientes.DataSource = clientesNegocio.CargarTabla();
            gvClientes.DataBind();
        }

        protected void btRecargar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            txtFiltro.Text = string.Empty;
        }

        protected void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gvClientes.DataSource = clientesNegocio.Buscar(txtFiltro.Text);
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(AM);
        }

        protected void btVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Backpage);
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }
    }




}