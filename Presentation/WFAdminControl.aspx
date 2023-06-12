<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WFAdminControl.aspx.cs" Inherits="Presentation.WFAdminControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />

<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-8">
            <%--Id control administrador--%>
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="ID"></asp:Label>
                <asp:TextBox ID="TBIdControlAdministrador" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--cargo--%>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Ingrese el cargo"></asp:Label>
                <asp:TextBox ID="TBcadmCargo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <%--Id Administrador--%>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Ingrese el Id del administrador"></asp:Label>
                <asp:DropDownList ID="DDLAdmin" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <%--Id Cuenta--%>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Ingrese el número de cuenta"></asp:Label>
                <asp:DropDownList ID="DDLIdAccount" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
    </div>
</div>



    <%--Botones--%>
    <div class="text-center">
    <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="BtnGuardar_Click" />
    <asp:Button ID="BtnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="BtnActualizar_Click" /><br />
    </div>
    <%--Mensaje --%>
    <asp:Label ID="Lblmsj" runat="server" Text=" "></asp:Label><br />

    <%--Tabla--%>
        <div class="text-center">
  <h2 class="fw-bold text-primary">Informacion del control administrador</h2>
</div>
    <asp:GridView ID="GVControlAdmin" runat="server" OnSelectedIndexChanged="GVControlAdmin_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="cadm_id" CssClass="table table-striped table-dark" OnRowDeleting="GVControlAdmin_RowDeleting">
        <Columns>
            <asp:BoundField DataField="cadm_id" HeaderText="Id Control administrador " />
            <asp:BoundField DataField="cadm_cargo" HeaderText="Cargo Control administrador" />
            <asp:BoundField DataField="tbl_cuenta_cue_id" HeaderText="Id cuenta" />
            <asp:BoundField DataField="tbl_administrador_adm_id" HeaderText="Id administrador" />
            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary"/>
            <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger"/>
        </Columns>
    </asp:GridView>
</asp:Content>
