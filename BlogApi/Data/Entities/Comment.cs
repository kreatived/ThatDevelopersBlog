using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.Data.Entities
{
    public class Comment: Entity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string PostId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParentId { get; set; }
        public string Slug { get; set; }
        public string FullSlug { get; set; }
        public string Text { get; set; }
        public CommentAuthor Author { get; set; }
        public DateTime PostedDate { get; set; }
        public List<string> Likes { get; set; }
    }
}