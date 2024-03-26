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
        IEnumerable<ProductDTO> GetProducts(string name, bool? isActive, int pageNumber, int pageSize, string sortBy, bool sortAsc);
        ProductDTO AddProduct(ProductDTO product);
        ProductDTO UpdateProduct(ProductDTO product);
        bool DeleteProduct(int productId);
        bool ActivateProduct(int productId);
    }
}
