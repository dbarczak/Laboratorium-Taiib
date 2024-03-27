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
        public bool AddToBasket(int userId, int productId, int quantity);
        public bool RemoveFromBasket(int basketItemId);
        public bool ChangeBasketItemQuantity(int basketItemId, int quantity);
        public List<BasketPositionDTO> GetBasketItems(int userId);
    }
}
