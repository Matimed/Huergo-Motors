using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HuergoMotors.Web.UserControls

{
    public partial class UserControlBuscador : System.Web.UI.UserControl
    {


        public event EventHandler BuscarClick;
        public event EventHandler RecargarClick;
        public event EventHandler NuevoClick;

        public TextBox Filtro
        {
            get { return txtFiltro; }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (BuscarClick != null)
            {
                BuscarClick(sender, e);
            }
        }
        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            if (RecargarClick != null)
            {
                RecargarClick(sender, e);
            }
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (NuevoClick != null)
            {
                NuevoClick(sender, e);
            }
        }
    }
}