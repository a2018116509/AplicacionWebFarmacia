using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frmLaboratorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }
        protected void mostrar()
        {
            Laboratorio lab = new Laboratorio();
            lab.Nombre = txtBuscar.Text;
            gvRegis.DataSource = lab.buscar();
            gvRegis.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Laboratorio lab = new Laboratorio();
            lab.Nombre = txtNombre.Text;
            if (lab.guardar()) { txtResp.Text = "Registro Guardado..!"; } else { txtResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId_laboratorio.Text = "";
            txtNombre.Text = "";
            txtBuscar.Text = "";
            txtResp.Text = "";
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Laboratorio lab = new Laboratorio();
            lab.id_Laboratorio = Convert.ToInt32(txtId_laboratorio.Text);
            lab.Nombre = txtNombre.Text;
            if (lab.modificar()) { txtResp.Text = "Registro Modificado..!"; } else { txtResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Laboratorio lab = new Laboratorio();
            lab.id_Laboratorio = Convert.ToInt32(txtId_laboratorio.Text);
            if (lab.eliminar()) { txtResp.Text = "Registro eliminado..!"; } else { txtResp.Text = "Error al eliminar; "; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvRegis_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId_laboratorio.Text = gvRegis.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvRegis.SelectedRow.Cells[1].Text;

        }
    }
}