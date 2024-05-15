using BBL.DTO;
using BBL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderService : IOrderService
    {
        private readonly WebshopContext _context;

        public OrderService(WebshopContext context)
        {
            _context = context;
        }

        public void CreateOrder(int userId)
        {
            /*var newOrder = new Order
            {
                UserID = userId,
                Date = DateTime.Now
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();*/
            /*User userX = _context.Users.Single(u => u.Id == userId);
            List<BasketPosition> baskets = userX.BasketPositions.ToList();
            List<Order> orders = _context.Orders.ToList();
            List<OrderPosition> orderPositions = _context.OrderPositions.ToList();
            foreach (var item in baskets)
            {
                Order newOrder = new Order()
                {
                    UserID = userX.Id,
                    Date = DateTime.Today
                };
                orders.Add(newOrder);
                _context.SaveChanges();
                orderPositions.Add(new()
                {
                    OrderID = newOrder.Id,
                    ProductID = item.ProductID,
                    Amount = item.Amount,
                    Price = item.Product.Price
                });
                baskets.Remove(item);
                _context.SaveChanges();*/

                var positions = _context.BasketPositions.Where(bp => bp.UserID == userId).ToList();

                if (positions.Any())
                {
                    var order = new Order
                    {
                        UserID = userId,
                        Date = DateTime.Now,
                        OrderPositions = positions.Select(bp => new OrderPosition
                        {
                            ProductID = bp.ProductID,
                            Amount = bp.Amount,
                            Price = bp.Product.Price
                        }).ToList()
                    };

                    _context.Orders.Add(order);
                    _context.BasketPositions.RemoveRange(positions);
                    _context.SaveChanges();
                }

        }
        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            return _context.Orders
                .Select(o=> new OrderResponseDTO
                {
                    Id = o.Id,
                    UserId = o.UserID,
                    Date = o.Date
                }).ToList();
        }
        public IEnumerable<OrderResponseDTO> GetUserOrders(int userId)
        {
            return _context.Orders
                .Where(o => o.UserID == userId)
                .Select(o => new OrderResponseDTO
                {
                    Id = o.Id,
                    Date = o.Date
                }).ToList();
                  
        }
    }
}
