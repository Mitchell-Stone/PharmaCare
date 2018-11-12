using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string NursingStationID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            NursingStationID = ddlNurseStations.SelectedValue;

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

             "WHERE IndoorPrescriptions.NursingStationId = @NursingStationID";

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

        protected void NurseStationSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ddlNurseStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            NursingStationID = ddlNurseStations.SelectedValue;
            scheduleList.DataSource = null;
            scheduleList.DataBind();
            BindData();
        }
    }
}