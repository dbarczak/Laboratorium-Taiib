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
        public List<ProductDTO> GetProducts(string name, bool? isActive, int pageNumber, int pageSize, string sortBy, bool sortAsc);
        public ProductDTO AddProduct(ProductDTO product);
        public ProductDTO UpdateProduct(ProductDTO product);
        public bool DeleteProduct(int productId);
        public bool ActivateProduct(int productId);
        public ProductDTO GetProduct(int productId);
    }
}
