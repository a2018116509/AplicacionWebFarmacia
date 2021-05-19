<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMedicamento.aspx.cs" Inherits="capaPresentacion.frmMedicamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <a href="frmLaboratorio.aspx">Laboratorios</a>&nbsp;
    <a href="frmMedicamento.aspx">Medicamentos</a>
    <h3>REGISTRO DE MEDICAMENTO</h3>
    <form id="form1" runat="server">
        <div>
             <asp:Table runat="server" Height="151px" Width="228px">
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtId_medicamento" Type ="hidden" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>NombreMed</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtNombreMed" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Descripcion</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                     <asp:TableCell>Precio</asp:TableCell>
                     <asp:TableCell><asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox></asp:TableCell>
                 </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Accion Terapeutica</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtAccion" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>Fecha Vencimiento</asp:TableCell>
                    <asp:TableCell><asp:TextBox type="date" ID="txtFecha" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                 <asp:TableRow>
                    <asp:TableCell>Laboratorio</asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="dd1" runat="server" AutoPostBack="false" Width="130"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
             <br />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />&nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" /><br />
            <asp:Label ID="txtResp" runat="server" Text=""></asp:Label>
        </div>
         <div>
            <label>Listado de Medicamento</label><br />
            <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>&nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar por Nombre" OnClick="btnBuscar_Click" />
            <br />
            <br />
            <asp:GridView ID="gvRegis" runat="server" AutoGenerateColumns="false" OnPageIndexChanged="gvRegis_SelectedIndexChanged" OnSelectedIndexChanged="gvRegis_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="id_medicamento" HeaderText="id_Medicamento"/>
                    <asp:BoundField DataField="nombremed" HeaderText="NombreMed"/>
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion"/>
                    <asp:BoundField DataField="precio" HeaderText="precio"/>
                    <asp:BoundField DataField="accionTerapeutica" HeaderText="Accion Terapeutica"/>
                    <asp:BoundField DataField="fechaVencimiento" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento"/>
                    <asp:BoundField DataField="nombre" HeaderText="Laboratorio"/>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Opciones" SelectText="Editar"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
