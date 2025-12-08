using Microsoft.EntityFrameworkCore;
using BCTECHAPI.Core.Models;

namespace BCTECHAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
