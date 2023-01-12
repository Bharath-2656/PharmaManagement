using System;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using pharmaManagement.Modals;

namespace pharmaManagement.Services
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetAllAsync();
        public Task<Patient>? GetByIdAsync(int id);
        public Task<ActionResult<Patient>?> CreateAsync(Patient patient);
        public void UpdateAsync(Patient patient);
        public Task<string> DeleteById(int id);

    }
}

