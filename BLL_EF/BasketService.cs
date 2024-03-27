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
    public class BasketService : IBasketService
    {
        private readonly WebshopContext _context;

        public BasketService(WebshopContext context)
        {
            _context = context;
        }

        public bool AddToBasket(int userId, int productId, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Ilość musi być większa od 0.");
            }

            var product = _context.Products.SingleOrDefault(p => p.Id == productId && p.IsActive);
            if (product == null)
            {
                return false;
            }

            var basketItem = new BasketPosition
            {
                UserID = userId,
                ProductID = productId,
                Amount = quantity
            };
            _context.BasketPositions.Add(basketItem);
            _context.SaveChanges();

            return true;
        }

        public bool RemoveFromBasket(int basketItemId)
        {
            var basketItem = _context.BasketPositions.Find(basketItemId);
            if (basketItem == null)
            {
                return false;
            }

            _context.BasketPositions.Remove(basketItem);
            _context.SaveChanges();

            return true;
        }
        public bool ChangeBasketItemQuantity(int basketItemId, int quantity)
        {
            if(quantity <= 0);
            {
                throw new ArgumentException("Ilość musi być większa od 0.");
            }

            var basketItem = _context.BasketPositions.Find(basketItemId);
            if (basketItem == null)
            {
                return false;
            }

            basketItem.Amount = quantity;
            _context.SaveChanges();

            return true;
        }
        public List<BasketPositionDTO> GetBasketItems(int userId)
        {
            var basketItems = _context.BasketPositions.Where(bi => bi.UserID == userId)
        .Select(bi => new BasketPositionDTO
        {
            Id = bi.Id,
            ProductId = bi.ProductID,
            Amount = bi.Amount,
        }).ToList();

            return basketItems;
        }
    }
}
