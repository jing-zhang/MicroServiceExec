using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Threading;

namespace MongoDBService
{
    public interface IUserRepository
    {
        void Insert(BsonDocument user);
        void InsertAsync(BsonDocument user);
        List<BsonDocument> Get(FilterDefinition<BsonDocument> filter);
    }
    public class UserRepository : IUserRepository
    {
        IMongoDatabase _db;
        IMongoCollection<BsonDocument> _users;

        const string TABLE_NAME = "Users";

        public UserRepository(IMongoDatabase db)
        {
            _db = db;
            _users = _db.GetCollection<BsonDocument>(TABLE_NAME);
        }

        public void Insert(BsonDocument user)
        {
            _users.InsertOne(user);
        }

        public async void InsertAsync(BsonDocument user)
        {
             await _users.InsertOneAsync(user);
        }

        public List<BsonDocument> Get(FilterDefinition<BsonDocument> filter)
        {
            return _users.Find<BsonDocument>(filter).ToList();
        }
    }
}
