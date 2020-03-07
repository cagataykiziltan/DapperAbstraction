using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperIntegration.Dapper
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IDbConnection _connection;

        public DapperRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]);
        }

       public IDbConnection Connection
        {
            get
            {
                if(_connection.State == ConnectionState.Broken)
                    _connection.Close();

                if(_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection;
            }
        }
        
        public void ConnectionClose()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();

        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public void CloseAndDispose()
        {
            ConnectionClose();
            Dispose();
        }
    }
}
