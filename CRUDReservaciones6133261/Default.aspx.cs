using System;
using System.Web.UI;

namespace CRUDReservaciones6133261
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnReservaciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reservaciones.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }

        protected void btnEmpleados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }
    }
}