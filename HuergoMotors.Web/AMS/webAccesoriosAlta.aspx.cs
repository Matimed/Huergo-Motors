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
    public partial class webAccesoriosAlta : System.Web.UI.Page
    {
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
        private int Id;
        private const string Backpage = "../webVehiculos.aspx";
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
                        HelperWeb.LeerDTO(Page.Controls, accesoriosNegocio.BuscarId(Id));
                        btGuardarcambios.Text = "Guardar Cambios";
                    }
                    else
                    {
                       btGuardarcambios.Text = "Agregar vehiculo";
                    }
                }
            }
            catch (Exception ex)
            {
                lbMensaje.Text = ex.Message;
            }
        }

        protected void btGuardarcambios_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                accesoriosNegocio.ModificarElemento(HelperWeb.GenerarDTO<AccesoriosDTO>(Controls, Id));
            }
            else
            {
                accesoriosNegocio.AgregarElemento(HelperWeb.GenerarDTO<AccesoriosDTO>(Controls));
            }
            Response.Redirect(Backpage);
        }

        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }
    }
}