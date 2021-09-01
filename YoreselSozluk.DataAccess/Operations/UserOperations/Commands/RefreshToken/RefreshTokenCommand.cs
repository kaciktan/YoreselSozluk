using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.UserModels.Token;
using YoreselSozluk.DataAccess.Operations.TokenOperations;

namespace YoreselSozluk.DataAccess.Operations.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }

        private readonly IContext _context;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IContext context, IConfiguration configuration)
        {
            _context = context;

            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(user);
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid Bir Refresh Token Bulunamadı");
            }
        }

        public class CreateTokenModel
        {
            public string Password { get; set; }
            public string Email { get; set; }
        }
    }
}
