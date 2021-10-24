using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using HuergoMotors.DTO;
using HuergoMotors.Negocio;

namespace HuergoMotors.Service
{
    [WebService(Namespace = "http://huergo.edu.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        [WebMethod]
        public ClientesDTO LogIn(string email, string clave)
        {

            ClientesNegocio clientesNegocio = new ClientesNegocio();
            return clientesNegocio.BuscarCliente(email, clave);
        }

        [WebMethod]
        public void Register(ClientesDTO cliente)
        {
            ClientesNegocio clientesNegocio = new ClientesNegocio();
            if (cliente.Id == 0)
            {
                clientesNegocio.AgregarElemento(cliente);
            }
            else
            {
                clientesNegocio.ModificarElemento(cliente);
            }
            
        }
         
        [WebMethod]
        public List<AccesoriosRDTO> CargarAccesorios()
        {
            AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
            return accesoriosNegocio.CargarTabla();
        }
        [WebMethod]
        public List<AccesoriosRDTO> BuscarAccesorios(string filtro)
        {
            AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
            return accesoriosNegocio.Buscar(filtro);
        }
        [WebMethod]
        public List<AccesoriosDTO> CargarAccesoriosID(List<int> idAccesorios)
        {
            AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
            List<AccesoriosDTO> accesorios = new List<AccesoriosDTO>();
            foreach (int idAccesorio in idAccesorios)
            {
                AccesoriosDTO accesorio = accesoriosNegocio.BuscarId(idAccesorio);
                accesorios.Add(accesorio);
            }
            return accesorios;
        }
        [WebMethod]
        public void RealizarVenta(VentasDTO venta, List<AccesoriosDTO> accesoriosVenta)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            ventasNegocio.ConfirmarVenta(venta, accesoriosVenta);
        }

        [WebMethod]
        public List<VentasRDTO> CargarVentasCliente(int id)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            return ventasNegocio.CargarTablaVentasCliente(id);
        }
        [WebMethod]
        public List<VentasAccesoriosRDTO> CargarVentasDetalle(int id)
        {
            VentasNegocio ventasNegocio = new VentasNegocio();
            return ventasNegocio.CargarTablaVentasAccesorios(id);
        }
    }
}
