using BBL.DTO;
using BLL.DTO;
using BLL.Interfaces;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;

namespace JW_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketPositionsController : ControllerBase
    {
        readonly IBasketService _basketPositionBLL;

        public BasketPositionsController(IBasketService basketPositionBLL)
        {
            _basketPositionBLL = basketPositionBLL;
        }

        [HttpPost]
        public void Post([FromBody] BasketPositionRequestDTO basketPositionDTORequest)
        {
            _basketPositionBLL.AddProductToBasket(basketPositionDTORequest);
        }

        [HttpDelete("{basketPositionId}")]
        public void DeleteProduct(int basketPositionId)
        {
            _basketPositionBLL.RemoveProductFromBasket(basketPositionId);
        }

        [HttpPut("Amount/{basketPositionId}")]
        public void UpdateAmountOfProduct(int basketPositionId,[FromBody] int amount)
        {
            _basketPositionBLL.ChangeBasketItemAmount(basketPositionId, amount);
        }

        [HttpGet("{userId}")]
        public IEnumerable<BasketPositionResponseDTO> GetUserBasket(int userId) 
        { 
            return _basketPositionBLL.GetBasket(userId);
        }

        [HttpPost("Order/{userId}")]
        public void Order (int userId)
        {
            _basketPositionBLL.CreateOrder(userId);
        }
    }
}
