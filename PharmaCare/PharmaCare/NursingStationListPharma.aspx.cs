/*
 *      Date Created = 27th October 2018
 *      Created By = 
 *      Purpose = This page is used to display the nursing station list
 *      Bugs = No known bugs
 */

using System;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmaCare
{
    public partial class NursingStationListPharma : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            /* string CS =ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;
             using(SqlConnection con =new SqlConnection(CS))
             {
                 SqlCommand cmd = new SqlCommand("Select NursingStationId from IndoorPrescriptions", con);
                 con.Open();
                 DropDownListNurse.DataSource = cmd.ExecuteReader();

                 DropDownListNurse.DataTextField = "NursingStationId";
                 DropDownListNurse.DataBind();

                 GridView1.DataBind();
             }
         
         */
        }


    }

}