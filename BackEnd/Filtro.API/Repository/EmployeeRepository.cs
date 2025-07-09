using Filtro.API.Data;
using Filtro.API.Models;
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
        public IEnumerable<Employee> GetAll() 
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "employee.json");
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();

        }

        public async Task AddRangeAsync(List<Employee> employees)
        {
            await _context.Employees.AddRangeAsync(employees);
            await _context.SaveChangesAsync();

        }
    }
}
