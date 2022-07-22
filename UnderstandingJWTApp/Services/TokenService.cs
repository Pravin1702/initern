using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnderstandingJWTApp.Model;

namespace UnderstandingJWTApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        string key = config["TokenKey"];
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
    public string GenerateToken(UserDTO user)
    {
        var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.NameId,user.Username)
           };
        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(3),
            SigningCredentials = cred
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDesc);
        return tokenHandler.WriteToken(token);
    }
}
}
