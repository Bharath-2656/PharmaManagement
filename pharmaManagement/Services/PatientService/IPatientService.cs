using System;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using pharmaManagement.Modals;
using pharmaManagement.DTO;

namespace pharmaManagement.Services
{
    public interface IPatientService
    {
        public IEnumerable<PatientDTO> GetAllAsync();
        public Task<Patient>? GetByIdAsync(int id);
        public Task<ActionResult<Patient>?> CreateAsync(PatientDTO patient);
        public void UpdateAsync(Patient patient);
        public Task<string> DeleteById(int id);

    }
}

