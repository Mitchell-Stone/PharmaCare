/*
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

            ButtonsDisabled();
        }

        private void ButtonsDisabled()
        {
            foreach (GridViewRow row in gvPrepList.Rows)
            {
                //the presciptions are already active so disable the buttons
                Button btn = (Button)gvPrepList.Rows[row.RowIndex].FindControl("btnSetStatus");

                btn.Enabled = false;
                btn.BorderColor = Color.Gray;
                btn.ForeColor = Color.Gray;
            }
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
            BindNonVerifiedData();

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Non-Verified Prescriptions";
        }

        protected void btnCancelledPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("cancelled");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Cancelled Prescriptions";

            ButtonsDisabled();
        }

        protected void btnOnHoldPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("hold");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying On-Hold Prescriptions";

            ButtonsDisabled();
        }

        protected void btnExpiredPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("expired");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Expired Prescriptions";

            ButtonsDisabled();
        }

        protected void btnCocktailPres_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("cocktail");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Cocktail Conflicted Prescriptions";

            ButtonsDisabled();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            //bind the data to the gridview datasource
            BindToGridView("all");

            //update the heading to indicate what is being shown
            table_header.Text = "Displaying Expired Prescriptions";

            ButtonsDisabled();
        }
    }
}