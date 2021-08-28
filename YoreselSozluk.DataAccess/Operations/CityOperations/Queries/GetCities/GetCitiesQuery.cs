using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.CityModels.GetCities;

namespace YoreselSozluk.DataAccess.Operations.CityOperations.Queries.GetCities
{
    public class GetCitiesQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetCitiesQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CitiesViewModel> Handle()
        {
            var list = _context.Cities.ToList();
            var result = _mapper.Map<List<CitiesViewModel>>(list);
            return result;
        }
        
    }
}
