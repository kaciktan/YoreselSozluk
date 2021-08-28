using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Models.CityModels.CityDetail;
using YoreselSozluk.DataAccess.Models.CityModels.CreateCity;
using YoreselSozluk.DataAccess.Models.CityModels.GetCities;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.DataAccess.Models.RegionModels.GetRegions;
using YoreselSozluk.DataAccess.Models.RegionModels.RegionDetail;
using YoreselSozluk.Entities;

namespace YoreselSozluk.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Regions
            CreateMap<CreateRegionModel, Region>();
            CreateMap<Region, RegionsViewModel>();
            CreateMap<Region, RegionDetailViewModel>();
            #endregion

            #region Cities
            CreateMap<CreateCityModel, City>();
            CreateMap<City, CitiesViewModel>().ForMember(dest=>dest.Name,
                opt=>opt.MapFrom(src=>$"({src.Code}) {src.Name}"));

            CreateMap<City, CityDetailViewModel>().ForMember(dest => dest.Name,
           opt => opt.MapFrom(src => $"({src.Code}) {src.Name}"));

            #endregion

        }
    }
}
