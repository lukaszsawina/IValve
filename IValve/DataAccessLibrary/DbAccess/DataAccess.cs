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

        public async Task<IEnumerable<PersonModel>> LoadPersonsAsync( string connectionName = "Default")
        {
            using (IDbConnection connection = new MySqlConnection(Helper.Connection(connectionName)))
            {
                string sql_query = "SELECT p.Person_ID, p.Firstname, p.Lastname, p.BirthDate, r.*, s.*, rm.* FROM person as p INNER JOIN roles as r on p.Role = r.Role_ID INNER JOIN status as s ON s.Status_ID = p.Status INNER JOIN rooms as rm ON rm.Room_ID = p.Room";
                var values = await connection.QueryAsync<PersonModel, RoleModel, StatusModel, RoomModel, PersonModel>(sql_query, (person, role, status, room) =>
                {
                    person.Role = role;
                    person.Status = status;
                    person.Room = room;
                    return person;
                }, splitOn: "Role_ID, Status_ID, Room_ID");
                
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
    }
}
