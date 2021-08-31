using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Queries.GetEntryDetail;

namespace YoreselSozluk.DataAccess.Models.EntryModels.EntryDetail
{
    public class EntryDetailViewModelValidator:AbstractValidator<GetEntryDetailQuery>
    {
        public EntryDetailViewModelValidator()
        {
            RuleFor(x => x.EntryId).GreaterThan(0);
        }
    }
}
