using Microsoft.AspNet.SignalR.Infrastructure;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNet.SignalR.Messaging;
using System.Data.Common;


namespace ServerPrac
{
    public class DbConnection
    {

        private readonly string _connectionString;

        public DbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public void OpenConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public SqlCommand CreateCommand(string sql, SqlConnection connection)
        {
            return new SqlCommand(sql, connection);
        }
        
    }
}
   

