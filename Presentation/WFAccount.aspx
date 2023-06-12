<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFAccount.aspx.cs" Inherits="Presentation.WFAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <%--id cuenta--%>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="TBIdCuenta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--Numero cuenta--%>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Ingrese el número de cuenta"></asp:Label>
                <asp:TextBox ID="TBNumeroCuenta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--saldo cuenta--%>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Ingrese el saldo de la cuenta"></asp:Label>
                <asp:TextBox ID="TBSaldoCuenta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--id cliente--%>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Seleccione el nombre del cliente"></asp:Label>
                <asp:DropDownList ID="DDLCustomer" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
    </div>
</div>


    <%--Botones--%>
    <div class="text-center">
    <asp:Button ID="BTNGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BTNGuardar_Click" />
    <asp:Button ID="BTNActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BTNActualizar_Click" /><br />
    </div>
    <%--Mensaje--%>
    <asp:Label ID="Lblmsj" runat="server" Text=" "></asp:Label><br />

    <%--Tabla--%>
        <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion de la cuenta</h2>
</div>
    <asp:GridView ID="GvAccount" runat="server" OnRowDeleting="GvAccount_RowDeleting" AutoGenerateColumns="False" OnSelectedIndexChanged="GvAccount_SelectedIndexChanged" DataKeyNames="cue_id" CssClass="table table-striped table-dark" >
        <Columns>
            <asp:BoundField DataField="cue_id" HeaderText="Id Cuenta" />
            <asp:BoundField DataField="cue_numero" HeaderText="Numero de cuenta" />
            <asp:BoundField DataField="cue_saldo" HeaderText="Saldo de la cuenta" />
            <asp:BoundField DataField="tbl_cliente_clie_id" HeaderText="Id Cliente" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
</asp:GridView>
</asp:Content>
