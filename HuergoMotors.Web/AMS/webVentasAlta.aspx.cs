using HuergoMotors.DTO;
using HuergoMotors.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web.AMS
{
	public partial class webVentasAlta : System.Web.UI.Page
	{
        VehiculosNegocio vehiculosNegocio = new VehiculosNegocio();
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
        VendedoresNegocio vendedoresNegocio = new VendedoresNegocio();
        ClientesNegocio clientesNegocio = new ClientesNegocio();
        VentasNegocio ventasNegocio = new VentasNegocio();


        private const string Backpage = "../webVentas.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = string.Empty;
            try
            {
                if (!Page.IsPostBack)
                {
                    cddVendedor.Cargar(vendedoresNegocio.CargarTabla());
                    cddVehiculo.Cargar(vehiculosNegocio.CargarTabla());
                    cddCliente.Cargar(clientesNegocio.CargarTabla());
                    ActualizarVehiculo();
                    ActualizarCliente();
                }                
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        private void ActualizarVehiculo()
        {
            try
            {
                int id = Convert.ToInt32(cddVehiculo.Valor);
                VehiculosDTO vehiculo = vehiculosNegocio.BuscarId(id);

                if (vehiculo != null)
                {
                    HelperWeb.LeerDTO(Page.Controls, vehiculo);
                }
                else
                {
                    lbMsg.Text = "El vehiculo no existe.";
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        private void ActualizarCliente()
        {
            try
            {
                int id = Convert.ToInt32(cddCliente.Valor);
                ClientesDTO cliente = clientesNegocio.BuscarId(id);

                if (cliente != null)
                {
                    HelperWeb.LeerDTO(Page.Controls, cliente);
                }
                else
                {
                    lbMsg.Text = "El cliente no existe.";
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

       
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                cddCliente.Cargar(clientesNegocio.Buscar(txtCliente.Text));
                ActualizarCliente();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }


        protected void btnAgregarAccesorio_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }

        protected void cddVehiculoIndexChanged(object sender, EventArgs e) { ActualizarVehiculo(); }
        protected void cddClienteIndexChanged(object sender, EventArgs e) { ActualizarCliente(); }

    }
}
