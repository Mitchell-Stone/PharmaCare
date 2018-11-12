﻿/*
 *      Student ID = 451381461
 *      Student Name = Mitchell Stone
 * 
 * 
 */



using PharmaCare.Models;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindNonVerifiedData();
            }          
        }

        private void BindNonVerifiedData()
        {
            //open connection to the local database
            SqlConnection con = PharmaCareDB.GetLocalConnection();

            try
            {
                //open the connection, populate the datasource and then bind it to the gridview
                con.Open();
                gvPrepList.DataSource = PrescriptionDB.BindPrescriptionType(con, "nonverified");
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
            //open connection to the local database
            SqlConnection con = PharmaCareDB.GetLocalConnection();

            try
            {               
                con.Open();
                //set the data source and then bind it to the grid view
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
            //bind the data to the gridview datasource
            BindActiveData();

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Active Prescriptions";

            foreach (GridViewRow row in gvPrepList.Rows)
            {
                //the presciptions are already active so disable the buttons
                Button btn = (Button)gvPrepList.Rows[row.RowIndex].FindControl("btnSetActive");

                btn.Enabled = false;
                btn.BorderColor = Color.Gray;
                btn.ForeColor = Color.Gray;
            }
        }

        protected void gvPrepList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SetPrescriptionActive")
            {
                //get the index of the row
                int index = Convert.ToInt32(e.CommandArgument);

                //get the value of the prescription id column cell
                int prescriptionId = Convert.ToInt32(gvPrepList.Rows[index].Cells[0].Text);

                //update the database
                PrescriptionDB.UpdatePrescriptionStatus(prescriptionId, "active");
            }

            //show the udpated data
            BindNonVerifiedData();
        }

        protected void btnNonVerifiedPres_Click(object sender, EventArgs e)
        {
            BindNonVerifiedData();

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Non-Verified Prescriptions";
        }
    }
}