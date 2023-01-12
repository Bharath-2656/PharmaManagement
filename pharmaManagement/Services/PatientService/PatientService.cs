using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using FirstWebApplication.Controllers;
using pharmaManagement.Modals;
using pharmaManagement.Controllers;

namespace pharmaManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDBContext _context;
        private readonly ILogger<PatientController> _logger;

        public PatientService(AppDBContext context, ILogger<PatientController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Patient>> GetAllAsync()
        {

            if (_context.Patients == null)
            {
                return null;
            }
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            if (_context.Patients == null)
            {
                return null;
            }
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return null;
            }

            return patient;
        }



        public async void UpdateAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<Patient>?> CreateAsync(Patient patient)
        {
            if (_context.Patients == null)
            {
                return null;
            }
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(patient.patientId);
        }

        public async Task<string> DeleteById(int id)
        {
            if (_context.Patients == null)
            {
                return "No Patients are available to delete";
            }
            var Patient = await _context.Patients.FindAsync(id);
            if (Patient == null)
            {
                return $"No Patient found with id {id}";
            }

            _context.Patients.Remove(Patient);
            await _context.SaveChangesAsync();
            return "Patient deleted";

        }
    }
}

