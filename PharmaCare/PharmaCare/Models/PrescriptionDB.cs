/*
 *      Date Created = 29 October 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = This is the model that controls all interaction with the database to return data about prescritpions.
 *      Bugs = No known bugs
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace PharmaCare.Models
{
    public class PrescriptionDB
    {
        /// <summary>
        /// gets the indoor prescriptions depending on patients id
        /// </summary>
        /// <param name="con"></param>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public static SqlDataReader GetIndoorPrescriptions(SqlConnection con, int PatientID)
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
        /// <summary>
        /// gets the outdoor prescriptions depending on patients id
        /// </summary>
        /// <param name="con"></param>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public static SqlDataReader GetOutdoorPrescriptions(SqlConnection con, int PatientID)
        {
            //select statement
            string selectStatement = "SELECT Prescription.PrescriptionId, Patients.Name, Doctors.DoctorName, " +
                "Prescription.PrescriptionDate, Prescription.AdditionalInformation, Prescription.PrescriptionStatus, " +
                "OPDPrescriptions.FilledAndDispatched, OPDPrescriptions.DateDispatched, OPDPrescriptions.TimeDispatched, " +
                "OPDPrescriptions.IndoorEmergency, OPDPrescriptions.ToFill FROM Prescription " +
                "INNER JOIN OPDPrescriptions ON Prescription.PrescriptionId = OPDPrescriptions.PrescriptionId " +
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
        /// gets drug details depending on prescription id
        /// </summary>
        /// <param name="con"></param>
        /// <param name="PrescriptionId"></param>
        /// <returns></returns>
        public static SqlDataReader getDrugDetails(SqlConnection con, int PrescriptionId)
        {
            string selectStatement = "SELECT PrescriptionDrugs.LinkId, PrescriptionDrugs.PrescriptionId, Drugs.DrugName, Drugs.DrugForm, DrugDetails.DrugDetailsId, DrugDetails.DrugDose, " +
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
        /// inserts an indoor prescription
        /// </summary>
        /// <param name="pres"></param>
        public static void insertIndoorPrescription(Indoor pres)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            int newId;
            //insert prescription statement
            string insertStatement = "INSERT INTO Prescription (PatientID,DoctorID,PrescriptionDate," +
            "AdditionalInformation,PrescriptionStatus) " +
            "VALUES ((SELECT PatientID FROM Patients WHERE Name = @PatientName), " +
            "(SELECT DoctorID FROM Doctors WHERE DoctorName = @DoctorName), " +
            "@PresDate, @AddInfo, @PresStatus) SELECT CAST (scope_identity() AS int)";

            try
            {
                //insert command
                SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                insertCommand.Parameters.AddWithValue("@PatientName", pres.PatientName);
                insertCommand.Parameters.AddWithValue("@DoctorName", pres.DoctorName);
                insertCommand.Parameters.AddWithValue("@PresDate", pres.PrescribingDate);
                insertCommand.Parameters.AddWithValue("@AddInfo", pres.InformationExtra);
                insertCommand.Parameters.AddWithValue("@PresStatus", pres.StatusPrescription);
                //open sql connection
                connection.Open();
                //get new prescription id
                newId = (int)insertCommand.ExecuteScalar();
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

            //insert indoor prescription
            string insertIndoorStatement = "INSERT INTO IndoorPrescriptions (PrescriptionId, RoomNumber, WingNumber, FloorNumber, NursingStationId) " +
                "VALUES (@PrescriptionId, @RoomNumber, @WingNumber, @FloorNumber, @NursingStationId)";
            //insert command
            SqlCommand insertIndoorCommand = new SqlCommand(insertIndoorStatement, connection);
            insertIndoorCommand.Parameters.AddWithValue("@PrescriptionId", newId);
            insertIndoorCommand.Parameters.AddWithValue("@RoomNumber", pres.RoomNumber);
            insertIndoorCommand.Parameters.AddWithValue("@WingNumber", pres.WingNumber);
            insertIndoorCommand.Parameters.AddWithValue("@FloorNumber", pres.FloorNumber);
            insertIndoorCommand.Parameters.AddWithValue("@NursingStationId", pres.NursingStationId);
            try
            {
                //open connection
                connection.Open();
                //execute insert query
                insertIndoorCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //throw sql query
                throw ex;
            }
            finally
            {
                //close connection
                connection.Close();
            }
        }
        
        /// <summary>
        /// inserts an outdoor prescription
        /// </summary>
        /// <param name="pres"></param>
        public static void insertOutdoorPrescription(Outdoor pres)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            int newId;
            //insert prescription statement
            string insertStatement = "INSERT INTO Prescription (PatientID,DoctorID,PrescriptionDate," +
            "AdditionalInformation,PrescriptionStatus) " +
            "VALUES ((SELECT PatientID FROM Patients WHERE Name = @PatientName), " +
            "(SELECT DoctorID FROM Doctors WHERE DoctorName = @DoctorName), " +
            "@PresDate, @AddInfo, @PresStatus) SELECT CAST (scope_identity() AS int)";

            try
            {
                //insert command
                SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                insertCommand.Parameters.AddWithValue("@PatientName", pres.PatientName);
                insertCommand.Parameters.AddWithValue("@DoctorName", pres.DoctorName);
                insertCommand.Parameters.AddWithValue("@PresDate", pres.PrescribingDate);
                insertCommand.Parameters.AddWithValue("@AddInfo", pres.InformationExtra);
                insertCommand.Parameters.AddWithValue("@PresStatus", pres.StatusPrescription);
                //open sql connection
                connection.Open();
                //get new prescription id
                newId = (int)insertCommand.ExecuteScalar();
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

            //insert outdoor prescription
            string insertIndoorStatement = "INSERT INTO OPDPrescriptions (PrescriptionId, FilledAndDispatched, DateDispatched, " +
                "TimeDispatched, IndoorEmergency, ToFill) " +
                "VALUES (@PrescriptionId, @FilledAndDispatched, @DateDispatched, @TimeDispatched, @IndoorEmergency, @ToFill)";
            //insert command
            SqlCommand insertIndoorCommand = new SqlCommand(insertIndoorStatement, connection);
            insertIndoorCommand.Parameters.AddWithValue("@PrescriptionId", newId);
            insertIndoorCommand.Parameters.AddWithValue("@FilledAndDispatched", pres.FilledDispatched);
            insertIndoorCommand.Parameters.AddWithValue("@DateDispatched", pres.DateDispatched);
            insertIndoorCommand.Parameters.AddWithValue("@TimeDispatched", pres.TimeDispatched);
            insertIndoorCommand.Parameters.AddWithValue("@IndoorEmergency", pres.IndoorEmergency);
            insertIndoorCommand.Parameters.AddWithValue("@ToFill", pres.ToFill);
            try
            {
                //open connection
                connection.Open();
                //execute insert query
                insertIndoorCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //throw sql query
                throw ex;
            }
            finally
            {
                //close connection
                connection.Close();
            }
        }

        /// <summary>
        /// Inserts Prescription drugs and drug details
        /// </summary>
        /// <param name="pres"></param>
        public static void insertPrescriptionDrugs(Details pres)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            int linkId;
            //insert statement
            string insertStatement = "INSERT INTO PrescriptionDrugs (PrescriptionId, DrugId) " +
                "VALUES (@PrescriptionId, (SELECT DrugId FROM Drugs Where DrugName = @DrugId)) " +
                "SELECT CAST (scope_identity() AS int)";


            SqlCommand insertPresDrugsCommand = new SqlCommand(insertStatement, connection);
            insertPresDrugsCommand.Parameters.AddWithValue("@PrescriptionId", pres.PrescriptionID);
            insertPresDrugsCommand.Parameters.AddWithValue("@DrugId", pres.DrugName);
            try
            {
                connection.Open();
                linkId = (int)insertPresDrugsCommand.ExecuteScalar();
                insertPresDrugsCommand.ExecuteNonQuery();
                insertDrugDetails(pres, linkId);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// inserts drug details depending on linkid
        /// </summary>
        /// <param name="pres"></param>
        /// <param name="linkId"></param>
        public static void insertDrugDetails(Details pres, int linkId)
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

        /// <summary>
        /// updates Prescription drugs and drug details
        /// </summary>
        /// <param name="pres"></param>
        public static void updatePrescriptionDrugs(Details pres)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //insert statement
            string insertStatement = "UPDATE PrescriptionDrugs SET DrugId = (SELECT DrugId FROM Drugs Where DrugName = @DrugId) " +
                "WHERE LinkId = @LinkId";


            SqlCommand insertPresDrugsCommand = new SqlCommand(insertStatement, connection);
            insertPresDrugsCommand.Parameters.AddWithValue("@LinkId", pres.LinkId);
            insertPresDrugsCommand.Parameters.AddWithValue("@DrugId", pres.DrugName);
            try
            {
                connection.Open();
                insertPresDrugsCommand.ExecuteNonQuery();
                updateDrugDetails(pres);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// updates selected drug details
        /// </summary>
        /// <param name="details"></param>
        public static void updateDrugDetails(Details details)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //update statement
            string updateStatement = "UPDATE DrugDetails SET DrugDose = @DrugDose, FirstTime = @FirstTime, LastTime = @LastTime, " +
                "TimesPerDay = @TimesPerDay, StatusOfDose = @StatusOfDose WHERE DrugDetailsId = @DrugDetailsId";

            //update command
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@DrugDose", details.DrugDose);
            updateCommand.Parameters.AddWithValue("@FirstTime", details.FirstTime);
            updateCommand.Parameters.AddWithValue("@LastTime", details.LastTime);
            updateCommand.Parameters.AddWithValue("@TimesPerDay", details.TimesPerDay);
            updateCommand.Parameters.AddWithValue("@StatusOfDose", details.StatusOfDose);
            updateCommand.Parameters.AddWithValue("@DrugDetailsId", details.DrugdetailsId);

            //try/catch block
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

        // Returns the data for all Active prescriptions to be displayed for printing
        public static DataTable LabelsToPrint()
        {
            //create a new data table for the data returned from the query
            DataTable dt = new DataTable();

            //get the sql connection
            SqlConnection con = PharmaCareDB.GetConnection();

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
            try
            {
                //open the connection and execute the reader
                con.Open();
                using (var command = new SqlCommand(sql, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    //load the reader into the data table
                    dt.Load(reader);
                    //return the data table
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }          
        }

        // Returns a data table of all prescriptions by a specific type
        public static DataTable BindPrescriptionType(string status)
        {
            //create a new data table
            DataTable dt = new DataTable();
            //get the connection
            SqlConnection con = PharmaCareDB.GetConnection();

            string sql = "SELECT PrescriptionStatus, Prescription.PrescriptionId, PrescriptionDate, " +
                "DrugName, DrugForm, DrugDose, TimesPerDay " +
                "FROM Prescription " + "LEFT JOIN PrescriptionDrugs " +
                "ON PrescriptionDrugs.PrescriptionId = Prescription.PrescriptionId " +
                "LEFT JOIN Drugs " +
                "ON Drugs.DrugId = PrescriptionDrugs.DrugId " +
                "RIGHT JOIN DrugDetails " +
                "ON DrugDetails.LinkId = PrescriptionDrugs.LinkId " +
                "WHERE PrescriptionStatus = @status " +
                "ORDER BY PrescriptionDate ASC";
            try
            {
                //open the connection and execute the reader
                con.Open();
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("status", status);
                    SqlDataReader reader = command.ExecuteReader();
                    //load the reader into the data table
                    dt.Load(reader);
                    //return the data table
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }

        public static DataTable BindPrescriptionById(int id)
        {
            //create a new data table
            DataTable dt = new DataTable();
            //get the connection
            SqlConnection con = PharmaCareDB.GetConnection();

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
            try
            {
                //open the connection and execute the reader
                con.Open();
                using (var command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    //load the reader into the data table
                    dt.Load(reader);
                    //return the data table
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }          
        }

        // Returns ALL the prescription data needed for the preperation window
        public static DataTable BindAllPrescriptionType()
        {
            //create a data table to hold the data returned from the query
            DataTable dt = new DataTable();

            //create the connection
            SqlConnection con = PharmaCareDB.GetConnection();

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

            try
            {
                //open the connection and execute the reader
                con.Open();
                using (var command = new SqlCommand(sql, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    //load the reader into the data table
                    dt.Load(reader);
                    //return the data table
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }

        // Updates the current status of a prescription
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
        /// updates prescription and indoor prescription details
        /// </summary>
        /// <param name="indoor"></param>
        public static void updatePrescription(Indoor indoor)
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

            updateCommand.Parameters.AddWithValue("@PatientId", indoor.PatientName);
            updateCommand.Parameters.AddWithValue("@DoctorId", indoor.DoctorName);
            updateCommand.Parameters.AddWithValue("@PresDate", indoor.PrescribingDate);
            if (!string.IsNullOrEmpty(indoor.InformationExtra))
            {
                updateCommand.Parameters.AddWithValue("@AddInfo", indoor.InformationExtra);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@AddInfo", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@PresStatus", indoor.StatusPrescription);
            updateCommand.Parameters.AddWithValue("@PrescriptionId", indoor.PrescriptionID);

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

            //update statement
            string updateInStatement = "UPDATE IndoorPrescriptions SET RoomNumber = @RoomNumber, " +
                "WingNumber = @WingNumber, FloorNumber = @FloorNumber, NursingStationId = @NursingStationId " +
                "WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand updateInCommand = new SqlCommand(updateInStatement, connection);

            updateInCommand.Parameters.AddWithValue("@PrescriptionId", indoor.PrescriptionID);
            updateInCommand.Parameters.AddWithValue("@RoomNumber", indoor.RoomNumber);
            updateInCommand.Parameters.AddWithValue("@WingNumber", indoor.WingNumber);
            updateInCommand.Parameters.AddWithValue("@FloorNumber", indoor.FloorNumber);
            updateInCommand.Parameters.AddWithValue("@NursingStationid", indoor.NursingStationId);

            try
            {
                //open sql connection
                connection.Open();
                //execute insert query
                updateInCommand.ExecuteNonQuery();
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

        /// <summary>
        /// updates outdoor prescription
        /// </summary>
        /// <param name="Indoor"></param>
        public static void updateOutdoorPrescription(Outdoor outdoor)
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

            updateCommand.Parameters.AddWithValue("@PatientId", outdoor.PatientName);
            updateCommand.Parameters.AddWithValue("@DoctorId", outdoor.DoctorName);
            updateCommand.Parameters.AddWithValue("@PresDate", outdoor.PrescribingDate);
            if (!string.IsNullOrEmpty(outdoor.InformationExtra))
            {
                updateCommand.Parameters.AddWithValue("@AddInfo", outdoor.InformationExtra);
            }
            else
            {
                updateCommand.Parameters.AddWithValue("@AddInfo", DBNull.Value);
            }
            updateCommand.Parameters.AddWithValue("@PresStatus", outdoor.StatusPrescription);
            updateCommand.Parameters.AddWithValue("@PrescriptionId", outdoor.PrescriptionID);

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

            //update statement
            string updateOutStatement = "UPDATE OPDPrescriptions SET FilledAndDispatched = @FilledAndDispatched, " +
                "DateDispatched = @DateDispatched, TimeDispatched = @TimeDispatched, IndoorEmergency = @IndoorEmergency, " +
                "ToFill = @ToFill WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand updateOutCommand = new SqlCommand(updateOutStatement, connection);

            updateOutCommand.Parameters.AddWithValue("@PrescriptionId", outdoor.PrescriptionID);
            updateOutCommand.Parameters.AddWithValue("@FilledAndDispatched", outdoor.FilledDispatched);
            updateOutCommand.Parameters.AddWithValue("@DateDispatched", outdoor.DateDispatched);
            updateOutCommand.Parameters.AddWithValue("@TimeDispatched", outdoor.TimeDispatched);
            updateOutCommand.Parameters.AddWithValue("@IndoorEmergency", outdoor.IndoorEmergency);
            updateOutCommand.Parameters.AddWithValue("@ToFill", outdoor.ToFill);

            try
            {
                //open sql connection
                connection.Open();
                //execute insert query
                updateOutCommand.ExecuteNonQuery();
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

        /// <summary>
        /// sets the prescription status to Cancelled
        /// </summary>
        /// <param name="id"></param>
        public static void cancelPrescription(int id)
        {
            //set connection to PharmaCareDB class getConneciton method
            SqlConnection connection = PharmaCareDB.GetConnection();

            //update statement
            string updateStatement = "UPDATE Prescription SET PrescriptionStatus = 'Cancelled' " +
                "WHERE PrescriptionId = @PrescriptionId";

            //update command
            SqlCommand cancelCommand = new SqlCommand(updateStatement, connection);

            cancelCommand.Parameters.AddWithValue("@PrescriptionId", id);

            try
            {
                //open sql connection
                connection.Open();
                //execute update query
                cancelCommand.ExecuteNonQuery();
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
