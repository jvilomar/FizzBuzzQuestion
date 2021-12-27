using Dapper;
using Microsoft.Data.Sqlite;
using System;
using FizzBuzzQ.TechDemo.Interfaces;
using FizzBuzzQ.TechDemo.Models;

namespace FizzBuzzQ.TechDemo.Data
{
    public class DataService : IDataService
    {
        private readonly DbConfiguration databaseConfig;

        public DataService(DbConfiguration databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Create(RequestInfo request)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            connection.Execute("INSERT INTO RequestInfo (RequestData, RequestDate)" +
                "VALUES (@RequestData, @RequestDate);", request);
        }
    }
}
