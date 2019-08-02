using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.Data.Entities
{
    public class CommentAuthor
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
    }
}