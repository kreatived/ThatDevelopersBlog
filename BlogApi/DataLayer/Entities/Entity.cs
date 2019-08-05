using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogApi.DataLayer.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}