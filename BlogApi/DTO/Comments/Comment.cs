using System;
using System.Collections.Generic;

namespace BlogApi.DTO.Comments
{
    public class Comment
    {
        public string PostId { get; set; }
        public string ParentId { get; set; }
        public string Slug { get; set; }
        public string FullSlug { get; set; }
        public string Text { get; set; }
        public Author Author { get; set; }
        public DateTime PostedDate { get; set; }
        public List<string> Likes { get; set; }

        public Comment(DataLayer.Entities.Comment comment)
        {
            PostId = comment.PostId;
            ParentId = comment.ParentId;
            Slug = comment.Slug;
            FullSlug = comment.FullSlug;
            Text = comment.Text;
            Author = new Author
            {
                Id = comment.Author.Id,
                Name = comment.Author.Name,
                AvatarUrl = comment.Author.AvatarUrl
            };
            PostedDate = comment.PostedDate;
            Likes = comment.Likes;
        }
    }
}