using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.RegionModels.UpdateRegion;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.UpdateRegion
{
    public class UpdateRegionCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public UpdateRegionModel Model { get; set; }
        public int RegionId { get; set; }
        public UpdateRegionCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == RegionId);
            if(region is null)
            {
                throw new InvalidOperationException("Bölge Bulunamadı");
            }
            region.Name = Model.Name == default ? region.Name : Model.Name;
            _context.SaveChanges();
        }
    }
}
