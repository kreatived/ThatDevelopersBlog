using System;

namespace BlogApi.DTO
{
    public class PostSummary
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public DateTime PublicationDate { get; set; } 
        public Author Author { get; set; }
        public int Likes { get; set; }
    }
}