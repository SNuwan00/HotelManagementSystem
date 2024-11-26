using System;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    internal class DBConnection
    {

        private static DBConnection connection;
        private SqlConnection conn;

        private DBConnection() { }
        public SqlConnection getConnection(String serverName, string dbName, string security) {
            if (conn == null)
            {
                String connString = "Data Source = " + serverName + ";" +
                                                "Initial Catalog = " + dbName + ";" +
                                                "Integrated Security = " + security;

                conn = new SqlConnection(connString);
            }
            return conn;
        }

        public static DBConnection GetInstance()
        {
            if (connection == null) { 
                connection = new DBConnection();
            }
            return connection;
        }
    }
}


//hotel_management_system_database
