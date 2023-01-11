using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using pharmaManagement.Modals;
using pharmaManagement.Services.AdminService;
using pharmaManagement.Services.TokenManager;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pharmaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IJWTTokenManager _configuration;
        public AdminController(IAdminService adminService, IJWTTokenManager configuration)
        {
            _adminService = adminService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<Admin>> login([FromBody] Login admin)
        {
            var users = await _adminService.GetByEmailIdAsync(admin.EmailId);

            if (users != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(admin.Password, users.Password);
                if (isValidPassword)
                {
                    var token = _configuration.Authenticate(admin.EmailId, users.Role);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Password must have 8 characters, one uppercase," +
                        " one lowercase, one special character and one digit");
                }
            }
            else
            {
                return BadRequest("user not found");
            }

        }
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<Admin>> Register(Admin admin)
        {
            if (admin != null)
            {
                var UserCheck = await _adminService.GetByEmailIdAsync(admin.EmailId);
                if (UserCheck == null)
                {
                    if (new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").IsMatch(admin.Password) && new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(admin.EmailId))
                    {
                        var saltSecret = BCrypt.Net.BCrypt.GenerateSalt();
                        admin.Password = BCrypt.Net.BCrypt.HashPassword(admin.Password, saltSecret);
                        await _adminService.CreateAsync(admin);
                        return Ok("Registered");

                    }
                    else
                    {
                        return BadRequest("Incoreect Email or password");
                    }
                }
                else
                {
                    return BadRequest("User already registered");
                }
            }
            else
            {
                return BadRequest("No details enetered");
            }

        }
    }
}

