using System;
using System.Data.SqlClient;

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
            //select statement
            string selectStatement = "SELECT Prescription.PrescriptionId, Patients.Name, Doctors.DoctorName, " +
                "Prescription.PrescriptionDate, Prescription.AdditionalInformation, Prescription.PrescriptionStatus, " +
                "IndoorPrescriptions.RoomNumber, " +
                "IndoorPrescriptions.WingNumber, IndoorPrescriptions.FloorNumber, IndoorPrescriptions.NursingStationId FROM Prescription " +
                "INNER JOIN IndoorPrescriptions ON Prescription.PrescriptionId = IndoorPrescriptions.PrescriptionId " +
                "INNER JOIN Doctors ON Prescription.DoctorID = Doctors.DoctorID " +
                "INNER JOIN Patients ON Prescription.PatientID = Patients.PatientID " +
                "WHERE Prescription.PatientID = @PatientID";
            
            using (var selectCommand = new SqlCommand(selectStatement, con))
            {
                selectCommand.Parameters.AddWithValue("@PatientID", PatientID);
                return selectCommand.ExecuteReader();
            }
        }

        public static SqlDataReader getDrugDetails(SqlConnection con, int PrescriptionId)
        {
            string selectStatement = "SELECT PrescriptionDrugs.PrescriptionId, Drugs.DrugName, Drugs.DrugForm, DrugDetails.DrugDose, " +
                "DrugDetails.FirstTime, DrugDetails.LastTime, DrugDetails.TimesPerDay, DrugDetails.StatusOfDose " +
                "FROM PrescriptionDrugs " +
                "INNER JOIN Drugs ON PrescriptionDrugs.DrugId = Drugs.DrugId " +
                "INNER JOIN DrugDetails ON PrescriptionDrugs.LinkId = DrugDetails.LinkId " +
                "WHERE PrescriptionDrugs.PrescriptionId = @PrescriptionId";

            using (var selectCommand = new SqlCommand(selectStatement, con))
            {
                selectCommand.Parameters.AddWithValue("@PrescriptionId", PrescriptionId);
                return selectCommand.ExecuteReader();
            }
        }

        /// <summary>
        /// Used for checking if a drug is dangerous
        /// </summary>
        /// <param name="con"></param>
        /// <param name="DrugName"></param>
        /// <returns></returns>
        //public static Prescription checkCocktail(string DrugName)
        //{
        //    //set connection to PharmaCareDB class GetConnection Method
        //    SqlConnection connection = PharmaCareDB.GetConnection();
        //    //select statement
        //    string selectStatement = "SELECT * FROM Drugs WHERE DrugName = @DrugName";

        //    SqlCommand selectCommand = new SqlCommand(selectStatement, connection);

        //     selectCommand.Parameters.AddWithValue("@DrugName", DrugName);
        //        try
        //        {
        //            //open connection
        //            connection.Open();

        //            SqlDataReader DrugReader = selectCommand.ExecuteReader();

        //        if (DrugReader.Read())
        //        {
        //            Prescription pres = new Prescription();
        //            pres.DrugName = DrugReader["DrugName"].ToString();
        //            //pres.Danger = (int)DrugReader["Dangerous"];

        //            return pres;
        //        }
        //        else
        //        {
        //            return null;
        //        }                

        //        }
        //        catch (Exception ex)
        //        {
        //            //throw error
        //            throw ex;
        //        }
        //        finally
        //        {
        //            //close the connection
        //            connection.Close();
        //        } 
        //}

        public static void insertPrescription(Prescription pres)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //insert statement
            string insertStatement = "INSERT INTO Prescription (PatientID,DoctorID,PrescriptionDate," +
            "AdditionalInformation,PrescriptionStatus) " +
            "VALUES ((SELECT PatientID FROM Patients WHERE Name = @PatientName), " +
            "(SELECT DoctorID FROM Doctors WHERE DoctorName = @DoctorName), " +
            "@PresDate, @AddInfo, @PresStatus)";

            //insert command
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@PatientName", pres.PatientName);
            insertCommand.Parameters.AddWithValue("@DoctorName", pres.DoctorName);
            insertCommand.Parameters.AddWithValue("@PresDate", pres.PrescribingDate);
            insertCommand.Parameters.AddWithValue("@AddInfo", pres.InformationExtra);
            insertCommand.Parameters.AddWithValue("@PresStatus", pres.StatusPrescription);

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

        public static void insertPrescriptionDrugs(int PrescriptionId, string DrugId)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //insert statement
            string insertStatement = "INSERT INTO PrescriptionDrugs (PrescriptionId, DrugId) VALUES " +
                "(@PrescriptionId, (SELECT DrugId FROM Drugs WHERE DrugName = @DrugId))";
            //insert command
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@PrescriptionId", PrescriptionId);
            insertCommand.Parameters.AddWithValue("@DrugId", DrugId);

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

        public static void insertDrugDetails(Prescription pres, int linkId)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //insert statement
            string insertStatement = "INSERT INTO DrugDetails (LinkId, DrugDose, FirstTime, LastTime, TimesPerDay, StatusOfDose) " +
                "VALUES (@LinkId, @DrugDose, @FirstTime, @LastTime, @TimesPerDay, @StatusOfDose)";

            //insert command
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@LinkId", linkId);
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
                "RIGHT JOIN Doctors " +
                "ON Prescription.DoctorID = Doctors.DoctorID " +
                "RIGHT JOIN Patients " +
                "ON Prescription.PatientID = Patients.PatientID " +
                "LEFT JOIN PrescriptionDrugs " +
                "ON PrescriptionDrugs.PrescriptionId = Prescription.PrescriptionId " +
                "LEFT JOIN Drugs " +
                "ON Drugs.DrugId = PrescriptionDrugs.DrugId " +
                "LEFT JOIN DrugDetails " +
                "ON DrugDetails.LinkId = PrescriptionDrugs.LinkId " +
                "WHERE PrescriptionStatus = 'Active' " +
                "ORDER BY Name";

            using (var command = new SqlCommand(sql, con))
            {
                return command.ExecuteReader();
            }
        }

        public static SqlDataReader BindPrescriptionType(SqlConnection con, string status)
        {
            string sql = "SELECT PrescriptionStatus, Prescription.PrescriptionId, PrescriptionDate, " +
                "DrugName, DrugForm, DrugDose, TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN PrescriptionDrugs " +
                "ON PrescriptionDrugs.PrescriptionId = Prescription.PrescriptionId " +
                "LEFT JOIN Drugs " +
                "ON Drugs.DrugId = PrescriptionDrugs.DrugId " +
                "RIGHT JOIN DrugDetails " +
                "ON DrugDetails.LinkId = PrescriptionDrugs.LinkId " +
                "WHERE PrescriptionStatus = @status " +
                "ORDER BY PrescriptionDate ASC";
            
            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("status", status);
                return command.ExecuteReader();
            }  
        }

        public static SqlDataReader BindPrescriptionById(SqlConnection con, int id)
        {
            string sql = "SELECT PrescriptionStatus, Prescription.PrescriptionId, PrescriptionDate, " +
                "DrugName, DrugForm, DrugDose, TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN PrescriptionDrugs " +
                "ON PrescriptionDrugs.PrescriptionId = Prescription.PrescriptionId " +
                "LEFT JOIN Drugs " +
                "ON Drugs.DrugId = PrescriptionDrugs.DrugId " +
                "RIGHT JOIN DrugDetails " +
                "ON DrugDetails.LinkId = PrescriptionDrugs.LinkId " +
                "WHERE Prescription.PrescriptionId = @id " +
                "ORDER BY PrescriptionDate ASC";

            using (var command = new SqlCommand(sql, con))
            {
                command.Parameters.AddWithValue("id", id);
                return command.ExecuteReader();
            }
        }

        public static SqlDataReader BindAllPrescriptionType(SqlConnection con)
        {
            string sql = "SELECT PrescriptionStatus, Prescription.PrescriptionId, PrescriptionDate, " +
                "DrugName, DrugForm, DrugDose, TimesPerDay " +
                "FROM Prescription " +
                "LEFT JOIN PrescriptionDrugs " +
                "ON PrescriptionDrugs.PrescriptionId = Prescription.PrescriptionId " +
                "LEFT JOIN Drugs " +
                "ON Drugs.DrugId = PrescriptionDrugs.DrugId " +
                "RIGHT JOIN DrugDetails " +
                "ON DrugDetails.LinkId = PrescriptionDrugs.LinkId " +
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
            string updateStatement = "UPDATE Prescription SET PatientID = (SELECT PatientID FROM Patients WHERE Name = @PatientId), " +
                "DoctorID = (SELECT DoctorID FROM Doctors WHERE DoctorName = @DoctorId), " +
                "PrescriptionDate = @PresDate, AdditionalInformation = @AddInfo, PrescriptionStatus = @PresStatus " +
                "WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

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

        public static void updateIndoorPrescription(Indoor Indoor)
        {
            //set connection to PharmaCareDB class getConneciton method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //update statement
            string updateStatement = "UPDATE IndoorPrescriptions SET RoomNumber = @RoomNumber, " +
                "WingNumber = @WingNumber, FloorNumber = @FloorNumber, NursingStationId = @NursingStationId " +
                "WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@PrescriptionId", Indoor.PrescriptionID);
            updateCommand.Parameters.AddWithValue("@RoomNumber", Indoor.RoomNumber);
            updateCommand.Parameters.AddWithValue("@WingNumber", Indoor.WingNumber);
            updateCommand.Parameters.AddWithValue("@FloorNumber", Indoor.FloorNumber);
            updateCommand.Parameters.AddWithValue("@NursingStationid", Indoor.NursingStationId);

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
            try
            {
                string sql = "SELECT OPDId, FilledAndDispatched, DateDispatched, TimeDispatched, IndoorEmergency, ToFill, Drugs.DrugId, " +
                    "DrugName, DrugForm, Patients.PatientID, Patients.Name, Prescription.PrescriptionId, " +
                    "Prescription.DoctorID, PrescriptionDate, AdditionalInformation, PrescriptionStatus, DrugDose " +
                    "FROM OPDPrescriptions " +
                    "LEFT JOIN Prescription " +
                    "ON OPDPrescriptions.prescriptionId = Prescription.PrescriptionId " +
                    "LEFT JOIN Patients " +
                    "ON Prescription.PatientID = Patients.PatientID " +
                    "LEFT JOIN PrescriptionDrugs " +
                    "ON Prescription.PrescriptionId = PrescriptionDrugs.PrescriptionId " +
                    "LEFT JOIN Drugs " +
                    "ON PrescriptionDrugs.DrugId = Drugs.DrugId " +
                    "LEFT JOIN DrugDetails " +
                    "ON DrugDetails.LinkId = PrescriptionDrugs.LinkId " +
                    "WHERE PrescriptionStatus = @status " +
                    "ORDER BY PrescriptionDate ASC";
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("status", status);
                    return command.ExecuteReader();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


    }


}
