using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        /// <summary>
        /// get patient by patientID
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatient(int patientID)
        {
            SqlConnection con = PharmaCareDB.GetConnection();
            try
            {
                con.Open();
                patient = PatientDB.getPatientById(patientID);
                DgvPrescriptions.DataSource = PrescriptionDB.GetPrescription(con, patientID);
                DgvPrescriptions.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                con.Close();
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
                    //DisplayPatientPrescriptions();
                    populatePatientDetails();
                    clearPrescription();
                    btnInsertPres.Enabled = true;
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
        /// validates an input is an integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool validateInt(string input)
        {
            int value;
            if (int.TryParse(input, out value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Insert Prescription into database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertPres_Click(object sender, EventArgs e)
        {
            Prescription pres = new Prescription();
            if (validateInt(PresDrugID.Text) && validateInt(PresPatientID.Text) && validateInt(PresDocID.Text) &&
                !string.IsNullOrEmpty(PresDate.Text + PresStatus.Text + PresDrugDose.Text +
                PresFirst.Text + PresLast.Text + PresTimesADay.Text + PresDoseStatus.Text))
            {
                pres.DrugID = Convert.ToInt32(PresDrugID.Text);
                pres.PatientID = Convert.ToInt32(PresPatientID.Text);
                pres.DoctorID = Convert.ToInt32(PresDocID.Text);
                pres.PrescribingDate = PresDate.Text;
                pres.InformationExtra = PresAddInfo.InnerText;
                pres.StatusPrescription = PresStatus.Text;
                pres.DoseStatus = PresDrugDose.Text;
                pres.FirstTimeUse = PresFirst.Text;
                pres.LastTimeUse = PresLast.Text;
                pres.FrequenseUseInADay = PresTimesADay.Text;
                pres.DoseStatus = PresDoseStatus.Text;
            }
            else
            {
                return;
            }

            try
            {
                if (pres != null)
                {
                    PrescriptionDB.insertPrescription(pres);
                    clearPrescription();
                }
                else
                {
                    return;
                }
               
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

        protected void btnModifyPres_Click(object sender, EventArgs e)
        {
            Prescription pres = new Prescription();

            if (validateInt(presID.Text) && validateInt(PresDrugID.Text) && validateInt(PresPatientID.Text) && validateInt(PresDocID.Text) &&
                !string.IsNullOrEmpty(PresDate.Text + PresStatus.Text + PresDrugDose.Text +
                PresFirst.Text + PresLast.Text + PresTimesADay.Text + PresDoseStatus.Text))
            {
                pres.PrescriptionID = Convert.ToInt32(presID.Text);
                pres.DrugID = Convert.ToInt32(PresDrugID.Text);
                pres.PatientID = Convert.ToInt32(PresPatientID.Text);
                pres.DoctorID = Convert.ToInt32(PresDocID.Text);
                pres.PrescribingDate = PresDate.Text;
                pres.InformationExtra = PresAddInfo.InnerText;
                pres.StatusPrescription = PresStatus.Text;
                pres.Doses = PresDrugDose.Text;
                pres.FirstTimeUse = PresFirst.Text;
                pres.LastTimeUse = PresLast.Text;
                pres.FrequenseUseInADay = PresTimesADay.Text;
                pres.DoseStatus = PresDoseStatus.Text;
            }
            try
            {
                PrescriptionDB.updatePrescription(pres);
                clearPrescription();
                GetPatient(pres.PatientID);
                DisplayPatientPrescriptions();
                populatePatientDetails();
                btnInsertPres.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnClearPres_Click(object sender, EventArgs e)
        {
            clearPrescription();
            btnInsertPres.Enabled = true;
        }

        protected void DgvPrescriptions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DgvPrescriptions, "Select$" + e.Row.RowIndex);
            }
        }

        protected void DgvPrescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDgvPrescriptionData();
        }

        private void getDgvPrescriptionData()
        {
            foreach (GridViewRow row in DgvPrescriptions.Rows)
            {
                if (row.RowIndex == DgvPrescriptions.SelectedIndex)
                {
                    presID.Text = row.Cells[0].Text;
                    PresDrugID.Text = row.Cells[1].Text;
                    PresPatientID.Text = row.Cells[2].Text;
                    PresDocID.Text = row.Cells[3].Text;
                    PresDate.Text = row.Cells[4].Text;
                    PresAddInfo.InnerText = row.Cells[5].Text;
                    PresStatus.Text = row.Cells[6].Text;
                    PresDrugDose.Text = row.Cells[7].Text;
                    PresFirst.Text = row.Cells[8].Text;
                    PresLast.Text = row.Cells[9].Text;
                    PresTimesADay.Text = row.Cells[10].Text;
                    PresDoseStatus.Text = row.Cells[11].Text;
                    btnInsertPres.Enabled = false;
                }
            }
        }

    }
}