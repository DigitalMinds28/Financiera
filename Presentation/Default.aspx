<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background: #8e9eab;
            /* fallback for old browsers */
            background: -webkit-linear-gradient(to right, #eef2f3, #8e9eab);
            /* Chrome 10-25, Safari 5.1-6 */
            background: linear-gradient(to right, #eef2f3, #8e9eab);
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
        }

        .container {
            max-width: 400px;
            margin-top: 100px;
        }

        .logo {
            max-width: 200px;
            margin-bottom: 20px;
        }

        .form-label {
            font-weight: bold;
        }

        .btn-primary {
            width: 100%;
        }

        .mt-3 {
            margin-top: 1rem;
        }

        footer {
            background-color: #343a40;
            color: #ffffff;
            padding: 1rem 0;
        }

        footer .container {
            text-align: center;
        }
    </style>
</head>
<body>
    <header class="d-flex justify-content-center">
        <img class="logo" src="resources/img/1685418903820.png" />
    </header>
    <form id="form1" runat="server">
        <div class="container d-flex flex-column align-items-center">
            <h2 class="text-center">Iniciar Sesión</h2>
            <div class="mb-3">
                <label for="TBCorreo" class="form-label">Correo</label>
                <asp:TextBox ID="TBCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="TBContrasena" class="form-label">Contraseña</label>
                <asp:TextBox ID="TBContrasena" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="BtGuardar" runat="server" Text="Iniciar" OnClick="BtGuardar_Click" CssClass="btn btn-primary" />
            <asp:Label ID="LblMsg" runat="server" Text="" CssClass="mt-3"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js"></script>
    <footer class="bg-dark text-light py-4">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <asp:Label ID="Label1" runat="server" Text="2023 © Fundación Universitaria de Popayán     Desarrollado por: Estudiantes VIII semestre Ingeniería de Sistemas." CssClass="text-muted"></asp:Label>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>

