using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frmMedicamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
            this.listarLaboratorio();
       
        }

        private void mostrar()
        {
            Medicamento med = new Medicamento();
            med.NombreMed = txtBuscar.Text;
            gvRegis.DataSource = med.buscar();
            gvRegis.DataBind();
        }
        protected void listarLaboratorio()
        {
            Laboratorio lab = new Laboratorio();
            if (IsPostBack == false)
            {
                dd1.DataSource = lab.listarLaboratorio();
                dd1.DataValueField = "id_laboratorio";
                dd1.DataTextField = "nombre";
                dd1.DataBind();
                dd1.Items.Insert(0, new ListItem("Selecciona", "0"));
            }
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId_medicamento.Text = "";
            txtNombreMed.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtAccion.Text = "";
            txtFecha.Text = "";
            dd1.SelectedIndex = dd1.Items.IndexOf(dd1.Items.FindByValue("0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Medicamento med = new Medicamento();
            med.NombreMed = txtNombreMed.Text;
            med.Descripcion = txtDescripcion.Text;
            med.Precio = Convert.ToInt32(txtPrecio.Text);
            med.AccionTerapeutica = txtAccion.Text;
            med.FechaVencimiento = Convert.ToDateTime(txtFecha.Text);
            med.id_Laboratorio = Convert.ToInt32(dd1.SelectedValue.ToString());
            if (med.guardar()) { txtResp.Text = "Registro Guardado..!"; } else { txtResp.Text = "Error al Registrar"; }
            this.mostrar();

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Medicamento med = new Medicamento();
            med.id_Medicamento = Convert.ToInt32(txtId_medicamento.Text);
            med.NombreMed = txtNombreMed.Text;
            med.Descripcion = txtDescripcion.Text;
            med.Precio = Convert.ToDecimal(txtPrecio.Text);
            med.AccionTerapeutica = txtAccion.Text;
            med.FechaVencimiento = Convert.ToDateTime(txtFecha.Text);
            med.id_Laboratorio = Convert.ToInt32(dd1.SelectedValue.ToString());
            if (med.modificar()) { txtResp.Text = "Registro Modificado..!"; } else { txtResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Medicamento med = new Medicamento();
            med.id_Medicamento = Convert.ToInt32(txtId_medicamento.Text);
            if (med.eliminar()) { txtResp.Text = "Registro eliminado..!"; } else { txtResp.Text = "Error al eliminar; "; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvRegis_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtId_medicamento.Text = gvRegis.SelectedRow.Cells[0].Text;
            txtNombreMed.Text = gvRegis.SelectedRow.Cells[1].Text;
            txtDescripcion.Text = gvRegis.SelectedRow.Cells[2].Text;
            txtPrecio.Text = gvRegis.SelectedRow.Cells[3].Text;
            txtAccion.Text = gvRegis.SelectedRow.Cells[4].Text;
            DateTime dt = Convert.ToDateTime(gvRegis.SelectedRow.Cells[5].Text);
            txtFecha.Text = String.Format("{0:yyyy-MM-dd}", dt);
            dd1.SelectedIndex = dd1.Items.IndexOf(dd1.Items.FindByText(gvRegis.SelectedRow.Cells[6].Text));
        }
    }
}