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
        public event EventHandler SelectedIndexChanged;
        public override string Propiedad
        {
            get { return Attributes["Propiedad"]; }
            set { Attributes["Propiedad"] = value; }
        }

        public override string Text
        {
            get { return Attributes["Text"]; }
            set
            {
                Attributes["Text"] = value;
                lbCampo.Text = value + ":";
            }
        }
      
        public override string Valor
        {
            get { return ddlCampo.SelectedValue; }
            set { ddlCampo.SelectedValue = value; }
        }

        public string DisplayMember
        {
            get { return Attributes["DisplayMember"]; }
            set { Attributes["DisplayMember"] = value; }
        }

        public bool AutoPostBack
        {
            get { return Convert.ToBoolean(Attributes["AutoPostBack"]); }
            set
            {
                Attributes["AutoPostBack"] = value.ToString();
                ddlCampo.AutoPostBack = AutoPostBack;
            }
        }


        public void Cargar(object dataSource)
        {
            HelperWeb.DisplayDropDown(ddlCampo, DisplayMember);
            ddlCampo.DataSource = dataSource;
            ddlCampo.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}