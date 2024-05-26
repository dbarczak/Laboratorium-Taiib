using BBL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;

namespace BLL_EF
{
    public class OrderService : IOrderService
    {
        private readonly WebShopContext _context;

        public OrderService(WebShopContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<OrderResponseDTO> getAllOrders()
        {
            return _context.Orders
                .Select(o => new OrderResponseDTO
                {
                    ID = o.ID,
                    UserID = o.UserID,
                    Date = o.Date
                }).ToList();
        }

        public IEnumerable<OrderResponseDTO> getOrders(int userId)
        {
            var u = _context.Users.Find(userId);
            if (u == null)
                throw new Exception($"nie ma takiego uzytkownika");
            return _context.Orders
                .Where(u => u.UserID == userId)
                .Select(o => new OrderResponseDTO
                {
                    ID = o.ID,
                    UserID = o.UserID,
                    Date = o.Date
                }).ToList();
        }

        public IEnumerable<OrderPositionResponseDTO> getOrderPosition(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
                throw new Exception($"nie ma takiego zamowienia");

            var orderPositions = _context.OrderPositions
                .Where(o => o.OrderID == orderId)
                .Select(orderPosition => new OrderPositionResponseDTO
                {
                     ID = orderPosition.ID,
                     ProductID = orderPosition.ProductID,
                     Amount = orderPosition.Amount,
                     Price = orderPosition.Price,
                     OrderID = orderPosition.OrderID
                }).ToList();

            return orderPositions;
        }
    }
}
