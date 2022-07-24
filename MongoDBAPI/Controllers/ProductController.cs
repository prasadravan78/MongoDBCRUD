namespace MongoDBAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MongoDBAPI.Models;
    using MongoDBAPI.Services.ProductService;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await productService.GetProductsAsync();

            return Ok(products);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product productToAdd)
        {
            var product = await productService.AddProductAsync(productToAdd);

            return Ok(product);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(Product productToUpdate)
        {
            var product = await productService.UpdateProductAsync(productToUpdate);

            return Ok(product);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);

            return NoContent();
        }

        [HttpPost]
        [Route("GetProductsByProductCategoryName")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByProductCategoryName(string productCategoryName)
        {
            var products = await productService.GetProductsByProductCategoryName(productCategoryName);

            return Ok(products);
        }

        [HttpPost]
        [Route("GetRelatedProductsByProductId")]
        public async Task<ActionResult<IEnumerable<Product>>> GetRelatedProductsByProductId(string productId)
        {
            var products = await productService.GetRelatedProductsByProductId(productId);

            return Ok(products);
        }
    }
}
