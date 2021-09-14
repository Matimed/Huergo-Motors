using System;
using System.Web.UI;
using HuergoMotors.DTO;
using HuergoMotors.Negocio;

namespace HuergoMotors.Web.AMS
{
    public partial class webClientesAlta : System.Web.UI.Page
    {
        ClientesNegocio clientesNegocio = new ClientesNegocio();
        private int Id;
        private const string Backpage = "../webClientes.aspx";

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
                        HelperWeb.LeerDTO(Page.Controls, clientesNegocio.BuscarId(Id));
                        btnGuardar.Text = "Guardar Cambios";
                    }
                    else
                    {
                        btnGuardar.Text = "Agregar cliente";
                    }
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    clientesNegocio.ModificarElemento(HelperWeb.GenerarDTO<ClientesDTO>(Controls));
                }
                else
                {
                    clientesNegocio.AgregarElemento(HelperWeb.GenerarDTO<ClientesDTO>(Controls));
                }
                Response.Redirect(Backpage);
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
    }
}