﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class HospitalDB
    {
    public static MySqlConnection GetConnection()
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
                MySqlConnection connection = new MySqlConnection(connectionString);
                //return the sqlconnection
                return connection;
            }
    }
}