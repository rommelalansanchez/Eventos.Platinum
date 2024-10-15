using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Eventos.Platinum.Library.DataAccess.Sql
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly IDatabaseConfiguration _sqlConfiguration;

        public SqlDataAccess(IDatabaseConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }

        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = new SqlConnection(_sqlConfiguration.ConnectionString);
            List<T> rows = (await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
            return rows;
        }

        public async Task<object> SaveDataAsync<T>(string storedProcedure, T parameters)
        {
            using IDbConnection connection = new SqlConnection(_sqlConfiguration.ConnectionString);
            return await connection.ExecuteScalarAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = new SqlConnection(_sqlConfiguration.ConnectionString);
            List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            return rows;
        }
    }
}
