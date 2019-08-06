using System;
using System.Collections.Generic;

namespace BlogApi.DTO
{
    public class Post
    {
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string Slug { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Author Author { get; set; }
        public List<string> Likes { get; set; }

        public Post(DataLayer.Entities.Post post)
        {
            Title = post.Title;
            Teaser = post.Teaser;
            Slug = post.Slug;
            HeaderImageUrl = post.HeaderImageUrl;
            Content = post.Content;
            PublicationDate = post.PublicationDate;
            Author = new Author {
                Id = post.Author.Id,
                Name = post.Author.Name,
                AvatarUrl = post.Author.AvatarUrl
            };
            Likes = post.Likes;
        }
    }
}