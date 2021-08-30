using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.HeadingModels.HeadingModel;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.HeadingOperations.Queries.GetHeadingDetail
{
    public class HeadingDetailQuery
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public int HeadingId { get; set; }
        public HeadingDetailQuery(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HeadingDetailViewModel Handle()
        {
            var heading = _context.Headings
                .Include(x=>x.City)
                .ThenInclude(x=>x.Region)
                .Include(x=>x.User)
                .FirstOrDefault(x => x.Id == HeadingId);
            if (heading is null) throw new InvalidOperationException("Başlık Bulunamadı");
            var result = _mapper.Map<HeadingDetailViewModel>(heading);
            return result;
        }
    }
}
