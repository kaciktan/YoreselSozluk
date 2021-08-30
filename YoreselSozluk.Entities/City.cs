using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.Entities
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
