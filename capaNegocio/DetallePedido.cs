using capaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class DetallePedido: clsConexion
    {
        private int id_pedido;
        private int id_medicamento;
        private decimal precio;
        private int cantidad;

        public DetallePedido()
        {
            id_pedido = 0;
            id_medicamento = 0;
            precio = 0;
            cantidad = 0;
        }
        public int IdPedido
        {
            get { return this.id_pedido; }
            set { this.id_pedido = value; }
        }
        public int IdMedicamento
        {
            get { return this.id_medicamento; }
            set { this.id_medicamento = value; }
        }
        public decimal Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }
        public bool guardar()
        {
            iniciarSP("guardarDetallepedido");
            parametroInt(id_medicamento, "id_m");
            parametroInt(cantidad, "cant");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool eliminar()
        {
            iniciarSP("eliminarDetallepedido");
            parametroInt(id_pedido, "id_p");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar(int id_pedido)
        {
            iniciarSP("buscarDetallepedido");
            parametroInt(id_pedido, "id_p");
            return mostrarData();
        }
    }
}
