using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.RegionModels.RegionDetail;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations.Queries.GetRegionDetail
{
    public class RegionDetailQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int RegionId { get; set; }

        public RegionDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RegionDetailViewModel Handle()
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == RegionId);
            if(region is null)
            {
                throw new InvalidOperationException("Bölge Bulunamadı");
            }
            var result = _mapper.Map<RegionDetailViewModel>(region);
            return result;
        }
    }
}
