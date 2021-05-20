<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAlmacen.aspx.cs" Inherits="capaPresentacion.frmAlmacen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <a href="frmLaboratorio.aspx">Laboratorios</a>&nbsp;
    <a href="frmMedicamento.aspx">Medicamentos</a>
    <a href="frmUsuario.aspx">Usuario</a>
    <a href="frmPedido.aspx"> Pedido</a>
    <a href="frmAlmacen.aspx"> Almacen</a>
    <h3>REGISTRO DE ALMACEN</h3>
    <form id="form1" runat="server">
        <div>
             <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtIdalmacen" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Sucursal</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                        <asp:TableCell>Ubicacion</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtUbicacion" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <br />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" style="height: 26px"/>&nbsp;
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />&nbsp; 
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br />
            <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
        </div>

        <br />
        <div>
            <label>Listado de Almacenes</label><br />
            <asp:TextBox ID="txtBuscar" runat="server" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>&nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click"/>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvAlmacen" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvAlmacen_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="id_almacen" HeaderText="Id Almacen"/>
                        <asp:BoundField DataField="sucursal" HeaderText="Sucursal"/>
                        <asp:BoundField DataField="ubicacion" HeaderText="Ubicacion"/>
                        <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Editar"/>
                    </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
