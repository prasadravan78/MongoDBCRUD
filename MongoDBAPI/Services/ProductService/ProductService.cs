namespace MongoDBAPI.Services.ProductService
{
    using MongoDB.Driver;
    using MongoDBAPI.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> productCollection;

        public ProductService(IProductConnectionSettings productConnectionSettings)
        {
            var client = new MongoClient(productConnectionSettings.ConnectionString);
            var database = client.GetDatabase(productConnectionSettings.DatabaseName);

            productCollection = database.GetCollection<Product>(productConnectionSettings.CollectionName);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await productCollection.Find(k => true).ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product productToAdd)
        {
            try
            {
                await productCollection.InsertOneAsync(productToAdd);
            }
            catch (Exception ex)
            {

            }

            return productToAdd;
        }

        public async Task<Product> UpdateProductAsync(Product productToUpdate)
        {
            try
            {
                await productCollection.ReplaceOneAsync<Product>(k => k.Id == productToUpdate.Id, productToUpdate);
            }
            catch (Exception ex)
            {

            }

            return productToUpdate;
        }

        public async Task DeleteProductAsync(string productIdToDelete)
        {
            await productCollection.DeleteOneAsync<Product>(k => k.Id == productIdToDelete);
        }

        public async Task<List<Product>> GetProductsByProductCategoryName(string productCategoryName)
        {
            return await productCollection.Find(k => true && k.ProductCategory.Name == productCategoryName).ToListAsync();
        }

        public async Task<List<Product>> GetRelatedProductsByProductId(string productId)
        {
            var product = await productCollection.Find(k => true && k.Id == productId).FirstOrDefaultAsync();

            return product.RelatedProducts;
        }
    }
}
