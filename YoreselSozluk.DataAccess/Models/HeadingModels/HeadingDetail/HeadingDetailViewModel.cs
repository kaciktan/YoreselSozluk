using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.HeadingModel
{
    public class HeadingDetailViewModel
    {
        public string Name { get; set; }
        public HeadingCityModel City { get; set; }
        public HeadingUserModel User { get; set; }
    }

    public class HeadingCityModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public HeadingRegionModel Region { get; set; }
    }

    public class HeadingRegionModel
    {
        public string Name { get; set; }
    }

    public class HeadingUserModel
    {
        public string UserName { get; set; }

    }
 
}
