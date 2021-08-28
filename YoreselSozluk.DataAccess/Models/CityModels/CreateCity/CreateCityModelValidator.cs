using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.CityOperations.Commands.CreateCity;

namespace YoreselSozluk.DataAccess.Models.CityModels.CreateCity
{
    public class CreateCityModelValidator:AbstractValidator<CreateCityCommand>
    {
        public CreateCityModelValidator()
        {
            RuleFor(x => x.Model.Code).MinimumLength(2);
            RuleFor(x=>x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.RegionId).GreaterThan(0);
        }
    }
}
