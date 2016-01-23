<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

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
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <h1><a href="Search.aspx" style="text-align: center">P.O.C.A <% Response.Write(Request.Cookies["userName"].Value); %></a></h1>
        <br />
        <asp:Button ID="btnConnections" runat="server" Text="Connections" OnClick="connections_Click" Width="126px" />
        <asp:Button ID="btnProfile" runat="server" Text="Profile" OnClick ="profile_Click" Width="110px" />
        <asp:Button ID="btnLogOut" runat="server" style="text-align: right" Text="Log out" Width="145px" OnClick="btnLogOut_Click" />
    
    </div>
        <p style="text-align: center">
            &nbsp;<asp:DropDownList ID="passion1" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="passion2" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="passion3" runat="server">
            </asp:DropDownList>
            <asp:Button  ID="searchButton" runat="server" OnClick="searchButton_Click" Text="Start searching." />
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
             <asp:Panel ID="Advanced_Search" runat="server" style="text-align: center"></asp:Panel>
            <asp:Panel ID="Panel_Controls" runat="server" style="text-align: center"></asp:Panel>
        </p>
    </form>
</body>
</html>
