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

        public bool ExecuteDeleteQuery(string query)
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

        public bool ExecuteInsertQuery(News News)
        {
            Mysql mysqlConnProp = new Mysql();
            bool ok = false;

            try
            {
                if (mysqlConnProp.OpenConnection())
                {

                    String query = $"insert into news (Title,description,logo,WebsiteLink,htmlContent,PublishDate) values (@TitleText  , @DescriptionText,'{News.LogoPath.FileName}' , '{News.WebsiteLink}', @htmlText,'{News.PublishDate}')";

                    //Create Command
                    MySqlCommand command = new MySqlCommand(query, mysqlConnProp.Connection);
                    command.Parameters.AddWithValue("@htmlText", News.HtmlContent);
                    command.Parameters.AddWithValue("@TitleText", News.Title);
                    command.Parameters.AddWithValue("@DescriptionText", News.Description);

                    //Create a data reader and Execute the command
                    int rowsnumber = command.ExecuteNonQuery();
                    mysqlConnProp.CloseConnection();
                    if (rowsnumber > -1)
                    {
                        ok = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            
            return ok;
        }
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