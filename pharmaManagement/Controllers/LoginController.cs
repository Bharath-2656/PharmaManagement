using System;
using FirstWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharmaManagement.Modals;

namespace pharmaManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;
        public LoginController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<Admin>> login(Admin user)
        {
            var users = await _context.Admins.FirstOrDefaultAsync(e => e.Id == user.Id);
            if (user != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound("User not found");
            }
            
        }
    }
}

