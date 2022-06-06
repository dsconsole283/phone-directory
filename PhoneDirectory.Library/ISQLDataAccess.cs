namespace PhoneDirectory.Library
{
    internal interface ISQLDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false);
        Task<T> LoadDataSingleAsync<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false);
        Task SaveDataAsync<T>(string sqlStatement, T parameters, string connectionString, bool isStoredProcedure = false);
    }
}