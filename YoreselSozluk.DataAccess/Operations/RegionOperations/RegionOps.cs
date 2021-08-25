using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.Entities;

namespace YoreselSozluk.DataAccess.Operations.RegionOperations
{
    public class RegionOps : GenericClass<Region>
    {
 
        public RegionOps(DbContext context) : base(context)
        {

        }

        public void Total()
        {
           // Blah.. Blah...
        }


    }
}
