using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.EntryModels.CreateEntry;
using YoreselSozluk.DataAccess.Models.EntryModels.DeleteEntry;
using YoreselSozluk.DataAccess.Models.EntryModels.EntryDetail;
using YoreselSozluk.DataAccess.Models.EntryModels.GetEntries;
using YoreselSozluk.DataAccess.Models.EntryModels.UpdateEntry;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.CreateEntry;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.DeleteEntry;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Commands.UpdateEntry;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Queries.GetEntries;
using YoreselSozluk.DataAccess.Operations.EntryOperations.Queries.GetEntryDetail;

namespace YoreselSozluk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public EntriesController(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public EntryDetailViewModel GetEntryDetail([FromQuery] int id)
        {
            GetEntryDetailQuery query = new GetEntryDetailQuery(_context, _mapper);
            query.EntryId = id;
            EntryDetailViewModelValidator validationRules = new EntryDetailViewModelValidator();
            validationRules.ValidateAndThrow(query);
            return query.Handle();
        }

        [HttpGet("{headingId}")]
        public List<EntriesViewModel> GetEntries(int headingId)
        {
            GetEntriesQuery query = new GetEntriesQuery(_context, _mapper);
            query.HeadingId = headingId;
            return query.Handle();
        }

        [HttpPost]
        public IActionResult CreateEntry([FromBody] CreateEntryModel model)
        {
            CreateEntryCommand command = new CreateEntryCommand(_context, _mapper);
            command.Model = model;
            CreateEntryModelValidator validationRules = new CreateEntryModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEntry(int id,[FromBody]UpdateEntryModel model)
        {
            UpdateEntryCommand command = new UpdateEntryCommand(_context, _mapper);
            command.EntryId = id;
            command.Model = model;
            UpdateEntryModelValidator validationRules = new UpdateEntryModelValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntry(int id)
        {
            DeleteEntryCommand command = new DeleteEntryCommand(_context,_mapper); 
            command.EntryId = id;
            DeleteEntryValidator validationRules = new DeleteEntryValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }
    }
}
