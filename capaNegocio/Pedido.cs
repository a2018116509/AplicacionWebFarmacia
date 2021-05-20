using capaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class Pedido: clsConexion
    {
        private int id_pedido;
        private DateTime fecha;
        private decimal total;
        private int id_usuario;
            
        public Pedido()
        {
            id_pedido = 0;
            fecha = DateTime.Today.Date;
            total = 0;
            id_usuario = 0;
        }
        public int IdPedido
        {
            get { return this.id_pedido; }
            set { this.id_pedido = value; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        public int IdUsuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        public decimal Total
        {
            get { return this.total; }
            set { this.total = value; }
        }

        public bool guardar()
        {
            iniciarSP("guardarpedido");
            parametroFecha(fecha, "fech");
            parametroDecimal(total, "tot");
            parametroInt(id_usuario, "id_us");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool modificar()
        {
            iniciarSP("modificarpedido");
            parametroInt(id_pedido, "id_p");
            parametroFecha(fecha, "fech");
            parametroDecimal(total, "tot");
            parametroInt(id_usuario, "id_us");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarpedido");
            parametroInt(id_pedido, "id_p");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public DataTable buscar(string buscar)
        {
            iniciarSP("buscarpedido");
            parametroVarchar(buscar, "buscar", 30);
            return mostrarData();
        }

        public string buscarUsuarioPedido(int id_p)
        {
            iniciarSP("buscarusuariopedido");
            parametroInt(id_p, "id_p");
            DataTable cod = new DataTable();
            cod = mostrarData();
            string id = "";
            foreach (DataRow row in cod.Rows)
            {
                id = row["id_usuario"].ToString();
            }
            return id;
        }
    }
}
