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

            request.Id = GetNextId();

            using var connection = new SqliteConnection(databaseConfig.Name);

            connection.Execute("INSERT INTO RequestInfo (RequestData, RequestDate)" +
                "VALUES (@RequestData, @RequestDate);", request);
        }

        private int GetNextId()
        {
            Random rnd = new Random(100);
            return rnd.Next();
        }
    }
}
