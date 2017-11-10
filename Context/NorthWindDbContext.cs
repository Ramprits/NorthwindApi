using Microsoft.EntityFrameworkCore;
using WebApplicationNorthwind.Entities;

namespace WebApplicationNorthwind.Context
{
    public class NorthWindDbContext : DbContext
    {
        public NorthWindDbContext(DbContextOptions<NorthWindDbContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
