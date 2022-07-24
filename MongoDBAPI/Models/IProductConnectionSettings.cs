namespace MongoDBAPI.Models
{
    public interface IProductConnectionSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}