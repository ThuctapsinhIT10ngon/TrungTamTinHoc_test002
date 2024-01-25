using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TrungTamTinHoc
{
    public class MongoDBConnector
    {
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;

        public MongoDBConnector(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            this.database = client.GetDatabase(databaseName);
            this.collection = database.GetCollection<BsonDocument>(collectionName);
        }

        public void InsertDocument(BsonDocument document)
        {
            this.collection.InsertOne(document);
        }

        public void UpdateDocument(FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            this.collection.UpdateOne(filter, update);
        }

        public BsonDocument FindDocument(FilterDefinition<BsonDocument> filter)
        {
            return this.collection.Find(filter).FirstOrDefault();
        }
    }
}