using BBL.DTO;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        public ProductResponseDTO GetProduct(int id);
        public IEnumerable<ProductResponseDTO> GetProducts(PaginationDTO pagination, string nameFilter, bool? isActiveFilter, string sortBy, bool sortAscending);
        public void AddProduct(ProductRequestDTO product);
        public void Updateproduct(int id, ProductRequestDTO product);
        public void DeleteProduct(int id);
        public void ActiveProduct(int id);

    }
}
