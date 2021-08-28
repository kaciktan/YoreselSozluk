using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.CityModels.CreateCity;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.CityOperations.Commands.CreateCity
{
    public class CreateCityCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateCityModel Model { get; set; }

        public CreateCityCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == Model.RegionId);
            if(region is null)
            {
                throw new InvalidOperationException("Bölge Bulunamadı");
            }
            var city = _context.Cities.FirstOrDefault(x=>x.Name==Model.Name || x.Code==Model.Code);
            if (city is not null)
            {
                throw new InvalidOperationException("Şehir Daha Önce Kaydedilmiş");
            }
            var result = _mapper.Map<City>(Model);
            _context.Cities.Add(result);
            _context.SaveChanges();        
        }
    }
}
