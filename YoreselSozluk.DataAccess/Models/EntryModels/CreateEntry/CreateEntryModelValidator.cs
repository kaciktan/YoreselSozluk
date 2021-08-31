using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.CreateEntry;

namespace YoreselSozluk.DataAccess.Models.EntryModels.CreateEntry
{
    public class CreateEntryModelValidator:AbstractValidator<CreateEntryCommand>
    {
        public CreateEntryModelValidator()
        {
            RuleFor(x => x.Model.Content).MinimumLength(1);
            RuleFor(x => x.Model.UserId).GreaterThan(0);
            RuleFor(x => x.Model.HeadingId).GreaterThan(0);
        }

    }
}
