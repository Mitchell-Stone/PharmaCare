using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class PrescriptionDB
    {
        public static List<Prescription> GetPrescription(int PatientID)
        {
            //set connection to schoolDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //select statement
            string selectStatement = "SELECT Prescription.*, Patients.Name AS PatName FROM Prescription " +
                "INNER JOIN Patients ON Prescription.PatientID = Patients.PatientID WHERE(Patients.PatientID = @PatientID)";
             //"SELECT * FROM Prescription WHERE PatientID = @PatientID";
            //
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {
                connection.Open();
                SqlDataReader PrescriptionReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                List<Prescription> patientPrescription = new List<Prescription>();
                while (PrescriptionReader.Read())
                {
                    Prescription prescription = new Prescription();
                    prescription.PrescriptionID = (int)PrescriptionReader["PrescriptionId"];
                    prescription.DrugID = (int)PrescriptionReader["DrugId"];
                    prescription.PatientID = (int)PrescriptionReader["PatientID"];
                    prescription.DoctorID = (int)PrescriptionReader["DoctorID"];
                    prescription.PrescribingDate = PrescriptionReader["PrescriptionDate"].ToString();
                    prescription.InformationExtra = PrescriptionReader["AdditionalInformation"].ToString();
                    prescription.StatusPrescription = PrescriptionReader["PrescriptionStatus"].ToString();
                    prescription.Doses = PrescriptionReader["DrugDose"].ToString();
                    prescription.FirstTimeUse = PrescriptionReader["FirstTime"].ToString();
                    prescription.LastTimeUse = PrescriptionReader["LastTime"].ToString();
                    prescription.FrequenseUseInADay = PrescriptionReader["TimesPerDay"].ToString();
                    prescription.DoseStatus = PrescriptionReader["StatusOfDose"].ToString();
                    patientPrescription.Add(prescription);

                }
                return patientPrescription;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}