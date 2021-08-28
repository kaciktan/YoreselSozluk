using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.DeleteRegion;

namespace YoreselSozluk.DataAccess.Models.RegionModels.DeleteRegion
{
    public class DeleteRegionValidator:AbstractValidator<DeleteRegionCommand>
    {
        public DeleteRegionValidator()
        {
            RuleFor(x => x.RegionId).GreaterThan(0);
        }
    }
}
