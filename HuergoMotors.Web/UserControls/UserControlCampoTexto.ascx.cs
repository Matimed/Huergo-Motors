using HuergoMotors.Web.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web.UserControls
{
    public partial class UserControlCampoTexto : UserControlCampoBase
    {

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
                lbCampo.Text = value+":"; 
            }
        }
        public override string Valor
        {
            get { return txtValor.Text; }
            set { txtValor.Text = value; }
        }

        public bool ReadOnly
        {
            get { return Convert.ToBoolean(Attributes["ReadOnly"]); }
            set 
            { 
                Attributes["ReadOnly"] = value.ToString();
                txtValor.ReadOnly = ReadOnly;
            }
        }

        public bool Nullable
        {
            get { return Convert.ToBoolean(Attributes["Nullable"]); }
            set { Attributes["Nullable"] = value.ToString(); }
        }
    }
}