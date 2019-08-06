using System.Collections.Generic;
using System.Linq;
using BlogApi.DataAccessLayer.Repositories;
using BlogApi.DTO;
using BlogApi.Exceptions;

namespace BlogApi.ServiceLayer.Services
{
    public interface IPostService
    {
        List<PostSummary> GetPostSummaries();
        Post GetPost(string slug);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<PostSummary> GetPostSummaries()
        {
            var posts = _postRepository.GetAll();

            var summaries = posts.Select(p => new PostSummary { Id = p.Id, Title = p.Title, Slug = p.Slug, Teaser = p.Teaser, PublicationDate = p.PublicationDate.Value, Author = new Author { Id = p.Author.Id, Name = p.Author.Name, AvatarUrl = p.Author.AvatarUrl}, Likes = p.Likes.Count }).ToList();
        
            return summaries;
        }

        public Post GetPost(string slug)
        {
            var post = _postRepository.GetBySlug(slug);

            if(post == null)
            {
                throw new PostNotFoundException("slug", slug);
            }

            return new Post(post);
        }
    }
}