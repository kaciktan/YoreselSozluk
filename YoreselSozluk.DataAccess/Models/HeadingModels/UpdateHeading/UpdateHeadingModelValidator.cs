using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.UpdateHeading;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.UpdateHeading
{
    public class UpdateHeadingModelValidator:AbstractValidator<UpdateHeadingCommand>
    {
        public UpdateHeadingModelValidator()
        {
            RuleFor(x => x.HeadingId).GreaterThan(0);
            RuleFor(x => x.Model.CityId).GreaterThan(0);
            RuleFor(x => x.Model.UserId).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(2);

        }
    }
}
