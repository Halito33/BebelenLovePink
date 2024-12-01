namespace BebelenLovePink.Data
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string Database { get; set ; } = null!;
    }
}
