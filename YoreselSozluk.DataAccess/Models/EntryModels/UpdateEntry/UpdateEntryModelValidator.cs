using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.UpdateEntry;

namespace YoreselSozluk.DataAccess.Models.EntryModels.UpdateEntry
{
    public class UpdateEntryModelValidator:AbstractValidator<UpdateEntryCommand>
    {
        public UpdateEntryModelValidator()
        {
            RuleFor(x => x.EntryId).GreaterThan(0);
            RuleFor(x => x.Model.Content).MinimumLength(1);
        }

    }
}
