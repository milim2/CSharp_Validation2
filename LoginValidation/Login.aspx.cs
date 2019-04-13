using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LoginValidation
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingMallConnectionString"].ConnectionString);

            con.Open();

            string query = "Select count(*) from login where UserName = '" + tbusername.Text + "' And Password = '" + tbpassword.Text + "' ";

            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@username", tbusername.Text);
            cmd.Parameters.AddWithValue("@password", tbpassword.Text);

            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (count == 1)
            {

                string query2 = " Select UserType from login where UserName = '" + tbusername.Text + "'";

                SqlCommand cmd2 = new SqlCommand(query2, con);
                
                string usertype = cmd2.ExecuteScalar().ToString();
                con.Close();


                if (usertype == "admin")
                {
                    Session["username"] = tbusername.Text;
                    Response.Redirect("AdminManagement.aspx");
                }
                else
                {
                    Session["username"] = tbusername.Text;
                    Response.Redirect("Secure.aspx");
                }
                con.Close();
            }
        }
    }
}
