using BBL.DTO;
using BBL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBarczak_WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("add")]
        public ActionResult AddToBasket([FromBody] BasketPositionDTO model)
        {
            if (model == null || model.UserId <= 0 || model.ProductId <= 0 || model.Amount <= 0)
            {
                return BadRequest("Nieprawidłowe dane.");
            }

            var result = _basketService.AddToBasket(model.UserId, model.ProductId, model.Amount);
            if (!result)
            {
                return BadRequest("Nie można dodać produktu do koszyka.");
            }

            return Ok();
        }

        [HttpDelete("remove/{basketItemId}")]
        public ActionResult RemoveFromBasket(int basketItemId)
        {
            var result = _basketService.RemoveFromBasket(basketItemId);
            if (!result)
            {
                return NotFound($"Nie znaleziono produktu w koszyku o ID: {basketItemId}.");
            }

            return Ok();
        }

        [HttpPut("updateQuantity")]
        public ActionResult ChangeBasketItemQuantity([FromBody] BasketPositionDTO model)
        {
            if (model == null || model.Id <= 0 || model.Amount <= 0)
            {
                return BadRequest("Nieprawidłowe dane.");
            }

            var result = _basketService.ChangeBasketItemQuantity(model.Id, model.Amount);
            if (!result)
            {
                return BadRequest("Nie można zmienić ilości produktu.");
            }

            return Ok();
        }

        [HttpGet("{userId}")]
        public ActionResult<List<BasketPositionDTO>> GetBasketItems(int userId)
        {
            var basketItems = _basketService.GetBasketItems(userId);
            if (basketItems == null || basketItems.Count == 0)
            {
                return NotFound("Koszyk jest pusty.");
            }

            return Ok(basketItems);
        }
    }
}
