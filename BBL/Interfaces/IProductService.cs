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
        public IEnumerable<ProductResponseDTO> GetProducts();
        public void AddProduct(ProductRequestDTO product);
        public void UpdateProduct(int id, ProductRequestDTO product);
        public void DeleteProduct(int productId);
        public void ActivateProduct(int productId);
        public ProductResponseDTO GetProduct(int productId);
    }
}
