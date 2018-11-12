using PharmaCare.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PharmaCare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindVerifiedData();
        }


        private void BindVerifiedData()
        {
            //get the connection string from the config file to connect to the local database
            string connectionString = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;

            //create the connection
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                gvPrepList.DataSource = PrescriptionDB.BindPrescriptionType(con, "verified");
                gvPrepList.DataBind();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        private void BindActiveData()
        {
            //get the connection string from the config file to connect to the local database
            string connectionString = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;

            //create the connection
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                gvPrepList.DataSource = PrescriptionDB.BindPrescriptionType(con, "active");
                gvPrepList.DataBind();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnActivePres_Click(object sender, EventArgs e)
        {
            BindActiveData();            
        }

        protected void btnVerifiedPres_Click(object sender, EventArgs e)
        {
            BindVerifiedData();
        }
    }
}