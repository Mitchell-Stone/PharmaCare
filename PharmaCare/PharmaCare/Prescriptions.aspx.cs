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

        private void GetPatient(int patientID)
        {
            try
            {
                patient = PatientDB.getPatientById(patientID);
                prescription = PrescriptionDB.GetPrescription(patientID);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Warning", "alert(" + ex.Message + ")", true);
                throw;
            }
        }

        private void GetPatientByName(string patientID)
        {
            try
            {
                patient = PatientDB.getPatientByName(patientID);
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

        protected void DgvPrescriptions_PreRender(object sender, EventArgs e)
        {
            if (DgvPrescriptions.HeaderRow != null)
            {
                DgvPrescriptions.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnPatient_Click(object sender, EventArgs e)
        {
            GetPatientByName(txtPatient.Text);
            GetPatient(patient.PatientID);
            DisplayPatientPrescriptions();
            Name.Text = patient.Name;
            Address.Text = patient.Address;
            City.Text = patient.City;
            Zip.Text = patient.ZipCode;
            Type.Text = patient.Type;
            DoctorID.Text = patient.doctorID.ToString();
            WardID.Text = patient.wardID.ToString();
            RoomID.Text = patient.roomID.ToString();
        }
    }
}