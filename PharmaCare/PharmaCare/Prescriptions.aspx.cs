using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class Prescriptions : System.Web.UI.Page
    {
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
            GetPrescriptions(patientID);
        }

        public static Prescription GetPrescriptions(int patientID)
        {
            //new sql connection
            SqlConnection connection = new SqlConnection();

            //create connection string to PharmaCareDB
            connection.ConnectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["PharmaCareDB"].ConnectionString;

            //open connection
            connection.Open();

            //select query with inner join and where clauses
            string query = "SELECT Prescription.*, Patients.Name AS PatName FROM Prescription " +
                "INNER JOIN Patients ON Prescription.PatientID = Patients.PatientID WHERE(Patients.PatientID = @PatientID)";
            SqlCommand selectCommand = new SqlCommand(query, connection);
            selectCommand.Parameters.AddWithValue("@PatientID", patientID);
            try
            {
                SqlDataReader prescriptionReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (prescriptionReader.Read())
                {
                    Prescription pres = new Prescription();
                    pres.PrescriptionID = (int)prescriptionReader["PrescriptionID"];
                    pres.DrugID = (int)prescriptionReader["DrugID"];
                    pres.PatientID = (int)prescriptionReader["PatientID"];
                    //TODO fix index out of range exception
                    //pres.PrescribingDate = prescriptionReader["PrescribingDate"].ToString();
                    pres.PrescribingDoctor = prescriptionReader["PrescribingDoctor"].ToString();
                    pres.InformationExtra = prescriptionReader["AdditionalInformation"].ToString();
                    pres.StatusPrescription = prescriptionReader["PrescriptionStatus"].ToString();
                    pres.Doses = prescriptionReader["DrugDose"].ToString();
                    pres.FirstTimeUse = prescriptionReader["FirstTime"].ToString();
                    pres.LastTimeUse = prescriptionReader["LastTime"].ToString();
                    pres.FrequenseUseInADay = prescriptionReader["TimesPerDay"].ToString();
                    pres.DoseStatus = prescriptionReader["StatusOfDose"].ToString();
                    //returns prescription relating to patient
                    return pres;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                connection.Close();
            }
        }
    }
}