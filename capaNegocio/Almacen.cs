using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocio
{
    public class Almacen : clsConexion
    {
        private int id_almacen;
        private string sucursal;
        private string ubicacion;


        public Almacen()
        {
            id_almacen = 0;
            sucursal = "";
            ubicacion = "";
        }
        public int Idalmacen
        {
            get { return this.id_almacen; }
            set { this.id_almacen = value; }
        }

        public string Sucursal
        {
            get { return this.sucursal; }
            set { this.sucursal = value; }
        }

        public string Ubicacion
        {
            get { return this.ubicacion; }
            set { this.ubicacion = value; }
        }

        public bool guardar()
        {
            iniciarSP("guardarAlmacen");
            parametroVarchar(sucursal, "suc", 30);
            parametroVarchar(ubicacion, "ubi", 50);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool modificar()
        {
            iniciarSP("modificarAlmacen");
            parametroInt(id_almacen, "id_al");
            parametroVarchar(sucursal, "suc", 30);
            parametroVarchar(ubicacion, "ubi", 50);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarAlmacen");
            parametroInt(id_almacen, "id_al");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public DataTable buscar()
        {
            iniciarSP("buscarAlmacen");
            parametroVarchar(sucursal, "buscar", 40);
            return mostrarData();

        }
        public DataTable listarAlmacen()
        {
            iniciarSP("listarAlmacen");
            return mostrarData();
        }
    }
}
