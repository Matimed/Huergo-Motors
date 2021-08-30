using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web
{
    public partial class Tablas : System.Web.UI.MasterPage
    {
        // Work in progres...

        public event EventHandler contentCallEvent;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btBuscar_Click(object sender, EventArgs e)
        {
            if (contentCallEvent != null)
            {
                contentCallEvent(this, EventArgs.Empty);
            }

        }
        
    }
}