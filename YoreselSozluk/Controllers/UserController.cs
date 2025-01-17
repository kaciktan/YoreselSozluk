﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoreselSozluk.DataAccess.Abstract;
using YoreselSozluk.DataAccess.Models.UserModels.CreateToken;
using YoreselSozluk.DataAccess.Models.UserModels.CreateUser;
using YoreselSozluk.DataAccess.Models.UserModels.Token;
using YoreselSozluk.DataAccess.Operations.UserOperations.Commands.CreateToken;
using YoreselSozluk.DataAccess.Operations.UserOperations.Commands.CreateUser;
using YoreselSozluk.DataAccess.Operations.UserOperations.Commands.RefreshToken;

namespace YoreselSozluk.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public UserController(IContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper);
            command.Model = newUser;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _configuration);
            command.Model = login;
            var token = command.Handle();
            return Ok(token);


        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return Ok(resultToken);
        }
    }
}
