using BBL.DTO;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JW_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService _orderBLL;

        public OrdersController(IOrderService orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet]
        public IEnumerable<OrderResponseDTO> getAllOrders()
        {
            return _orderBLL.getAllOrders();
        }

        [HttpGet("{userId}")]
        public IEnumerable<OrderResponseDTO> getUserOrders(int userId)
        {
            return _orderBLL.getOrders(userId);
        }

        [HttpGet("{orderId}/Positions")]
        public IEnumerable<OrderPositionResponseDTO> getOrderPositions(int orderId)
        {
            return _orderBLL.getOrderPosition(orderId);
        }
    }
}
