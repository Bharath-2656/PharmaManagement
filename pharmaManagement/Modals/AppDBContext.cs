using Microsoft.EntityFrameworkCore;
using pharmaManagement.Modals;

namespace FirstWebApplication.Controllers
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        //Create Table here
        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}