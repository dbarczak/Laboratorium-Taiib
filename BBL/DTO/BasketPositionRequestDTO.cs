using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO
{
    public class BasketPositionRequestDTO
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
