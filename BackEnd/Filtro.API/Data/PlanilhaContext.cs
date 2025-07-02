using Filtro.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Filtro.API.Data
{
    public class PlanilhaContext : DbContext
    {
        public PlanilhaContext(DbContextOptions<PlanilhaContext> options) : base(options)
        {
        }

        public DbSet<Employee> emplyees { get; set; }

    }
}
