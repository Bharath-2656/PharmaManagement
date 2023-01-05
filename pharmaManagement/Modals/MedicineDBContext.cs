using Microsoft.EntityFrameworkCore;
using pharmaManagement.Modals;

namespace FirstWebApplication.Controllers
{
    public class MedicineDBContext : DbContext
    {
        public MedicineDBContext(DbContextOptions<MedicineDBContext> options) : base(options)
        {

        }

        //Create Table here
        public DbSet<Medicine> Users { get; set; }
    }
}