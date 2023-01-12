using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using pharmaManagement.Modals;
using pharmaManagement.Services;
using System.Net;
using pharmaManagement.DTO;
using AutoMapper;

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
        public async Task<IActionResult> GetAllPatientsAsync()
        {

           List<Patient> patient =  await _patientService.GetAllAsync();
            if(patient.Count == 0)
            {
                return NotFound("No Patient found");
            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<PatientDTO>>(patient));
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
                return Ok(patient);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Patient/PostPatient")]
        public Patient PostPatient(Patient Patient)
        {
            _patientService.CreateAsync(Patient);
            return Patient;
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