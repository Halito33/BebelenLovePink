using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BebelenLovePink.Models
{
    public class Inventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("nombre")]
        public string Nombre { get; set; } = null!;

        [BsonElement("marca")]
        public string Marca { get; set; } = null!;

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }


        [BsonElement("photo")]
        public string PhotoUrl { get; set; }

        [BsonElement("cantidad")]
        public int Cantidad { get; set; } = 0!;

        [BsonElement("estado")]
        public string Estado { get; set; }

        [BsonElement("precio")]
        public int Precio { get; set; } = 0!;
    }
}
