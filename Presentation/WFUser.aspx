<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFUser.aspx.cs" Inherits="Presentation.WFUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-12">
            <%--id usuario--%>
           <asp:Label ID="TBIdUser" runat="server" Text=""></asp:Label><br />

            <%--correo--%>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Correo"></asp:Label>
                <asp:TextBox ID="TBCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--contraseña--%>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server"  Text="contraseña" ></asp:Label>
                <asp:TextBox ID="TBContraseña" runat="server"
                 CssClass="form-control" TextMode="Password"></asp:TextBox><br />
            </div>

            <%--estado--%>
            <div class="form-group">
                <asp:Label ID="TBEstado" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="DDLState" runat="server" CssClass="form-control">
                <asp:ListItem Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="Activo">Activo</asp:ListItem>
                <asp:ListItem Value="Inactivo">Inactivo</asp:ListItem>
                </asp:DropDownList><br />
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
    <asp:Label ID="Lblmsj" runat="server" Text=" "></asp:Label><br />

    <%--Tabla--%>
        <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion del usuario</h2>
</div>
    <asp:GridView ID="GVUser" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" CssClass="table table-striped table-dark">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
            <asp:BoundField DataField="usu_id" HeaderText="Id usuario " />
            <asp:BoundField DataField="usu_correo" HeaderText="Correo usuario" />
            <asp:BoundField DataField="usu_contrasena" HeaderText="Contraseña usuario" />
            <asp:BoundField DataField="usu_salt" HeaderText="Salt" />
            <asp:BoundField DataField="usu_estado" HeaderText="Estado ususario" />
        </Columns>
    </asp:GridView>
</asp:Content>
