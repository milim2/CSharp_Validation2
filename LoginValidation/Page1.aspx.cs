using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginValidation
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Label1.Text = (string)(Session["username"]);

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Clear();
        }
    }
}