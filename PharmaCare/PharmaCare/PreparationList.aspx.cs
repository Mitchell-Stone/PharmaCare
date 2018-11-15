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
            if (!Page.IsPostBack)
            {
                BindToGridView("All");    
            }    
        }

        private void SetStatusDDL()
        {
            for (int i = 0; i < gvPrepList.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)gvPrepList.Rows[i].FindControl("ddlStatusTypes");
                ddl.DataSource = allStatus;
                ddl.DataBind();
            }
        }

        private void BindToGridView(string status)
        {
            SqlConnection con = PharmaCareDB.GetConnection();
            List<string> tempList = new List<string>();

            try
            {
                //open the connection, populate the datasource and then bind it to the gridview
                con.Open();
                if (status == "All")
                {
                    SqlDataReader reader = PrescriptionDB.BindAllPrescriptionType(con);
                    gvPrepList.DataSource = reader;
                    gvPrepList.DataBind();               

                    SetStatusDDL();
                }
                else
                {
                    SqlDataReader reader = PrescriptionDB.BindPrescriptionType(con, status);
                    gvPrepList.DataSource = reader;
                    gvPrepList.DataBind();

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

        protected void btnActivePres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("Active");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Active Prescriptions";
        }

        protected void gvPrepList_RowCommand(object sender, GridViewCommandEventArgs c)
        {          
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
    }
}