using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LoginValidation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlRole.SelectedIndex = 0;
            RefreshData();            
        }        

        protected void RefreshData()
        {

            string cs = "Data Source=(local);Initial Catalog=ShoppingMall;Integrated Security=True";
            SqlDataReader rdr = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "Select * from login";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(rdr);

                    GridView2.DataSource = dt;
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }

            }
        }
       
        protected void add_btn_Click1(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            string usertype = ddlRole.SelectedItem.Text;

            try
            {
                if (UserExists(username))
                {
                    lblMessage.Text = "The user name is already taken. Please try again!!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if(CreateUser(username, password, usertype))
                    {
                        lblMessage.Text = "User Registered";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMessage.Text = "User NOT Registered";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }


        protected bool CreateUser(string username, string password, string usertype)
        {
            string query = "Insert into login value (@username, @password, @usertype)";

            int result = 0;

            string cs = "Data Source=(local);Initial Catalog=ShoppingMall;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", tbUsername.Text);
                cmd.Parameters.AddWithValue("@password", tbPassword.Text);
                cmd.Parameters.AddWithValue("@usertype", ddlRole.SelectedItem.Text);

                con.Open();
                result = (int)cmd.ExecuteNonQuery();
            }

            if (result == 1)
                return true;
            else
                return false;
        }


        protected bool UserExists(string username)
        {
            string query = "Select Count(username) from login where UserName=@username ";

            int result;

            string cs = "Data Source=(local);Initial Catalog=ShoppingMall;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", tbUsername.Text);
                con.Open();

                result = (int)cmd.ExecuteScalar();
            }

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbid.Text);

            string cs = "Data Source=(local);Initial Catalog=ShoppingMall;Integrated Security=True";

            string query = "Update login " +
                "Set UserName=@username, Password=@password, UserType=@usertype where UserID='"+ id +"' ";

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", tbUsername.Text);
                    cmd.Parameters.AddWithValue("@password", tbPassword.Text);
                    cmd.Parameters.AddWithValue("@usertype", ddlRole.SelectedItem.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    GridView1.EditIndex = -1;
                    RefreshData();

                    con.Close();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        protected void del_btn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbid.Text);

            string cs = "Data Source=(local);Initial Catalog=ShoppingMall;Integrated Security=True";

            string query = "Delete * from login where UserID=@id ";

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    RefreshData();

                    con.Close();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }               
            }
        }

        protected void refresh_btn_Click1(object sender, EventArgs e)
        {
            RefreshData();
        }

        protected void HandleException(Exception ex)
        {
            lblMessage.Text = ex.Message.ToString();
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }

    }
}