<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LOGINWEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="login-container">
        <h1>INGRESAR</h1>
        <div id="loginError" class="error-message"></div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="username" Text="USUARIO:" />
            <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="username" ErrorMessage="El nombre de usuario es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="password" Text="CONTRASEÑA:" />
            <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="password" ErrorMessage="La contraseña es obligatoria" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
