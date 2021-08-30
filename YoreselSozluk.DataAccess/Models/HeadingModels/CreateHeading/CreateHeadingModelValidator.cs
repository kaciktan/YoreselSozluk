using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.CreateHeading;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.CreateHeading
{
    public class CreateHeadingModelValidator:AbstractValidator<CreateHeadingCommand>
    {
        public CreateHeadingModelValidator()
        {
            RuleFor(x => x.Model.CityId).GreaterThan(0);
            RuleFor(x => x.Model.UserId).GreaterThan(0);
           // RuleFor(x => x.Model.Name).MinimumLength(2);

        }
    }
}
