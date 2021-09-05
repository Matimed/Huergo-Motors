using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web
{
    public partial class UserControlCampoTexto : System.Web.UI.UserControl
    {
        
        public string Text
        {
            set { lbCampo.Text = value; }
        }
        public string Valor
        {
            get { return txtValor.Text; }
            set { txtValor.Text = value; }
        }
      
    }
}