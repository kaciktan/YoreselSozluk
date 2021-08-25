using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.Business.Operations.RegionOperations.CreateRegion;

namespace YoreselSozluk.Business.Models.RegionModels
{
    public class CreateRegionModelValidator:AbstractValidator<CreateRegionBLL>
    {
        public CreateRegionModelValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3);
        }
    }
}
