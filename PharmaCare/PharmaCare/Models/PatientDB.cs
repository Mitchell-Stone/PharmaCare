using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class PatientDB
    {
        public static Patient GetAllPatients()
        {
            //set connection to HospitalDB class GetConnection method
            SqlConnection connection = HospitalDB.GetConnection();
            //select statement
            string selectStatement = "SELECT * FROM patients";
            //select command
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            //try open connection otherwise throw error
            try
            {
                connection.Open();
                SqlDataReader patientReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                //read patients from patient table in hospitaldb
                if (patientReader.Read())
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
                    //return patient information
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