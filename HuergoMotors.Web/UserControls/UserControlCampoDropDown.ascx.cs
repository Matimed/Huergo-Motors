using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web.UserControls
{
    public partial class UserControlCampoDropDown : UserControlCampoBase
    {
        public new string Propiedad
        {
            get { return Attributes["Propiedad"]; }
            set { Attributes["Propiedad"] = value; }
        }

        public new string Text
        {
            set { lbCampo.Text = value; }
        }
      
        public new string Valor
        {
            get { return ddlCampo.SelectedValue; }
            set { ddlCampo.SelectedValue = value; }
        }

        public string DisplayMember
        {
            get { return Attributes["DisplayMember"]; }
            set { Attributes["DisplayMember"] = value; }
        }

        public void Cargar(object dataSource)
        {
            HelperWeb.DisplayDropDown(ddlCampo, DisplayMember);
            ddlCampo.DataSource = dataSource;
            ddlCampo.DataBind();
        }
    }
}