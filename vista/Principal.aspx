<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="vista_Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Principal</title>
    <script src="../plugins/jquery/jquery-3.3.1.js"></script>
    <script src="../plugins/js/global.js"></script>
    <script src="../plugins/js/login.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <span><asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkCerrar_click" CssClass="nav-text">Cerrar Sesión</asp:LinkButton></span>
        </div>
    </form>
</body>
</html>
