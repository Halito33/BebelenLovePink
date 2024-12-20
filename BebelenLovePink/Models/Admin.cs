using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BebelenLovePink.Models
{

    public partial class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("usuario")]
        public string User { get; set; } = null!;
        [BsonElement("password")]
        public string Password { get; set; } = null!;

    }
}
