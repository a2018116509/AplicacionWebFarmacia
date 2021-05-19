using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using capaDatos;

namespace capaNegocio
{
    public class Laboratorio : clsConexion
    {
        private int id_laboratorio;
        private string nombre;

        public Laboratorio()
        {
            id_laboratorio = 0;
            nombre = "";
        }
        public int id_Laboratorio
        {
            get { return this.id_laboratorio; }
            set { this.id_laboratorio = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public bool guardar()
        {
            iniciarSP("guardarLaboratorio");
            parametroVarchar(nombre, "nom", 40);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarLaboratorio");
            parametroVarchar(nombre, "buscar", 40);
            return mostrarData();
        }
        public DataTable listarLaboratorio()
        {
            iniciarSP("listarLaboratorio");
            return mostrarData();
        }
        public bool modificar()
        {
            iniciarSP("modificarLaboratorio");
            parametroInt(id_laboratorio, "id_l");
            parametroVarchar(nombre, "nom", 40);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarLaboratorio");
            parametroInt(id_laboratorio, "id_l");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
    }
}
