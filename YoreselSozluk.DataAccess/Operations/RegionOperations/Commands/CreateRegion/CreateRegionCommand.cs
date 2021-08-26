using AutoMapper;
using System;
using System.Linq;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.CreateRegion
{
    public class CreateRegionCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateRegionModel Model { get; set; }

        public CreateRegionCommand(IContext context,IMapper mapper)
        {
            _mapper= mapper;
            _context = context;
        }

        public void Handle()
        {

            var region = _context.Regions.FirstOrDefault(x => x.Name == Model.Name);
            if (region is not null)
            {
                throw new InvalidOperationException("Bu Bölge Zaten Kayıtlı");
            }
            var result = _mapper.Map<Region>(Model);
            _context.Regions.Add(result);
            _context.SaveChanges();
        }
    }
}
