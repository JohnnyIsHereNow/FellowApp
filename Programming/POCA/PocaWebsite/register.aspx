<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="PocaWebsite.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--Poca title-->
        <div>
            <asp:Label runat="server" Text="P.O.C.A" Font-Size="XX-Large"></asp:Label>
        <!--Profile Picture-->
            <asp:Image ID="profileImage" runat="server" Width="100" Height="100" ImageUrl="~/Images/missing.png" />
            <asp:FileUpload ID="FileUploadControl" runat="server" />            
        <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />            
        <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
            <asp:Label ID="lbFirstName" runat="server" Text="First Name: "></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>

            <asp:Label ID="lbLastName" runat="server" Text="Last Name: "></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

            <asp:Label ID="lbEmail" runat="server" Text="E-mail: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            <asp:Label ID="lbUsername" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

            <asp:Label ID="lbPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>

            <asp:Label ID="lbPasswordAgain" runat="server" Text="Write password again: "></asp:Label>
            <asp:TextBox ID="txtPasswordAgain" runat="server"></asp:TextBox>

            <asp:Label ID="lbBirthDate" runat="server" Text="Birthdate: "></asp:Label>
            <asp:Calendar ID="calBirthDate" runat="server" style="margin-left: 287px; margin-top: 0px" Width="279px"></asp:Calendar>
        </div>
    </form>
</body>
</html>
