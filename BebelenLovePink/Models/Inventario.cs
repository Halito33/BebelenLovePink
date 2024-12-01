using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BebelenLovePink.Models
{
    public partial class Inventario
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

        public string photo { get; set; }

        [BsonElement("cantidad")]
        public int Cantidad { get; set; }

        [BsonElement("precio")]
        public int Precio { get; set; }
    }
}
