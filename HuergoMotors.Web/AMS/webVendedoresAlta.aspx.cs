using System;
using System.Web.UI;
using HuergoMotors.Negocio;
using HuergoMotors.DTO;

namespace HuergoMotors.Web.AMS
{
    public partial class webVendedoresAlta : System.Web.UI.Page
    {
        VendedoresNegocio vendedoresNegocio = new VendedoresNegocio();
        private int Id;
        private const string Backpage = "../webVendedores.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = string.Empty;
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
                        btnGuardar.Text = "Guardar Cambios";
                        HelperWeb.LeerDTO(Page.Controls, vendedoresNegocio.BuscarId(Id));
                    }
                    else
                    {
                        btnGuardar.Text = "Agregar vendedor";
                    }
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }
        public void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }
    }
}