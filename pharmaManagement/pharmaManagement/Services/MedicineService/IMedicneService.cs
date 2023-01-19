using System;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using pharmaManagement.Modals;

namespace pharmaManagement.Services
{
	public interface IMedicneService
	{
        public Task<List<Medicine>> GetAllAsync();
        public Task<Medicine>? GetByIdAsync(int id);
        public Task<ActionResult<Medicine>?> CreateAsync(Medicine medicine);
        public void UpdateAsync(Medicine medicine);
        public Task<string> DeleteById(int id);

    }
}

