using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using FirstWebApplication.Controllers;
using pharmaManagement.Modals;

namespace pharmaManagement.Services.MedicineService
{
	public class MedicineService: IMedicneService
	{
        private readonly AppDBContext _context;
        private readonly ILogger<MedicineController> _logger;

        public MedicineService(AppDBContext context, ILogger<MedicineController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Medicine>> GetAllAsync()
        {

            if (_context.Medicines == null)
            {
                return null;
            }
            var medicines = await _context.Medicines.ToListAsync();
                return medicines;
            }

            public async Task<Medicine?> GetByIdAsync(int id)
            {
                if (_context.Medicines == null)
                {
                    return null;
                }
                var medicine = await _context.Medicines.FindAsync(id);

                if (medicine == null)
                {
                    return null;
                }

                return medicine;
            }

      

            public async void UpdateAsync(Medicine medicine)
            {
                _context.Entry(medicine).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task<ActionResult<Medicine>?> CreateAsync(Medicine medicine)
            {
                if (_context.Medicines == null)
                {
                    return null;
                }
                _context.Medicines.Add(medicine);
                await _context.SaveChangesAsync();
                return await GetByIdAsync(medicine.Id);
            }

            public async Task<string> DeleteById(int id)
            {
                if (_context.Medicines == null)
                {
                    return "No Medicines are available to delete";
                }
                var Medicine = await _context.Medicines.FindAsync(id);
                if (Medicine == null)
                {
                    return $"No Medicine found with id {id}";
                }

                _context.Medicines.Remove(Medicine);
                await _context.SaveChangesAsync();
                return "User deleted";
          
        }
	}
}

