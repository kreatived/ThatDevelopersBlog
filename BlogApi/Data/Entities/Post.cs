using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.Data.Entities
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Teaser { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime? PublicationDate { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }
        public List<string> Likes { get; set; }
    }
}