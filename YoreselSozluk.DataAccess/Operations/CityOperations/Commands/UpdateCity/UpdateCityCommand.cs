using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.CityModels.UpdateCity;

namespace YoreselSozluk.DataAccess.Operations.CityOperations.Commands.UpdateCity
{
    public class UpdateCityCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public UpdateCityModel Model { get; set; }
        public int CityId { get; set; }

        public UpdateCityCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var city = _context.Cities.FirstOrDefault(x=>x.Id==CityId);
            if(city is null)
            {
                throw new InvalidOperationException("Şehir Bulunamadı");
            }

            if(_context.Cities.Any(x=>x.Name==Model.Name|| x.Code == Model.Code))
            {
                throw new InvalidOperationException("Bu Şehir Daha Önce Kaydedilmiş. Güncelleme Yapılamaz!");
            }

            city.Name = Model.Name == default ? city.Name : Model.Name;
            city.Code = Model.Code == default ? city.Code : Model.Code;
            city.RegionId = Model.RegionId == default ? city.RegionId : Model.RegionId;
            _context.SaveChanges();

        }
    }
}
