using System;
using System.Web.UI;
using HuergoMotors.Negocio;
using HuergoMotors.DTO;

namespace HuergoMotors.Web.AMS
{
    public partial class webAccesoriosAlta : System.Web.UI.Page
    {
        AccesoriosNegocio accesoriosNegocio = new AccesoriosNegocio();
        VehiculosNegocio vehiculosNegocio = new VehiculosNegocio();
        private int Id;
        private const string Backpage = "../webAccesorios.aspx";
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
                        HelperWeb.DisplayDropDown(ddlIdVehiculo, "Modelo");
                        ddlIdVehiculo.DataSource = vehiculosNegocio.CargarTabla();
                        ddlIdVehiculo.DataBind();
                        HelperWeb.LeerDTO(Page.Controls, accesoriosNegocio.BuscarId(Id));
                        btnGuardar.Text = "Guardar Cambios";
                    }
                    else
                    {
                        HelperWeb.DisplayDropDown(ddlIdVehiculo, "Modelo");
                        ddlIdVehiculo.DataSource = vehiculosNegocio.CargarTabla();
                        ddlIdVehiculo.DataBind();
                        btnGuardar.Text = "Agregar accesorio";
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }
    }
}
