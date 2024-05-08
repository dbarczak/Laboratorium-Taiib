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
        public void CreateOrder(int userId, BasketPositionRequestDTO basketDTO);
        public IEnumerable<OrderResponseDTO> GetAllOrders();
        public IEnumerable<OrderResponseDTO> GetUserOrders(int userId);
    }
}
