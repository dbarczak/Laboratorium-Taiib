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

        public List<ProductDTO> GetProducts(string name, bool? isActive, int pageNumber, int pageSize, string sortBy, bool sortAsc)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if (isActive.HasValue)
            {
                query = query.Where(p => p.IsActive == isActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "name":
                        query = sortAsc ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                        break;
                    case "price":
                        query = sortAsc ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                        break;
                    default:
                        throw new ArgumentException("Invalid sort field.");
                }
            }

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var productsDto = query.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Image = p.Image,
                IsActive = p.IsActive
            }).ToList();

            return productsDto;
        }

        public ProductDTO AddProduct(ProductDTO productDto)
        {
            if (productDto.Price <= 0)
            {
                throw new ArgumentException("Cena produktu musi być większa od zera.");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Image = productDto.Image,
                IsActive = productDto.IsActive
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;

            return productDto;

        }

        public ProductDTO UpdateProduct(ProductDTO productDto)
        {
            if (productDto.Price <= 0)
            {
                throw new ArgumentException("Cena produktu musi być większa od zera.");
            }

            var product = _context.Products.Find(productDto.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Produkt o ID {productDto.Id} nie został znaleziony.");
            }

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Image = productDto.Image;
            product.IsActive = productDto.IsActive;

            _context.SaveChanges();

            return productDto;

        }

        public bool DeleteProduct(int productId)
        {
            var product = _context.Products
            .Include(p => p.OrderPositions)
            .Include(p => p.BasketPositions)
            .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return false;
            }

            bool isInOrder = product.OrderPositions.Any();
            bool isInBasket = product.BasketPositions.Any();

            if (isInOrder)
            {
                product.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else if (isInBasket)
            {
                return false;
            }
            else
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ActivateProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return false;
            }
            if (!product.IsActive)
            {
                product.IsActive = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ProductDTO GetProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return null;
            }

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive
            };
        }
    }

}
