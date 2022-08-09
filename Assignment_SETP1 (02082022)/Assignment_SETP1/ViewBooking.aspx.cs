using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment_SETP1
{
    public partial class ViewBooking : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TextBoxbookingID.Text = Session["Bookingref"].ToString();

            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customer.CustomerBookingInfo B, Customer.CustomerProfileInfo P WHERE B.customerUserID = P.userID AND BookingID ='" + TextBoxbookingID.Text + "';"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                       
                        TextBoxbookingID.Text = sdr["BookingID"].ToString();
                        TextBoxdate.Text = sdr["bookingCreationDateTime"].ToString();
                        TextBoxuserComment.Text = sdr["customerComment"].ToString();
                        TextBoxserviceDate.Text = sdr["appoointmentDateTime"].ToString();
                        TextBoxcustName.Text = sdr["customerName"].ToString();
                        TextBoxaddress.Text = sdr["customerAddress"].ToString();
                        TextBoxquotedPrice.Text = sdr["bookingPrice"].ToString();
                        DropDownList1.DataSource = DropDownList1.SelectedItem.Value;
                        }
                    con.Close();
                }
                }

            }
        }


        protected void cancelbutton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Mybooking.aspx");

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void updatebutton1_Click(object sender, EventArgs e)
        {
            TextBoxbookingID.Text = Session["Bookingref"].ToString();
            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Customer.CustomerBookingInfo SET [bookingPrice]= '" + TextBoxquotedPrice.Text + "', [appoointmentStatus] = '" + DropDownList1.SelectedItem.Text + "' WHERE BookingID ='" + TextBoxbookingID.Text + "';", con))
                { cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@bookingPrice", TextBoxquotedPrice.Text);
                    cmd.Parameters.AddWithValue("@appoointmentStatus", DropDownList1.SelectedItem.Text);
                    cmd.ExecuteNonQuery();
                    ShowMessage("Service Info update sucessfully.");
                    con.Close();
                  


                }
            }
            Response.Redirect("Mybooking.aspx");
        }

        /// <summary>  
        /// This function is used for show message.  
        /// </summary>  
        /// <param name="msg"></param>  
        void ShowMessage(string msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", 
                "<script language = 'javascript' > alert('" + msg + "');</ script > ");  
        }
    }
}