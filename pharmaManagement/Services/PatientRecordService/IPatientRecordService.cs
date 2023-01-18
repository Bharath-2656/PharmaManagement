using System;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using pharmaManagement.Modals;
using pharmaManagement.DTO;

namespace pharmaManagement.Services
{
    public interface IPatientRecordService
    {
        public Task<List<GetPatientRecordDTO?>> GetAllAsync();
        public Task<List<GetPatientRecordDTO?>> GetPatientRecordsByPatientId(int id);
        public List<GetPatientRecordDTO?> GetPatientRecordsByRecordId(int id);
        public Task<List<GetPatientRecordDTO>> CreateAsync(PatientRecord patientRecord);
    }
}

