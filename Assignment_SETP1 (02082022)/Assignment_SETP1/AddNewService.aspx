<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewService.aspx.cs" Inherits="Assignment_SETP1.AddNewService" %>

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

        .auto-style24 {
            margin-left: 42px;
        }
        .auto-style25 {
            width: 370px;
            height: 15px;
        }
        .auto-style26 {
            width: 370px;
            height: 15px;
        }
        .auto-style27 {
            width: 370px;
            height: 15px;
        }
        </style>
</head>
<body style="height: 750px">
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

        <!--Service table-->
        <div class="main">
        <br />
        <h2 class="servicetitle">My Services</h2>

        <ul class="servicemenu">
        <li style="width:200px;"><a href="MyServices.aspx" ><img src="repairing-service.png" width="50" height="50"/><br />My Services</a></li>
        <li style="width:200px;" ><a href="AddNewService.aspx" style="color:#4169E1;"><img src="plus.png" width="50" height="50"/><br />Add New Service</a></li>
        </ul>
<br />
       <div class="viewservicetable">
           <table class="auto-style1">
               <tr>
                   <td class="viewservicetableheader" colspan="3">Add New Service</td>
               </tr>
               <tr class="unusedviewservicerow1">
                   <td class="auto-style25"></td>
                   <td class="auto-style26"></td>
                   <td class="auto-style27"></td>
               </tr>
               <tr class="viewservicetitlerow3">
                   <td class="viewservicetitle3">Title</td>
                   <td class="viewservicetitle3">Description</td>
                   <td class="viewservicetitle3">Price Range ($)</td>
               </tr>
               <tr>
                   <td class="descriptiontextbox">
                       <asp:TextBox cssclass="descriptiontextbox" ID="TextBoxtitle" runat="server" Width="320px" Height="60px" TextMode="MultiLine" Wrap="True" BorderStyle="Solid" BorderColor="Gray" ></asp:TextBox>
                   </td>
                   <td class="descriptiontextbox">
                       <asp:TextBox cssclass="descriptiontextbox" ID="TextBoxdescription" runat="server" Width="320px" Height="60px" TextMode="MultiLine" Wrap="True" BorderStyle="Solid" BorderColor="Gray" ></asp:TextBox>
                   </td>
                   <td class="textboxtoadjust2">
                       <asp:TextBox ID="TextBoxpriceRange" runat="server" Width="320px"></asp:TextBox>
                   </td>
               </tr>
               <tr class="unusedviewservicerow2">
                   <td class="auto-style11"></td>
                   <td class="auto-style17"></td>
                   <td class="auto-style21"></td>
               </tr>
               <tr>
                   <td class="auto-style12"></td>
                   <td class="auto-style18"></td>
                   <td class="tdcancelandupdatebutton2">
                       <asp:LinkButton CssClass="cancelbutton2" ID="CancelButton4" runat="server" OnClick="cancelbutton4_Click">Cancel</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                       <asp:LinkButton CssClass="submitbutton1" ID="SubmitButton1" runat="server" OnClick="submitbutton1_Click">Submit</asp:LinkButton>
                   </td>
               </tr>
           </table>
           </div>
             </div>
       <br />
   </form> 
</body>
</html>
