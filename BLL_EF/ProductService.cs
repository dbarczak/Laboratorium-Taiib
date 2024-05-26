using BBL.DTO;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class ProductService : IProductService
    {
        private readonly WebShopContext _context;

        public ProductService(WebShopContext _context)
        {
            this._context = _context;
        }

        public void ActiveProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                if (product.IsActive == false)
                {
                    product.IsActive = true;
                    _context.SaveChanges();
                }
            }
        }

        public void AddProduct(ProductRequestDTO product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive
            };
            if (product.Price <= 0)
            {
                return;
            }
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }


        public void Updateproduct(int id, ProductRequestDTO product)
        {
            if (product.Price <= 0)
            {
                return;
            }
            var productToUpdate = _context.Products.Find(id);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Image = product.Image;
                productToUpdate.IsActive = product.IsActive;

                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {


                if (_context.BasketPositions.FirstOrDefault(o => o.ProductID == id) != null)
                    return;
                else if (_context.OrderPositions.FirstOrDefault(o => o.ProductID == id) != null)
                    product.IsActive = false;
                
                
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public ProductResponseDTO GetProduct(int id)
        {
            var product = _context.Products
                .Where(p => p.ID == id)
                .Select(p => new ProductResponseDTO
                {
                    ID = p.ID,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                }).FirstOrDefault();
            return product;
        }

        public IEnumerable<ProductResponseDTO> GetProducts(PaginationDTO pagination, string? nameFilter, bool? isActiveFilter, string? sortBy, bool sortAscending)
        {
            int count = pagination?.Count ?? 10;
            int page = pagination?.Page ?? 0; 

            IEnumerable<Product> products = _context.Products.ToList();

            if (!string.IsNullOrEmpty(nameFilter))
                products = products.Where(p => p.Name.Contains(nameFilter));

            if (isActiveFilter.HasValue)
                products = products.Where(p => p.IsActive == isActiveFilter.Value);

            if(!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "Name":
                        products = sortAscending ? products.OrderBy(p=>p.Name) : products.OrderByDescending(p=>p.Name); break;
                    case "Price":
                        products = sortAscending ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price); break;
                    default:
                        products = products.OrderBy(p => p.ID); break;
                }
            }
            return products.Skip(count * page).Take(count).Select(x => new ProductResponseDTO
            {
                ID = x.ID,
                Name = x.Name,
                Price = x.Price,
                Image = x.Image,
                IsActive = x.IsActive
            });
        }
    }
}
