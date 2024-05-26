using BBL.DTO;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JW_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductService _productBLL;

        public ProductsController(IProductService productBLL)
        {
            _productBLL = productBLL;
        }

        [HttpGet("{id}")]
        public ProductResponseDTO GetProduct(int id)
        {
            return _productBLL.GetProduct(id);
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> Get([FromQuery] PaginationDTO pagination, string? nameFilter, bool? isActiveFilter, string? sortBy, bool sortAscending)
        {
            return _productBLL.GetProducts(pagination, nameFilter, isActiveFilter, sortBy, sortAscending);
        }

        [HttpPost]
        public void Post([FromBody] ProductRequestDTO productDTORequest)
        {
            _productBLL.AddProduct(productDTORequest);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductRequestDTO productDTORequest)
        {
            _productBLL.Updateproduct(id, productDTORequest);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productBLL.DeleteProduct(id);
        }

        [HttpPut("Activate/{id}")]
        public void ActiveProduct(int id)
        {
            _productBLL.ActiveProduct(id);
        }
        
    }
}
