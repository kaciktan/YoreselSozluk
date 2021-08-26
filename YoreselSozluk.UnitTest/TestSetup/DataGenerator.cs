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


            if (!context.Regions.Any())
            {
               context.Regions.AddRange(regions);
            }


        
        }
    }
}
