using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.RegionModels;
using YoreselSozluk.DataAccess.Models.RegionModels.CreateRegion;
using YoreselSozluk.DataAccess.Operations.RegionOperations.Commands.CreateRegion;

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


    }
}
