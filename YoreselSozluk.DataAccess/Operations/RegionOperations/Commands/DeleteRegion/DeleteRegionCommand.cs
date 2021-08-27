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
        public DeleteRegionCommand(IContext context)
        {
            _context = context;
        }

    }
}
