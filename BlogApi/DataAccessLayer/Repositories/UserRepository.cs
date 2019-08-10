using BlogApi.DataLayer;
using BlogApi.DataLayer.Entities;
using MongoDB.Driver;

namespace BlogApi.DataAccessLayer.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User GetBySubId(string subId);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IBlogDatabaseSettings settings) : base(settings, settings.UsersCollectionName)
        {
            var indexOptions = new CreateIndexOptions();
            var indexKeys = Builders<User>.IndexKeys.Ascending(p => p.SubId);
            var indexModel = new CreateIndexModel<User>(indexKeys, indexOptions);
            _entities.Indexes.CreateOne(indexModel);
        }

        public User GetBySubId(string subId)
        {
            return _entities.Find(e => e.SubId == subId).FirstOrDefault();
        }
    }
}