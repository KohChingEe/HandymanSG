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
    public partial class ViewMyService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TextBoxserviceID.Text = Session["ServiceRef"].ToString();

                string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Business.BusinessServiceInfo WHERE serviceID ='" + TextBoxserviceID.Text + "';"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            TextBoxserviceID.Text = sdr["ServiceID"].ToString();
                            TextBoxtitle.Text = sdr["serviceTitle"].ToString();
                            TextBoxdescription.Text = sdr["serviceDesc"].ToString();
                            TextBoxpriceRange.Text = sdr["servicePrice"].ToString();
                        }
                        con.Close();
                    }
                }

            }
        }

        protected void cancelbutton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyServices.aspx");
        }

        protected void updatebutton3_Click(object sender, EventArgs e)
        {
            TextBoxserviceID.Text = Session["ServiceRef"].ToString();
            string constring = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Business.BusinessServiceInfo SET [servicePrice]= '" + TextBoxpriceRange.Text + "', [serviceDesc]='" + TextBoxdescription.Text + "' WHERE serviceID ='" + TextBoxserviceID.Text + "';", con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@serviceDesc", TextBoxdescription.Text);
                    cmd.Parameters.AddWithValue("@servicePrice", TextBoxpriceRange.Text);
                    cmd.ExecuteNonQuery();
                    ShowMessage("Service Info update sucessfully.");
                    con.Close();



                }
            }
            Response.Redirect("MyServices.aspx");
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
