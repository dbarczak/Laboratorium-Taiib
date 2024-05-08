using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.DTO
{
    public class UserRequestDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
