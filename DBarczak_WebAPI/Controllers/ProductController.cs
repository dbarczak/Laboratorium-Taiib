using BBL.DTO;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBarczak_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public ProductResponseDTO GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost]
        public void AddProduct([FromBody] ProductRequestDTO product)
        {
            _productService.AddProduct(product);
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, ProductRequestDTO product)
        {
            _productService.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
        }

    }
}