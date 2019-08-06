using System.Collections.Generic;
using BlogApi.DataLayer;
using BlogApi.DataLayer.Entities;
using MongoDB.Driver;

namespace BlogApi.DataAccessLayer.Repositories
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

        public override List<Post> GetAll()
        {
            return _entities.Find(p => p.PublicationDate.HasValue).ToList();
        }
    }
}