using System;
using System.Data;
using capaDatos;

namespace capaNegocio
{
    public class Usuario:clsConexion
    {
        private int id_usuario;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string contraseña;
        private string telefono;
        private DateTime fechaNacimiento;
        private string correo;

        public Usuario()
        {
            id_usuario= 0;
            nombre = "";
            apellidoPaterno = "";
            apellidoMaterno = "";
            contraseña = "";
            telefono = "";
            fechaNacimiento = DateTime.Today.Date;
            correo = "";
        }

        public int Idusuario
        {
            get { return this.id_usuario; }
            set { this.id_usuario = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string ApellidoPaterno
        {
            get { return this.apellidoPaterno; }
            set { this.apellidoPaterno = value; }
        }

        public string ApellidoMaterno
        {
            get { return this.apellidoMaterno; }
            set { this.apellidoMaterno = value; }
        }

        public string Contraseña
        {
            get { return this.contraseña; }
            set { this.contraseña = value; }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }

        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }
        ///Metodos CRUD
        public bool guardar()
        {
            iniciarSP("guardarUsuario");
            parametroInt(id_usuario, "id");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellidoPaterno, "apeP", 40);
            parametroVarchar(apellidoMaterno, "apeM", 40);
            parametroVarchar(contraseña, "con", 20);
            parametroVarchar(telefono, "tel", 20);
            parametroFecha(fechaNacimiento, "fec");
            parametroVarchar(correo, "cor", 20);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool modificar()
        {
            iniciarSP("modificarUsuario");
            parametroInt(id_usuario, "id");
            parametroVarchar(nombre, "nom", 30);
            parametroVarchar(apellidoPaterno, "apeP", 40);
            parametroVarchar(apellidoMaterno, "apeM", 40);
            parametroVarchar(contraseña, "con", 20);
            parametroVarchar(telefono, "tel", 20);
            parametroFecha(fechaNacimiento, "fec");
            parametroVarchar(correo, "cor", 20);
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public bool eliminar()
        {
            iniciarSP("eliminarUsuario");
            parametroInt(id_usuario, "id_us");
            if (ejecutarSP() == true) { return true; } else { return false; }
        }

        public DataTable buscar()
        {
            iniciarSP("buscarUsuario");
            parametroVarchar(nombre, "buscar", 30);
            return mostrarData();
        }

    }
}
