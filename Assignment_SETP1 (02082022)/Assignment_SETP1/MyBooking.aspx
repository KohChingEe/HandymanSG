<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBooking.aspx.cs" Inherits="Assignment_SETP1.MyBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="MyBookingStyleSheet.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat:400,400i,700" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin='anonymous'></script>
</head>
<body>
    <form id="form1" runat="server">
           <div class="container">
             <div style=" font-size:larger; padding-left:17px;"><h1>HANDYMAN</h1></div>
                  <div class="menucontainer">
                      <div class="dropdown">
                            <a class="dropbtn" href="#myaccount">My Account  <i class='far fa-user'></i></a>
                              <div class="dropdown-content">
                              <a href="MyAccount.aspx">My Account</a>
                              <a href="MyServices.aspx">My Services</a>
                              <a href="MyBooking.aspx">My Booking</a>
                              <a href="#">Sign Out</a>
                              </div>
                      </div>
                  <div class="menucontainer"><a href="MyServices.aspx">Services</a></div>   
                  <div class="menucontainer"><a href="BusinessHomepage.aspx">Home</a></div>
           </div>
          </div>
        <br />

        <!--Booking table-->
        <div class="main">
        <br />
        <h2 class="bookingtitle">My Booking</h2>

        <ul class="bookingmenu">
        <li style="width:220px;"><a href="MyBooking.aspx" style="color:#4169E1;"><img src="booking.png" width="50" height="50"/><br />New Bookings</a></li>
        <li style="width:220px;"><a href="PendingBookings.aspx"><img src="calendar (1).png" width="50" height="50"/><br />Pending Bookings</a></li>
        <li style="width:220px;"><a href="CompletedBooking.aspx"><img src="calendar.png" width="50" height="50"/><br />Completed</a></li>
        </ul>
<br />
            <!--Search bar-->
        <!--<div class="search-container">
         
  <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="90%" placeholder="Search.." OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button"  /> 
        </div>
        <br />-->
            <!--table-Gridview-->
        <div class="tablesection">
            <asp:GridView ID="GridView1" runat="server"
                CssClass="mybookingdatagrid" PagerStyle-CssClass="bookingpager" EmptyDataRowStyle-CssClass="emptytable"
 HeaderStyle-CssClass="bookingheader" RowStyle-CssClass="bookingrows" AllowPaging = "True" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="False" CellPadding="8" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:BoundField DataField ="Sn" HeaderText="S/N" >
                    <HeaderStyle Width="3%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="Date" HeaderText="Date" >
                    <HeaderStyle Width="13%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="Bookingref" HeaderText="Booking Reference" >
                    <HeaderStyle Width="12%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="UserComment" HeaderText="User Comment" >
                    <HeaderStyle Width="17%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="ServiceDate" HeaderText="Service Date" >
                    <HeaderStyle Width="13%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="CustName" HeaderText="Customer Name" >
                    <HeaderStyle Width="14%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="Address" HeaderText="Address" >
                    <HeaderStyle Width="20%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Action" >
                        <ItemTemplate>
                            <asp:LinkButton ID="ViewButton1" runat="server" CssClass="viewbutton" Text="View" OnCommand="ViewButton1_Click" CommandName="view" CommandArgument='<%# Eval("BookingRef")%>'>
                                
                            </asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="8%" />
                    </asp:TemplateField>
                </Columns>
                <emptydatarowstyle CssClass="emptyrow" backcolor="white" BorderColor="white" borderstyle="none" 
          forecolor="black" Font-Size="Large" Font-Italic="true" Height="50px"/> 
                <EmptyDataTemplate>No New Booking</EmptyDataTemplate>
<HeaderStyle CssClass="bookingheader"></HeaderStyle>

<PagerStyle CssClass="bookingpager"></PagerStyle>

<RowStyle CssClass="bookingrows"></RowStyle>
            </asp:GridView>
          </div>
            </div>
        <br />

    </form> 
</body>
</html>
