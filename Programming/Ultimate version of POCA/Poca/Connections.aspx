<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Connections.aspx.cs" Inherits="Connections" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }

        .panel {
            text-align: center;
             margin: 0 auto; 
             width: 650px;
             
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <h1><a href="Search.aspx" style="text-align: center">P.O.C.A <% Response.Write(Request.Cookies["userName"].Value); %></a></h1>
        <asp:Panel ID="Panel_Controls" runat="server" CssClass ="panel" ></asp:Panel>
    </div>
    </form>
</body>
</html>
