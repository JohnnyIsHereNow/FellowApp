<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfileOfOthers.aspx.cs" Inherits="ProfileOfOthers" %>

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
            <td><asp:Label ID="lbRealName" runat="server" Text="Real Name: " ></asp:Label> 
            <td><asp:TextBox ID="txtRealName" runat="server" ReadOnly="true"></asp:TextBox>
            <td>
            </p>
            </tr>
            <tr>
            <p class="auto-style1">        
            <td><asp:Label ID="lbEmail" runat="server" Text="E-mail: "></asp:Label>
            <td><asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" ></asp:TextBox>
                <td>
                </p>
            <tr>    
            <p class="auto-style1">     
            <td><asp:Label ID="lbUsername" runat="server" Text="Username: "></asp:Label>
            <td><asp:TextBox ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox>
            <td>
            </p>
            <tr>
            <p class="auto-style1">
            <asp:Label ID="lbBirthDate" runat="server" Text="Birthdate: " ></asp:Label>
            </p>

        <p class="auto-style1">Passion 1:
            <asp:Label ID="Passion1" runat="server" Text="" ></asp:Label>
        </p>
        <p class="auto-style1">Passion 2:
            <asp:Label ID="Passion2" runat="server" Text="" ></asp:Label>
        </p>
        <p class="auto-style1">Passion 3:
            <asp:Label ID="Passion3" runat="server" Text="" ></asp:Label>
        </p>
        <p class="auto-style1">
            <asp:Button ID="AddConnection" runat="server" Text="Add connection" OnClick="AddConnection_Click" />
        </p>
    
    </div>
    </form>
</body>
</html>
