<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebsiteT1.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank you for registering!</title>
    <script type="text/javascript" src="javascripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="javascripts/BirthdaySelection.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:Label runat="server" Text="P.O.C.A" Font-Size="XX-Large"></asp:Label>
        <!--Profile Picture-->
            <asp:Image ID="profileImage" runat="server" Width="100" Height="100" ImageUrl="~/Images/missing.png" /> <br>
            <asp:FileUpload ID="FileUploadControl" runat="server" />            <br>
            <table style="width:auto; text-align:center">
                <tr>
            <td> <asp:Label ID="lbFirstName" runat="server" Text="First Name: "></asp:Label></td>
            <td><asp:TextBox ID="txtFirstName" runat="server" style="text-align:center"></asp:TextBox>
                <asp:RequiredFieldValidator 
                ID="nameValidator"
                ControlToValidate="txtFirstName"
                Display="Static"
                runat="server"
                ErrorMessage="Please enter your first name">
                </asp:RequiredFieldValidator>
            </td>
                </tr>
                <tr>
            <td><asp:Label ID="lbLastName" runat="server" Text="Last Name: " style="text-align:center"></asp:Label></td>
            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                ID="lastFieldValidator"
                ControlToValidate="txtLastName"
                Display="Static"
                runat="server"
                ErrorMessage="Please enter your last name">
                </asp:RequiredFieldValidator>
            </td>
                </tr>
                <tr>
            <td><asp:Label ID="lbEmail" runat="server" Text="E-mail: "></asp:Label>
            </td>
            <td><asp:TextBox ID="txtEmail" runat="server" style="text-align:center"></asp:TextBox>
                <asp:RegularExpressionValidator 
                ID="emailValidator"
                Display="Static"
                runat="server" 
                ValidationExpression ="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ControlToValidate ="txtEmail"
                ErrorMessage ="Invalid email format">
                </asp:RegularExpressionValidator>
            </td>
                </tr>
                <tr>
            <td><asp:Label ID="lbUsername" runat="server" Text="Username: "></asp:Label></td>
            <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                ID="userFieldValidator"
                ControlToValidate="txtUsername"
                Display="Static"
                runat="server"
                ErrorMessage="Please enter a username">
                </asp:RequiredFieldValidator>
            </td>
                </tr>
                <tr>
            <td><asp:Label ID="lbPassword" runat="server" Text="Password: "></asp:Label></td>
            <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                ID="passwordFieldValidator"
                ControlToValidate="txtPassword"
                Display="Static"
                runat="server"
                ErrorMessage="Please enter a password">
                </asp:RequiredFieldValidator>
            </td>
                </tr>
                <tr>
            <td><asp:Label ID="lbPasswordAgain" runat="server" Text="Re-type Password: "></asp:Label></td>
            <td><asp:TextBox ID="txtRePassword" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator 
                ID="rePassFieldValidator"
                ControlToValidate ="txtRePassword"
                ControlToCompare = "txtPassword"
                Display="Static"
                runat="server"
                ErrorMessage="Passwords do not match">
                </asp:RequiredFieldValidator>
            </td>
                </tr>
            </table>

            <asp:Label ID="lbBirthDate" runat="server" Text="Birthdate: "></asp:Label>
            <select id="days" name="days"></select>
            <select id="months" name="months"></select>
            <select id="years" name="years"></select>
            <br />

            <asp:Button runat="server" ID="UploadButton" Text="Register" OnClick="RegisterButton_Click" /><br> 
            <asp:Label ID="StatusLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
