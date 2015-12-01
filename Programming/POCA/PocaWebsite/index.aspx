<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PocaWebsite.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link href="~/CSS/graphics.css" rel="Stylesheet" type="text/css" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="style3">
            <div style="text-align: center" class="style3">
                <asp:Label ID="lblPocaName" runat="server" Text="P.O.C.A" Font-Size="XX-Large"></asp:Label>
            </div>
            <div style="text-align: center">
                <asp:Label ID="lblUserName" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div style="text-align: center">
                <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
                <input id="txtPassword" type="password" />
            </div>
            <div style="text-align: center">
                <asp:Button ID="btnLogin" runat="server" Text="Login" Width="194px" />
            </div>
            <div style="text-align: center">
                <asp:HyperLink ID="hlRegiter" runat="server" NavigateUrl="~/register.aspx">Don't have an account ? Click here to create one now.</asp:HyperLink>
            </div>
            <div style="text-align: center">
                <asp:HyperLink ID="hlForget" runat="server" NavigateUrl="~/forgetPassword.aspx">Did you forget your password? Click here to recover.</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
