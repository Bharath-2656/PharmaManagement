using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using pharmaManagement.Modals;
using pharmaManagement.Services;

namespace FirstWebApplication.Controllers
{
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IMedicneService _medicineService;

        public MedicineController(AppDBContext context, IMedicneService medicneService)
        {
            _context = context;
            _medicineService = medicneService;
        }

        //Get all Medicines
        [HttpGet]
        [Route("Medicine/GetAllMedicines")]
        public async Task<List<Medicine>> GetAllMedicinesAsync()
        {
           
            return await _medicineService.GetAllAsync();
        }

        ////Get Medicine name by id
        //[HttpGet]
        //[Route("Medicine/GetName")]
        //public async Task<string> GetNameAsync(int Id)
        //{
        //    return await _medicineService.GetByIdAsync(Id);
        //}

        [Route("Medicine/GetMedicineById/{Id}")]
        [HttpGet]
        public async Task<Medicine> GetMedicineByIdAsync(int Id)
        {
            return await _medicineService.GetByIdAsync(Id);

        }

        [HttpPost]
        [Route("Medicine/PostMedicine")]
        public Medicine PostMedicine(Medicine Medicine)
        {
            _medicineService.CreateAsync(Medicine);
            return Medicine;
        }
    }


}