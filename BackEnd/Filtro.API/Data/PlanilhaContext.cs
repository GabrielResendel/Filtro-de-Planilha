using Filtro.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtro.API.Data
{
    public class PlanilhaContext : DbContext
    {
        
        public PlanilhaContext(DbContextOptions<PlanilhaContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.HiringDate)
                .HasColumnType("timestamp without time zone");
        }

    }
}
