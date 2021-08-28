using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.CityOperations.Commands.UpdateCity;

namespace YoreselSozluk.DataAccess.Models.CityModels.UpdateCity
{
    public class UpdateCityModelValidator:AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityModelValidator()
        {
            RuleFor(command => command.CityId).GreaterThan(0);
            RuleFor(x => x.Model.Code).MinimumLength(2);
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.RegionId).GreaterThan(0);

        }
    }
}
