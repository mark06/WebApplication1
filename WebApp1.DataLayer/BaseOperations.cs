using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WebApp1.Configuration;

namespace WebApp1.DataLayer
{
    public class BaseOperations: IDisposable
    {
        public SqlConnection Connection { get; set; }
        private bool disposeConnection;

        public BaseOperations(SqlConnection connection)
        {
            Connection = connection;

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            disposeConnection = false;
        }

        public BaseOperations(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();

            disposeConnection = true;
        }

        public BaseOperations() : this(Config.GetInstance.ConnectionString) { }

        public void Dispose()
        {
            if (disposeConnection)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}
