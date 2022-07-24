namespace MongoDBAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;

    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Quantity")]
        public int? Quantity { get; set; }

        [BsonElement("ProductCategory")]
        public ProductCategory ProductCategory { get; set; }

        [BsonElement("RelatedProducts")]
        public List<Product> RelatedProducts { get; set; }
    }
}
