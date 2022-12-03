using Contact_Information.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact_Information.Interfaces.Users
{
    public interface IUsersController
    {
        public Task<List<UserDTO>> GetUsers();
    }
}
