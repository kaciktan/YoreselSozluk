using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Queries.GetHeadingDetail;

namespace YoreselSozluk.DataAccess.Models.HeadingModels.HeadingDetail
{
    public class HeadingDetailViewModelValidator:AbstractValidator<HeadingDetailQuery>
    {
        public HeadingDetailViewModelValidator()
        {
            RuleFor(x => x.HeadingId).GreaterThan(0);
        }

    }
}
