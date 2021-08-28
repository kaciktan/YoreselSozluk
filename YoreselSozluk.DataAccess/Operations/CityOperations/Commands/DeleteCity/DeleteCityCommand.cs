using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;

namespace YoreselSozluk.DataAccess.Operations.CityOperations.Commands.DeleteCity
{
    public class DeleteCityCommand
    {
        private readonly IContext _context;
        public int CityId { get; set; }

        public DeleteCityCommand(IContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var city = _context.Cities.FirstOrDefault(x => x.Id == CityId);
            if (city is null)
            {
                throw new InvalidOperationException("Şehir Bulunamadı");
            }

            var heading  = _context.Headings.FirstOrDefault(x=>x.CityId == CityId);
            if (heading is not null)
            {
                throw new InvalidOperationException("Başlık Oluşturulan Bir Şehir Silinemez");
            }

            _context.Cities.Remove(city);
            _context.SaveChanges();
        }
    }
}
