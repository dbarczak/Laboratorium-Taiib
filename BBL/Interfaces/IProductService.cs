using BBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts(int page, int pageSize, string filterByName, bool? isActive, string sortBy, bool isDescending);
        public ProductDTO AddProduct(ProductDTO productDto);
        public ProductDTO UpdateProduct(int id, ProductDTO productDto);
        public bool DeleteProduct(int id);
        bool ActivateProduct(int productId);
    }
}
