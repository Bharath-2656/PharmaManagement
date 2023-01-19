using System;
using FirstWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using pharmaManagement.Modals;

namespace pharmaManagement.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AdminService> _logger;

        public AdminService(AppDBContext context, ILogger<AdminService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Admin>? GetByEmailIdAsync(string EmailId)
        {
            if (_context.Admins == null)
            {
                return null;
            }
            var admin = _context.Admins.FirstOrDefault(x => x.EmailId == EmailId);

            if (admin == null)
            {
                return null;
            }

            return admin;
        }
        public async Task<ActionResult<Admin>?> CreateAsync(Admin admin)
        {
            if (_context.Admins == null)
            {
                return null;
            }
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            return await GetByEmailIdAsync(admin.EmailId);
        }
    }
}

