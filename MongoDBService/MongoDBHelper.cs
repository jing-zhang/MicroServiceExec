using System;
using MongoDB.Driver;


namespace MongoDBService
{
    public interface IMongoHelper 
    {
    }

    public class MongoHelper
    {
        IMongoClient _client { get; set; }

        public IMongoDatabase _database { get; private set; }

        const string CONN_STR = "mongodb://localhost:27017";

        const string DB_NAME = "local";

        public MongoHelper()
        {
            _client = new MongoClient(CONN_STR);
            _database = _client.GetDatabase(DB_NAME);
        }
        
    }
}
