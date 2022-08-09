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
    public partial class MyServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.GVbind(this.PopulateData());
            }
        }

        protected void GVbind(List<BookingInfo> bookings)
        {
            string cs = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS SN, serviceTitle,ServiceID,serviceDesc,servicePrice FROM Business.BusinessServiceInfo;", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    GridView2.DataSource = bookings;
                    GridView2.DataBind();
                }
                else
                {
                    //Empty DataTable to execute the “else-condition”  
                    DataTable dt = new DataTable();
                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                }
                con.Close();
            }
        }

        public class BookingInfo
        {
            public int Sn { get; set; }
            public string Serviceid { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        private List<BookingInfo> PopulateData()
        {
            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS SN, serviceTitle,ServiceID,serviceDesc,servicePrice FROM Business.BusinessServiceInfo;", con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        List<BookingInfo> bookings = new List<BookingInfo>();
                        while (sdr.Read())
                        {
                            bookings.Add(new BookingInfo());
                            bookings[bookings.Count - 1].Sn = Convert.ToInt32(sdr["Sn"]);
                            bookings[bookings.Count -1].Title = sdr["serviceTitle"].ToString();
                            bookings[bookings.Count - 1].Serviceid = sdr["ServiceID"].ToString();
                            bookings[bookings.Count - 1].Description = (String)sdr["serviceDesc"];
                            bookings[bookings.Count - 1].Price = Convert.ToDecimal(sdr["servicePrice"]);
                        }
                        con.Close();
                        return bookings;
                    }
                }
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.GVbind(this.PopulateData());
        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SearchButton1_Click(object sender, EventArgs e)
        {

        }

        protected void ViewButton4_Click(object sender, EventArgs e)
        {
            LinkButton ViewButton4 = ((LinkButton)sender);
            string selectedServiceRef = ViewButton4.CommandArgument;
            Session["ServiceRef"] = selectedServiceRef;
            Response.Redirect("ViewMyService.aspx");
        }

        protected void DeleteButton1_Click(object sender, EventArgs e)
        {
            LinkButton DeleteButton1 = ((LinkButton)sender);
            string selectedServiceRef = DeleteButton1.CommandArgument;
            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Business.BusinessServiceInfo WHERE serviceID ='" + DeleteButton1.CommandArgument + "';", con))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Data has deleted') </script>");
                    Response.Redirect("MyServices.aspx");
                    con.Close();

                }
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}