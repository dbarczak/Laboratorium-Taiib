using BBL.DTO;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderResponseDTO> getAllOrders();
        public IEnumerable<OrderResponseDTO> getOrders(int id);
        public IEnumerable<OrderPositionResponseDTO> getOrderPosition(int id);
    }
}
