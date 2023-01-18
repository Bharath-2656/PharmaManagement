using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using FirstWebApplication.Controllers;
using pharmaManagement.Modals;
using pharmaManagement.Controllers;
using pharmaManagement.DTO;

namespace pharmaManagement.Services
{
    public class PatientRecordService : IPatientRecordService
    {
        private readonly AppDBContext _context;
        private readonly ILogger<PatientRecordController> _logger;

        public PatientRecordService(AppDBContext context, ILogger<PatientRecordController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Inner JOIn or LINQ in C#
        public async Task<List<GetPatientRecordDTO?>> GetAllAsync()
        {
            var patientRecord = (from p in _context.Patients
                                 join pr in _context.PatientRecords on p.patientId equals pr.patientId
                                 select new GetPatientRecordDTO
                                 {
                                     RecordId = pr.RecordId,
                                     patientId = p.patientId,
                                     medicineId = pr.medicineId,
                                     count = pr.count,
                                     Name = p.FirstName + ' ' + p.LastName,
                                     Age = p.Age,
                                     EmailId = p.EmailId,
                                     Address = p.Address
                                 }).ToList();
            return patientRecord;
        }

        public async Task<List<GetPatientRecordDTO?>> GetPatientRecordsByPatientId(int id)
        {
            var patientRecord = (from p in _context.Patients
                                 join pr in _context.PatientRecords on p.patientId equals pr.patientId
                                 where pr.patientId == id
                                 select new GetPatientRecordDTO
                                 {
                                     RecordId = pr.RecordId,
                                     patientId = p.patientId,
                                     medicineId = pr.medicineId,
                                     count = pr.count,
                                     Name = p.FirstName + ' ' + p.LastName,
                                     Age = p.Age,
                                     EmailId = p.EmailId,
                                     Address = p.Address
                                 }).ToList();
            return patientRecord;
        }


        public List<GetPatientRecordDTO?> GetPatientRecordsByRecordId(int id)
        {
            var patientRecord =  (from p in _context.Patients
                                 join pr in _context.PatientRecords on p.patientId equals pr.patientId
                                 where pr.RecordId == id
                                 select new GetPatientRecordDTO
                                 {
                                     RecordId = pr.RecordId,
                                     patientId = p.patientId,
                                     medicineId = pr.medicineId,
                                     count = pr.count,
                                     Name = p.FirstName + ' ' + p.LastName,
                                     Age = p.Age,
                                     EmailId = p.EmailId,
                                     Address = p.Address
                                 }).ToList();
            return patientRecord;
        }

        public async Task<List<GetPatientRecordDTO>?> CreateAsync(PatientRecord patientRecord)
        {
            if (_context.PatientRecords == null)
            {
                return null;
            }
            var medicine = _context.Medicines.FindAsync(patientRecord.medicineId);
            var patient = _context.Patients.FindAsync(patientRecord.patientId);
            if(medicine ==null && patient ==null)
            {
                return null;
            }
            _context.PatientRecords.Add(patientRecord);
            await _context.SaveChangesAsync();
            return GetPatientRecordsByRecordId(patientRecord.RecordId);
        }

    }
}

