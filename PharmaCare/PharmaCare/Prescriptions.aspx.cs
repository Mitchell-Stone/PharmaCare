﻿/*
 *      Student ID: 450950837
 *      Student Name: Kaitlyn Parsons
 */
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
            btnModify.Enabled = false;
            btnEditPresDetails.Enabled = false;
        }

        /// <summary>
        /// get patient by patientID and populates their prescriptions
        /// </summary>
        /// <param name="patientID"></param>
        private void GetPatient(int patientID)
        {
            SqlConnection con = PharmaCareDB.GetConnection();
            try
            {
                con.Open();
                patient = PatientDB.getPatientById(patientID);
                DgvPrescriptions.DataSource = PrescriptionDB.GetIndoorPrescriptions(con, patientID);
                DgvPrescriptions.DataBind();
                con.Close();
                con.Open();
                DgvOutdoorPrescriptions.DataSource = PrescriptionDB.GetOutdoorPrescriptions(con, patientID);
                DgvOutdoorPrescriptions.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
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
        /// get patient by name
        /// </summary>
        /// <param name="patientID"></param>
        private void getPatients(string patientID)
        {
            SqlConnection con = PharmaCareDB.GetConnection();
            try
            {
                con.Open();
                SqlDataReader reader = PatientDB.getPatients(con, patientID);
                dgvPatients.DataSource = reader;
                dgvPatients.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
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
                getPatients(txtPatient.Text);
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
            Indoor pres = new Indoor();
            if (!string.IsNullOrEmpty(PresDrugID.Text + PresPatientID.Text + PresDocID.Text +
                PresDate.Text + PresStatus.Text))
            {
                //prescription
                pres.PatientName = PresPatientID.Text;
                pres.DoctorName = PresDocID.Text;
                pres.PrescribingDate = PresDate.Text;
                pres.InformationExtra = PresAddInfo.InnerText;
                pres.StatusPrescription = PresStatus.Text;
                //drug details
                pres.DrugName = PresDrugID.Text;
                pres.Doses = PresDrugDose.Text;
                pres.FirstTimeUse = PresFirst.Text;
                pres.LastTimeUse = PresLast.Text;
                pres.FrequenseUseInADay = PresTimesADay.Text;
                pres.DoseStatus = PresDoseStatus.Text;
                //indoor details
                pres.RoomNumber = Convert.ToInt32(txtRoom.Text);
                pres.WingNumber = Convert.ToInt32(txtWing.Text);
                pres.FloorNumber = Convert.ToInt32(txtFloor.Text);
                pres.NursingStationId = txtNursingStationId.Text;
            }
            else
            {
                return;
            }

            try
            {
                if (pres != null)
                {
                    PrescriptionDB.insertIndoorPrescription(pres);
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
            //prescription
            PresPatientID.Text = null;
            PresDocID.Text = null;
            PresDate.Text = null;
            PresAddInfo.InnerText = null;
            PresStatus.Text = null;
            //details
            PresDrugID.Text = null;
            PresDrugDose.Text = null;
            PresFirst.Text = null;
            PresLast.Text = null;
            PresTimesADay.Text = null;
            PresDoseStatus.Text = null;
            //indoor
            txtRoom.Text = null;
            txtWing.Text = null;
            txtFloor.Text = null;
            txtNursingStationId.Text = null;
            dgvAddPrescriptionDetails.DataSource = null;
            dgvAddPrescriptionDetails.DataBind();
        }

        /// <summary>
        /// updates the prescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModifyPres_Click(object sender, EventArgs e)
        {
            Indoor pres = new Indoor();

            if (validateInt(presID.Text) && validateInt(txtRoom.Text) && validateInt(txtWing.Text) && validateInt(txtFloor.Text) && 
                !string.IsNullOrEmpty(PresDrugID.Text + PresPatientID.Text + PresDocID.Text +
                PresDate.Text + PresStatus.Text + txtNursingStationId.Text))
            {
                //prescription
                pres.PrescriptionID = Convert.ToInt32(presID.Text);
                pres.PatientName = PresPatientID.Text;
                pres.DoctorName = PresDocID.Text;
                pres.PrescribingDate = PresDate.Text;
                pres.InformationExtra = PresAddInfo.InnerText;
                pres.StatusPrescription = PresStatus.Text;

                //indoor
                pres.RoomNumber = Convert.ToInt32(txtRoom.Text);
                pres.WingNumber = Convert.ToInt32(txtWing.Text);
                pres.FloorNumber = Convert.ToInt32(txtFloor.Text);
                pres.NursingStationId = txtNursingStationId.Text;
            }
            try
            {
                PrescriptionDB.updatePrescription(pres);
                clearPrescription();
                btnInsert.Enabled = true;
                btnModify.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// clear prescription button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClearPres_Click(object sender, EventArgs e)
        {
            clearPrescription();
            btnInsert.Enabled = true;
            btnModify.Enabled = false;
        }

        protected void DgvPrescriptions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Hiding the Select Button Cell in Header Row.
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hiding the Select Button Cells showing for each Data Row. 
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");

                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DgvPrescriptions, "Select$" + e.Row.RowIndex);
            }
        }

        protected void DgvPrescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearPrescription();
            foreach (GridViewRow row in DgvPrescriptions.Rows)
            {
                if (row.RowIndex == DgvPrescriptions.SelectedIndex)
                {
                    //set row cells to text fields
                    presID.Text = row.Cells[1].Text;
                    PresPatientID.Text = row.Cells[2].Text;
                    PresDocID.Text = row.Cells[3].Text;
                    PresDate.Text = row.Cells[4].Text;
                    PresAddInfo.InnerText = row.Cells[5].Text;
                    PresStatus.Text = row.Cells[6].Text;
                    txtRoom.Text = row.Cells[7].Text;
                    txtWing.Text = row.Cells[8].Text;
                    txtFloor.Text = row.Cells[9].Text;
                    txtNursingStationId.Text = row.Cells[10].Text;

                }
            }
            BindDrugDetailsToDGV();
            btnInsert.Enabled = false;
            btnModify.Enabled = true;
        }

        private void BindDrugDetailsToDGV()
        {
            SqlConnection con = PharmaCareDB.GetConnection();
            try
            {
                con.Open();
                dgvAddPrescriptionDetails.DataSource = PrescriptionDB.getDrugDetails(con, Convert.ToInt32(presID.Text));
                dgvAddPrescriptionDetails.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnCheckCocktail_Click(object sender, EventArgs e)
        {
            btnModify.Enabled = true;
        }

        /// <summary>
        /// adds drugs to an indoor prescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPresDetails_Click(object sender, EventArgs e)
        {
            Details pres = new Details();

            if (!string.IsNullOrEmpty(PresDrugID.Text + PresDrugDose.Text +
                PresFirst.Text + PresLast.Text + PresTimesADay.Text + PresDoseStatus.Text))
            {
                pres.PrescriptionID = Convert.ToInt32(presID.Text);
                pres.DrugName = PresDrugID.Text;
                pres.Doses = PresDrugDose.Text;
                pres.FirstTimeUse = PresFirst.Text;
                pres.LastTimeUse = PresLast.Text;
                pres.FrequenseUseInADay = PresTimesADay.Text;
                pres.DoseStatus = PresDoseStatus.Text;
            }
            try
            {
                PrescriptionDB.insertPrescriptionDrugs(pres);
                BindDrugDetailsToDGV();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// disables outdoor tools and enable indoor tools
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIndoor_Click(object sender, EventArgs e)
        {
            Outdoor.Visible = false;
            OutdoorTable.Visible = false;
            OutdoorBtns.Visible = false;
            Indoor.Visible = true;
            IndoorTable.Visible = true;
            IndoorBtns.Visible = true;
        }

        /// <summary>
        /// disables indoor tools and enable outdoor tools
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOutdoor_Click(object sender, EventArgs e)
        {
            Outdoor.Visible = true;
            OutdoorTable.Visible = true;
            OutdoorBtns.Visible = true;
            Indoor.Visible = false;
            IndoorTable.Visible = false;
            IndoorBtns.Visible = false;
        }

        protected void dgvPatients_PreRender(object sender, EventArgs e)
        {
            if (dgvPatients.HeaderRow != null)
            {
                dgvPatients.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void DgvOutdoorPrescriptions_PreRender(object sender, EventArgs e)
        {
            if (DgvOutdoorPrescriptions.HeaderRow != null)
            {
                DgvOutdoorPrescriptions.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void DgvOutdoorPrescriptions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Hiding the Select Button Cell in Header Row.
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hiding the Select Button Cells showing for each Data Row. 
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");

                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DgvOutdoorPrescriptions, "Select$" + e.Row.RowIndex);
            }
        }

        protected void DgvOutdoorPrescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in DgvOutdoorPrescriptions.Rows)
            {
                if (row.RowIndex == DgvOutdoorPrescriptions.SelectedIndex)
                {
                    txtOutPresId.Text = row.Cells[1].Text;
                    txtOutPatient.Text = row.Cells[2].Text;
                    txtOutDoctor.Text = row.Cells[3].Text;
                    txtOutDate.Text = row.Cells[4].Text;
                    txtOutPresDetails.InnerText = row.Cells[5].Text;
                    txtOutPresStatus.Text = row.Cells[6].Text;
                    txtFilledDispatched.Text = row.Cells[7].Text;
                    txtDateDispatched.Text = row.Cells[8].Text;
                    txtTimeDispatched.Text = row.Cells[9].Text;
                    txtInEmergency.Text = row.Cells[10].Text;
                    txtToFill.Text = row.Cells[11].Text;
                }
            }
            btnInsertOutdoor.Enabled = false;
            btnModifyOutdoor.Enabled = true;
        }

        protected void dgvPatients_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Hiding the Select Button Cell in Header Row.
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hiding the Select Button Cells showing for each Data Row. 
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");

                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(dgvPatients, "Select$" + e.Row.RowIndex);
            }
        }

        protected void dgvPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in dgvPatients.Rows)
            {
                if (row.RowIndex == dgvPatients.SelectedIndex)
                {
                    string id = row.Cells[1].Text;
                    GetPatient(Convert.ToInt32(id));

                    populatePatientDetails();
                }
            }
        }

        protected void btnAddOutPresDetails_Click(object sender, EventArgs e)
        {

        }

        protected void btnCheckOutCocktail_Click(object sender, EventArgs e)
        {

        }

        protected void btnInsertOutdoor_Click(object sender, EventArgs e)
        {

        }

        protected void btnModifyOutdoor_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearOutdoor_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditPresDetails_Click(object sender, EventArgs e)
        {
            Details pres = new Details();

            if (validateInt(txtDrugDetailsId.Text) && !string.IsNullOrEmpty(PresDrugID.Text + PresDrugDose.Text + 
                PresFirst.Text + PresLast.Text + PresTimesADay.Text + PresDoseStatus.Text))
            {
                //drug details
                pres.DrugdetailsId = Convert.ToInt32(txtDrugDetailsId.Text);
                pres.DrugName = PresDrugID.Text;
                pres.DrugDose = PresDrugDose.Text;
                pres.FirstTime = PresFirst.Text;
                pres.LastTime = PresLast.Text;
                pres.TimesPerDay = PresTimesADay.Text;
                pres.StatusOfDose = PresDoseStatus.Text;
            }
            try
            {
                PrescriptionDB.updateDrugDetails(pres);
                BindDrugDetailsToDGV();
                btnAddPresDetails.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvAddPrescriptionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // Hiding the Select Button Cell in Header Row.
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Hiding the Select Button Cells showing for each Data Row. 
                e.Row.Cells[0].Style.Add(HtmlTextWriterStyle.Display, "none");

                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(dgvAddPrescriptionDetails, "Select$" + e.Row.RowIndex);
            }
        }

        protected void dgvAddPrescriptionDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = dgvAddPrescriptionDetails.SelectedRow;
            //populate text fields 
            txtDrugDetailsId.Text = row.Cells[1].Text;
            PresDrugID.Text = row.Cells[2].Text;
            PresDrugDose.Text = row.Cells[4].Text;
            PresFirst.Text = row.Cells[5].Text;
            PresLast.Text = row.Cells[6].Text;
            PresTimesADay.Text = row.Cells[7].Text;
            PresDoseStatus.Text = row.Cells[8].Text;
            btnModify.Enabled = true;
            btnAddPresDetails.Enabled = false;
            btnEditPresDetails.Enabled = true;
        }

        protected void dgvAddPrescriptionDetails_PreRender(object sender, EventArgs e)
        {
            if (dgvAddPrescriptionDetails.HeaderRow != null)
            {
                dgvAddPrescriptionDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}