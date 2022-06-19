using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Leave.Models;

namespace Leave.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Leave_type> Leave_types { get; set; }
        public DbSet<Leave_history> Leave_histories { get; set; }
        public DbSet<Leave_allocation> Leave_Allocations { get; set; }
        public DbSet<Leave.Models.Leave_type_view_model>? Detail_Leave_type_view_model { get; set; }

    }
}