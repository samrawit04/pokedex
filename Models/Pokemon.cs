using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pokedex.Models
{
    public class Pokemon
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)] 
        public string? Id { get; set; }

        public string? Name { get; set; }  
        public string? Type { get; set; }
        public string? Ability { get; set; }
        public int? Level { get; set; }
    }
}