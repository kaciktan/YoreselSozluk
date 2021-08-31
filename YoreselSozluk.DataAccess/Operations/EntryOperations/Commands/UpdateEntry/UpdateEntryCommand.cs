using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.EntryModels.UpdateEntry;

namespace YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.UpdateEntry
{
    public class UpdateEntryCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int EntryId { get; set; }
        public UpdateEntryModel Model { get; set; }

        public UpdateEntryCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var entry = _context.Entries.FirstOrDefault(x=>x.Id == EntryId);
            if (entry is null) throw new InvalidOperationException("Entry Bulunamadı");        
            entry.Content = Model.Content==default?entry.Content:Model.Content;
            _context.SaveChanges();
        }
    }
}
