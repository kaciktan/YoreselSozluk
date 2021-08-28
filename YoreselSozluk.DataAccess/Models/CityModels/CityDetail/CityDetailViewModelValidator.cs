using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Operations.CityOperations.Queries.GetCityDetail;

namespace YoreselSozluk.DataAccess.Models.CityModels.CityDetail
{
    public class CityDetailViewModelValidator:AbstractValidator<CityDetailQuery>
    {
        public CityDetailViewModelValidator()
        {
            RuleFor(query => query.CityId).GreaterThan(0);
        }
    }
}
