using System;
using System.Collections.Generic;
using System.Linq;
using BlogApi.DataAccessLayer.Repositories;
using BlogApi.DTO;
using BlogApi.DTO.Posts;
using BlogApi.Exceptions;
using BlogApi.ServiceLayer.Models;
using PostEntity = BlogApi.DataLayer.Entities.Post;
using AuthorEntity = BlogApi.DataLayer.Entities.Author;

namespace BlogApi.ServiceLayer.Services
{
    public interface IPostService
    {
        List<PostSummary> GetPostSummaries();
        Post GetPost(string slug);
        Post CreatePost(PostForCreate postForCreate, ApplicationUser byUser);
    }

    public class PostService : IPostService
    {
        private readonly ISlugService _slugService;
        private readonly IPostRepository _postRepository;

        public PostService(ISlugService slugService, IPostRepository postRepository)
        {
            _slugService = slugService;
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

        public Post CreatePost(PostForCreate postForCreate, ApplicationUser byUser)
        {
            ValidateUserCanCreatePosts(byUser);

            var post = new PostEntity 
            {
                Title = postForCreate.Title,
                Teaser = postForCreate.Teaser,
                Slug = _slugService.GenerateSlugForPostTitle(postForCreate.Title),
                HeaderImageUrl = postForCreate.HeaderImageUrl,
                Content = postForCreate.Content,
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = DateTime.UtcNow,
                Likes = new List<string>(),
                Author = new AuthorEntity
                {
                    Id = byUser.Id,
                    Name = byUser.Name,
                    AvatarUrl = byUser.AvatarUrl
                }
            };

            return new Post(_postRepository.Insert(post));
        }

        private static void ValidateUserCanCreatePosts(ApplicationUser byUser)
        {
            byUser.Permissions.TryGetValue("CanCreatePosts", out bool canCreatePosts);

            if(!canCreatePosts)
            {
                throw new UnauthorizedOperationException(byUser.Id, "Create Post");
            }
        }
    }
}