﻿using System;
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

         
        public void Page_Load(object sender, EventArgs e)
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
                        HelperWeb.LeerDTO(Page.Controls, vehiculosNegocio.BuscarId(Id));
                    }
                    else
                    {
                        btGuardar.Text = "Agregar vehiculo";
                    }

                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = ex.Message;
            }
        }

        public void btGuardar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                vehiculosNegocio.ModificarElemento(HelperWeb.GenerarDTO<VehiculosDTO>(Controls, Id));
            }
            else
            {
                vehiculosNegocio.AgregarElemento(HelperWeb.GenerarDTO<VehiculosDTO>(Controls));
            }
            Response.Redirect(Backpage);


        }
        public void btVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Backpage);
        }
    }
}