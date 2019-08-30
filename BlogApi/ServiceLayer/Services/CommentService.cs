using System.Collections.Generic;
using System.Linq;
using BlogApi.DataAccessLayer.Repositories;
using BlogApi.Exceptions;

namespace BlogApi.ServiceLayer.Services
{
    public interface ICommentService
    {
        List<DTO.Comments.Comment> GetPostComments(string postId, int pageNum);
    }

    public class CommentService : ICommentService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        public List<DTO.Comments.Comment> GetPostComments(string slug, int pageNum)
        {
            var post = _postRepository.GetBySlug(slug);

            if(post == null)
            {
                throw new PostNotFoundException("slug", slug);
            }

            var comments = _commentRepository.GetCommentsByPostId(post.Id, pageNum);
            return comments.Select(c => new DTO.Comments.Comment(c)).ToList();
        }
    }
}