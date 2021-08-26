using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.CreateRegion;

namespace YoreselSozluk.DataAccess.Models.RegionModels
{
    public class CreateRegionModelValidator:AbstractValidator<CreateRegionCommand>
    {
        public CreateRegionModelValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3);
        }
    }
}
