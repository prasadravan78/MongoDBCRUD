namespace MongoDBAPI.Services.ProductService
{
    using MongoDBAPI.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();

        Task<Product> AddProductAsync(Product productToAdd);

        Task<Product> UpdateProductAsync(Product productToAdd);

        Task DeleteProductAsync(string productIdToDelete);
    }
}