using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devart.Data;
using Devart.Data.MySql;

namespace gsbProject
{
    class DB
    {
        public MySqlConnection connection;
        private string connectionString;

        public DB(string server, string db, string login, string password)
        {
            this.connectionString = "SERVER=" + server + ";" + "DATABASE=" + db + ";" + "UID=" + login + ";" + "PASSWORD=" + password + ";CharSet=utf8;";
        }

        //ouvrir la connexion à la base
        public bool OpenConnection()
        {
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        //fermer la connexion à la base
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}
