using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.HeadingModels.CreateHeading;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.CreateHeading
{
    public class CreateHeadingCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateHeadingModel Model { get; set; }

        public CreateHeadingCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Model.UserId);
            if (user is null)
            {
                throw new InvalidOperationException("Kullanıcı Bulunamadı");
            }

            var city = _context.Cities.FirstOrDefault(x => x.Id == Model.CityId);
            if (city is null)
            {
                throw new InvalidOperationException("Şehir Bulunamadı");
            }

            var heading = _context.Headings.FirstOrDefault(x => x.Name == Model.Name && x.CityId==Model.CityId);
            if (heading is not null)
            {
                throw new InvalidOperationException("Bu Başlık Daha Önce Açılmış");
            }      
            var result = _mapper.Map<Heading>(heading);

            _context.Headings.Add(result);

            _context.SaveChanges();

        }

    }
}
