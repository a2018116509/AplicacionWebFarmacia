using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frmAlmacen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }
        protected void mostrar()
        {
            Almacen alm = new Almacen();
            alm.Sucursal = txtBuscar.Text;
            gvAlmacen.DataSource = alm.buscar();
            gvAlmacen.DataBind();
        }


        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdalmacen.Text = "";
            txtSucursal.Text = "";
            txtUbicacion.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Almacen alm = new Almacen();
            alm.Sucursal = txtSucursal.Text;
            alm.Ubicacion = txtUbicacion.Text;
            if (alm.guardar()) { lblResp.Text = "Usuario Guardado..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Almacen alm = new Almacen();
            alm.Idalmacen = Convert.ToInt32(txtIdalmacen.Text);
            alm.Sucursal = txtSucursal.Text;
            alm.Ubicacion = txtUbicacion.Text;
            if (alm.modificar()) { lblResp.Text = "Registro Modificado..!"; } else { lblResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Almacen alm = new Almacen();
            alm.Idalmacen = Convert.ToInt32(txtIdalmacen.Text);
            if (alm.eliminar()) { lblResp.Text = "Registro eliminado..!"; } else { lblResp.Text = "Error al eliminar; "; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdalmacen.Text = gvAlmacen.SelectedRow.Cells[0].Text;
            txtSucursal.Text = gvAlmacen.SelectedRow.Cells[1].Text;
            txtUbicacion.Text = gvAlmacen.SelectedRow.Cells[2].Text;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}