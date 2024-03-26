using BBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public interface IOrderService
    {
        OrderDTO CreateOrder(int userId);
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetUserOrders(int userId);
        IEnumerable<OrderDTO> GetOrderItems(int orderId);
    }
}
