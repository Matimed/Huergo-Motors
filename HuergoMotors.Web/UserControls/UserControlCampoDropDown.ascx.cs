using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web
{
    public partial class UserControlCampoDropDown : System.Web.UI.UserControl
    {
        public string Campo { get; set; }
        
        public string Text
        {
            set { lbCampo.Text = value; }
        }
      
        public string Valor
        {
            get { return ddlCampo.SelectedValue; }
            set { ddlCampo.SelectedValue = value; }
        }

        public void Cargar(object dataSource)
        {
            HelperWeb.DisplayDropDown(ddlCampo, Campo);
            ddlCampo.DataSource = dataSource;
            ddlCampo.DataBind();
        }
    }
}