using BlogApi.Data;
using BlogApi.Data.Entities;
using MongoDB.Driver;

namespace BlogApi.DAL.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        
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
    }
}