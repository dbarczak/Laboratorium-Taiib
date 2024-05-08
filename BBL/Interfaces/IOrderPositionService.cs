using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public interface IOrderPositionService
    {
        public int GetOrderPosition(int orderId);
    }
}
