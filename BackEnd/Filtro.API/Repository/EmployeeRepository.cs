using Filtro.API.Data;
using Filtro.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Filtro.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PlanilhaContext _context;

        public EmployeeRepository(PlanilhaContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetAllAsync() 
        {
          return await _context.Employees.ToListAsync();

        }

        public async Task AddRangeAsync(List<Employee> employees)
        {
            await _context.Employees.AddRangeAsync(employees);
            await _context.SaveChangesAsync();

        }
    }
}
