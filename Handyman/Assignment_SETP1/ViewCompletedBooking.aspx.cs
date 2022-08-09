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
    public partial class ViewCompletedBooking : System.Web.UI.Page
    {
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
                            TextBoxserviceDate.Text = sdr["appoointmentDateTime"].ToString();
                            TextBoxuserComment.Text = sdr["customerComment"].ToString();
                            TextBoxamountPaid.Text = sdr["bookingPrice"].ToString();
                            TextBoxcustName.Text = sdr["customerName"].ToString();
                            TextBoxaddress.Text = sdr["customerAddress"].ToString();
                        }
                        con.Close();
                    }
                }

            }
        }

        protected void backbutton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompletedBooking.aspx");
        }
    }
}