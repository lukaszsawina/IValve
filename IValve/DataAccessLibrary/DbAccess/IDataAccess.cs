using Dapper;

namespace DataAccessLibrary.DbAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadDataSP<T, U>(string storedProcedure, U parameters, string connectionName = "Default");
        Task<IEnumerable<T>> LoadDataSQL<T>(string query, string connectionName = "Default");
        Task<int> SaveDataSP(string storedProcedure, DynamicParameters parameters, string connectionName = "Default");
    }
}
