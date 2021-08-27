using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.DataAccess.Models.RegionModels.GetRegions;
using YoreselSozluk.Entities;

namespace YoreselSozluk.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRegionModel, Region>();
            CreateMap<Region, RegionsViewModel>();

        }
    }
}
