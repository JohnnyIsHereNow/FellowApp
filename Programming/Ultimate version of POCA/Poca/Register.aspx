<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="javaScripts/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="javaScripts/BirthdaySelection.js"></script>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }

        .auto-style2 {
            text-align: center;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <h1 class="auto-style1"><a href="Login.aspx" style="text-align: center">P.O.C.A</a></h1>
            <table class="auto-style2"> 
            <tr> 
            <p class="auto-style1">
            <td><asp:Label ID="lbRealName" runat="server" Text="Real Name: "></asp:Label>
            <td><asp:TextBox ID="txtRealName" runat="server"></asp:TextBox>
            <td>    <asp:RequiredFieldValidator 
                ID="lastFieldValidator"
                ControlToValidate="txtRealName"
                Display="Dynamic"
                runat="server"
                ErrorMessage="Please enter your real name">
                </asp:RequiredFieldValidator>
                </p>
            <tr>
            <p class="auto-style1">        
            <td><asp:Label ID="lbEmail" runat="server" Text="E-mail: "></asp:Label>
            <td><asp:TextBox ID="txtEmail" runat="server" style="text-align:center"></asp:TextBox>
                <td><asp:RegularExpressionValidator 
                ID="emailValidator"
                Display="Dynamic"
                runat="server" 
                ValidationExpression ="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ControlToValidate ="txtEmail"
                ErrorMessage ="Invalid email format">
                </asp:RegularExpressionValidator>
                </p>
            <tr>    
            <p class="auto-style1">        
            <td><asp:Label ID="lbUsername" runat="server" Text="Username: "></asp:Label>
            <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <td><asp:RequiredFieldValidator 
                ID="userFieldValidator"
                ControlToValidate="txtUsername"
                Display="Dynamic"
                runat="server"
                ErrorMessage="Please enter a username">
                </asp:RequiredFieldValidator>
                </p>
            <tr>
            <p class="auto-style1">        
            <td><asp:Label ID="lbPassword" runat="server" Text="Password: "></asp:Label>
            <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                <td><asp:RequiredFieldValidator 
                ID="passwordFieldValidator"
                ControlToValidate="txtPassword"
                Display="Dynamic"
                runat="server"
                ErrorMessage="Please enter a password">
                </asp:RequiredFieldValidator>
                </p>
            <tr>    
            <p class="auto-style1">    
            <td><asp:Label ID="lbPasswordAgain" runat="server" Text="Re-type Password: "></asp:Label>
            <td><asp:TextBox ID="txtRePassword" TextMode="Password" runat="server"></asp:TextBox>
                <td><asp:RequiredFieldValidator 
                ID="rePassFieldValidator"
                ControlToValidate ="txtRePassword"
                ControlToCompare = "txtPassword"
                Display="Dynamic"
                runat="server"
                ErrorMessage="Passwords do not match">
                </asp:RequiredFieldValidator>
                </p>
            </table>
            <p class="auto-style1">
            <asp:Label ID="lbBirthDate" runat="server" Text="Birthdate: "></asp:Label>
            <select id="days" name="days"></select>
            <select id="months" name="months"></select>
            <select id="years" name="years"></select>
            </p>

        <p class="auto-style1">Passion 1:
            <asp:DropDownList ID="passion1" runat="server">
            </asp:DropDownList>
        </p>
        <p class="auto-style1">Passion 2:
            <asp:DropDownList ID="passion2" runat="server">
            </asp:DropDownList>
        </p>
        <p class="auto-style1">Passion 3:
            <asp:DropDownList ID="passion3" runat="server">
            </asp:DropDownList>
        </p>
        <p class="auto-style1">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </p>
        <p class="auto-style1">
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
            <%--<asp:Button ID="Login" runat="server" Text="Login" OnClick="Button2_Click" />--%>
        </p>
    
    </div>
    </form>
</body>
</html>
