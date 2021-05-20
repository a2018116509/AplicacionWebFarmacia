using capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class Medicamento: clsConexion
    {
        private int id_medicamento;
        private string nombremed;
        private string descripcion;
        private decimal precio;
        private string accionTerapeutica;
        private DateTime fechaVencimiento;
        private int id_laboratorio;


        public Medicamento()
        {
            id_medicamento = 0;
            nombremed = "";
            descripcion = "";
            precio = 0;
            accionTerapeutica = "";
            fechaVencimiento = DateTime.Today.Date;
            id_laboratorio = 0;
        }
        public int id_Medicamento
        {
            get { return this.id_medicamento; }
            set { this.id_medicamento = value; }
        }

        public string NombreMed
        {
            get { return this.nombremed; }
            set { this.nombremed = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }
        public decimal Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        public string AccionTerapeutica
        {
            get { return this.accionTerapeutica; }
            set { this.accionTerapeutica = value; }
        }
        public DateTime FechaVencimiento
        {
            get { return this.fechaVencimiento; }
            set { this.fechaVencimiento = value; }
        }
        public int id_Laboratorio
        {
            get { return this.id_laboratorio; }
            set { this.id_laboratorio = value; }
        }
        public bool guardar()
        {
            iniciarSP("guardarMedicamento");
            parametroVarchar(nombremed, "nomd", 30);
            parametroVarchar(descripcion, "des", 30);
            parametroDecimal(precio, "pre");
            parametroVarchar(accionTerapeutica, "acc", 30);
            parametroFecha(fechaVencimiento, "fec");
            parametroInt(id_laboratorio, "id_l");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool modificar()
        {
            iniciarSP("modificarMedicamento");
            parametroInt(id_medicamento, "id_m");
            parametroVarchar(nombremed, "nomd", 30);
            parametroVarchar(descripcion, "des", 30);
            parametroDecimal(precio, "pre");
            parametroVarchar(accionTerapeutica, "acc", 30);
            parametroFecha(fechaVencimiento, "fec");
            parametroInt(id_laboratorio, "id_l");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public bool eliminar()
        {
            iniciarSP("eliminarMedicamento");
            parametroInt(id_medicamento, "id_m");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }
        public DataTable buscar()
        {
            iniciarSP("buscarMedicamento");
            parametroVarchar(nombremed, "buscar", 40);
            return mostrarData();

        }
    }
}
