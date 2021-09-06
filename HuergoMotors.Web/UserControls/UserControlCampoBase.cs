using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuergoMotors.Web.UserControls
{
    public abstract class UserControlCampoBase : System.Web.UI.UserControl
    {
        abstract public string Propiedad { get; set; }
        abstract public string Text { get; set; }
        abstract public string Valor { get; set; }
    }
}