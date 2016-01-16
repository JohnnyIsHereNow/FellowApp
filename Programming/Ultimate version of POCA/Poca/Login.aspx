<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body style="text-align: justify">
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <h1 class="auto-style1"><a href="Login.aspx">P.O.C.A</a></h1>
    
    </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <h1 style="text-align: center">
            Log in</h1>
        <p style="text-align: center" class="auto-style1">
            Username:
            <asp:TextBox ID="txtUsername" runat="server" ></asp:TextBox>
        </p>
    <p style="text-align: center">
        Password: 
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p style="text-align: center">
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </p>
        <p style="text-align: center">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </p>
    </form>
    <p style="text-align: center" ><a href="RecoverPassword.aspx">
        Click here if you forgot your username.</a></p>
    <p style="text-align: center"><a href="Register.aspx">
        Not register yet ? Click here to create an account !</a></p>
</body>
</html>
