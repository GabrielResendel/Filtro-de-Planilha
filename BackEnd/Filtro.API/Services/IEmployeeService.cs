using Filtro.API.Models;

namespace Filtro.API.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> FilterWord(string wordKey);

        IEnumerable<Employee> GetAll();
    }

}   
