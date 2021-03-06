﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Application;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserRegistered userRegistered = _userService.Register(userRegistration);
            // TODO: return Created
            return Ok(userRegistered);
        }
    }
}
