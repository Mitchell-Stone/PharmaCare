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
        /// <summary>
        /// gets the prescriptions depending on patients id
        /// </summary>
        /// <param name="con"></param>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public static SqlDataReader GetPrescription(SqlConnection con, int PatientID)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //select statement
            string selectStatement = "SELECT Prescription.PrescriptionId, Drugs.DrugName, Drugs.DrugForm, Patients.Name, Doctors.DoctorName, " +
                "Prescription.PrescriptionDate, Prescription.AdditionalInformation, Prescription.PrescriptionStatus, Prescription.DrugDose, " +
                "Prescription.FirstTime, Prescription.LastTime, Prescription.TimesPerDay, Prescription.StatusOfDose FROM Prescription " +
                "INNER JOIN Drugs ON Prescription.DrugId = Drugs.DrugId " +
                "INNER JOIN Doctors ON Prescription.DoctorID = Doctors.DoctorID " +
                "INNER JOIN Patients ON Prescription.PatientID = Patients.PatientID " +
                "WHERE Prescription.PatientID = @PatientID";
            
            using (var selectCommand = new SqlCommand(selectStatement, con))
            {
                selectCommand.Parameters.AddWithValue("@PatientID", PatientID);
                return selectCommand.ExecuteReader();
            }
        }

        /// <summary>
        /// Used for checking if a drug is dangerous
        /// </summary>
        /// <param name="con"></param>
        /// <param name="DrugName"></param>
        /// <returns></returns>
        public static Prescription checkCocktail(string DrugName)
        {
            //set connection to PharmaCareDB class GetConnection Method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //select statement
            string selectStatement = "SELECT * FROM Drugs WHERE DrugName = @DrugName";

            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

             selectCommand.Parameters.AddWithValue("@DrugName", DrugName);
                try
                {
                    //open connection
                    connection.Open();

                    SqlDataReader DrugReader = selectCommand.ExecuteReader();

                if (DrugReader.Read())
                {
                    Prescription pres = new Prescription();
                    pres.DrugName = DrugReader["DrugName"].ToString();
                    pres.Danger = (int)DrugReader["Dangerous"];

                    return pres;
                }
                else
                {
                    return null;
                }                

                }
                catch (Exception ex)
                {
                    //throw error
                    throw ex;
                }
                finally
                {
                    //close the connection
                    connection.Close();
                } 
        }

        public static void insertPrescription(Prescription pres)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //insert statement
            string insertStatement = "INSERT INTO Prescription (DrugId,PatientID,DoctorID,PrescriptionDate," +
            "AdditionalInformation,PrescriptionStatus,DrugDose,FirstTime,LastTime,TimesPerDay,StatusOfDose) " +
            "VALUES ((SELECT DrugId FROM Drugs WHERE DrugName = @DrugName), " +
            "(SELECT PatientID FROM Patients WHERE Name = @PatientName), " +
            "(SELECT DoctorID FROM Doctors WHERE DoctorName = @DoctorName), " +
            "@PresDate, @AddInfo, @PresStatus, @DrugDose, " +
            "@FirstTime, @LastTime, @TimesPerDay, @StatusOfDose)";

            //insert command
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@DrugName", pres.DrugName);
            insertCommand.Parameters.AddWithValue("@PatientName", pres.PatientName);
            insertCommand.Parameters.AddWithValue("@DoctorName", pres.DoctorName);
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

        public static SqlDataReader LabelsToPrint(SqlConnection con)
        {
            string sql = "SELECT Patients.PatientID, Name, DoctorName, " +
                "DrugName, DrugDose, TimesPerDay " +
                "FROM Prescription " +
                "RIGHT JOIN Doctors ON Prescription.DoctorID = Doctors.DoctorID " +
                "RIGHT JOIN Patients ON Prescription.PatientID = Patients.PatientID " +
                "LEFT JOIN Drugs ON Prescription.DrugId = Drugs.DrugId " +
                "WHERE PrescriptionStatus = 'Active' " +
                "ORDER BY Name";

            using (var command = new SqlCommand(sql, con))
            {
                return command.ExecuteReader();
            }
        }

        public static SqlDataReader BindPrescriptionType(SqlConnection con, string status)
        {
            string sql = "SELECT PrescriptionStatus, PrescriptionId, PrescriptionDate, " +
                "DrugName, DrugForm, DrugDose, TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN Drugs " +
                "ON Prescription.DrugId = Drugs.DrugId " +
                "WHERE PrescriptionStatus = @status " +
                "ORDER BY PrescriptionDate ASC";
            
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("status", status);
                return command.ExecuteReader();
            }  
        }

        public static SqlDataReader BindAllPrescriptionType(SqlConnection con)
        {
            string sql = "SELECT PrescriptionStatus, PrescriptionId, PrescriptionDate, " +
                "DrugName, DrugForm, DrugDose, TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN Drugs " +
                "ON Prescription.DrugId = Drugs.DrugId " +
                "ORDER BY PrescriptionDate ASC";

            using (var command = new SqlCommand(sql, con))
            {
                return command.ExecuteReader();
            }
        }

        public static void UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            //open connection to the local database
            SqlConnection con = PharmaCareDB.GetODPprescription();

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
            string updateStatement = "UPDATE Prescription SET DrugId = (SELECT DrugId FROM Drugs WHERE DrugName = @DrugId), " +
                "PatientID = (SELECT PatientID FROM Patients WHERE Name = @PatientId), " +
                "DoctorID = (SELECT DoctorID FROM Doctors WHERE DoctorName = @DoctorId), " +
                "PrescriptionDate = @PresDate, AdditionalInformation = @AddInfo, PrescriptionStatus = @PresStatus, " +
                "DrugDose = @DrugDose, FirstTime = @FirstTime, LastTime = @LastTime, TimesPerDay = @TimesPerDay, " +
                "StatusOfDose = @StatusOfDose WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@DrugId", pres.DrugName);
            updateCommand.Parameters.AddWithValue("@PatientId", pres.PatientName);
            updateCommand.Parameters.AddWithValue("@DoctorId", pres.DoctorName);
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
        public static SqlDataReader GetODPprescription(SqlConnection con, string status)
        {
            string sql = "SELECT OPDPrescriptions.OPDId, OPDPrescriptions.PrescriptionId, OPDPrescriptions.Filled&Dispatched, " +
                "OPDPrescriptions.DateDispatched, OPDPrescriptions.TimeDispatched, OPDPrescriptions.IndoorEmergency, OPDPrescriptions.ToFill " +
                "FROM OPDPrescriptions " +
                "LEFT JOIN Prescription " +
                "ON OPDPrescriptions.prescriptionId = Prescription.PrescriptionId " +
                "WHERE Prescription.PrescriptionStatus = @status " +
                "ORDER BY Prescription.PrescriptionDate ASC";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("status", status);
                return command.ExecuteReader();
            }
        }

    }
}