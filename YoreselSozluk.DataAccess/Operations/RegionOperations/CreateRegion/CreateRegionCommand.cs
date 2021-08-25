using System;
using System.Linq;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations.CreateRegion
{
    public class CreateRegionCommand
    {


        public Region Region { get; }
        public IContext Context { get; }

        public CreateRegionCommand(Region region,IContext context)
        {
            Region = region;
            Context = context;
        }


        public void Handle()
        {
            Context.Regions.Add(Region);
            Context.SaveChanges();
        }
    }
}
