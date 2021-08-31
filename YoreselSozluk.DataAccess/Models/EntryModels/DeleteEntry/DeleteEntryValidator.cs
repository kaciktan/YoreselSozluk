using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.DeleteEntry;

namespace YoreselSozluk.DataAccess.Models.EntryModels.DeleteEntry
{
    public class DeleteEntryValidator:AbstractValidator<DeleteEntryCommand>
    {
        public DeleteEntryValidator()
        {
            RuleFor(x => x.EntryId).GreaterThan(0);
        }
    }
}
