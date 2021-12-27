using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using FizzBuzzQ.TechDemo.Interfaces;
using FizzBuzzQ.TechDemo.Models;

namespace FizzBuzzQ.TechDemo.Data
{
    public class DatabaseSetup : IDatabaseSetup
    {
        private readonly DbConfiguration _dbConfiguration;

        public DatabaseSetup(DbConfiguration dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_dbConfiguration.Name);
            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'RequestInfo';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "RequestInfo")
                return;

            connection.Execute("Create Table RequestInfo (" +
                "Id INTEGER AUTOINCREMENT," +
                "RequestData VARCHAR(1000) NULL," +
                "RequestDate VARCHAR(25) NULL);");
        }

    }
}
