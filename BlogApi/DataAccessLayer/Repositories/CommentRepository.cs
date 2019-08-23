using System.Collections.Generic;
using BlogApi.DataLayer;
using BlogApi.DataLayer.Entities;
using MongoDB.Driver;

namespace BlogApi.DataAccessLayer.Repositories
{
    public interface ICommentRepository: IRepository<Comment>
    {
        List<Comment> GetCommentsByPostId(string postId, int pageNum);
    }

    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private const int PageSize = 20;

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

        public List<Comment> GetCommentsByPostId(string postId, int pageNum)
        {
            return _entities.Find(c => c.PostId == postId).SortBy(c => c.FullSlug).Skip(PageSize * pageNum).Limit(PageSize).ToList();
        }
    }
}