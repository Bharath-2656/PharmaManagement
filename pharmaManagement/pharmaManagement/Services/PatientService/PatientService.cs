using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using FirstWebApplication.Controllers;
using pharmaManagement.Modals;
using pharmaManagement.Controllers;
using pharmaManagement.DTO;
using AutoMapper;

namespace pharmaManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDBContext _context;
        private readonly ILogger<PatientController> _logger;
        private readonly PatientDTO patientDTO;
        IMapper _mapper;
        ModelFactory _modelFactory;

        public PatientService(AppDBContext context, ILogger<PatientController> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        public IEnumerable<PatientDTO> GetAllAsync()
        {

            if (_context.Patients == null)
            {
                return null;
            }
            var patients = _context.Patients.ToList().Select(c => _modelFactory.Create(c));
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

        public async Task<ActionResult<Patient>?> CreateAsync(PatientDTO patient)
        {
            if (_context.Patients == null)
            {
                return null;
            }
            var patient1 = _mapper.Map<Patient>(patient);
            _context.Patients.Add(patient1);
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

