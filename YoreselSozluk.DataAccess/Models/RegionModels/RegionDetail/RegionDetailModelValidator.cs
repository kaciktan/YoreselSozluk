using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Queries.GetRegionDetail;

namespace YoreselSozluk.DataAccess.Models.RegionModels.RegionDetail
{
    public class RegionDetailModelValidator:AbstractValidator<RegionDetailQuery>
    {
        public RegionDetailModelValidator()
        {
            RuleFor(x => x.RegionId).GreaterThan(0);
        }
    }
}
