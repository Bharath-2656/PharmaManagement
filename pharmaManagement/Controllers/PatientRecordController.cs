using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using pharmaManagement.Modals;
using pharmaManagement.Services;
using System.Net;
using pharmaManagement.DTO;
using AutoMapper;
using System;

namespace FirstWebApplication.Controllers
{
    [ApiController]
    public class PatientRecordController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPatientRecordService _patientRecordService;
        private readonly IMapper _mapper;

        public PatientRecordController(AppDBContext context, IPatientRecordService patientRecordService)
        {
            _context = context;
            _patientRecordService = patientRecordService;
        }

        //Get all Patient Records
        [HttpGet]
        [Authorize(Roles = "Admin")]

        [Route("PatientRecord/GetAllPatientRecords")]
        public async Task<IActionResult> GetAllPatientsAsync()
        {

            List<GetPatientRecordDTO> patientRecord = await _patientRecordService.GetAllAsync();
            if (patientRecord.Count == 0)
            {
                return NotFound("No PatientRecord found");
            }
            else
            {
                return Ok(patientRecord);
            }
        }


        [Route("patient-record/{patientid}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPatientRecordsByPatientId(int Id)
        {
            List<GetPatientRecordDTO> patientRecord = await _patientRecordService.GetPatientRecordsByPatientId(Id);
            if (patientRecord == null)
            {
                return NotFound("No PatientRecord found");
            }
            else
            {
                return Ok(patientRecord);
            }

        }

        [Route("patient-record/{recordid}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public  async Task<IActionResult> GetPatientRecordsByRecordId(int Id)
        {
            List<GetPatientRecordDTO> patientRecord = _patientRecordService.GetPatientRecordsByRecordId(Id);
            if (patientRecord == null)
            {
                return NotFound("No PatientRecord found");
            }
            else
            {
                return Ok(patientRecord);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("PatientRecord/PostPatientRecord")]
        public PatientRecord PostPatient(PatientRecord PatientRecord)
        {
            _patientRecordService.CreateAsync(PatientRecord);
            return PatientRecord;
        }

    }


}