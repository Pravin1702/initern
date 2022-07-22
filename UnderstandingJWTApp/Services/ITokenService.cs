using UnderstandingJWTApp.Model;

namespace UnderstandingJWTApp.Services
{
    public interface ITokenService
    {
        public string GenerateToken(UserDTO user);
    }
}
