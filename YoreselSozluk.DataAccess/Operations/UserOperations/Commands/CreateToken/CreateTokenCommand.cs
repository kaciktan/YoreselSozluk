using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.UserModels.CreateToken;
using YoreselSozluk.DataAccess.Models.UserModels.Token;
using YoreselSozluk.DataAccess.Operations.TokenOperations;

namespace YoreselSozluk.DataAccess.Operations.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IContext _context;      
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
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
                throw new InvalidOperationException("Kullanıcı Adı-Şifre Hatalı");
            }

        }

    }
}
