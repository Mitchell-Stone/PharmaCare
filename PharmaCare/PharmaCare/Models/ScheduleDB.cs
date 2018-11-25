/*
 *      Date Created = 30th October 2018
 *      Created By = Kyle 
 *      Purpose = This is the model for database interaction and returns data for the schedule page
 *      Bugs = No known bugs
 */

using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PharmaCare.Models
{
    public class ScheduleDB
    {
        private string Nurse { get; set; }
        public ScheduleDB(string NursingStationID, DataGrid scheduleList)
        {
            GetSchedule(NursingStationID, scheduleList);
        }
        // User defined method for SQL query
        private void GetSchedule(string NursingStationID, DataGrid scheduleList)
        {
            scheduleList.DataSource = null;
            scheduleList.DataBind();

            this.Nurse = NursingStationID;

            string query =

            "SELECT Patients.Name, CONCAT(IndoorPrescriptions.FloorNumber, ', ', IndoorPrescriptions.WingNumber, ', ', " +
            "IndoorPrescriptions.RoomNumber) AS Ward, Drugs.DrugName, DrugDetails.DrugDose, " +
            "DrugDetails.TimesPerDay, DrugDetails.FirstTime, DrugDetails.LastTime " +

            "FROM Prescription " +

            "INNER JOIN IndoorPrescriptions " +

            "ON Prescription.PrescriptionId = IndoorPrescriptions.PrescriptionId " +

            "INNER JOIN Patients " +

            "ON Prescription.PatientID = Patients.PatientID " +

            "INNER JOIN PrescriptionDrugs " +

            "ON PrescriptionDrugs.PrescriptionId = Prescription.PrescriptionId " +
            
            "INNER JOIN Drugs " +
            
            "On PrescriptionDrugs.DrugId = Drugs.DrugId " +
            
            "INNER JOIN DrugDetails " +
            
            "ON PrescriptionDrugs.LinkId = DrugDetails.LinkId " +

            "WHERE IndoorPrescriptions.NursingStationId = @NursingStationID " +
            
            "AND DrugDetails.StatusOfDose = 'Active' " +
            
            "ORDER BY Ward";
            
            // Using predefined method for DB connection
            string connection = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;

            // Opening DB connection with query command and closing after use
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                // Adding SQL parameters and binding data
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.Add(new SqlParameter("@NursingStationID", NursingStationID));
                    scheduleList.DataSource = command.ExecuteReader();
                    scheduleList.DataBind();
                }
            }
        }
    }
}