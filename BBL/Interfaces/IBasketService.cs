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
	bool AddToBasket(int userId, int productId, int quantity);
	bool RemoveFromBasket(int basketItemId);
	bool ChangeBasketItemQuantity(int basketItemId, int quantity);
	IEnumerable<BasketItemDTO> GetBasketItems(int userId);
    }
}
