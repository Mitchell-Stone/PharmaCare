using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class PatientDB
    {

        public static Patient getPatient(int PatientID)
        {
            //set connection to schoolDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //select statement
            string selectStatement = "SELECT * FROM Patients WHERE PatientID = @PatientID";
            //
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();
                SqlDataReader patientReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

                if
                   (patientReader.Read())
                {
                    Patient patient = new Patient();
                    patient.PatientID = (int)patientReader["PatientID"];
                    patient.Name = patientReader["Name"].ToString();
                    patient.Address = patientReader["Address"].ToString();
                    patient.City = patientReader["City"].ToString();
                    patient.ZipCode = patientReader["ZipCode"].ToString();
                    patient.Type = patientReader["Type"].ToString();
                    patient.doctorID = (int)patientReader["DoctorID"];
                    patient.wardID = (int)patientReader["WardID"];
                    patient.roomID = (int)patientReader["RoomID"];

                    return patient;

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
                connection.Close();
            }
        }
    }
}