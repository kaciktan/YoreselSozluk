using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Abstract
{
    public interface IContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
