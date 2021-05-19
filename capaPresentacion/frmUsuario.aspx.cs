using capaNegocio;
using System;

namespace capaPresentacion
{
    public partial class frmUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.mostrar();
        }
        protected void mostrar()
        {
            Usuario us = new Usuario();
            us.Nombre = txtBuscar.Text;
            gvUsuario.DataSource = us.buscar();
            gvUsuario.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.Nombre = txtNombre.Text;
            us.ApellidoPaterno = txtApellidoP.Text;
            us.ApellidoMaterno = txtApellidoM.Text;
            us.Contraseña = txtContra.Text;
            us.Telefono = txtTelefono.Text;
            us.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            us.Correo = txtCorreo.Text;
            if (us.guardar()) { lblResp.Text = "Usuario Guardado..!"; } else { lblResp.Text = "Error al Registrar"; }
            this.mostrar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.mostrar();
        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdusuario.Text = gvUsuario.SelectedRow.Cells[0].Text;
            txtNombre.Text = gvUsuario.SelectedRow.Cells[1].Text;
            txtApellidoP.Text = gvUsuario.SelectedRow.Cells[2].Text;
            txtApellidoM.Text = gvUsuario.SelectedRow.Cells[3].Text;
            txtApellidoM.Text = gvUsuario.SelectedRow.Cells[3].Text;
            txtTelefono.Text = gvUsuario.SelectedRow.Cells[4].Text;
            DateTime dt = Convert.ToDateTime(gvUsuario.SelectedRow.Cells[5].Text);
            txtFecha.Text = String.Format("{0:yyyy-MM-dd}", dt);
            txtCorreo.Text = gvUsuario.SelectedRow.Cells[6].Text;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.Idusuario = Convert.ToInt32(txtIdusuario.Text);
            us.Nombre = txtNombre.Text;
            us.ApellidoPaterno = txtApellidoP.Text;
            us.ApellidoMaterno = txtApellidoM.Text;
            us.Contraseña = txtContra.Text;
            us.Telefono = txtTelefono.Text;
            us.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
            us.Correo = txtCorreo.Text;
            if (us.modificar()) { lblResp.Text = "Usuario Modificado..!"; } else { lblResp.Text = "Error al Modificar"; }
            this.mostrar();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtContra.Text = "";
            txtTelefono.Text = "";
            txtFecha.Text = "";
            lblResp.Text = "";
            txtBuscar.Text = "";
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.Idusuario = Convert.ToInt32(txtIdusuario.Text);
            if (us.eliminar()) { lblResp.Text = "Usuario Eliminado..!"; } else { lblResp.Text = "Error al Eliminar"; }
            this.mostrar();
        }
    }
}