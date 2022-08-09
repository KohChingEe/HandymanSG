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
    public partial class AddNewService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cancelbutton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyServices.aspx");
        }

        protected void submitbutton1_Click(object sender, EventArgs e)
        {

            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Business.BusinessServiceInfo ([serviceID],[serviceTitle], [serviceDesc], [servicePrice]) VALUES (@serviceID, @serviceTitle, @serviceDesc,@servicePrice) WHERE ;", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@serviceID", "SVR00007");
                    cmd.Parameters.AddWithValue("@serviceTitle", TextBoxtitle.Text);
                    cmd.Parameters.AddWithValue("@serviceDesc", TextBoxdescription.Text);
                    cmd.Parameters.AddWithValue("@servicePrice", TextBoxpriceRange.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();



                }
            }
            Response.Redirect("MyServices.aspx");
        }
    }
}