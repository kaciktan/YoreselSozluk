using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.CityModels.CityDetail;
using YoreselSozluk.DataAccess.Models.CityModels.CreateCity;
using YoreselSozluk.DataAccess.Models.CityModels.DeleteCity;
using YoreselSozluk.DataAccess.Models.CityModels.GetCities;
using YoreselSozluk.DataAccess.Models.CityModels.UpdateCity;
using YoreselSozluk.DataAccess.Operations.CityOperations.Commands.CreateCity;
using YoreselSozluk.DataAccess.Operations.CityOperations.Commands.DeleteCity;
using YoreselSozluk.DataAccess.Operations.CityOperations.Commands.UpdateCity;
using YoreselSozluk.DataAccess.Operations.CityOperations.Queries.GetCities;
using YoreselSozluk.DataAccess.Operations.CityOperations.Queries.GetCityDetail;

namespace YoreselSozluk.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CitiesController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CitiesViewModel> GetCities()
        {
            GetCitiesQuery query = new GetCitiesQuery(_context, _mapper);
            return query.Handle();
        }

        [HttpGet("{id}")]
        public CityDetailViewModel GetCityDetail(int id)
        {
            CityDetailQuery query = new CityDetailQuery(_context, _mapper);
            query.CityId = id;
            CityDetailViewModelValidator validationRules = new CityDetailViewModelValidator();
            validationRules.ValidateAndThrow(query);
            return query.Handle();
        }

        [HttpPost]
        public IActionResult CreateCity([FromBody] CreateCityModel model)
        {
            CreateCityCommand command = new CreateCityCommand(_context, _mapper);
            command.Model = model;
            CreateCityModelValidator validationRules = new CreateCityModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] UpdateCityModel model)
        {
            UpdateCityCommand command = new UpdateCityCommand(_context, _mapper);
            command.CityId = id;
            command.Model = model;
            UpdateCityModelValidator validationRules = new UpdateCityModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            DeleteCityCommand command = new DeleteCityCommand(_context);
            command.CityId = id;
            DeleteCityValidator validationRules = new DeleteCityValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}
