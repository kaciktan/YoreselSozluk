using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Models.CityModels.CityDetail;
using YoreselSozluk.DataAccess.Models.CityModels.CreateCity;
using YoreselSozluk.DataAccess.Models.CityModels.GetCities;
using YoreselSozluk.DataAccess.Models.EntryModels.CreateEntry;
using YoreselSozluk.DataAccess.Models.EntryModels.EntryDetail;
using YoreselSozluk.DataAccess.Models.EntryModels.GetEntries;
using YoreselSozluk.DataAccess.Models.HeadingModels.CreateHeading;
using YoreselSozluk.DataAccess.Models.HeadingModels.GetHeadings;
using YoreselSozluk.DataAccess.Models.HeadingModels.HeadingModel;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.DataAccess.Models.RegionModels.GetRegions;
using YoreselSozluk.DataAccess.Models.RegionModels.RegionDetail;
using YoreselSozluk.Entities;

namespace YoreselSozluk.Common
{
    public class MappingProfile : Profile
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
            CreateMap<City, CitiesViewModel>().ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"({src.Code}) {src.Name}"));

            CreateMap<City, CityDetailViewModel>().ForMember(dest => dest.Name,
           opt => opt.MapFrom(src => $"({src.Code}) {src.Name}"));

            #endregion

            #region Headings
            CreateMap<CreateHeadingModel, Heading>();
            CreateMap<Heading, HeadingDetailViewModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => new HeadingCityModel { Name = $" ({src.City.Code}) " + src.City.Name, Code = src.City.Code }))
                .ForPath(dest => dest.City.Region, opt => opt.MapFrom(src => new HeadingRegionModel { Name = src.City.Region.Name }))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => new HeadingUserModel { UserName=src.User.UserName}));

            CreateMap<Heading, HeadingsViewModel>()
              .ForMember(dest => dest.City, opt => opt.MapFrom(src => new HeadingsCityModel { Name = $" ({src.City.Code}) " + src.City.Name, Code = src.City.Code }))
              .ForPath(dest => dest.City.Region, opt => opt.MapFrom(src => new HeadingsRegionModel { Name = src.City.Region.Name }))
              .ForMember(dest => dest.User, opt => opt.MapFrom(src => new HeadingsUserModel { UserName = src.User.UserName }));

            #endregion

            #region Entries
            CreateMap<CreateEntryModel, Entry>();
            CreateMap<Entry, EntryDetailViewModel>()
                .ForMember(dest => dest.User,
                opt => opt.MapFrom(src => new EntryDetailUser { UserName = src.User.UserName }));
            CreateMap<Entry, EntriesViewModel>()
             .ForMember(dest => dest.User,
             opt => opt.MapFrom(src => new EntriesUser { UserName = src.User.UserName }));

            #endregion

        }
    }
}
