using Filtro.API.Models;
namespace Filtro.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();

        Task AddRangeAsync(List<Employee> employees);
    }
}
