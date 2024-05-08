using BBL.DTO;
using BBL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class ProductService : IProductService
    {
        private readonly WebshopContext _context;

        public ProductService(WebshopContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductResponseDTO> GetProducts()
        {
            return _context.Products
                .Select(p => new ProductResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                }).ToList();
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
            if(product.Price <= 0)
            {
                return;
            }
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }
        public void UpdateProduct(int id, ProductRequestDTO product)
        {
            if (product.Price <= 0)
            {
                return;
            }
            var productToUpdate = _context.Products.Find(id);
            if(productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Image = product.Image;
                productToUpdate.IsActive = product.IsActive;

                _context.SaveChanges();
            }
        }
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public void ActivateProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if( product != null )
            {
                if( product.IsActive == false)
                {
                    product.IsActive = true;
                    _context.SaveChanges();
                }
            }
        }
        public ProductResponseDTO GetProduct(int productId)
        {
            var product = _context.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Image = p.Image,
                    IsActive = p.IsActive
                }).FirstOrDefault();
            return product;
        }
    }

}
