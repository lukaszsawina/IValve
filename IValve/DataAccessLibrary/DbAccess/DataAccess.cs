using Dapper;
using DataAccessLibrary.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DbAccess
{
    public class DataAccess : IDataAccess
    {
        public async Task<IEnumerable<T>> LoadDataSP<T, U>(string storedProcedure, U parameters, string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                IEnumerable<T> values = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return values.ToList();
            }
        }

        public async Task<IEnumerable<T>> LoadDataSQL<T>(string query, string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                IEnumerable<T> values = await connection.QueryAsync<T>(query);
                return values.ToList();
            }
        }

        public async Task<IEnumerable<DrinkModel>> LoadDrinksAsync(string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                string sql_query = "SELECT d.Drink_ID, d.Name, d.Amount, st.* FROM drinks as d INNER JOIN supplytypes as st ON st.Type_ID = d.Type";
                var values = await connection.QueryAsync<DrinkModel, SupplyType, DrinkModel>(sql_query, (drink, type) =>
                {
                    drink.Type = type;
                    return drink;
                }, splitOn: "Type_ID");

                return values.ToList();
            }
        }

        public async Task<IEnumerable<FoodModel>> LoadFoodAsync(string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                string sql_query = "SELECT f.Food_ID, f.Name, f.Amount, st.* FROM food as f INNER JOIN supplytypes as st ON st.Type_ID = f.Type";
                var values = await connection.QueryAsync<FoodModel, SupplyType, FoodModel>(sql_query, (food, type) =>
                {
                    food.Type = type;
                    return food;
                }, splitOn: "Type_ID");

                return values.ToList();
            }
        }

        public async Task<IEnumerable<ItemModel>> LoadItemsAsync(string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                string sql_query = "SELECT i.Item_ID, i.Name, i.Amount, st.* FROM items as i INNER JOIN supplytypes as st ON st.Type_ID = i.Type";
                var values = await connection.QueryAsync<ItemModel, SupplyType, ItemModel>(sql_query, (item, type) =>
                {
                    item.Type = type;
                    return item;
                }, splitOn: "Type_ID");

                return values.ToList();
            }
        }

        public async Task<IEnumerable<PersonModel>> LoadPersonsAsync( string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                string sql_query = "SELECT p.Person_ID, p.Firstname, p.Lastname, p.BirthDate, r.*, s.*, rm.Room_ID, rm.Capacity, st.* FROM person as p INNER JOIN roles as r on p.Role = r.Role_ID INNER JOIN status as s ON s.Status_ID = p.Status INNER JOIN rooms as rm ON rm.Room_ID = p.Room INNER JOIN sections as st ON st.Section_ID = rm.Section";
                var values = await connection.QueryAsync<PersonModel, RoleModel, StatusModel, RoomModel, SectionModel, PersonModel>(sql_query, (person, role, status, room, section) =>
                {
                    person.Role = role;
                    person.Status = status;
                    person.Room = room;
                    person.Room.Section = section;
                    return person;
                }, splitOn: "Role_ID, Status_ID, Room_ID, Section_ID");
                
                return values.ToList();
            }
        }
        public async Task<IEnumerable<RoomModel>> LoadRoomsAsync(string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                string sql_query = "SELECT r.Room_ID, r.Capacity, count(p.Person_ID) as 'Occupied', s.*FROM rooms as r INNER JOIN sections as s ON s.Section_ID = r.Section LEFT JOIN person as p ON p.Room = r.Room_ID GROUP BY r.Room_ID;";
                var values = await connection.QueryAsync<RoomModel, SectionModel, RoomModel>(sql_query, (room, section) =>
                {
                    room.Section = section;
                    return room;
                }, splitOn: "Section_ID");
                return values.ToList();
            }
        }
        public async Task<int> SaveDataSP(string storedProcedure, DynamicParameters parameters, string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("new_id");
            }
        }
        public async Task UpdateDataSP(string storedProcedure, DynamicParameters parameters, string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
