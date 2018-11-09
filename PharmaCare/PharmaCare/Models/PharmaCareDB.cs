using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class PharmaCareDB
    {
        public static SqlConnection GetConnection()
        {
            //connection string for pharmacaredb
            string connectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["PharmaCareDB"].ConnectionString;
            //sql connection 
            SqlConnection connection = new SqlConnection(connectionString);
            //return the connection
            return connection;
        }
    }
}