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
            get { return _connection; }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
