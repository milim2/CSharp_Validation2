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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btregister_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShoppingMallConnectionString"].ConnectionString);

            string query = "Insert into login  values (@username, @password, @usertype)";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@username", tbusername.Text);
            cmd.Parameters.AddWithValue("@password", tbpassword.Text);
            cmd.Parameters.AddWithValue("@usertype", tbusertype.Text);

            cmd.ExecuteNonQuery();
            Response.Redirect("Login.aspx");

        }

        protected void btcancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}