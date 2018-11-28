/*
 *      Date Created = 27th October 2018
 *      Created By = 
 *      Purpose = This manages the PharmaCare Login Page
 *      Bugs = No known bugs
 */

using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmaCare
{
    public partial class WebForm5 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString);
            //SqlConnection conn = HospitalDB.GetConnection();
            conn.Open();
            string checkuser = "select count (*) from Staff where UserName ='" + txtUsername.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkpasswordQuery = "select Password from Staff where UserName ='" + txtUsername.Text + "'";
                SqlCommand passComm = new SqlCommand(checkpasswordQuery, conn);
                string password = passComm.ExecuteScalar().ToString();
                if (password == txtPassword.Text)
                {
                    Session["New"] = txtUsername.Text;

                    string security = "select SecurityLevel from Staff where UserName = '" + txtUsername.Text + "'";
                    if (security == "1")
                    {
                        Response.Redirect("LogIn.aspx");
                    }
                    else
                        //Response.Write("Password is correct");
                        //Response.Write("<script>alert('login successful');</script>");
                        Response.Redirect("Users.aspx");
                }
                else
                {
                    Response.Write("Password is not correct");
                }

            }
            else
            {
                Response.Write("UserName is not correct");
            }

        }
        protected void btn_SignUp(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}