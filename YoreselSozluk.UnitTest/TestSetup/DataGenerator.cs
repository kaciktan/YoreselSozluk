using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Concrete;
using YoreselSozluk.Entities;

namespace YoreselSozluk.UnitTest.TestSetup
{
    public static class DataGenerator
    {
        public static void AddFakeDatas(this Context context)
        {
            List<Region> regions = new List<Region>() { 
                new Region(){ Id=1, Name="Akdeniz"},
                new Region(){ Id=2, Name="Doğu Anadolu"},
                new Region(){ Id=3, Name="İç Anadolu"},
                new Region(){ Id=4, Name="Güney Doğu Anadolu"},
            };

            List<City> cities = new List<City>()
            {
                new City(){ Id=1,RegionId=1,Name="Adana",Code="01"},
                new City(){ Id=2,RegionId=1,Name="Mersin",Code="33"},
    
            };


            if (!context.Regions.Any())
            {
               context.Regions.AddRange(regions);
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(cities);
            }


        
        }
    }
}
