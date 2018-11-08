using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PharmaCare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }


        private void BindData()
        {
            //get the connection string from the config file to connect to the local database
            string connectionString = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;

            //create the connection
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT Prescription.PrescriptionDate, Drugs.DrugName, Drugs.DrugForm, Prescription.DrugDose, Prescription.TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN Drugs " +
                "ON Prescription.DrugId = Drugs.DrugId " +
                "WHERE Prescription.PrescriptionStatus = 'verified' " +
                "ORDER BY DrugName";

            //generate the command and open the connection
            SqlCommand command = new SqlCommand(query, con);
            con.Open();

            //set the data source to the datagrid and then bind the data
            gvPrepList.DataSource = command.ExecuteReader();
            gvPrepList.DataBind();

            //close the connection
            con.Close();
        }
    }
}