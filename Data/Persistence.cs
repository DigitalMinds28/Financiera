using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Persistence
    {
        MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);

        public MySqlConnection openConection()
        {

            try
            {
                _connection.Open();
                return _connection;
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
        }
        public void closeConection()
        {
            _connection.Close();
        }
    }
}