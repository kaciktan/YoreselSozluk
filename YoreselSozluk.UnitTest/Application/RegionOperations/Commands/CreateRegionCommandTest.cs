using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YoreselSozluk.DataAccess.Concrete;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.CreateRegion;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.UnitTest.TestSetup;
using YoreselSozluk.DataAccess.Models.RegionModels;
using FluentAssertions;

namespace YoreselSozluk.UnitTest.Application.RegionOperations.Commands
{
    public class CreateRegionCommandTest:IClassFixture<CommonTestFixture>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CreateRegionCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Theory]
        [InlineData("a")]
        [InlineData("")]
        public void WhehInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            CreateRegionCommand command = new CreateRegionCommand(_context, _mapper);
            command.Model = new CreateRegionModel() { Name = name };
            CreateRegionModelValidator validationRules = new CreateRegionModelValidator();
            var result = validationRules.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Fact]
        public void WhenInvalidInputsAreGiven_Region_ShouldBeReturnErrors()
        {
            CreateRegionCommand command = new CreateRegionCommand(_context, _mapper);
            command.Model = new CreateRegionModel() { Name = "Akdeniz" };
            FluentActions.Invoking(()=>command.Handle()).Should().Throw<InvalidOperationException>();
        }

    }
}
