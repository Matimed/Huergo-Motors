using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuergoMotors.Negocio;
using HuergoMotors.Web;
using HuergoMotors.DTO;

namespace HuergoMotors.Web
{
    public partial class webVehiculosAlta : System.Web.UI.Page
    {
        VehiculosNegocio vehiculosNegocio = new VehiculosNegocio();
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
                    VehiculosDTO vehiculo = new VehiculosDTO();
                    vehiculo = vehiculosNegocio.BuscarId(Id);

                    txtModelo.Text = vehiculo.Modelo;
                    txtPrecioVenta.Text = vehiculo.PrecioVenta.ToString();
                    txtStock.Text = vehiculo.Stock.ToString();
                    txtTipo.Text = vehiculo.Tipo;
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        protected void btGuardar_Click(object sender, EventArgs e)
        {
            VehiculosDTO vehiculo = new VehiculosDTO();
            vehiculo.Id = Id;
            vehiculo.Tipo = txtTipo.Text;
            vehiculo.Modelo = txtModelo.Text;
            vehiculo.PrecioVenta = HelperWeb.ConvertirNumeroRacional(txtPrecioVenta);
            vehiculo.Stock = HelperWeb.ConvertirNumeroNatural(txtStock);
            vehiculosNegocio.ModificarElemento(vehiculo);
            Response.Redirect(Backpage);

        }

        protected void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }
    }
}