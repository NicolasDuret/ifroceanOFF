using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IfroceanOFF.DAL
{
    class DalConnexion
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        public static MySqlConnection connection;

        public static MySqlConnection OpenConnection()
        {
            if (connection == null) //  si la connexion est déjà ouverte, il ne la refera pas 
            {
                server = "localhost";
                database = "ifrocean";
                uid = "ifrocean";
                password = "ifrocean";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
