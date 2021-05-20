using capaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace capaPresentacion
{
    public partial class frmPedido : System.Web.UI.Page
    {
        DataTable dtb;
        DataTable carrito = new DataTable();
        DataTable detalleObj = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDetalle();
            txtFechaPedido.Text = DateTime.Now.ToString("yyyy-MM-dd");
        
       }
        public void CargarDetalle()
        {
            if (Session["pedido"] == null)
            {
                dtb = new DataTable("Carrito");
                dtb.Columns.Add("id_medicamento", System.Type.GetType("System.String"));
                dtb.Columns.Add("descripcion", System.Type.GetType("System.String"));
                dtb.Columns.Add("precio", System.Type.GetType("System.Double"));
                dtb.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
                dtb.Columns.Add("preciov", System.Type.GetType("System.Double"));

                Session["pedido"] = dtb;
                Session["prueba"] = dtb;
            }
            else
            {
                Session["pedido"] = Session["prueba"];
            }
        }
        protected void selectUsuario()
        {
            Usuario us = new Usuario();
            us.Nombre = txtBuscarU.Text;
            gvUsuario.DataSource = us.buscar();
            gvUsuario.DataBind();
        }
        protected void selectMedicamento()
        {
            Medicamento med = new Medicamento();
            med.NombreMed = txtBuscarM.Text;
            gvMedicamento.DataSource = med.buscar();
            gvMedicamento.DataBind();
        }
        protected void selectPedido()
        {
            Pedido med = new Pedido();
            gvPedido.DataSource = med.buscar(txtBuscarP.Text);
            gvPedido.DataBind();
        }
        public void cargarcarrito()
        {
            gvDetalle.DataSource = Session["pedido"];
            gvDetalle.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtFechaPedido.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtIdUsuario.Text = "";
            txtIdPedido.Text = "";
            txtUsuario.Text = "";
            txtBuscarU.Text = "";
            txtBuscarP.Text = "";
            lblResp.Text = "";
            lblTotal.Text = "";
            gvDetalle.DataBind();
            Session["pedido"] = null;
            Session["prueba"] = null;
        }
        protected decimal calcularTotal()
        {
            decimal total = 0;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                total = total + Convert.ToDecimal(row.Cells[5].Text);
            }
            return total;
        }
        protected void actualizarSubtotal()
        {
            int cantidad = 0;
            int precio = 0;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                cantidad = Convert.ToInt32(((TextBox)row.Cells[4].FindControl("txtCantidad")).Text);
                precio = Convert.ToInt32(row.Cells[3].Text);
                row.Cells[5].Text = Convert.ToString(cantidad * precio);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            actualizarSubtotal();
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());

            Pedido ped = new Pedido();
            ped.Fecha = Convert.ToDateTime(txtFechaPedido.Text);
            ped.Total = calcularTotal();
            ped.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            if (ped.guardar()) { lblResp.Text = "Pedido Registrada..!"; } else { lblResp.Text = "Error al Registrar"; }

            DetallePedido dp;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                dp = new DetallePedido();
                dp.IdMedicamento= Convert.ToInt32(row.Cells[1].Text);
                dp.Precio = Convert.ToDecimal(row.Cells[5].Text);
                dp.Cantidad = Convert.ToInt32(((TextBox)row.Cells[4].FindControl("txtCantidad")).Text);
                dp.guardar();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            actualizarSubtotal();
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
            Pedido ped = new Pedido();
            ped.IdPedido = Convert.ToInt32(txtIdPedido.Text);
            ped.Fecha = Convert.ToDateTime(txtFechaPedido.Text);
            ped.Total = calcularTotal();
            ped.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            if (ped.modificar()) { lblResp.Text = "Pedido Modificada..!"; } else { lblResp.Text = "Error al Modificar"; }

            DetallePedido dp1 = new DetallePedido();
            dp1.IdPedido = Convert.ToInt32(txtIdPedido.Text);
            dp1.eliminar();

            DetallePedido dp;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                dp = new DetallePedido();
                dp.IdMedicamento = Convert.ToInt32(row.Cells[1].Text);
                dp.Precio = Convert.ToDecimal(row.Cells[5].Text);
                dp.Cantidad = Convert.ToInt32(((TextBox)row.Cells[4].FindControl("txtCantidad")).Text);
                dp.guardar();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            DetallePedido dp1 = new DetallePedido();
            dp1.IdPedido = Convert.ToInt32(txtIdPedido.Text);
            dp1.eliminar();

            Pedido ped = new Pedido();
            ped.IdPedido = Convert.ToInt32(txtIdPedido.Text);
            if (ped.eliminar()) { lblResp.Text = "Pedido Eliminada..!"; } else { lblResp.Text = "Error al Eliminar"; }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            miModalP.Show();
            gvPedido.DataBind(); //deja limpio la tabla de registros
            lblError.Text = "";
        }
        protected void buscarUsuario(object sender, EventArgs e)
        {
            miModalU.Show(); //inicia el modal Cliente
            gvUsuario.DataBind(); //deja limpio la tabla de registros
        }
        protected void buscarMedicamento(object sender, EventArgs e)
        {
            miModalM.Show(); //inicia el modal Producto
            gvMedicamento.DataBind(); //deja limpio la tabla de registros
            lblError.Text = "";
        }
        protected void gvDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvDetalle.SelectedRow.Cells[1].Text);
            var db = (DataTable)Session["pedido"];
            detalleObj = null;
            foreach (DataRow row in db.Rows)
            {
                if (detalleObj == null)
                {
                    detalleObj = new DataTable("Carrito");
                    detalleObj.Columns.Add("id_medicamento", System.Type.GetType("System.String"));
                    detalleObj.Columns.Add("descripcion", System.Type.GetType("System.String"));
                    detalleObj.Columns.Add("precio", System.Type.GetType("System.Double"));
                    detalleObj.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
                    detalleObj.Columns.Add("preciov", System.Type.GetType("System.Double"));
                }
                int es = Convert.ToInt32(row["id_medicamento"].ToString());
                if (es != id)
                {
                    DataRow fila = detalleObj.NewRow();
                    fila[0] = Convert.ToInt32(row["id_medicamento"].ToString());
                    fila[1] = Convert.ToString(row["descripcion"].ToString());
                    fila[2] = Convert.ToDecimal(row["precio"].ToString());
                    fila[3] = Convert.ToInt32(row["cantidad"].ToString());
                    fila[4] = Convert.ToDecimal(row["preciov"].ToString());
                    detalleObj.Rows.Add(fila);
                }
            }
            Session["pedido"] = detalleObj;
            Session["prueba"] = detalleObj;
            gvDetalle.DataSource = detalleObj;
            gvDetalle.DataBind();
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());

        }

        protected void btnBuscarUsuario(object sender, EventArgs e)
        {
            selectUsuario();
            miModalU.Show();
        }

        protected void btnCerrarCli(object sender, EventArgs e)
        {
            miModalU.Hide();
        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdUsuario.Text = gvUsuario.SelectedRow.Cells[0].Text;
            txtUsuario.Text = gvUsuario.SelectedRow.Cells[1].Text + ' ' + gvUsuario.SelectedRow.Cells[2].Text;

        }
        private bool existeMedEnDetalle(int idMed)
        {
            bool existe = false;
            foreach (GridViewRow row in gvDetalle.Rows)
            {
                if (Convert.ToInt32(row.Cells[1].Text) == idMed)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public void AgregarItem(string id_medicamento, string nombre, double precio)
        {
            double preciov;
            int cantidad = 1;
            preciov = precio * cantidad;
            carrito = (DataTable)Session["pedido"];
            DataRow fila = carrito.NewRow();
            fila[0] = id_medicamento;
            fila[1] = nombre;
            fila[2] = precio;
            fila[3] = (int)cantidad;
            fila[4] = preciov;
            carrito.Rows.Add(fila);
            Session["pedido"] = carrito;
            cargarcarrito();
        }
    
        protected void gvMedicamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cod = gvMedicamento.SelectedRow.Cells[0].Text;
            string nomb = gvMedicamento.SelectedRow.Cells[1].Text;
            double precio = Convert.ToDouble(gvMedicamento.SelectedRow.Cells[3].Text);

            if (existeMedEnDetalle(Convert.ToInt32(cod)) == true)
            {
                lblError.Text = "Ya se encuentra agregado";
                miModalM.Show();
            }
            else
            {
                AgregarItem(cod, nomb, precio);
                lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());
                miModalM.Show();
            }
        }

        protected void btnCerrarPro(object sender, EventArgs e)
        {
            miModalM.Hide();
        }

        protected void btnBuscarP(object sender, EventArgs e)
        {
            selectPedido();
            miModalP.Show();
        }

        protected void gvPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdPedido.Text = gvPedido.SelectedRow.Cells[0].Text;
       
            DateTime dt = Convert.ToDateTime(gvPedido.SelectedRow.Cells[1].Text);
            txtFechaPedido.Text = String.Format("{0:yyyy-MM-dd}", dt);
            txtUsuario.Text = gvPedido.SelectedRow.Cells[3].Text;
            Pedido ped = new Pedido();
            txtIdUsuario.Text = ped.buscarUsuarioPedido(Convert.ToInt32(txtIdPedido.Text));

            DetallePedido det = new DetallePedido();
            DataTable detalle = new DataTable();
            detalle = det.buscar(Convert.ToInt32(txtIdPedido.Text));
            gvDetalle.DataSource = detalle;
            gvDetalle.DataBind();
            Session["prueba"] = detalle;
            lblTotal.Text = "Total bs: " + Convert.ToString(calcularTotal());

        }

        protected void btnCerrarVent(object sender, EventArgs e)
        {
            miModalP.Hide();
        }

     
        protected void btnBuscarM(object sender, EventArgs e)
        {
            //busqueda dentro del modal producto
            selectMedicamento();
            miModalM.Show();
        }
    }
}