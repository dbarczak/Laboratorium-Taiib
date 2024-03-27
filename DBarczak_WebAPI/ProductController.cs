using BBL.DTO;
using BBL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBarczak_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts([FromQuery] string name, [FromQuery] bool? isActive, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy = "Name", [FromQuery] bool sortAsc = true)
        {
            var products = _productService.GetProducts(name, isActive, pageNumber, pageSize, sortBy, sortAsc);
            return Ok(products);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<ProductDTO> AddProduct([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = _productService.AddProduct(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public ActionResult<ProductDTO> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var updatedProduct = _productService.UpdateProduct(productDto);
            return Ok(updatedProduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Products/activate/5
        [HttpPut("activate/{id}")]
        public IActionResult ActivateProduct(int id)
        {
            var result = _productService.ActivateProduct(id);
            if (!result)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok($"Product with ID {id} activated.");
        }
    }
}

