using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.UpdateRegion;

namespace YoreselSozluk.DataAccess.Models.RegionModels.UpdateRegion
{
    public class UpdateRegionModelValidator:AbstractValidator<UpdateRegionCommand>
    {
        public UpdateRegionModelValidator()
        {
            RuleFor(x => x.RegionId).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(3);
        }
    }
}
