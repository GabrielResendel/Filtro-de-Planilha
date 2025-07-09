using Filtro.API.Models;
namespace Filtro.API.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();

        Task AddRangeAsync(List<Employee> employees);
    }
}
