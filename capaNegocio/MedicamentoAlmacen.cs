using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class MedicamentoAlmacen : clsConexion
    {

        private int id_medicamento;
        private int id_almacen;
        private int stock;

        public MedicamentoAlmacen()
        {
            id_medicamento = 0;
            id_almacen = 0;
            stock = 0;
        }
        public int id_Medicamento
        {
            get { return this.id_medicamento; }
            set { this.id_medicamento = value; }
        }
        public int id_Almacen
        {
            get { return this.id_almacen; }
            set { this.id_almacen = value; }
        }
        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }

        public bool guardar()
        {
            iniciarSP("guardarMedicamentoAlmacen");
            parametroInt(id_medicamento, "id_md");
            parametroInt(id_almacen, "id_al");
            parametroInt(stock, "stk");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool modificar()
        {
            iniciarSP("modificarMedicamentoAlmacen");
            parametroInt(id_medicamento, "id_med");
            parametroInt(id_almacen, "id_alm");
            parametroInt(stock, "stk");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool eliminar()
        {
            iniciarSP("eliminarMedicamentoAlmacen");
            parametroInt(id_medicamento, "id_med");
            parametroInt(id_almacen, "id_alm");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarMedicamentoAlmacen");
            parametroInt(id_medicamento, "id_md");
            return mostrarData();
        }

        public DataTable buscarNombre(string nombre)
        {
            iniciarSP("buscarNombreMedicamentoAlmacen");
            parametroVarchar(nombre, "buscar", 40);
            return mostrarData();
        }

        public DataTable buscarNombrePorID(int id)
        {
            iniciarSP("buscarNombrePorIDMedicamentoAlmacen");
            parametroInt(id, "ids");
            return mostrarData();
        }

    }
}
