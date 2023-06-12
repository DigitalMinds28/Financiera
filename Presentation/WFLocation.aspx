<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFLocation.aspx.cs" Inherits="Presentation.WFLocation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />

<div class="container">
    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="form-group">
                <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
                <asp:TextBox ID="TBId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="LblUbicacion" runat="server" Text="Nombre_Ubicacion"></asp:Label>
                <asp:TextBox ID="TBUbicacion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
</div>

    
    <%--Botones--%>
    <div class="text-center">
    <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" />
    <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BtnActualizar_Click" />
        </div>
    <%--Mensaje--%>
    <asp:Label ID="LblMensaje" runat="server" Text="  "></asp:Label><br />

    <%--Tabla--%>
        <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion de la ubicacion </h2>
</div>
    <asp:GridView ID="GVLocation" runat="server" OnRowDeleting="GVLocation_RowDeleting" AutoGenerateColumns="False" DataKeyNames="ubi_id" OnSelectedIndexChanged="GVLocation_SelectedIndexChanged" CssClass="table table-striped table-dark">
        <Columns>
            <asp:BoundField DataField="ubi_id" HeaderText="Id Ubicacion " />
            <asp:BoundField DataField="ubi_nombre" HeaderText="Nombre del lugar" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:CommandField ShowDeleteButton="True"  ControlStyle-CssClass="btn btn-danger"/>
        </Columns>
    </asp:GridView>
</asp:Content>
