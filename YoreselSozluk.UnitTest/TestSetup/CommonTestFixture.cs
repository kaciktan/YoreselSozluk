using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.Common;
using YoreselSozluk.DataAccess.Concrete;

namespace YoreselSozluk.UnitTest.TestSetup
{
    public class CommonTestFixture
    {
        public Context  Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("YoresetSozlukTestDB").Options;
            Context = new Context(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
            Context.AddFakeDatas();
            Context.SaveChanges();


            Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }


}
