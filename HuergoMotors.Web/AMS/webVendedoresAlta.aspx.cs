using System;
using System.Web.UI;
using HuergoMotors.Negocio;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public partial class VendedoresAlta : Page
    {
        VendedoresNegocio vendedoresNegocio = new VendedoresNegocio();
        private int Id;
        private const string Backpage = "../webVendedores.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    Id = Convert.ToInt32(Request.QueryString["id"]);
                }
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        HelperWeb.LeerDTO(Page.Controls, vendedoresNegocio.BuscarId(Id));
                        btAceptar.Text = "Guardar Cambios";
                    }
                    else
                    {
                        btAceptar.Text = "Agregar vehiculo";
                    }
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }
        public void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                vendedoresNegocio.ModificarElemento(HelperWeb.GenerarDTO<VendedoresDTO>(Controls, Id));
            }
            else
            {
                vendedoresNegocio.AgregarElemento(HelperWeb.GenerarDTO<VendedoresDTO>(Controls));
            }
            Response.Redirect(Backpage);
        }
    }
}