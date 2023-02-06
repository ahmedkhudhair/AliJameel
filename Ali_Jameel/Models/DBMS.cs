using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Ali_Jameel.Models
{
    public class DBMS
    {
        public DBMS()
        {

        }
        public DataTable ExecuteSelectQuery(string query)
        {
            Mysql mysqlConnProp = new Mysql();
            DataTable table = new DataTable();
            if (mysqlConnProp.OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, mysqlConnProp.Connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                table.Load(dataReader);
                mysqlConnProp.CloseConnection();
            }

            return table;
        }

        public bool ExecuteInsertQuery(string query)
        {
            Mysql mysqlConnProp = new Mysql();
            bool ok = false;
            if (mysqlConnProp.OpenConnection())
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, mysqlConnProp.Connection);
                //Create a data reader and Execute the command
                int rowsnumber = cmd.ExecuteNonQuery();
                mysqlConnProp.CloseConnection();
                if (rowsnumber > -1)
                {
                    ok = true;
                }
            }
            return ok;
        }

        //public bool ExecuteInsertQuery(string post_title, Byte[] data)
        //{
        //    Mysql mysqlConnProp = new Mysql();
        //    bool ok = false;
        //    if (mysqlConnProp.OpenConnection())
        //    {



        //        String query = "INSERT INTO post (post_title,poststream) VALUES (@post_title,@poststream)";

        //        //Create Command
        //        MySqlCommand command = new MySqlCommand(query, mysqlConnProp.Connection);
        //        command.Parameters.Add("@post_title", MySqlDbType.String).Value = post_title;
        //        command.Parameters.Add("@poststream", MySqlDbType.Blob).Value = data;


        //        //Create a data reader and Execute the command
        //        int rowsnumber = command.ExecuteNonQuery();
        //        mysqlConnProp.CloseConnection();
        //        if (rowsnumber > -1)
        //        {
        //            ok = true;
        //        }
        //    }
        //    return ok;
        //}
    }

    public class Mysql
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;

        public MySqlConnection Connection { get => _connection; set => _connection = value; }
        public string Server { get => _server; set => _server = value; }
        public string Database { get => _database; set => _database = value; }
        public string Uid { get => _uid; set => _uid = value; }
        public string Password { get => _password; set => _password = value; }

        public Mysql()
        {
            Initialize();
        }

        private void Initialize()
        {
            _server = "localhost";
            _database = "alijameel";
            _uid = "ahmed";
            _password = "ahmed@123";
            string connectionString;
            connectionString = "Server=localhost;Port=3307;Database=alijameel;Uid=ahmed;Pwd=ahmed@123;";

            _connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}