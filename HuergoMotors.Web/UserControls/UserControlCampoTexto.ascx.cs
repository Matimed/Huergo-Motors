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

        public new string Propiedad
        {
            get { return Attributes["Propiedad"]; }
            set { Attributes["Propiedad"] = value; }
        }

        public new string Text
        {
            get { return Attributes["Text"]; }
            set 
            {
                Attributes["Text"] = value;
                lbCampo.Text = value+":"; 
            }
        }
        public new string Valor
        {
            get { return txtValor.Text; }
            set { txtValor.Text = value; }
        }

    }
}