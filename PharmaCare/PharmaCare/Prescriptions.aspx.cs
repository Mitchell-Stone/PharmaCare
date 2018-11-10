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

        /// <summary>
        /// get patient by patientID
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatient(int patientID)
        {
            try
            {
                patient = PatientDB.getPatientById(patientID);
                prescription = PrescriptionDB.GetPrescription(patientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// get patient by name
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatientByName(string patientID)
        {
            try
            {
                patient = PatientDB.getPatientByName(patientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// display patients prescriptions in datagrid
        /// </summary>
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

        /// <summary>
        /// search for a patient and retrieve their prescriptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPatient_Click(object sender, EventArgs e)
        {
            if (txtPatient.Text != "" && txtPatient.Text != null)
            {
                GetPatientByName(txtPatient.Text);
                if (patient != null)
                {
                    GetPatient(patient.PatientID);
                    DisplayPatientPrescriptions();
                    populatePatientDetails();
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// populate the patients details
        /// </summary>
        private void populatePatientDetails()
        {
            Name.Text = patient.Name;
            Address.Text = patient.Address;
            City.Text = patient.City;
            Zip.Text = patient.ZipCode;
            Type.Text = patient.Type;
            DoctorID.Text = patient.doctorID.ToString();
            WardID.Text = patient.wardID.ToString();
            RoomID.Text = patient.roomID.ToString();
        }

        /// <summary>
        /// Insert Prescription into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertPres_Click(object sender, EventArgs e)
        {
            Prescription pres = new Prescription();
            int drugId = Convert.ToInt32(PresDrugID.Text);
            int patientId = Convert.ToInt32(PresPatientID.Text);
            int doctorId = Convert.ToInt32(PresDocID.Text);
            string presDate = PresDate.Text;
            string addInfo = PresAddInfo.InnerText;
            string presStatus = PresStatus.Text;
            string drugDose = PresDrugDose.Text;
            string first = PresFirst.Text;
            string last = PresLast.Text;
            string timesADay = PresTimesADay.Text;
            string doseStatus = PresDoseStatus.Text;

            try
            {
                PrescriptionDB.insertPrescription(drugId, patientId, doctorId, presDate, addInfo, presStatus, drugDose, first, last, timesADay, doseStatus);
                clearPrescription();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// clear prescription 
        /// </summary>
        private void clearPrescription()
        {
            PresDrugID.Text = null;
            PresPatientID.Text = null;
            PresDocID.Text = null;
            PresDate.Text = null;
            PresAddInfo.InnerText = null;
            PresStatus.Text = null;
            PresDrugDose.Text = null;
            PresFirst.Text = null;
            PresLast.Text = null;
            PresTimesADay.Text = null;
            PresDoseStatus.Text = null;
        }
    }
}