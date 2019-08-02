using System.Collections.Generic;
using BlogApi.Data;
using BlogApi.Data.Entities;
using MongoDB.Driver;

namespace BlogApi.DAL.Repositories
{
    public interface ICommentRepository: IRepository<Comment>
    {
        
    }

    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(IBlogDatabaseSettings settings) : base(settings, settings.CommentsCollectionName)
        {
            var indexOptions = new CreateIndexOptions();
            var commentIdPostedDateIndexKeys = Builders<Comment>.IndexKeys.Ascending(c => c.PostId).Ascending(c => c.PostedDate);
            var commentIdPostedDateIndexModel = new CreateIndexModel<Comment>(commentIdPostedDateIndexKeys, indexOptions);

            var commentIdFullSlugIndexKeys = Builders<Comment>.IndexKeys.Ascending(c => c.PostId).Ascending(c => c.FullSlug);
            var commentIdFullSlugIndexModel = new CreateIndexModel<Comment>(commentIdFullSlugIndexKeys, indexOptions);
            
            var indexModels = new List<CreateIndexModel<Comment>> {
                commentIdFullSlugIndexModel,
                commentIdPostedDateIndexModel
            };
            _entities.Indexes.CreateMany(indexModels);
        }
    }
}