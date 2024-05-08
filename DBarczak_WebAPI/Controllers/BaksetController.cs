using BBL.DTO;
using BBL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DBarczak_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        [HttpGet("{id}")]
        public IEnumerable<BasketPositionResponseDTO> GetBasketItems(int id)
        {
            return _basketService.GetBasketItems(id);
        }

        [HttpPut("{id}")]
        public void ChangeBasketItemQuantity(int id, int quantity)
        {
            _basketService.ChangeBasketItemQuantity(id, quantity);
        }

        [HttpDelete("{id}")]
        public void RemoveFromBasket(int id)
        {
            _basketService.RemoveFromBasket(id);
        }


        [HttpPost]
        public void AddToBasket([FromBody] BasketPositionRequestDTO basketDto)
        {
            _basketService.AddToBasket(basketDto);
        }
    }
}