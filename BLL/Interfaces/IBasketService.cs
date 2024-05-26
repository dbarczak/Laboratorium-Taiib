using BBL.DTO;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBasketService
    {
        public void AddProductToBasket(BasketPositionRequestDTO basketPositionDTORequest);
        public void RemoveProductFromBasket(int id);
        public void ChangeBasketItemAmount(int basketItemId, int quantity);
        public IEnumerable<BasketPositionResponseDTO> GetBasket(int idUser);
        public void CreateOrder(int idUser);

    }
}
