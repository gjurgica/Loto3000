using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;


namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null) return NotFound("Incorrect username or password");

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            _userService.RegisterUser(model);
            return Ok("Successfully registered!");
        }
        [AllowAnonymous]
        [HttpPost("buyticket")]
        public IActionResult BuyTicket([FromBody] string numbers,[FromQuery] int userId)
        {
            //var userId = GetAuthorizedUserId();
            _userService.BuyTicket(numbers, userId);
            return Ok("You can check luckynumbers here:http://localhost:56747/api/admin/luckynumbers winners here: http://localhost:56747/api/admin/winners");
        }
        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value,
                out var userId))
            {
                throw new Exception("Name identifier claim does not exist.");
            }
            return userId;
        }
    }
}