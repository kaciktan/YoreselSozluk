using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.HeadingModels.HeadingModel;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Concrete
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeadingCity>().HasKey(x => new { x.HeadingId, x.CityId,x.RegionId});

            modelBuilder.Entity<HeadingCity>()
                .HasOne(x => x.Heading).WithMany(x => x.HeadingCities).HasForeignKey(x=>x.CityId);
           
        }

    }
}
