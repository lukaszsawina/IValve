namespace DataAccessLibrary.DbAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadDataSP<T, U>(string storedProcedure, U parameters, string connectionName = "Default");
        Task<IEnumerable<T>> LoadDataSQL<T>(string query, string connectionName = "Default");
        Task<IEnumerable<T>> SaveDataSP<T, U>(string storedProcedure, U parameters, string connectionName = "Default");
    }
}
