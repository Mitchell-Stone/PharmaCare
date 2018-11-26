﻿/*
 *      Date Created = 30th October 2018
 *      Created By = 
 *      Purpose = This is the model that returns the data needed for patient interaction
 *      Bugs = No known bugs
 */

using System.Data.SqlClient;

namespace PharmaCare.Models
{
    public class PatientDB
    {
        /// <summary>
        /// Gets the patient by name
        /// </summary>
        /// <param name="PatientName"></param>
        /// <returns></returns>
        public static Patient getPatientByName(string PatientName)
        {
            //set connection to PharmaCareDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //select statement
            string selectStatement = "SELECT * FROM Patients WHERE Name = @PatientName";
            //select command
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PatientName", PatientName);

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

        /// <summary>
        /// gets all Patients with matching name
        /// </summary>
        /// <param name="con"></param>
        /// <param name="PatientName"></param>
        /// <returns></returns>
        public static SqlDataReader getPatients(SqlConnection con, string PatientName)
        {
            //select statement
            string selectStatement = "SELECT * FROM Patients WHERE Name = @PatientName";

            //select command
            using (var selectCommand = new SqlCommand(selectStatement, con))
            {
                selectCommand.Parameters.AddWithValue("@PatientName", PatientName);
                return selectCommand.ExecuteReader();
            }
        }

        /// <summary>
        /// Gets the patient by ID
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public static Patient getPatientById(int PatientID)
        {
            //set connection to schoolDB class GetConnection method
            SqlConnection connection = PharmaCareDB.GetConnection();
            //select statement
            string selectStatement = "SELECT * FROM Patients WHERE PatientID = @PatientID";
            //select command
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