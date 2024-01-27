using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;

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

        public List<BsonDocument> FindAllDocument(FilterDefinition<BsonDocument> filter)
        {
            return this.collection.Find(filter).ToList();
        }

        public List<BsonDocument> Lookup(string fromCollection, string localField, string foreignField, string asField)
        {
            var pipeline = new BsonDocument[]
            {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", fromCollection },
                { "localField", localField },
                { "foreignField", foreignField },
                { "as", asField }
            })
            };

            return collection.Aggregate<BsonDocument>(pipeline).ToList();
        }
    }

    public class MongoDBConnector_1
    {
        private IMongoDatabase database;
        private IMongoCollection<dynamic> _collection;

        public IMongoCollection<dynamic> Collection => _collection;

        public MongoDBConnector_1(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            this.database = client.GetDatabase(databaseName);
            this._collection = database.GetCollection<dynamic>(collectionName);
        }
    }
}