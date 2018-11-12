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

        public static void insertPrescription(Prescription pres)
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

            insertCommand.Parameters.AddWithValue("@DrugId", pres.DrugID);
            insertCommand.Parameters.AddWithValue("@PatientId", pres.PatientID);
            insertCommand.Parameters.AddWithValue("@DoctorId", pres.DoctorID);
            insertCommand.Parameters.AddWithValue("@PresDate", pres.PrescribingDate);
            insertCommand.Parameters.AddWithValue("@AddInfo", pres.InformationExtra);
            insertCommand.Parameters.AddWithValue("@PresStatus", pres.StatusPrescription);
            insertCommand.Parameters.AddWithValue("@DrugDose", pres.Doses);
            insertCommand.Parameters.AddWithValue("@FirstTime", pres.FirstTimeUse);
            insertCommand.Parameters.AddWithValue("@LastTime", pres.LastTimeUse);
            insertCommand.Parameters.AddWithValue("@TimesPerDay", pres.FrequenseUseInADay);
            insertCommand.Parameters.AddWithValue("@StatusOfDose", pres.DoseStatus);

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

        public static SqlDataReader BindPrescriptionType(SqlConnection con, string status)
        {
            string sql = "SELECT Prescription.PrescriptionId, Prescription.PrescriptionDate, Drugs.DrugName, Drugs.DrugForm, Prescription.DrugDose, Prescription.TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN Drugs " +
                "ON Prescription.DrugId = Drugs.DrugId " +
                "WHERE Prescription.PrescriptionStatus = @status " +
                "ORDER BY Prescription.PrescriptionDate ASC";
            
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("status", status);
                return command.ExecuteReader();
            }  
        }

        public static SqlDataReader BindAllPrescriptionType(SqlConnection con)
        {
            string sql = "SELECT Prescription.PrescriptionId, Prescription.PrescriptionDate, Drugs.DrugName, Drugs.DrugForm, Prescription.DrugDose, Prescription.TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN Drugs " +
                "ON Prescription.DrugId = Drugs.DrugId " +
                "ORDER BY Prescription.PrescriptionDate ASC";

            using (var command = new SqlCommand(sql, con))
            {
                return command.ExecuteReader();
            }
        }

        public static void UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            //open connection to the local database
            SqlConnection con = PharmaCareDB.GetLocalConnection();

            string sql = "UPDATE Prescription " +
                "SET PrescriptionStatus = @status " +
                "WHERE PrescriptionId = @prescriptionId";

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

        /// <summary>
        /// updates prescription
        /// </summary>
        /// <param name="pres"></param>
        public static void updatePrescription(Prescription pres)
        {
            //set connection to PharmaCareDB class getConneciton method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //update statement
            string updateStatement = "UPDATE Prescription SET DrugId = @DrugId, PatientID = @PatientId, DoctorID = @DoctorId, PrescriptionDate = @PresDate, " +
            "AdditionalInformation = @AddInfo, PrescriptionStatus = @PresStatus, DrugDose = @DrugDose, FirstTime = @FirstTime, LastTime = @LastTime, " +
            "TimesPerDay = @TimesPerDay, StatusOfDose = @StatusOfDose WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@DrugId", pres.DrugID);
            updateCommand.Parameters.AddWithValue("@PatientId", pres.PatientID);
            updateCommand.Parameters.AddWithValue("@DoctorId", pres.DoctorID);
            updateCommand.Parameters.AddWithValue("@PresDate", pres.PrescribingDate);
            if (!string.IsNullOrEmpty(pres.InformationExtra))
            {
                updateCommand.Parameters.AddWithValue("@AddInfo", pres.InformationExtra);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@AddInfo", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@PresStatus", pres.StatusPrescription);
            updateCommand.Parameters.AddWithValue("@DrugDose", pres.Doses);
            updateCommand.Parameters.AddWithValue("@FirstTime", pres.FirstTimeUse);
            updateCommand.Parameters.AddWithValue("@LastTime", pres.LastTimeUse);
            updateCommand.Parameters.AddWithValue("@TimesPerDay", pres.FrequenseUseInADay);
            updateCommand.Parameters.AddWithValue("@StatusOfDose", pres.DoseStatus);
            updateCommand.Parameters.AddWithValue("@PrescriptionId", pres.PrescriptionID);

            try
            {
                //open sql connection
                connection.Open();
                //execute insert query
                updateCommand.ExecuteNonQuery();
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

    }
}