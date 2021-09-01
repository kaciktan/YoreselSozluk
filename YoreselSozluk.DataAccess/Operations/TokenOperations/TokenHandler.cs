using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Models.UserModels.Token;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.TokenOperations
{
    public class TokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            tokenModel.Expiration = DateTime.Now.AddMinutes(15);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Token:Issuer"],
                Audience = _configuration["Token:Audience"],
                Expires = tokenModel.Expiration,
                NotBefore = DateTime.Now,
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()), //Token içindeki alanlara claim deniyor. name alanına ID verdik
                    new Claim(ClaimTypes.Role,user.Roles),
                }),
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor); // verdiğimiz ayarlara göre token ürettik

            tokenModel.AccessToken = tokenHandler.WriteToken(token);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
