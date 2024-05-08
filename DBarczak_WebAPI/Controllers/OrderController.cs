using BBL.DTO;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBarczak_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet("{id}")]
        public IEnumerable<OrderResponseDTO> GetUserOrders(int id)
        {
            return _orderService.GetUserOrders(id);
        }


        [HttpPost]
        public void CreateOrder([FromBody] int userId, BasketPositionRequestDTO basketDTO)
        {
            _orderService.CreateOrder(userId, basketDTO);
        }
    }
}