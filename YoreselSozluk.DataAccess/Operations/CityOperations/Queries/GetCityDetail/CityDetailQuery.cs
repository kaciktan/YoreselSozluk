using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.CityModels.CityDetail;

namespace YoreselSozluk.DataAccess.Operations.CityOperations.Queries.GetCityDetail
{
    public class CityDetailQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int CityId { get; set; }

        public CityDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CityDetailViewModel Handle()
        {
            var city = _context.Cities.FirstOrDefault(x => x.Id == CityId);
            if (city is null)
            {
                throw new InvalidOperationException("Şehir Bulunamadı");
            }

            var result = _mapper.Map<CityDetailViewModel>(city);
            return result;
        }

    }
}
