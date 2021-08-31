using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.EntryModels.EntryDetail;

namespace YoreselSozluk.DataAccess.Operations.EntryOperations.Queries.GetEntryDetail
{
    public class GetEntryDetailQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int EntryId { get; set; }

        public GetEntryDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EntryDetailViewModel Handle()
        {
            var entry = _context.Entries
                .Include(x=>x.User)
                .FirstOrDefault(x=>x.Id==EntryId);
            if (entry is null) throw new InvalidOperationException("Entry Bulunamadı");
            var result = _mapper.Map<EntryDetailViewModel>(entry);
            return result;
        }

    }
}
