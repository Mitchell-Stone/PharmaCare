using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //creating a session
            if (Session["New"] != null)
            {
                welcomeLbl.Text += Session["New"].ToString();
            }
            else
            {
                Response.Redirect("");
            }
          
        }

        protected void LogOut_btn_Click(object sender, EventArgs e)
        {
            Session["New"] = null;
            Response.Redirect("LogIn.aspx");

        }
    }
}