using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.UserModels.CreateUser;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateUserModel Model { get; set; }

        public CreateUserCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == Model.UserName);

            if (user is not null)
            {
                throw new InvalidOperationException("Kullanıcı Zaten Mevcut");
            }

           if (_context.Users.Any(x=>x.Email==Model.Email))
           {
               throw new InvalidOperationException("Email Daha Önceden Kayıtlı");
           }

            user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
