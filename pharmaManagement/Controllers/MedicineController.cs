using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using pharmaManagement.Modals;
using pharmaManagement.Services;
using System.Net;

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
        [Authorize(Roles = "Admin")]
        [Route("Medicine/GetAllMedicines")]
        public async Task<List<Medicine>> GetAllMedicinesAsync()
        {
           
            return await _medicineService.GetAllAsync();
        }

    
        [Route("Medicine/GetMedicineById/{Id}")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetMedicineByIdAsync(int Id)
        {
            Medicine medicine =  await _medicineService.GetByIdAsync(Id);
            if(medicine== null)
            {
                return NotFound("No Medicine found");
            }
            else
            {
                return Ok(medicine);
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Medicine/PostMedicine")]
        public Medicine PostMedicine(Medicine Medicine)
        {
            _medicineService.CreateAsync(Medicine);
            return Medicine;
        }

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        //[Route("Medicine/delete/{id}")]
        //public async Task<string> DeleteDoctor(int id)
        //{
        //    return await _medicineService.DeleteById(id);
        //}
    }


}