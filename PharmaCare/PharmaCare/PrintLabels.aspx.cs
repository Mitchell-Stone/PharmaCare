using PharmaCare.Models;
using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                BindToGridView();
            }                
        }

        private void BindToGridView()
        {
            SqlConnection con = PharmaCareDB.GetConnection();
            try
            {
                con.Open();
                SqlDataReader reader = PrescriptionDB.LabelsToPrint(con);
                gvLabelList.DataSource = reader;
                gvLabelList.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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