using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.Business.Models.RegionModels;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Operations.RegionOperations;
using YoreselSozluk.DataAccess.Operations.RegionOperations.CreateRegion;
using YoreselSozluk.Entities;

namespace YoreselSozluk.Business.Operations.RegionOperations.CreateRegion
{
    public class CreateRegionBLL
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public CreateRegionModel Model { get; set; }

        public CreateRegionBLL(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var region = _context.Regions.FirstOrDefault(x => x.Name == Model.Name);
            if (region is not null)
            {
                throw new InvalidOperationException("Bu Bölge Zaten Kayıtlı");
            }
            var result = _mapper.Map<Region>(Model);

            CreateRegionCommand command = new CreateRegionCommand(region,_context);
            command.Handle();

        }
    }
}
