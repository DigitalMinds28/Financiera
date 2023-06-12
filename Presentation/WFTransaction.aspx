<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFTransaction.aspx.cs" Inherits="Presentation.WFTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />
<link href="resources/css/bootstrap.min.css" rel="stylesheet" />
<div class="container">
    <%--Idtransaccion--%>
    <div class="form-group">
        <asp:Label ID="LblIdTransaccion" runat="server" Text="Id transaccion"></asp:Label>
        <asp:TextBox ID="TBIdTransaccion" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <%--TranFechayHora--%>
    <div class="form-group">
        <asp:Label ID="LblTranFechayHora" runat="server" Text="Fecha y Hora"></asp:Label>
        <asp:TextBox ID="TBTranFechayHora" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <%--TranTipo--%>
    <div class="form-group">
        <asp:Label ID="LblTipo" runat="server" Text="Tipo"></asp:Label>
        <asp:DropDownList ID="DDLTipo" runat="server" CssClass="form-control">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="efectivo">Efectivo</asp:ListItem>
                <asp:ListItem Value="Transaccion">Transaccion</asp:ListItem>
                </asp:DropDownList><br />
    </div>

    <%--TranMonto--%>
    <div class="form-group">
        <asp:Label ID="LblTranMonto" runat="server" Text="Monto"></asp:Label>
        <asp:TextBox ID="TBTranMonto" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <%--TranCuentaDestino--%>
    <div class="form-group">
        <asp:Label ID="LblTranCuentaDestino" runat="server" Text="Id Cuenta Destino"></asp:Label>
        <asp:DropDownList ID="DDLCuentaDestino" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <%--CuentaId--%>
    <div class="form-group">
        <asp:Label ID="LblCuentaId" runat="server" Text="Id Cuenta"></asp:Label>
        <asp:DropDownList ID="DDLCuentaId" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <%--UbicacionId--%>
    <div class="form-group">
        <asp:Label ID="LblUbicacionId" runat="server" Text="Id Ubicacion"></asp:Label>
        <asp:DropDownList ID="DDLUbicacionId" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
</div>


    <%--Botones--%>
    <div class="text-center">
    <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="Button1_Click" />
        </div>
    <%--Mensaje--%>
    <asp:Label ID="Lblmsj" runat="server" Text=" "></asp:Label>

    <%--Tabla--%>
        <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion de la transaccion</h2>
</div>
 <asp:GridView ID="GVTransaccion" runat="server" OnRowDeleting="GVTransaccion_RowDeleting" AutoGenerateColumns="False" OnSelectedIndexChanged="GVTransaccion_SelectedIndexChanged" DataKeyNames="tran_id" CssClass="table table-striped table-dark">
    <Columns>
        <asp:BoundField DataField="tran_id" HeaderText="Id transaccion " />
        <asp:BoundField DataField="tran_fecha_hora" HeaderText="Fecha y hora" />
        <asp:BoundField DataField="tran_tipo" HeaderText="Tipo de transaccion" />
        <asp:BoundField DataField="tran_monto" HeaderText="Monto " />
        <asp:BoundField DataField="tran_cuenta_destino_id" HeaderText="Cuenta destino" />
        <asp:BoundField DataField="tbl_cuenta_cue_id" HeaderText="Cuenta origen" />
        <asp:BoundField DataField="tbl_ubicacion_ubi_id" HeaderText="Id Ubicacion" />
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
        <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
    </Columns>
</asp:GridView>
</asp:Content>
