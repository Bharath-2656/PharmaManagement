using System;
using Microsoft.AspNetCore.Mvc;
using pharmaManagement.Modals;

namespace pharmaManagement.Services
{
    public interface IAdminService
    {
        public Task<Admin>? GetByEmailIdAsync(string EmailId);
        public Task<ActionResult<Admin>?> CreateAsync(Admin admin);

    }
}

