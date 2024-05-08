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

        public void AddToBasket(BasketPositionRequestDTO basketDto)
        {
            var product = _context.Products.Find(basketDto.ProductId);
            if (product.IsActive == true)
            {
                var newBasket = new BasketPosition
                {
                    UserID = basketDto.UserId,
                    ProductID = basketDto.ProductId,
                    Amount = basketDto.Amount
                };


                _context.BasketPositions.Add(newBasket);
                _context.SaveChanges();
            }
        }
        public void RemoveFromBasket(int basketItemId)
        {
            var basket = _context.BasketPositions.Find(basketItemId);
            if (basket != null)
            {
                _context.BasketPositions.Remove(basket);
                _context.SaveChanges();
            }
        }
        public void ChangeBasketItemQuantity(int basketItemId, int quantity)
        {
            if (quantity > 0)
            {
                var basket = _context.BasketPositions.Find(basketItemId);
                if (basket != null)
                {
                    basket.Amount = quantity;

                    _context.SaveChanges();
                }
            }
        }
        public IEnumerable<BasketPositionResponseDTO> GetBasketItems(int userId)
        {
            return _context.BasketPositions
                .Select(bp => new BasketPositionResponseDTO
                {
                    Id = bp.Id,
                    UserId = bp.UserID,
                    ProductId = bp.ProductID,
                    Amount = bp.Amount
                }).ToList();
        }
    }
}
