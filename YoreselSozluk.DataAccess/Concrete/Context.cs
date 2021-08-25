using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Concrete
{
    public class Context:DbContext,IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Heading> Headings { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
