using Filtro.API.Models;
using Filtro.API.Repository;

namespace Filtro.API.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository) 
        {
            _repository = repository;
        }

        public IEnumerable<Employee> FilterWord(string wordKey) 
        {
            var employee = _repository.GetAll();
            return employee
                .Where(f => f.Position.Contains(wordKey, StringComparison.OrdinalIgnoreCase) ||
                f.Name.Contains(wordKey,StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Employee> GetAll() 
        {
            return _repository.GetAll();
        }

    }
}
