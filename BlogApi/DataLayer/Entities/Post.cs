using System;
using System.Collections.Generic;

namespace BlogApi.DataLayer.Entities
{
    public class Post: Entity
    {
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Author Author { get; set; }
        public List<string> Likes { get; set; }
    }
}