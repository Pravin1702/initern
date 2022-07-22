using UnderstandingJWTApp.Model;

namespace UnderstandingJWTApp.Services
{
    public interface IUserService
    {
        Task<UserDTO> Register(UserDTO user);
        Task<UserDTO> Login(UserDTO user);

    }
}
