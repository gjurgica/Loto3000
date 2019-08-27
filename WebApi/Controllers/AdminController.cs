using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        public IActionResult Start()
        {
             _adminService.StartSession();
            return Ok("New Session is start");
        }
        [HttpGet("winners")]
        public ActionResult<List<WinnerModel>> Get()
        {
           return _adminService.CheckWinners();
        }
    }
}