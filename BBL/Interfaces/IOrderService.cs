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
        OrderDTO GetOrder(int orderId);
        IEnumerable<OrderDTO> GetAllOrdersForUser(int userId);
        OrderDTO CreateOrder(OrderDTO orderDto);
        bool UpdateOrder(OrderDTO orderDto);
        bool DeleteOrder(int orderId);
    }
}
