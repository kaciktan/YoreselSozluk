using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.Business.Models.RegionModels;
using YoreselSozluk.Entities;

namespace YoreselSozluk.Business.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRegionModel, Region>();
        }
    }
}
