using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.DeleteRegion
{
    public class DeleteRegionCommand
    {
        private readonly IContext _context;
        public int RegionId { get; set; }
        public DeleteRegionCommand(IContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var region = _context.Regions.FirstOrDefault(x => x.Id == RegionId);
            if (region is null)
            {
                throw new InvalidOperationException("Bölge Bulunamadı");
            }
            var city = _context.Cities.FirstOrDefault(x => x.RegionId == region.Id);
            if (city is not null)
            {
                throw new InvalidOperationException("Bağlı Şehir Mevcut. Kayıt Silinemez");
            }
            _context.Regions.Remove(region);
            _context.SaveChanges();

        }
    }
}
