using System.Collections.Generic;
using BlogApi.DataLayer.Entities;

namespace BlogApi.DataAccessLayer.Repositories
{
    public interface IRepository<T> where T: Entity
    {
        List<T> GetAll();
        T GetById(string id);
        T Insert(T obj);
        void Update(string id, T obj);
        void Delete(string id);
    }
}