using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.DeleteHeading;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.DeleteHeading
{
    public class DeleteHeadingValidator:AbstractValidator<DeleteHeadingCommand>
    {
        public DeleteHeadingValidator()
        {
            RuleFor(x => x.HeadingId).GreaterThan(0);
        }
    }
}
