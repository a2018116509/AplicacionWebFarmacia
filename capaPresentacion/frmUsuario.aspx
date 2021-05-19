<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUsuario.aspx.cs" Inherits="capaPresentacion.frmUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h3>REGISTRO DE USUARIOS</h3>
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtIdusuario" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Nombre</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Apellido Paterno</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtApellidoP" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Apellido Materno</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtApellidoM" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Contraseña</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtContra" TextMode="Password" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Telefono</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Fecha Nacimiento</asp:TableCell>
                    <asp:TableCell><asp:TextBox type="date" ID="txtFecha" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Correo</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <br />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />&nbsp; 
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br />
            <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <label>Listado de Usuarios</label><br />
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click"/>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id_usuario" HeaderText="IdCliente"/>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre"/>
                        <asp:BoundField DataField="apellidoPaterno" HeaderText="Apellido Paterno"/>
                        <asp:BoundField DataField="apellidoMaterno" HeaderText="Apellido Materno"/>
                        <asp:BoundField DataField="telefono" HeaderText="Telefono"/>
                        <asp:BoundField DataField="fechaNacimiento" DataFormatString="{0:d}" HeaderText="Fecha de Nacimiento"/>
                        <asp:BoundField DataField="correo" HeaderText="Correo"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Seleccionar"/>
                    </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
