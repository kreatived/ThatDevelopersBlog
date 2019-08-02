using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.Data.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}