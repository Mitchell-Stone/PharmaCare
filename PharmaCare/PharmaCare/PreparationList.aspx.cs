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
using System.Data;
using System.Linq;

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

                table_header.Text = "Displaying All Prescriptions";
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

        private List<Preperation> GetObjectList(DataTable dt)
        {
            var list = (from rw in dt.AsEnumerable()
                        select new Preperation()
                        {
                            PrescriptionId = Convert.ToInt32(rw["PrescriptionId"]),
                            PrescriptionDate = Convert.ToString(rw["PrescriptionDate"]),
                            DrugName = Convert.ToString(rw["DrugName"]),
                            DrugForm = Convert.ToString(rw["DrugForm"]),
                            DrugDose = Convert.ToInt32(rw["DrugDose"]),
                            PrescriptionStatus = Convert.ToString(rw["PrescriptionStatus"]),
                            TimesPerDay = Convert.ToInt32(rw["TimesPerDay"])
                        }).ToList();
            return list;   
        }

        private void BindToGridView(int prescriptionId)
        {
            //create a new data table and put the sql results into it
            List<Preperation> prep = GetObjectList(PrescriptionDB.BindPrescriptionById(prescriptionId));

            var grpList = prep.GroupBy(u => u.PrescriptionId).Select(grp => grp.ToList()).ToList();

            //bind the data table to the grid view
            gvPrepList.DataSource = grpList;
            gvPrepList.DataBind();
        }

        private void BindToGridView(string status)
        {
            // Open the connection, populate the datasource and then bind it to the gridview
            if (status == "All")
            {
                //create a new data table and put the sql results into it
                List<Preperation> prep = GetObjectList(PrescriptionDB.BindAllPrescriptionType());

                var grpList = prep.GroupBy(u => u.PrescriptionId).Select(grp => grp.ToList()).ToList();

                foreach (var grp in grpList)
                {
                    //dt.Rows.Add(grp);
                }

                //bind the data table to the grid view
                gvPrepList.DataSource = grpList;
                gvPrepList.DataBind();               

                // Bind the selections to the dropdown list for each row
                SetStatusDDL();
            }
            else
            {
                //create a new data table and put the sql results into it
                List<Preperation> prep = GetObjectList(PrescriptionDB.BindPrescriptionType(status));

                var grpList = prep.GroupBy(u => u.PrescriptionId).Select(grp => grp.ToList()).ToList();

                //bind the data table to the grid view
                gvPrepList.DataSource = grpList;
                gvPrepList.DataBind();

                // Bind the selections to the dropdown list for each row
                SetStatusDDL();
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

        protected void btnSearchForPrescription_Click(object sender, EventArgs e)
        {
            // Conducts search for prescriptions by id number when number is entered into the text box
            try
            {
                //get the id from the search box
                int id = Convert.ToInt32(tbPrescriptionIdSearch.Text);
                if (tbPrescriptionIdSearch.Text != null)
                {
                    //search for the id and bind to the grid view
                    BindToGridView(id);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("No value entered");
            }         
        }
    }
}