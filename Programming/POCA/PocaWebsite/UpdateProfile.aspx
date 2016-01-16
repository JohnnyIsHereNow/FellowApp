<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="PocaWebsite.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <!--Poca title-->
    <div>
    <asp:Label runat="server" Text="P.O.C.A" Font-Size="XX-Large" style="margin-left:650px"></asp:Label>
        <br />
    <asp:Image ID="profileImage" runat="server" Width="100" Height="100" ImageUrl="~/Images/missing.png" style="margin-left:650px" />
        <br />
    <asp:FileUpload ID="FileUploadControl" style="margin-left:550px" runat="server" />            
        &nbsp;<asp:Button runat="server" ID="UploadButton" style="margin-left:1px" Text="Upload" OnClick="UploadButton_Click" />            
        <br />
    <asp:Label runat="server" ID="StatusLabel" style="margin-left:550px" Text="Upload status: " />

        <br />

    <asp:Label ID="lbNewFirstName" style="margin-left:550px" runat="server" Text="New First Name: "></asp:Label>
    <asp:TextBox ID="txtNewFirstName" style="margin-left: 25px" runat="server" ></asp:TextBox>

        <br />

    <asp:Label ID="lbNewLastName" runat="server" style="margin-left:550px" Text="New Last Name: "></asp:Label>
    <asp:TextBox ID="txtNewLastName" style="margin-left:27px" runat="server"></asp:TextBox>

        <br />

    <asp:Label ID="lbNewEmail" runat="server" style="margin-left:550px" Text="New e-mail address: "></asp:Label>
        <asp:TextBox ID="txtNewEmail" style="margin-left:3px" runat="server"></asp:TextBox>

        <br />

    <asp:Label ID="lbNewUsername" runat="server" style="margin-left:550px" Text="New username: "></asp:Label>
    &nbsp;<asp:TextBox ID="txtNewUsername" style="margin-left:31px" runat="server"></asp:TextBox>

        <br />

    <asp:Label ID="lbNewPassword" runat="server" style="margin-left:550px" Text="New password: "></asp:Label>
    <asp:TextBox ID="txtNewPassword" style="margin-left:36px" runat="server"></asp:TextBox>

        <br />

    <asp:Label ID="lbNewPasswordAgain" style="margin-left:550px" runat="server" Text="New password again: "></asp:Label>
    <asp:TextBox ID="txtNewPasswordAgain" style="margin-left:-3px" runat="server"></asp:TextBox>

        <br />

    <asp:Label ID="lbNewBirthDate" style="margin-left:550px" runat="server" Text="Select new birthdate: "></asp:Label>

    </div>
    <asp:Calendar ID="calNewBirthDate" runat="server" style="margin-left: 552px; margin-top: 0px" Width="279px" ></asp:Calendar>

        <p>

    <asp:Button ID="UpdateButton" style="margin-left:580px" runat="server" Text="Update details!" OnClick="UpdateButton_Click" />
    &nbsp;<asp:Button ID="DeleteButton" runat="server" Text="Delete account!" OnClick="DeleteButton_Click" />
        </p>

    </form>
</body>
</html>
