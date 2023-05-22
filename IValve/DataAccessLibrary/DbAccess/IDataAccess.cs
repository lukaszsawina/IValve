using Dapper;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.DbAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadDataSP<T, U>(string storedProcedure, U parameters, string connectionName = "Default");

        Task<IEnumerable<PersonModel>> LoadPersonsAsync(string connectionName = "Default");
        Task<IEnumerable<RoomModel>> LoadRoomsAsync(string connectionName = "Default");
        Task<IEnumerable<DrinkModel>> LoadDrinksAsync(string connection = "Default");
        Task<IEnumerable<FoodModel>> LoadFoodAsync(string connection = "Default");
        Task<IEnumerable<ItemModel>> LoadItemsAsync(string connection = "Default");
        Task<IEnumerable<JobModel>> LoadJobsAsync(string connection = "Default");

        Task<IEnumerable<T>> LoadDataSQL<T>(string query, string connectionName = "Default");
        Task<int> SaveDataSP(string storedProcedure, DynamicParameters parameters, string connectionName = "Default");
        Task UpdateDataSP(string storedProcedure, DynamicParameters parameters, string connectionName = "Default");
    }
}
