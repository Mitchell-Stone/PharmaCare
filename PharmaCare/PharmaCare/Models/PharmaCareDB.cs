﻿using System.Configuration;
using System.Data.SqlClient;

namespace PharmaCare.Models
{
    public class PharmaCareDB
    {
        public static SqlConnection GetConnection()
        {
            //connection string for pharmacaredb
            string connectionString = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;
            //sql connection 
            SqlConnection connection = new SqlConnection(connectionString);
            //return the connection
            return connection;
        }

        public static SqlConnection GetLocalConnection()
        {
            //get the connection string from the config file to connect to the local database
            string connectionString = ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;

            //create the connection
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}