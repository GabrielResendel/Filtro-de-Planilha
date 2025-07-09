using Filtro.API.DTOS;
using Filtro.API.Models;

namespace Filtro.API.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> FilterWord(string? wordKey, int? id,double? wage,DateTime? hiringDate);
        IEnumerable<Employee> FilterMinWage(double wageMin);
        IEnumerable<Employee> FilterMaxWage(double wageMax);
        IEnumerable<Employee> FilterHiringDateMin(DateTime dateMin);
        IEnumerable<Employee> FilterHiringDateMax(DateTime dateMax);
        IEnumerable<Employee> FilterPosition(string position);
        IEnumerable<Employee> FilterName(string name);

        Task SaveEmployeesAsync(List<EmployeeDTO> employeesDto);

        IEnumerable<Employee> GetAll();
    }

}   
