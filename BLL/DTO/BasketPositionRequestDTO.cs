using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO
{
    public class BasketPositionRequestDTO
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
    }
}
