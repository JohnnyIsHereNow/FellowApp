<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

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
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        <h1><a href="Login.aspx">P.O.C.A</a></h1>
        <h1>Recover password.</h1>
    
    </div>
        <p style="text-align: center">
            Username: </p>
        <p style="text-align: center">
            <asp:TextBox ID="TextBox1" runat="server" Width="429px"></asp:TextBox>
        </p>
        <p style="text-align: center">
            Secret question:</p>
        <p style="text-align: center">
&nbsp;<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 0px" Width="429px"></asp:TextBox>
        </p>
        <p class="auto-style1">
            Answer:</p>
        <p style="text-align: center">
&nbsp;<asp:TextBox ID="TextBox2" runat="server" style="text-align: right" Width="433px"></asp:TextBox>
        </p>
        <p style="text-align: center">
            New password:
        </p>
        <p style="text-align: center">
            <asp:TextBox ID="TextBox4" runat="server" style="text-align: right" Width="433px"></asp:TextBox>
        </p>
        <p style="text-align: center">
            Repeat new password:</p>
        <p style="text-align: center">
            <asp:TextBox ID="TextBox5" runat="server" style="text-align: right" Width="433px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Recover password." />
    </form>
    <p>
        No error for now.</p>
</body>
</html>
