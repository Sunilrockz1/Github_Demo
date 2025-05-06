using Microsoft.EntityFrameworkCore;

namespace Abfirstapplicationapi.Models
{
    public class Employeecontext:DbContext
    {
        public Employeecontext(DbContextOptions<Employeecontext>options):base(options)
        {

        }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
