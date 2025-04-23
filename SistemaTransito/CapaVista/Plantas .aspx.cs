using SistemaTransito.CapaDatos;
using SistemaTransito.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaTransito.CapaVista
{
    public partial class Restricion : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
          
          
        }

        private void CargarRestriciones()
        {
            Cls_Vehiculo vehiculo = new Cls_Vehiculo();
            vehiculo.placa = tplaca.Text.Trim();
            gridview1.DataSource = null;
            gridview1.DataBind();
            gridview1.DataSource = Restriccion_Logica.consultarestriccion(vehiculo.placa);
            gridview1.DataBind();
        }

      

        protected void buscar_Click(object sender, EventArgs e)
        {
            CargarRestriciones();
        }
    }
}