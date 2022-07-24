namespace MongoDBAPI.Models
{

    public class ProductConnectionSettings : IProductConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
