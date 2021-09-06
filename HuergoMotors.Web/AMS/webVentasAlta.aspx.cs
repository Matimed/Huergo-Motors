using HuergoMotors.DTO;
using HuergoMotors.Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
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

                    HelperWeb.DisplayDropDown(ddlAccesorio, "Nombre");
                    ddlAccesorio.DataSource = accesoriosNegocio.BuscarIdVehiculo(id);
                    ddlAccesorio.DataBind();
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

        private decimal PrecioTotalAccesorios(List<AccesoriosDTO> accesoriosVenta)
        {
            decimal precioTotal = 0;
            foreach (AccesoriosDTO accesorio in accesoriosVenta)
            {
                precioTotal += accesorio.Precio;
            }
            return precioTotal;
         }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VentasDTO ventaDTO = HelperWeb.GenerarDTO<VentasDTO>(Controls);

                if (ventaDTO.Fecha > DateTime.Now.Date) throw new Exception
                            ("La fecha no puede ser posterior a la actual del sistema");

                List<AccesoriosDTO> accesoriosVenta = GetAccesoriosVenta();

                ventaDTO.Total = HelperWeb.ConvertirNumeroRacional(ctPrecio.Valor) + PrecioTotalAccesorios(accesoriosVenta);
                ventasNegocio.ConfirmarVenta(ventaDTO, accesoriosVenta);

                Response.Redirect(Backpage);
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        private List<AccesoriosDTO> GetAccesoriosVenta()
        {
            List<AccesoriosDTO> accesoriosVenta = new List<AccesoriosDTO>();
            if ((List<AccesoriosDTO>)ViewState["accesoriosVenta"] != null)
            {
                accesoriosVenta = (List<AccesoriosDTO>)ViewState["accesoriosVenta"];
            }

            return accesoriosVenta;
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
            try
            {
                int id = Convert.ToInt32(ddlAccesorio.SelectedValue);
                AccesoriosDTO accesorio = accesoriosNegocio.BuscarId(id);

                List<AccesoriosDTO> accesoriosVenta = GetAccesoriosVenta();

                accesoriosVenta.Add(accesorio);

                ViewState.Add("accesoriosVenta", accesoriosVenta);


                gvAccesorios.DataSource = accesoriosVenta;
                gvAccesorios.DataBind();
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }

        protected void cddVehiculoIndexChanged(object sender, EventArgs e) { ActualizarVehiculo(); }
        protected void cddClienteIndexChanged(object sender, EventArgs e) { ActualizarCliente(); }

    }
}
