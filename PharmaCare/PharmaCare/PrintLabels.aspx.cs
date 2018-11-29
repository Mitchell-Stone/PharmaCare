/*
 *      Date Created = 15th Novemeber 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = The Print Labes page displays all the currently active prescriptions so they can be printed.
 *      Bugs = No known bugs
 */
 
using PharmaCare.Models;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm1 : Page
    {
        // The Load Page function
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindToGridView();
            }                
        }

        // Binds the data returned from the SQL query and binds it to the grid view using a data table
        private void BindToGridView()
        {
            DataTable dt = PrescriptionDB.LabelsToPrint();
            gvLabelList.DataSource = dt;
            gvLabelList.DataBind();
        }

        // Gathers the data from the grid view row when a button is selected on that row
        protected void gvLabelList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewLabel")
            {
                //get the index of the row
                int index = Convert.ToInt32(e.CommandArgument);

                //get the value of the prescription id column cell
                int patientId = Convert.ToInt32(gvLabelList.Rows[index].Cells[0].Text);
                string patientName = gvLabelList.Rows[index].Cells[1].Text;
                string doctorName = gvLabelList.Rows[index].Cells[2].Text;
                string drugName = gvLabelList.Rows[index].Cells[3].Text;
                int drugDose = Convert.ToInt32(gvLabelList.Rows[index].Cells[4].Text);
                int timesPerDay = Convert.ToInt32(gvLabelList.Rows[index].Cells[5].Text);

                // Populate the example image of the label
                lblDoctorName.Text = String.Format("Subscribing Doctor: Dr {0}", doctorName);
                lblPatientId.Text = String.Format("Patient ID: {0}", patientId);
                lblPatientName.Text = String.Format("Patient Name: {0}", patientName);
                lblDrugName.Text = String.Format("Drug Prescribed: {0}", drugName);
                lblDrugDose.Text = String.Format("Drug Dosage: {0}mg", drugDose);
                lblTimesPerDay.Text = String.Format("Take prescribed dose {0} time/s per day", timesPerDay);
            }

            if (e.CommandName == "PrintLabel")
            {
                Console.WriteLine("PRINTING LABEL");       
            }
        }
    }
}