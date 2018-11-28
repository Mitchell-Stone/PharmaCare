/*
 *      Date Created = 27th October 2018
 *      Created By = 
 *      Purpose = 
 *      Bugs = No known bugs
 */

using System;
using System.Configuration;
using System.Data.SqlClient;

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

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString);
            //SqlConnection conn = HospitalDB.GetConnection();


            string update = "insert into Staff(FirstName,LastName,UserName,Password,SecurityLevel) values('" + txtfirst.Text + "','" + txtlast.Text + "','" + txtuser.Text + "','" + txtpassword.Text + "','" + txtlevel.Text + "')";

            SqlCommand cmd = new SqlCommand(update, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            // int value =  cmd.ExecuteNonQuery();
            conn.Close();
            // if (value > 0)
            // {
            Response.Write("Data saved");

            // }

        }
    }
}