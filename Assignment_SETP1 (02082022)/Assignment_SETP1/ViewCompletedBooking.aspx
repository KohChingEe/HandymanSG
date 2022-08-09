<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCompletedBooking.aspx.cs" Inherits="Assignment_SETP1.ViewCompletedBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="MyBookingStyleSheet.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat:400,400i,700" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin='anonymous'></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style11 {
            width: 370px;
        }
        .auto-style12 {
            width: 370px;
            height: 38px;
        }
        .auto-style17 {
            width: 370px;
        }
        .auto-style18 {
            width: 370px;
            height: 38px;
        }
        .auto-style21 {
            width: 370px;
        }

        .auto-style23 {
            width: 370px;
            height: 26px;
        }
        .auto-style24 {
            margin-left: 42px;
        }
        </style>
</head>
<body style="height: 600px">
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
        <li style="width:220px;"><a href="MyBooking.aspx"><img src="booking.png" width="50" height="50"/><br />New Bookings</a></li>
        <li style="width:220px;"><a href="PendingBookings.aspx"><img src="calendar (1).png" width="50" height="50"/><br />Pending Bookings</a></li>
        <li style="width:220px;"><a href="CompletedBooking.aspx"><img src="calendar.png" width="50" height="50"/><br />Completed</a></li>
        </ul>
<br />

       <div class="viewbookingtable">
           <table class="auto-style1">
               <tr>
                   <td class="tableheader" colspan="3">Completed Booking</td>
               </tr>
               <tr class="unusedbookingrow">
                   <td class="auto-style11"></td>
                   <td class="auto-style17"></td>
                   <td class="auto-style21"></td>
               </tr>
               <tr class="bookingtitlerow">
                   <td class="bookingtitle2">Booking ID</td>
                   <td class="bookingtitle2">Service Date</td>
                   <td class="bookingtitle2">User Comment</td>
               </tr>
               <tr>
                   <td class="textboxtoadjust">
                       <asp:TextBox ID="TextBoxbookingID" runat="server" CssClass="auto-style24" Width="320px" disabled="disabled"></asp:TextBox>
                   </td>
                   <td class="textboxtoadjust">
                       <asp:TextBox ID="TextBoxserviceDate" runat="server" Width="320px" disabled="disabled"></asp:TextBox>
                   </td>
                   <td class="textboxtoadjust">
                       <asp:TextBox ID="TextBoxuserComment" runat="server" Width="320px" disabled="disabled"></asp:TextBox>
                   </td>
               </tr>
               <tr class="unusedbookingrow2">
                   <td class="auto-style11"></td>
                   <td class="auto-style17"></td>
                   <td class="auto-style21"></td>
               </tr>
               <tr>
                   <td class="bookingtitle2">Amount Paid ($)</td>
                   <td class="bookingtitle2">Customer Name</td>
                   <td class="bookingtitle2">Customer Address</td>
               </tr>
               <tr>
                   <td class="textboxtoadjust">
                       <asp:TextBox ID="TextBoxamountPaid" runat="server" Width="320px" disabled="disabled"></asp:TextBox>
                   </td>
                   <td class="textboxtoadjust">
                        <asp:TextBox ID="TextBoxcustName" runat="server" Width="320px" disabled="disabled"></asp:TextBox>
                   </td>
                   <td class="addresstextbox">
                       <asp:TextBox CssClass="addresstextbox" ID="TextBoxaddress" runat="server" Width="320px" Height="60px" TextMode="MultiLine" Wrap="True" disabled="disabled" BorderStyle="Solid" BorderColor="Gray" ></asp:TextBox>
                   </td>
               </tr>
               <tr class="unusedbookingrow3">
                   <td class="auto-style11"></td>
                   <td class="auto-style17"></td>
                   <td class="auto-style21"></td>
               </tr>
               <tr>
                   <td class="auto-style12"></td>
                   <td class="auto-style18"></td>
                   <td class="tdbackbutton">
                       <asp:LinkButton CssClass="backbutton1" ID="BackButton1" runat="server" OnClick="backbutton1_Click">Back</asp:LinkButton>
                   </td>
               </tr>
           </table>
           </div>
             </div>
       <br />
   </form> 
</body>
</html>
