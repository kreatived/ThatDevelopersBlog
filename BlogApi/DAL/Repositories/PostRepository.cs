using BlogApi.Data;
using BlogApi.Data.Entities;
using MongoDB.Driver;

namespace BlogApi.DAL.Repositories
{
    public interface IPostRepository: IRepository<Post>
    {
        
    }

    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IBlogDatabaseSettings settings) : base(settings, settings.PostsCollectionName)
        {
            var indexOptions = new CreateIndexOptions();
            var indexKeys = Builders<Post>.IndexKeys.Ascending(p => p.Slug);
            var indexModel = new CreateIndexModel<Post>(indexKeys, indexOptions);
            _entities.Indexes.CreateOne(indexModel);
        }
    }
}