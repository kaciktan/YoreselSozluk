using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.CityOperations.Commands.DeleteCity;

namespace YoreselSozluk.DataAccess.Models.CityModels.DeleteCity
{
    public class DeleteCityValidator:AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityValidator()
        {
            RuleFor(command => command.CityId).GreaterThan(0);
        }
    }
}
