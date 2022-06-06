using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PhoneDirectory.Library
{
    internal class SQLDataAccess : ISQLDataAccess
    {
        public async Task<List<T>> LoadDataAsync<T, U>(string sqlStatement,
                                      U parameters,
                                      string connectionString,
                                      bool isStoredProcedure = false)
        {

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sqlStatement, parameters, commandType: commandType);

                List<T> result = new();

                result = rows.ToList();

                return result;
            }
        }

        public async Task SaveDataAsync<T>(string sqlStatement,
                                T parameters,
                                string connectionString,
                                bool isStoredProcedure = false)
        {

            CommandType commandType = CommandType.Text;

            if (isStoredProcedure)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sqlStatement, parameters, commandType: commandType);
            }
        }
    }
}
