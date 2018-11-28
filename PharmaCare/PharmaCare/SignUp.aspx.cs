/*
 *      Date Created = 27th October 2018
 *      Created By = Saugat Raut
 *      Purpose = This page will help user to sign up
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
            //get connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString);

            // query
            string update = "insert into Staff(FirstName,LastName,UserName,Password,SecurityLevel) values('" + txtfirst.Text + "','" + txtlast.Text + "','" + txtuser.Text + "','" + txtpassword.Text + "','" + txtlevel.Text + "')";

            SqlCommand cmd = new SqlCommand(update, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
           
            conn.Close();
            
            Response.Write("Data saved");

            // clear all the textboxes
            txtfirst.Text = "";
            txtlast.Text = "";
            txtlevel.Text = "";
            txtpassword.Text = "";
            txtuser.Text = "";
          

        }
    }
}