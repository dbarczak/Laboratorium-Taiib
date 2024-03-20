using BBL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(int userId);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO CreateUser(UserDTO userDto);
        bool UpdateUser(UserDTO userDto);
        bool DeleteUser(int userId);
    }
}
