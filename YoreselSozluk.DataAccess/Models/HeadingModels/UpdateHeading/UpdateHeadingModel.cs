using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.UpdateHeading
{
    public class UpdateHeadingModel
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; } // Heading  : Endele -> Akdeniz / (33) Mersin -> Entry: Öyle yapma o şekilde yapma anlamındadır.
    }
}
