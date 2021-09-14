using HuergoMotors.Negocio;
using System;


namespace HuergoMotors.Web
{
    public partial class webVentasAccesorios : System.Web.UI.Page
    {
        VentasNegocio ventasNegocio = new VentasNegocio();
        private int Id;
        private const string AM = "/AMS/webVentasAlta.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Request.QueryString["id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["id"]);
                }
                lbMsg.Text = string.Empty;
                if (!Page.IsPostBack)   //Esta es solo la primera vez que entra a la pagina.
                {
                    if (Request.QueryString["id"] != null)
                    {
                        CargarTabla();
                    }
                    ucBuscador.Filtro.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void CargarTabla()
        {
            gv.DataSource = ventasNegocio.CargarTablaVentasAccesorios(Id);
            gv.DataBind();
        }

        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarTabla();
            ucBuscador.Filtro.Text = string.Empty;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = ventasNegocio.Buscar(ucBuscador.Filtro.Text);
                gv.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect(AM);
        }

    }
}