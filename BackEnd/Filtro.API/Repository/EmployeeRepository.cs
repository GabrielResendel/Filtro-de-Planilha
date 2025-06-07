using Filtro.API.Models;
using System.Text.Json;
namespace Filtro.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll() 
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "employee.json");
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();

        }
    }
}
