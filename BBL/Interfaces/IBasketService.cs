using BBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public interface IBasketService
    {
        public void AddToBasket(BasketPositionRequestDTO basketDto);
        public void RemoveFromBasket(int basketItemId);
        public void ChangeBasketItemQuantity(int basketItemId, int quantity);
        public IEnumerable<BasketPositionResponseDTO> GetBasketItems(int userId);
    }
}
