using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class DoctorDB
    {
        public static Doctor GetAllDoctors()
        {
            //set connection to HospitalDB class GetConnection method
            SqlConnection connection = HospitalDB.GetConnection();
            //select statement
            string selectStatement = "SELECT * FROM doctors";
            //select command
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            //try open connection otherwise throw error
            try
            {
                connection.Open();
                SqlDataReader doctorReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                //read patients from patient table in hospitaldb
                if (doctorReader.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.DoctorID = (int)doctorReader["DoctorID"];
                    doctor.Name = doctorReader["Name"].ToString();
                    doctor.Address = doctorReader["Address"].ToString();
                    doctor.City = doctorReader["City"].ToString();
                    doctor.ZipCode = doctorReader["ZipCode"].ToString();
                    doctor.Speciality = doctorReader["Speciality"].ToString();
                    return doctor;
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