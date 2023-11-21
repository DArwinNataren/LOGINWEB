<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="LOGINWEB.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        #form1 {
            background-color: #fff;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        #GridView1 {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
        }

        #GridView1 th,
        #GridView1 td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        #GridView1 th {
            background-color: #f2f2f2;
        }

        .btn {
            background-color: #4caf50;
            color: white;
            border: none;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
            border-radius: 5px;
        }

        .btn-create {
            background-color: #4caf50;
        }

        .btn-search {
            background-color: #2196F3;
        }

        .btn-update {
            background-color: #ff9800;
        }

        .btn-delete {
            background-color: #f44336;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" AssociatedControlID="Nombre" Text="Nombre:" />
            <asp:TextBox ID="Nombre" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server" AssociatedControlID="ApellidoP" Text="Apellido Paterno:" />
            <asp:TextBox ID="ApellidoP" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server" AssociatedControlID="ApellidoM" Text="Apellido Materno:" />
            <asp:TextBox ID="ApellidoM" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server" AssociatedControlID="Matricula" Text="Matricula:" />
            <asp:TextBox ID="Matricula" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server" AssociatedControlID="Carrera" Text="Carrera:" />
            <asp:TextBox ID="Carrera" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server" AssociatedControlID="User" Text="Usuario:" />
            <asp:TextBox ID="User" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label runat="server" AssociatedControlID="Password" Text="Contraseña:" />
            <asp:TextBox ID="Password" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Button ID="btnCreate" runat="server" Text="Crear" CssClass="btn btn-create" OnClick="btnCreate_Click" />
            <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-delete" OnClick="btnDelete_Click" />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>
