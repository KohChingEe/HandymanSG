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
    public partial class CompletedBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GVbind(this.PopulateData());
            }
        }

        protected void ViewButton3_Click(object sender, EventArgs e)
        {
            LinkButton ViewButton3 = ((LinkButton)sender);
            string selectedBookingRef = ViewButton3.CommandArgument;
            Session["Bookingref"] = selectedBookingRef;
            Response.Redirect("ViewCompletedBooking.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        protected void GVbind(List<BookingInfo> bookings)
        {
            string cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS SN, B.bookingCreationDateTime, B.BookingID, B.customerComment, B.appoointmentDateTime,  P.customerName, P.customerAddress FROM Customer.CustomerBookingInfo B, Customer.CustomerProfileInfo P WHERE B.customerUserID = P.userID AND appoointmentStatus = 'Completed'; ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView1.DataSource = bookings;
                    GridView1.DataBind();
                }
                else
                {
                    //Empty DataTable to execute the “else-condition”  
                    DataTable dt = new DataTable();
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                con.Close();
            }
        }
        public class BookingInfo
        {
            public int Sn { get; set; }
            public string Bookingref { get; set; }
            public string UserComment { get; set; }
            public DateTime ServiceDate { get; set; }
            public string CustName { get; set; }
            public string Address { get; set; }
            public decimal Amount { get; set; }
        }

        private List<BookingInfo> PopulateData()
        {
            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS SN, B.BookingID, B.customerComment, B.appoointmentDateTime,  P.customerName, P.customerAddress, B.bookingPrice FROM Customer.CustomerBookingInfo B, Customer.CustomerProfileInfo P WHERE B.customerUserID = P.userID AND appoointmentStatus = 'Completed'; ", con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        List<BookingInfo> bookings = new List<BookingInfo>();
                        while (sdr.Read())
                        {
                            bookings.Add(new BookingInfo());
                            bookings[bookings.Count - 1].Sn = Convert.ToInt32(sdr["Sn"]);
                            bookings[bookings.Count - 1].Bookingref = sdr["BookingID"].ToString();
                            bookings[bookings.Count - 1].UserComment = (String)sdr["customerComment"];
                            bookings[bookings.Count - 1].ServiceDate = (DateTime)sdr["appoointmentDateTime"];
                            bookings[bookings.Count - 1].CustName = sdr["customerName"].ToString();
                            bookings[bookings.Count - 1].Address = sdr["customerAddress"].ToString();
                            bookings[bookings.Count - 1].Amount = Convert.ToDecimal(sdr["bookingPrice"]);
                        }
                        con.Close();
                        return bookings;
                    }
                }
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.GVbind(this.PopulateData());
        }

        protected void SearchButton3_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}