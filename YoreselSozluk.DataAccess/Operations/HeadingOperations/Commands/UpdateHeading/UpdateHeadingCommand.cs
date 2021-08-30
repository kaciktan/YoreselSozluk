using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.HeadingModels.UpdateHeading;

namespace YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.UpdateHeading
{
    public class UpdateHeadingCommand
    {
        private readonly IContext _context;
        public UpdateHeadingModel Model { get; set; }
        public int HeadingId { get; set; }

        public UpdateHeadingCommand(IContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var heading = _context.Headings.FirstOrDefault(x => x.Id == HeadingId);
            if (heading is null) throw new InvalidOperationException("Başlık Bulunamadı");   
            if (heading.UserId != Model.UserId) throw new InvalidOperationException("Başlığı Sadece Başlığı Açan Kullanıcı Değiştirebilir");
            heading.CityId = Model.CityId == default ? heading.CityId : Model.CityId;
            heading.Name = Model.Name == default ? heading.Name : Model.Name;
            _context.SaveChanges();
        }

    }
}
