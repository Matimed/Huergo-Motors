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

    }
}
