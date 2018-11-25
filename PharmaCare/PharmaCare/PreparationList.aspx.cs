/*
 *      Date Created = 5th Novemeber 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = This page is to view all the prescriptions and their allocated drug. The status of the prescription can be altered from this window.
 *      Bugs = No known bugs
 */

using PharmaCare.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PharmaCare
{
    public partial class WebForm2 : Page
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

        // The page load function
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

        // Binds the list of available status types to the dropdown list shown in the gridview
        private void SetStatusDDL()
        {
            // Function that is called to bind the dropdown selection values
            for (int i = 0; i < gvGroupPrepList.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)gvGroupPrepList.Rows[i].FindControl("ddlStatusTypes");
                ddl.DataSource = allStatus;
                ddl.DataBind();
            }
        }

        // Creates a list of Preperation objects to be displayed on the gridview
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


        // Gathers the presctription data from the database with a specific ID and then binds it to the gridview
        private void BindToGridView(int prescriptionId)
        {
            //create a new data table and put the sql results into it
            List<Preperation> prep = GetObjectList(PrescriptionDB.BindPrescriptionById(prescriptionId));

            var grpList = prep.GroupBy(u => u.PrescriptionId).Select(grp => grp.ToList()).ToList();

            //bind the data table to the grid view
            gvPrepList.DataSource = grpList;
            gvPrepList.DataBind();
        }

        // Bind the prescription data from the database with a specific status and then binds it to the gridview
        private void BindToGridView(string status)
        {
            // Open the connection, populate the datasource and then bind it to the gridview
            if (status == "All")
            {
                // Gets the object list for all prescription types
                List<Preperation> prepList = GetObjectList(PrescriptionDB.BindAllPrescriptionType());

                // Create a temp list for temp storage
                List<GroupPreperation> tempList = new List<GroupPreperation>();

                // Groups all the items in the list together by their prescription ID
                var grpList = prepList.GroupBy(u => u.PrescriptionId).Select(grp => grp.ToList()).ToList();

                // Iterate of the grplist and create the data needed for the intial selection table
                foreach (var grp in grpList)
                {
                    GroupPreperation prep = new GroupPreperation();
                    prep.PrescriptionId = grp[0].PrescriptionId;
                    prep.PrescriptionCount = grp.Count;
                    prep.PrescriptionDate = grp[0].PrescriptionDate;
                    prep.PrepList = grp;
                    
                    tempList.Add(prep);
                }

                //b Bind the data table to the group preperation grid view
                gvGroupPrepList.DataSource = tempList;
                gvGroupPrepList.DataBind();

                SetStatusDDL();
            }
            else
            {
                // Performs the same function in the first part of the if statment but returns
                // a list of prescriptions by a specific type
                List<Preperation> prepList = GetObjectList(PrescriptionDB.BindPrescriptionType(status));

                List<GroupPreperation> tempList = new List<GroupPreperation>();

                var grpList = prepList.GroupBy(u => u.PrescriptionId).Select(grp => grp.ToList()).ToList();

                foreach (var grp in grpList)
                {
                    GroupPreperation prep = new GroupPreperation();
                    prep.PrescriptionId = grp[0].PrescriptionId;
                    prep.PrescriptionCount = grp.Count;
                    prep.PrescriptionDate = grp[0].PrescriptionDate;
                    prep.PrepList = grp;

                    tempList.Add(prep);
                }

                //bind the data table to the grid view
                gvGroupPrepList.DataSource = tempList;
                gvGroupPrepList.DataBind();

                SetStatusDDL();
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

        // Conducts search for prescriptions by id number when number is entered into the text box
        protected void btnSearchForPrescription_Click(object sender, EventArgs e)
        {           
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

        // Gathers the data about the prescription from the selected row when a row button is pressed
        protected void gvGroupPrepList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewPrescription")
            {
                // Get the index of the row
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the value of the prescription id column cell
                int prescriptionId = Convert.ToInt32(gvGroupPrepList.Rows[index].Cells[0].Text);

                // Create a data table and bind it to the gridview
                DataTable dt = PrescriptionDB.BindPrescriptionById(prescriptionId);
                gvPrepList.DataSource = dt;
                gvPrepList.DataBind();
            }
            // Managed the controls for the grid view
            if (e.CommandName == "SetPrescriptionStatus")
            {
                //get the index of the row
                int index = Convert.ToInt32(e.CommandArgument);

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
    }
}