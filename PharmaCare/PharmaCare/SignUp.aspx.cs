/*
 *      Date Created = 27th October 2018
 *      Created By = 
 *      Purpose = 
 *      Bugs = No known bugs
 */

using System;

namespace PharmaCare
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_back(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }

        protected void btn_submit(object sender, EventArgs e)
        {

        }
    }
}