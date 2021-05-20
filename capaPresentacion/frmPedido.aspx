<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPedido.aspx.cs" Inherits="capaPresentacion.frmPedido" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .modalBackground{
            background-color: black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 !important;
            z-index:20;
        }
        .modalPopup{
            padding:20px 0px 24px 10px;
            position: relative;
            width:550px;
            height:300px;
            background-color:white;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <center>
    <a href="frmLaboratorio.aspx">Laboratorios</a>&nbsp;
    <a href="frmMedicamento.aspx">Medicamentos</a>
    <a href="frmUsuario.aspx">Usuario</a>
    <a href="frmPedido.aspx"> Pedido</a>
    <a href="frmAlmacen.aspx"> Almacen</a>
        <h3>REGISTRO DE PEDIDOS</h3>
        
        <form id="form1" runat="server">
            <div>
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdPedido" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtIdUsuario" Type="hidden" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>FechaPedido</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtFechaPedido" type="date" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Usuario</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><a href="#" runat="server" onserverclick="buscarUsuario">Buscar Usuario</a></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell><a href="#" runat="server" onserverclick="buscarMedicamento">Agregar Medicamento</a></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <%--Tabla detalle Pedido--%>
                <div>
                    <asp:GridView ID="gvDetalle" Width="500px" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvDetalle_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Quitar"/>
                            <asp:BoundField DataField="id_medicamento" HeaderText="Codigo"/>
                            <asp:BoundField DataField="descripcion" ItemStyle-Width="150" HeaderText="Descripcion"/>
                            <asp:BoundField DataField="precio" HeaderText="Precio"/>
                            <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidad" Width="90px" runat="server">1</asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="precio" ItemStyle-HorizontalAlign="Right" HeaderText="SubTotal"/>
                        </Columns>
                    </asp:GridView>
                    <asp:Table runat="server" Width="500px">
                        <asp:TableRow>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px"></asp:TableCell>
                            <asp:TableCell Width="100px" HorizontalAlign="Right">
                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>             

                </div>
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>&nbsp;
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>&nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/><br />
                <asp:Label ID="lblResp" runat="server" Text=""></asp:Label>
            </div>

            <%--Modales Usuario Medicamento--%>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <%--Inicio modal buscar usuario--%>
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="miModalU" runat="server" TargetControlID="lblUsuario" PopupControlID="modalUsuario" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            
            <div id="modalUsuario" class="modalPopup">
                 <div id="Header" class="header" >
                     Busqueda de Usuarios
                     <br />
                     <br />
                 </div>
                 <div id="main" class="main">
                    <asp:TextBox ID="txtBuscarU" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarUs" runat="server" Text="Buscar por Nombre" OnClick="btnBuscarUsuario"/>
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
                             <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns> 
                    </asp:GridView>

                 </div>
                 <div>  
                     <br />
                      <asp:Button id="btnCerrarC" runat="server" text="Cerrar" OnClick="btnCerrarCli" />
                 </div>
            </div>
            <%--Fin modal buscar usuario--%>

            <%--Inicio modal buscar medicamento--%>
             <asp:Label ID="lblMedicamento" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="miModalM" runat="server" TargetControlID="lblMedicamento" PopupControlID="modalMedicamento" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            <div id="modalMedicamento" class="modalPopup">
                 <div id="Header2" class="header" >
                     Seleccione uno o varios medicamentos
                     <br />
                     <br />
                 </div>
                 <div id="main2" class="main">
                    <asp:TextBox ID="txtBuscarM" runat="server"></asp:TextBox>&nbsp;
                      <asp:Button ID="btnBuscarMed" runat="server" Text="Buscar por Nombre" OnClick="btnBuscarM"/><br />
                   
                    <br />
                     <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="gvMedicamento" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvMedicamento_SelectedIndexChanged">
                        <Columns>
                           <asp:BoundField DataField="id_medicamento" HeaderText="id_Medicamento"/>
                            <asp:BoundField DataField="nombremed" HeaderText="NombreMed"/>
                            <asp:BoundField DataField="descripcion" HeaderText="descripcion"/>
                            <asp:BoundField DataField="precio" HeaderText="precio"/>
                            <asp:BoundField DataField="accionTerapeutica" HeaderText="Accion Terapeutica"/>
                            <asp:BoundField DataField="fechaVencimiento" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento"/>
                            <asp:BoundField DataField="nombre" HeaderText="Laboratorio"/>
                             <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>
                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarP" runat="server" text="Cerrar" OnClick="btnCerrarPro" />
                 </div>
            </div>
            <%--Fin modal buscar medicamento--%>   
            
            <%--Inicio modal buscar pedido--%>
            <asp:Label ID="lblPedido" runat="server" Text=""></asp:Label>
            <ajaxToolkit:ModalPopupExtender ID="miModalP" runat="server" TargetControlID="lblPedido" PopupControlID="modalPedido" 
                BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
            
            <div id="modalPedido" class="modalPopup">
                 <div id="Header3" class="header" >
                     Busqueda de Pedido
                     <br />
                     <br />
                 </div>
                 <div id="main3" class="main">
                    <asp:TextBox ID="txtBuscarP" runat="server"></asp:TextBox>&nbsp;
                    <asp:Button ID="btnBuscarPed" runat="server" Text="Buscar por Nombre de Usuario" OnClick="btnBuscarP"/>
                    <br />
                    <br />
                    <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPedido_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id_pedido" HeaderText="IdPedido"/>
                            <asp:BoundField DataField="fecha" DataFormatString="{0:d}" HeaderText="FechaPedido"/>
                            <asp:BoundField DataField="total" HeaderText="Total"/>
                            <asp:BoundField DataField="usuario" HeaderText="Usuario"/>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Opcion" SelectText="Seleccionar"/>
                        </Columns>
                    </asp:GridView>

                 </div>
                 <div>
                     <br />
                      <asp:Button id="btnCerrarV" runat="server" text="Cerrar" OnClick="btnCerrarVent" />
                 </div>
            </div>
            <%--Fin modal buscar pedido--%>
        </form> 
    </center>
</body>
</html>
