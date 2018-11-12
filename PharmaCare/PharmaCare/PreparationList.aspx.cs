/*
 *      Student ID = 451381461
 *      Student Name = Mitchell Stone
 * 
 * 
 */

using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private List<string> allStatus = new List<string>()
        { 
            "Active",
            "Non-Verified",
            "On Hold",
            "Cocktail Warning",
            "Cancelled",
            "Deleted",
            "Expired",
            "Suspended"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindToGridView("nonverified");    
            }

            SetStatusDDL();
        }

        private void SetStatusDDL(string currentStatus)
        {
            foreach (GridViewRow row in gvPrepList.Rows)
            {
                //the presciptions are already active so disable the buttons
                DropDownList ddl = (DropDownList)gvPrepList.Rows[row.RowIndex].FindControl("ddlStatusTypes");

                ddl.DataSource = allStatus;
                ddl.DataBind();
            }
        }

        private void BindToGridView(string status)
        {
            //open connection to the local database
            SqlConnection con = PharmaCareDB.GetLocalConnection();

            try
            {
                //open the connection, populate the datasource and then bind it to the gridview
                con.Open();
                if (status == "all")
                {
                    gvPrepList.DataSource = PrescriptionDB.BindAllPrescriptionType(con);
                    gvPrepList.DataBind();
                }
                else
                {
                    gvPrepList.DataSource = PrescriptionDB.BindPrescriptionType(con, status);
                    gvPrepList.DataBind();
                }   
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
            BindToGridView("active");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Active Prescriptions";
        }

        protected void gvPrepList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string active = "active";
            if (e.CommandName == "SetPrescriptionActive")
            {
                //get the index of the row
                int index = Convert.ToInt32(e.CommandArgument);

                //get the value of the prescription id column cell
                int prescriptionId = Convert.ToInt32(gvPrepList.Rows[index].Cells[0].Text);

                //update the database
                PrescriptionDB.UpdatePrescriptionStatus(prescriptionId, active);
            }

            //show the udpated data
            BindToGridView(active);
        }

        protected void btnNonVerifiedPres_Click(object sender, EventArgs e)
        {
            BindToGridView("nonverified");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Non-Verified Prescriptions";
        }

        protected void btnCancelledPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("cancelled");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Cancelled Prescriptions";
        }

        protected void btnOnHoldPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("hold");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying On-Hold Prescriptions";
        }

        protected void btnExpiredPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("expired");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Expired Prescriptions";
        }

        protected void btnCocktailPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("cocktail");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Cocktail Conflicted Prescriptions";;
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("all");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying All Prescriptions";
        }
    }
}