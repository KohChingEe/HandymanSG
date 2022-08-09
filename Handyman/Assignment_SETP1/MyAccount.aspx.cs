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
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //String TextBoxbusinessProfileID = Session["BusinessProfileID"].ToString();
                String TextBoxbusinessProfileID = "P00001";
                string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Business.BusinessProfileInfo WHERE profileID ='" + TextBoxbusinessProfileID + "';"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            TextBoxCompanyName.Text = sdr["companyName"].ToString();
                            TextBoxServiceCategory.Text = sdr["serviceCategory"].ToString();
                            TextBoxContact.Text = sdr["contactPhoneNumber"].ToString();
                            TextBoxEmail.Text = sdr["emailID"].ToString();
                            TextBoxAddress.Text = sdr["companyAddress"].ToString();
                        }
                        con.Close();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //String TextBoxbusinessProfileID = Session["BusinessProfileID"].ToString();
            String TextBoxbusinessProfileID = "P00001";
            int TextBox2 = 1 ;
            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE RepairAppDB.Business.BusinessProfileInfo SET [companyName]= '" + TextBoxCompanyName.Text + "', [companyRating]= '" + TextBox2 + "', [serviceCategory]= '" + TextBoxServiceCategory.Text + "', [contactPhoneNumber] = '" + TextBoxContact.Text + "', [emailID] = '" + TextBoxEmail.Text + "', [companyAddress] = '" + TextBoxAddress.Text + "' WHERE profileID ='" + TextBoxbusinessProfileID + "';", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@companyName", TextBoxCompanyName.Text);
                    cmd.Parameters.AddWithValue("@companyRating", TextBox2);
                    cmd.Parameters.AddWithValue("@serviceCategory", TextBoxServiceCategory.Text);
                    cmd.Parameters.AddWithValue("@contactPhoneNumber", TextBoxContact.Text);
                    cmd.Parameters.AddWithValue("@emailID", TextBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@companyAddress", TextBoxAddress.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("MyAccount.aspx");
        }
    }
}