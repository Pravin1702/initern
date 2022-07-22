using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using UnderstandingJWTApp.Model;

namespace UnderstandingJWTApp.Services
{
    public class UserService : IUserService
    {
        SqlConnection conn;
        private readonly ITokenService _tokenService;


        public UserService(IConfiguration configuration, ITokenService tokenService)
        {
            conn = new SqlConnection(configuration.GetConnectionString("conn"));
            _tokenService = tokenService;
        }
        public async Task<UserDTO> Login(UserDTO user)
        {

            SqlCommand cmd = new SqlCommand("proc_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", user.Username);
            conn.Open();
            SqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (reader.Read())
            {
                byte[] dbPass = (byte[])reader[1];
                byte[] data = (byte[])reader[2];
                HMACSHA512 hmac = new HMACSHA512(data);
                byte[] userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != dbPass[i])
                    {
                        return null;
                    }
                }
                user.Password = "";
                user.Token = _tokenService.GenerateToken(user);
                return user;
            }
            conn.Close();
            return null;
        }

        public async Task<UserDTO> Register(UserDTO user)
        {
            User myUser = new User();
            HMACSHA512 hmac = new HMACSHA512();
            myUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            myUser.PasswKey = hmac.Key;
            myUser.Username = user.Username;
            SqlCommand cmd = new SqlCommand("proc_register", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@un", myUser.Username);
            cmd.Parameters.AddWithValue("@upass", myUser.Password);
            cmd.Parameters.AddWithValue("@ukey", myUser.PasswKey);
            conn.Open();
            int result = await cmd.ExecuteNonQueryAsync();
            conn.Close();
            if (result == 0)
                return null;
            user.Password = "";
            user.Token = _tokenService.GenerateToken(user);
            return user;
        }
    }
}
