using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.HeadingModels.GetHeadings;

namespace YoreselSozluk.DataAccess.Operations.HeadingOperations.Queries.GetHeadings
{
    public class GetHeadingsQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;


        public GetHeadingsQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<HeadingsViewModel> Handle()
        {
            var list = _context.Headings
                .Include(x => x.City)
                .ThenInclude(x => x.Region)
                .Include(x => x.User)
                .ToList();
            var result = _mapper.Map<List<HeadingsViewModel>>(list);
            return result;

        }
    }
}
