using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.RegionModels.GetRegions;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations.Queries.GetRegions
{
    public class GetRegionsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public GetRegionsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<RegionsViewModel> Handle()
        {
            var list = _context.Regions.ToList();
            var result  = _mapper.Map<List<RegionsViewModel>>(list);
            return result;
        }
    }
}
