/*
 *      Date Created = 27th October 2018
 *      Created By = 
 *      Purpose = This class manages the connection to the TAFE internal database
 *      Bugs = No known bugs
 */

using System.Data.SqlClient;

namespace PharmaCare.Models
{
    public class HospitalDB
    {
    public static SqlConnection GetConnection()
            {
                string server;
                string database;
                string uid;
                string password;

                //server ip
                server = "172.17.124.118";
                //database name
                database = "hospitaldb";
                //username
                uid = "elan";
                //password
                password = "elan759";
                //connectionString
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                //set the connection string to the mysql connecter
                SqlConnection connection = new SqlConnection(connectionString);
                //return the sqlconnection
                return connection;
            }
    }
}