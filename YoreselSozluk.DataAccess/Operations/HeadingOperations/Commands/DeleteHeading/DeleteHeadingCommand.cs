using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;

namespace YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.DeleteHeading
{
    public class DeleteHeadingCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int HeadingId {  get; set; }

        public DeleteHeadingCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var heading = _context.Headings.FirstOrDefault(x=>x.Id==HeadingId);
            if (heading is null)
            {
                throw new InvalidOperationException("Başlık Bulunamadı");
            }
            var entry = _context.Entries.FirstOrDefault(x=>x.HeadingId==HeadingId);
            if (entry is not null)
            {
                throw new InvalidOperationException("Başlık Silinemez Kayıt Mevcut");
            }

            _context.Headings.Remove(heading);
            _context.SaveChanges();
        }
    }
}
