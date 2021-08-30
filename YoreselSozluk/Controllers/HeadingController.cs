using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.HeadingModels.CreateHeading;
using YoreselSozluk.DataAccess.Models.HeadingModels.DeleteHeading;
using YoreselSozluk.DataAccess.Models.HeadingModels.GetHeadings;
using YoreselSozluk.DataAccess.Models.HeadingModels.HeadingDetail;
using YoreselSozluk.DataAccess.Models.HeadingModels.HeadingModel;
using YoreselSozluk.DataAccess.Models.HeadingModels.UpdateHeading;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.CreateHeading;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.DeleteHeading;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Commands.UpdateHeading;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Queries.GetHeadingDetail;
using YoreselSozluk.DataAccess.Operations.HeadingOperations.Queries.GetHeadings;

namespace YoreselSozluk.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class HeadingController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public HeadingController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public List<HeadingsViewModel> GetHeadings()
        {
            GetHeadingsQuery query = new GetHeadingsQuery(_context,_mapper);
            return query.Handle();
        }

        [HttpGet("{id}")]
        public HeadingDetailViewModel GetHeadingDetail(int id)
        {
            HeadingDetailQuery query = new HeadingDetailQuery(_context, _mapper);
            query.HeadingId = id;
            HeadingDetailViewModelValidator validationRules = new HeadingDetailViewModelValidator();
            validationRules.ValidateAndThrow(query);
            return query.Handle();
        }

        [HttpPost]
        public IActionResult CreateHeading([FromBody]CreateHeadingModel model)
        {
            CreateHeadingCommand command = new CreateHeadingCommand(_context,_mapper);
            command.Model = model;
            CreateHeadingModelValidator validationRules = new CreateHeadingModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHeading(int id,[FromBody]UpdateHeadingModel model)
        {
            UpdateHeadingCommand command = new UpdateHeadingCommand(_context);
            command.HeadingId = id;
            command.Model = model;
            UpdateHeadingModelValidator validationRules = new UpdateHeadingModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteHeading(int id)
        {
            DeleteHeadingCommand command = new DeleteHeadingCommand(_context,_mapper);
            command.HeadingId = id;
            DeleteHeadingValidator validationRules = new DeleteHeadingValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
       
    }
}
