<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFCustomer.aspx.cs" Inherits="Presentation.WFCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />
   <link href="resources/css/bootstrap.min.css" rel="stylesheet" />
<div class="container">
    <div class="row">
        <div class="form-group col-md-3">
            <%--id--%>
            <asp:Label ID="LblId" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="TBId" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <%--identificacion--%>
            <asp:Label ID="LblIdentificacion" runat="server" Text="Identificacion"></asp:Label>
            <asp:TextBox ID="TBIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <%--Nombre--%>
            <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="TBNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <%--Apellido--%>
            <asp:Label ID="LblApellido" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="TBApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <%--Telefono--%>
            <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="TBTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
</div>

    <%--Botones--%>
    <div class="text-center">
  <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" />
  <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BtnActualizar_Click" />
</div>
     <%--Mensaje--%>
    <asp:Label ID="LblMensaje" runat="server" Text=" "></asp:Label><br />

    <%--Tabla--%>
    <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion del cliente</h2>
</div>
    <asp:GridView ID="GVCustomer" runat="server" OnRowDeleting="GVCustomer_RowDeleting1" AutoGenerateColumns="False" OnSelectedIndexChanged="GVCustomer_SelectedIndexChanged" DataKeyNames="clie_id" CssClass="table table-striped table-dark">
        <Columns>
            <asp:BoundField DataField="clie_id" HeaderText="Id Cliente " />
            <asp:BoundField DataField="clie_identificacion" HeaderText="Identificacion" />
            <asp:BoundField DataField="clie_nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="clie_apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="clie_telefono" HeaderText="Telefono" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView><br />
</asp:Content>
