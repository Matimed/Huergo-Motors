using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public partial class WebForm1 : Page
    {
        ClientesNegocio clientesNegocio = new ClientesNegocio();
        private int Id;
        private const string Backpage = "../webClientes.aspx";

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
                        HelperWeb.LeerDTO(Page.Controls, clientesNegocio.BuscarId(Id));
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

        protected void Button1_Click(object sender, EventArgs e)
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
    }
}