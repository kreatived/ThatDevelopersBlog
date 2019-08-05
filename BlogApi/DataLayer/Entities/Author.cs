using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.DataLayer.Entities
{
    public class Author
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
    }
}