using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.Entities
{
    public class HeadingCity
    {
        public int HeadingId { get; set; }
        public Heading Heading { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        
    }
}
