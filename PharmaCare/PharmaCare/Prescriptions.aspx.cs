using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class Prescriptions : System.Web.UI.Page
    {
        Patient patient = new Patient();
        List<Prescription> prescription = new List<Prescription>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DgvPatients_PreRender(object sender, EventArgs e)
        {
            if (DgvPatients.HeaderRow != null)
            {
                DgvPatients.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void DgvPatients_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int patientID = Convert.ToInt16(e.CommandArgument);
            GetPatient(patientID);
            DisplayPatientPrescriptions();
        }

        private void GetPatient(int patientID)
        {
            try
            {
                patient = PatientDB.getPatient(patientID);
                prescription = PrescriptionDB.GetPrescription(patientID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Warning", "alert(" + ex.Message + ")", true);
                throw;
            }
            
        }

        private void DisplayPatientPrescriptions()
        {
            DgvPrescriptions.DataSource = prescription;
            DgvPrescriptions.DataBind();
        }
    }
}