<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFManager.aspx.cs" Inherits="Presentation.WFManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br /> 

<div class="container">
    <div class="row justify-content-center">
        <div class="col-sm-12 col-md-6">
            <%--Id--%>
            <div class="form-group">
                <asp:Label ID="LblId" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="TBiD" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--Nombre--%>
            <div class="form-group">
                <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="TBNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--Apellido--%>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="TBApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--Mensaje--%>
            <div class="form-group">
                <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</div>


    <%--Botones--%>
    <div class="text-center">
    <asp:Button ID="BTNGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BTNGuardar_Click" />
    <asp:Button ID="BTNActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BTNActualizar_Click" /><br /> 
    </div>
    <%--Tabla--%> 
        <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion del administrador</h2>
</div>
    <asp:GridView ID="GVManager" runat="server" OnSelectedIndexChanged="GVManager_SelectedIndexChanged1" DataKeyNames="adm_id" OnRowDeleting="GVManager_RowDeleting" AutoGenerateColumns="False" CssClass="table table-striped table-dark">
        <Columns>
            <asp:BoundField DataField="adm_id" HeaderText="Id administrador " />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger" />
        </Columns>
    </asp:GridView>
</asp:Content>
