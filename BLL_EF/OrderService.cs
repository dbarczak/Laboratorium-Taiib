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

        public void CreateOrder(int userId, BasketPositionRequestDTO basketDTO)
        {
            var newOrder = new Order
            {
                UserID = userId,
                Date = DateTime.Now
            };
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

           
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
