using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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

        private void GetSchedule(string NursingStationID, DataGrid scheduleList)
        {
            scheduleList.DataSource = null;
            scheduleList.DataBind();

            this.Nurse = NursingStationID;

            string query =

            "SELECT Patients.Name, CONCAT(IndoorPrescriptions.FloorNumber, ', ', IndoorPrescriptions.WingNumber, ', ', " +
            "IndoorPrescriptions.RoomNumber) AS Ward, Drugs.DrugName, Prescription.DrugDose, " +
            "Prescription.TimesPerDay, Prescription.FirstTime, Prescription.LastTime " +

            "FROM Prescription " +

            "INNER JOIN IndoorPrescriptions " +

            "ON Prescription.PrescriptionId = IndoorPrescriptions.PrescriptionId " +

            "INNER JOIN Patients " +

            "ON Prescription.PatientID = Patients.PatientID " +

            "INNER JOIN Drugs " +

            "ON Prescription.DrugId = Drugs.DrugId " +

            "WHERE IndoorPrescriptions.NursingStationId = @NursingStationID " +
            
            "AND Prescription.PrescriptionStatus = 'active' ";
            
            string connection = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

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