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
    public class PatientController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(AppDBContext context, IPatientService patientService, IMapper mapper)
        {
            _context = context;
            _patientService = patientService;
            _mapper = mapper;
        }

        //Get all Patients
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Patient/GetAllPatients")]
        public IEnumerable<PatientDTO> GetAllPatientsAsync()
        {

           IEnumerable<PatientDTO> patient =  _patientService.GetAllAsync();
            //if(patient.Count == 0)
            //{
            //    return NotFound("No Patient found");
            //}
            //else
            {
                return patient;
            }
        }


        [Route("Patient/GetPatientById/{Id}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetPatientByIdAsync(int Id)
        {
            Patient patient = await _patientService.GetByIdAsync(Id);
            if (patient == null)
            {
                return NotFound("No Patient found");
            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<PatientDTO>>(patient));
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Patient/PostPatient")]
        public IActionResult PostPatient(PatientDTO patient)
        {
            _patientService.CreateAsync(patient);

            return Ok(_mapper.Map<IEnumerable<PatientDTO>>(patient));
        }

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        //[Route("Patient/delete/{id}")]
        //public async Task<string> DeleteDoctor(int id)
        //{
        //    return await _patientService.DeleteById(id);
        //}
    }


}