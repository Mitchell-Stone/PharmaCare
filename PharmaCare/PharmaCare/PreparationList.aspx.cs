/*
 *      Student ID = 451381461
 *      Student Name = Mitchell Stone
 *      Purpose = This page is capable of viewing all 
 * 
 */
 
using PharmaCare.Models;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace PharmaCare
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        // List of strings for status dropdown selectors
        private List<string> allStatus = new List<string>()
        {
            "--Select Status--",
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
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                //Show all prescriptions when opening the page
                BindToGridView("All");    
            }    
        }

        private void SetStatusDDL()
        {
            // Function that is called to bind the dropdown selection values
            for (int i = 0; i < gvPrepList.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)gvPrepList.Rows[i].FindControl("ddlStatusTypes");
                ddl.DataSource = allStatus;
                ddl.DataBind();
            }
        }

        private void BindToGridView(int prescriptionId)
        {
            // Create an SQL connection
            SqlConnection con = PharmaCareDB.GetConnection();
            List<string> tempList = new List<string>();

            try
            {
                con.Open();
                // Read the data from the connection and 
                SqlDataReader reader = PrescriptionDB.BindPrescriptionById(con, prescriptionId);
                gvPrepList.DataSource = reader;
                gvPrepList.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        private void BindToGridView(string status)
        {
            // Create an SQL connection
            SqlConnection con = PharmaCareDB.GetConnection();
            List<string> tempList = new List<string>();

            try
            {
                // Open the connection, populate the datasource and then bind it to the gridview
                con.Open();
                if (status == "All")
                {
                    // Read the data and bind it to the gridview
                    SqlDataReader reader = PrescriptionDB.BindAllPrescriptionType(con);
                    gvPrepList.DataSource = reader;
                    gvPrepList.DataBind();               

                    // Bind the selections to the dropdown list for each row
                    SetStatusDDL();
                }
                else
                {
                    // Read the data and bind it to the gridview
                    SqlDataReader reader = PrescriptionDB.BindPrescriptionType(con, status);
                    gvPrepList.DataSource = reader;
                    gvPrepList.DataBind();

                    // Bind the selections to the dropdown list for each row
                    SetStatusDDL();
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

        protected void gvPrepList_RowCommand(object sender, GridViewCommandEventArgs c)
        {
            // Managed the controls for the grid view
            if (c.CommandName == "SetPrescriptionStatus")
            {
                //get the index of the row
                int index = Convert.ToInt32(c.CommandArgument);

                //get the value of the prescription id column cell
                int prescriptionId = Convert.ToInt32(gvPrepList.Rows[index].Cells[0].Text);

                DropDownList drop = gvPrepList.Rows[index].FindControl("ddlStatusTypes") as DropDownList;
                string status = drop.Text;

                //update the database
                PrescriptionDB.UpdatePrescriptionStatus(prescriptionId, status);

                //show the udpated data
                BindToGridView(status);
            }
        }

        #region Controls for the selection type buttons

        protected void btnActivePres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("Active");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Active Prescriptions";
        }     

        protected void btnNonVerifiedPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("Non-Verified");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Non-Verified Prescriptions";
        }

        protected void btnCancelledPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("Cancelled");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Cancelled Prescriptions";
        }

        protected void btnOnHoldPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("On Hold");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying On-Hold Prescriptions";
        }

        protected void btnExpiredPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("Expired");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Expired Prescriptions";
        }

        protected void btnCocktailPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("Cocktail Warning");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Cocktail Conflicted Prescriptions";;
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("All");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying All Prescriptions";
        }

        #endregion

        protected void tbPrescriptionIdSearch_TextChanged(object sender, EventArgs e)
        {
            // Conducts search for prescriptions by id number when number is entered into the text box

            BindToGridView(Convert.ToInt32(tbPrescriptionIdSearch.Text));
        }
    }
}