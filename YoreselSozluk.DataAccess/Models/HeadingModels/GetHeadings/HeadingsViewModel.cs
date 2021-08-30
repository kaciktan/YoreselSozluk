using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.GetHeadings
{
    public class HeadingsViewModel
    {
        public string Name { get; set; }
        public HeadingsCityModel City { get; set; }
        public HeadingsUserModel User {  get; set; }
    }

    public class HeadingsCityModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public HeadingsRegionModel Region { get; set; }
    }

    public class HeadingsRegionModel
    {
        public string Name { get; set; }
    }

    public class HeadingsUserModel
    {
        public string UserName { get; set; }

    }

}
