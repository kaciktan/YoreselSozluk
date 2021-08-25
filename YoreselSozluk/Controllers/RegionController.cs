using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.Business.Models.RegionModels;
using YoreselSozluk.Business.Operations.RegionOperations.CreateRegion;
using YoreselSozluk.DataAccess.Abstract;

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
            CreateRegionBLL regionBLL = new CreateRegionBLL(_context, _mapper);
            regionBLL.Model = model;
            CreateRegionModelValidator validationRules = new CreateRegionModelValidator();
            validationRules.ValidateAndThrow(regionBLL);
            regionBLL.Handle();
            return Ok();
        }


    }
}
