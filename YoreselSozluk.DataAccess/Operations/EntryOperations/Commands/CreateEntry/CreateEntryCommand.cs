using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.EntryModels.CreateEntry;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.CreateEntry
{
    public class CreateEntryCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateEntryModel Model { get; set; }

        public CreateEntryCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var heading = _context.Headings.FirstOrDefault(x => x.Id == Model.HeadingId);
            if (heading is null)
            {
                throw new InvalidOperationException("Başlık Bulunamadı");
            }
            var user =  _context.Users.FirstOrDefault(x=>x.Id==Model.UserId);
            if (user is null)
            {
                throw new InvalidOperationException("Kullanıcı Bulunamadı");
            }

            var result = _mapper.Map<Entry>(Model);

            _context.Entries.Add(result);
            _context.SaveChanges();

        }

        
    }
}
