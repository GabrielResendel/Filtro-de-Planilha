using Filtro.API.DTOS;
using Filtro.API.Models;

namespace Filtro.API.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> FilterWord(string? wordKey, int? id,double? wage,DateTime? hiringDate);
        Task<IEnumerable<Employee>> FilterMinWage(double wageMin);
        Task<IEnumerable<Employee>> FilterMaxWage(double wageMax);
        Task<IEnumerable<Employee>> FilterHiringDateMin(DateTime dateMin);
        Task<IEnumerable<Employee>> FilterHiringDateMax(DateTime dateMax);
        Task<IEnumerable<Employee>> FilterPosition(string position);
        Task<IEnumerable<Employee>>FilterName(string name);

        Task SaveEmployeesAsync(List<EmployeeDTO> employeesDto);

        Task<IEnumerable<Employee>> GetAllAsync();
    }

}   
