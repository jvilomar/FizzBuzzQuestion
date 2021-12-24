using Dapper;
using Microsoft.Data.Sqlite;
using System;
using WillDom.TechDemo.Interfaces;
using WillDom.TechDemo.Mdels;

namespace WillDom.TechDemo.Data
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

            connection.Execute("INSERT INTO RequestInfo (Id, RequestData, RequestDate)" +
                "VALUES (@Id, @RequestData, @RequestDate);", request);
        }

        private int GetNextId()
        {
            Random rnd = new Random(100);
            return rnd.Next();
        }
    }
}
