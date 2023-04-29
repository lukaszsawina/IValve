using Dapper;
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
                IEnumerable<T> values = await connection.QueryAsync<T>(query, commandType: CommandType.Text);
                return values.ToList();
            }
        }

        public Task<IEnumerable<T>> SaveDataSP<T, U>(string storedProcedure, U parameters, string connectionName = "Default")
        {
            throw new NotImplementedException();
        }
    }
}
