using System.Data;

namespace DapperIntegration.Dapper
{
    public interface IDapperRepository
    {
        IDbConnection Connection { get; }
        void Dispose();
    }
}