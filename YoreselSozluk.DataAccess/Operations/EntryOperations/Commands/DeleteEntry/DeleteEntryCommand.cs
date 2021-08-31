using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;

namespace YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.DeleteEntry
{
    public class DeleteEntryCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int EntryId { get; set; }
        public DeleteEntryCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var entry = _context.Entries.FirstOrDefault(x => x.Id == EntryId);
            if (entry is null) throw new InvalidOperationException("Entry Bulunamadı");
            _context.Entries.Remove(entry);
            _context.SaveChanges();
        }

    }
}
