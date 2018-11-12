using System;
using System.Collections.Generic;
using System.Configuration;
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
            //select command
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PatientID", PatientID);
            try
            {
                //open sql connection
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
                //return patientPrescription
                return patientPrescription;
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

        public static void insertPrescription(int DrugID, int PatientID, int DoctorID, string PresDate, 
            string AddInfo, string PresStatus, string DrugDose, string firstTime, string lastTime, string timesPerDay, string DoseStatus)
        {
            //set connection to schoolDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //insert statement
            string insertStatement = "INSERT INTO Prescription (DrugId,PatientID,DoctorID,PrescriptionDate," +
                "AdditionalInformation,PrescriptionStatus,DrugDose,FirstTime,LastTime,TimesPerDay,StatusOfDose) " +
                "VALUES (@DrugId, @PatientId, @DoctorId, @PresDate, @AddInfo, @PresStatus, @DrugDose, " +
                "@FirstTime, @LastTime, @TimesPerDay, @StatusOfDose)";

            //insert command
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@DrugId", DrugID);
            insertCommand.Parameters.AddWithValue("@PatientId", PatientID);
            insertCommand.Parameters.AddWithValue("@DoctorId", DoctorID);
            insertCommand.Parameters.AddWithValue("@PresDate", PresDate);
            insertCommand.Parameters.AddWithValue("@AddInfo", AddInfo);
            insertCommand.Parameters.AddWithValue("@PresStatus", PresStatus);
            insertCommand.Parameters.AddWithValue("@DrugDose", DrugDose);
            insertCommand.Parameters.AddWithValue("@FirstTime", firstTime);
            insertCommand.Parameters.AddWithValue("@LastTime", lastTime);
            insertCommand.Parameters.AddWithValue("@TimesPerDay", timesPerDay);
            insertCommand.Parameters.AddWithValue("@StatusOfDose", DoseStatus);

            try
            {
                //open sql connection
                connection.Open();
                //execute insert query
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //throw sql error
                throw ex;
            }
            finally
            {
                //close sql connection
                connection.Close();
            }
        }

        public static SqlDataReader BindPrescriptionType(SqlConnection con, string scriptStatus)
        {
            SqlCommand command = con.CreateCommand();

            command.CommandText = "SELECT Prescription.PrescriptionId, Prescription.PrescriptionDate, Drugs.DrugName, Drugs.DrugForm, Prescription.DrugDose, Prescription.TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN Drugs " +
                "ON Prescription.DrugId = Drugs.DrugId " +
                "WHERE Prescription.PrescriptionStatus = @status " +
                "ORDER BY Prescription.PrescriptionDate ASC";
            command.Parameters.AddWithValue("status", scriptStatus);

            return command.ExecuteReader();
        }

        public static void UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            //open connection to the local database
            SqlConnection con = PharmaCareDB.GetLocalConnection();

            string sql = "UPDATE Prescription " +
                "SET PrescriptionStatus = @status " +
                "Where PrescriptionId = @prescriptionId";

            try
            {
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("status", status);
                    command.Parameters.AddWithValue("prescriptionId", prescriptionId);

                    con.Open();
                    command.ExecuteNonQuery();
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
    }
}