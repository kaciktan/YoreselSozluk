using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.Common;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.RegionModels;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.DataAccess.Models.RegionModels.GetRegions;
using YoreselSozluk.DataAccess.Models.RegionModels.UpdateRegion;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.CreateRegion;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.UpdateRegion;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Queries.GetRegions;

namespace YoreselSozluk.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;


        public RegionController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<RegionsViewModel> GetRegions()
        {
            GetRegionsQuery query = new GetRegionsQuery(_context, _mapper);
            return query.Handle();
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionDetail(int id)
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult CreateRegion(CreateRegionModel model)
        {
            CreateRegionCommand command = new CreateRegionCommand(_context, _mapper);
            command.Model = model;
            CreateRegionModelValidator validationRules = new CreateRegionModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

  

        [HttpPut("{id}")]
        public IActionResult UpdateRegion(int id,[FromBody]UpdateRegionModel model)
        {
            UpdateRegionCommand command = new UpdateRegionCommand(_context, _mapper);
            command.RegionId = id;
            command.Model = model;
            UpdateRegionModelValidator validationRules = new UpdateRegionModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegion(int id)
        {

            return Ok();
        }


    }
}
