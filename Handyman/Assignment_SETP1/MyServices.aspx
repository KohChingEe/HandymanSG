<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyServices.aspx.cs" Inherits="Assignment_SETP1.MyServices" %>

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

        <!--Service table-->
        <div class="main">
        <br />
        <h2 class="servicetitle">My Services</h2>

        <ul class="servicemenu">
        <li style="width:200px;"><a href="MyServices.aspx" style="color:#4169E1;"><img src="repairing-service.png" width="50" height="50"/><br />My Services</a></li>
        <li style="width:200px;"><a href="AddNewService.aspx"><img src="plus.png" width="50" height="50"/><br />Add New Service</a></li>
        </ul>
<br />
            <!--Search bar-->
        <!--<div class="search-container">
   <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="90%" placeholder="Search.." OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="button" OnClick="SearchButton1_Click"  /> 
        </div>
        <br />-->
            <!--table-Gridview-->
        <div class="servicetablesection">
            <asp:GridView ID="GridView2" runat="server"
                CssClass="myservicedatagrid" PagerStyle-CssClass="servicepager"
 HeaderStyle-CssClass="serviceheader" RowStyle-CssClass="servicerows" AllowPaging = "True" OnPageIndexChanging = "OnPaging" AutoGenerateColumns="False" CellPadding="8" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField ="Sn" HeaderText="S/N" >
                    <HeaderStyle Width="3%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="Serviceid" HeaderText="Service ID" >
                    <HeaderStyle Width="14%" />
                    </asp:BoundField>
                     <asp:BoundField DataField ="Title" HeaderText="Title" >
                    <HeaderStyle Width="17%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="Description" HeaderText="Description" >
                    <HeaderStyle Width="33%" />
                    </asp:BoundField>
                    <asp:BoundField DataField ="Price" HeaderText="Price Range ($)" >
                    <HeaderStyle Width="12%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Action" >
                        <ItemTemplate>
                            <asp:LinkButton ID="ViewButton4" runat="server" CssClass="viewbutton2" Text="Edit" OnCommand="ViewButton4_Click" CommandName="view2" CommandArgument='<%# Eval("Serviceid")%>'>
                                
                            </asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="8%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="" >
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton1" runat="server" CssClass="deletebutton1" Text="" OnCommand="DeleteButton1_Click" CommandName="delete1" CommandArgument='<%# Eval("Serviceid")%>'>
                                <img src="delete.png" alt="delete" width="25" height="25" style="vertical-align:top;"/>
                            </asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="8%" />
                    </asp:TemplateField>
                </Columns>
                <emptydatarowstyle CssClass="emptyrow" backcolor="white" BorderColor="white" borderstyle="none" 
          forecolor="black" Font-Size="Large" Font-Italic="true" Height="50px"/> 
                <EmptyDataTemplate>No Service Listed</EmptyDataTemplate>
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
