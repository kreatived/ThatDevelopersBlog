using System.Collections.Generic;
using BlogApi.DataLayer;
using BlogApi.DataLayer.Entities;
using MongoDB.Driver;

namespace BlogApi.DataAccessLayer.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _entities;

        protected Repository(IBlogDatabaseSettings settings, string collectionName) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _entities = database.GetCollection<T>(collectionName);
        }

        public virtual List<T> GetAll()
        {
            return _entities.Find(obj => true).ToList();
        }

        public virtual T GetById(string id)
        {
            return _entities.Find<T>(o => o.Id == id).FirstOrDefault();
        }

        public virtual T Insert(T obj)
        {
            _entities.InsertOne(obj);
            return obj;
        }

        public virtual void Update(string id, T obj)
        {
            _entities.ReplaceOne(o => o.Id == id, obj);
        }

        public virtual void Delete(string id)
        {
            _entities.DeleteOne(o => o.Id == id);
        }
    }
}