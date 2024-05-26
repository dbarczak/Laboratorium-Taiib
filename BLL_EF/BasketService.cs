using BBL.DTO;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore.Storage;
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

        private readonly WebShopContext _context;

        public BasketService(WebShopContext _context)
        {
            this._context = _context;
        }

        public void AddProductToBasket(BasketPositionRequestDTO basketPositionDTORequest)
        {

            var user = _context.Users.Find(basketPositionDTORequest.UserID);
            var product = _context.Products.Find(basketPositionDTORequest.ProductID);

            bool flagAmountIncrease = false;

            if (user != null || product != null)
            {

                var pos = _context.BasketPositions.Where(u => u.UserID == basketPositionDTORequest.UserID);
                if (pos != null)
                {
                    foreach (var p in pos)
                    {
                        var productId = p.ProductID;
                        if (productId == basketPositionDTORequest.ProductID)
                        {
                            p.Amount += basketPositionDTORequest.Amount;
                            flagAmountIncrease = true;

                        }
                    }
                    _context.SaveChanges();
                }
                if (!flagAmountIncrease)
                {
                    if (product.IsActive == true)
                    {
                        var bp = new BasketPosition
                        {
                            User = user,
                            UserID = basketPositionDTORequest.UserID,
                            Product = product,
                            ProductID = basketPositionDTORequest.ProductID,
                            Amount = basketPositionDTORequest.Amount
                        };
                        _context.BasketPositions.Add(bp);
                    }
                    _context.SaveChanges();
                }
            }
        }
        public void RemoveProductFromBasket(int id)
        {
            var basket = _context.BasketPositions.Find(id);
            if (basket != null)
            {
                _context.BasketPositions.Remove(basket);
                _context.SaveChanges();
            }
        }

        public void ChangeBasketItemAmount(int basketItemId, int quantity)
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

        public IEnumerable<BasketPositionResponseDTO> GetBasket(int idUser)
        {
            User user = _context.Users.Find(idUser);
            if (user == null)
                throw new Exception($"nie ma takiego uzytkownika");

            var basketPositions = _context.BasketPositions
                .Where(u => u.UserID == idUser)
                .Select(basketPosition => new BasketPositionResponseDTO
                {
                     ID = basketPosition.ID,
                     ProductID = basketPosition.ProductID,
                     UserID = basketPosition.UserID,
                     Amount = basketPosition.Amount
                }).ToList();

            return basketPositions;
        }

        public void CreateOrder(int idUser)
        {
            User user = _context.Users.Find(idUser);
            if (user == null)
                throw new Exception($"nie ma takiego uzytkownika");

            var basketPositions = _context.BasketPositions.Where(i=>i.UserID==idUser).ToList();

            Order newOrder = new Order
            {
                Date = DateTime.Now,
                User = user,
                UserID = idUser,
                Positions = new List<OrderPosition>()
            };

            List<OrderPosition> temp = new List<OrderPosition>();

            foreach(var basketPos in basketPositions)
            {
                var pr = _context.Products.Find(basketPos.ProductID); if (pr == null) throw new Exception("Blad");
                var orPos = new OrderPosition
                {
                    Order = newOrder,
                    Amount = basketPos.Amount,
                    OrderID = newOrder.ID,
                    Product = pr,
                    ProductID = basketPos.ProductID,
                    Price = basketPos.Amount * pr.Price
                };
                _context.OrderPositions.Add(orPos);
                _context.SaveChanges();
                temp.Add(orPos);
                _context.BasketPositions.Remove(basketPos);
                _context.SaveChanges();
            }
            newOrder.Positions = temp;
            _context.Orders.Add(newOrder);
           // db.SaveChanges();
        }
    }
}
