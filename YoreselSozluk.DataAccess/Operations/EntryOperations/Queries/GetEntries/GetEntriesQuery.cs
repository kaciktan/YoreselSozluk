using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.EntryModels.GetEntries;

namespace YoreselSozluk.DataAccess.Operations.EntryOperations.Queries.GetEntries
{
    public class GetEntriesQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int HeadingId { get; set; }
        public GetEntriesQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<EntriesViewModel> Handle()
        {
            var list = _context.Entries.Where(x=>x.HeadingId==HeadingId).Include(x=>x.User).ToList();
            var result = _mapper.Map<List<EntriesViewModel>>(list);
            return result;

        }
    }
}
