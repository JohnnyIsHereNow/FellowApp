<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking.aspx.cs" Inherits="Booking" %>

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
    <div>
         <h1 class="auto-style1"><a href="Search.aspx" style="text-align: center">P.O.C.A <% Response.Write(Request.Cookies["userName"].Value); %></a></h1>
         <p class="auto-style1">
             <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
         </p>

    </div>
        <p style="text-align: center">
            <asp:DropDownList ID="ddlAdvisors" runat="server" Height="30px" Width="380px" OnSelectedIndexChanged="ddlAdvisors_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
&nbsp;
            <asp:DropDownList ID="ddlDates" runat="server" Height="30px" Width="380px" AutoPostBack="true" OnSelectedIndexChanged="ddlDates_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p style="text-align: center">
            <asp:Button ID="btnBook" runat="server" Text="Try to book" OnClick="btnBook_Click" Enabled="false" />
        </p>
        <p style="text-align: center">
            <asp:Label ID="lblCheckBookings" runat="server" Text="Check your bookings:" style="font-size: x-large"></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:DropDownList ID="ddlAdvisors0" runat="server" Height="30px" Width="380px" OnSelectedIndexChanged="ddlAdvisors0_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDates0" runat="server" Height="30px" Width="380px" AutoPostBack="true" OnSelectedIndexChanged="ddlDates0_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p style="text-align: center">
            <asp:Button ID="btnRemoveBook" runat="server" Text="Cancel booking!" Enabled ="false" OnClick="btnRemoveBook_Click" />
        </p>
        <p style="text-align: center">
            <asp:Label ID="lblBookedDates" runat="server" Text="Booked dates:" style="font-size: x-large"></asp:Label>
        </p>
        <p style="text-align: center">
            <asp:DropDownList ID="ddlBookedDates" runat="server" Height="19px" OnSelectedIndexChanged="ddlBookedDates_SelectedIndexChanged" style="margin-left: 0px" Width="284px">
            </asp:DropDownList>
        </p>
        <p style="text-align: center">
            <asp:Label ID="lblAddDate" runat="server" Text="Add available date:"></asp:Label>
        </p>
       <div style="width:15%; margin: 0 auto;">
        <p style="text-align: center">
            <asp:Calendar ID="calDate" runat="server" ondayrender="calDate_DayRender"  ></asp:Calendar>
             <div style="width:15%; margin: 0 auto;">
        <p style="text-align: center">
            <asp:Label ID="lbHour" runat="server" Text="Hour: " ></asp:Label>
            <asp:DropDownList ID="ddlHour" runat="server">
            </asp:DropDownList>
            </p>
                 </div>
        </p>
           <p style="text-align: center">
               <asp:Button ID="btnAddBook" runat="server" Text="Add available date!" OnClick="btnAddBook_Click" />
        </p>
           </div>
    </form>
</body>
</html>
