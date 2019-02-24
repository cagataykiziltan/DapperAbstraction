using System;
using System.Linq;
using Dapper;
using DapperIntegration.Dapper;

namespace DapperIntegration
{
    class Program
    {
        static void Main(string[] args)
        {

            IDapperRepository microOrm = new DapperRepository();

            #region Query

            var result = microOrm.Connection.Query<object>("Your Query").FirstOrDefault();

            #endregion

            #region DynamicParameters

            DynamicParameters parameters = new DynamicParameters();

            var query = "select * from SampleTable where id=@Id";
            parameters.Add("Id", 1);

            var resultForDynamicParameters = microOrm.Connection.Query<object>(query, parameters).FirstOrDefault();

            #endregion

            #region MultipleQuery

            var dapperQuery = microOrm.Connection.QueryMultiple("select * from SampleTable1 where id=3 select * from SampleTable2");

            var book = dapperQuery.Read().FirstOrDefault();
            var writers = dapperQuery.Read().ToList();

            #endregion

            microOrm.Connection.Dispose();

            Console.ReadKey();

        }

    }


}
