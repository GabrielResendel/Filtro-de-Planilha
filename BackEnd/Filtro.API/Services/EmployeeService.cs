using Filtro.API.DTOS;
using Filtro.API.Models;
using Filtro.API.Repository;
using System.Globalization;

namespace Filtro.API.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository) 
        {
            _repository = repository;
        }
        
        public async Task SaveEmployeesAsync(List<EmployeeDTO> employeesDto)
        {
            var employees = new List<Employee>();

            foreach (var dto in employeesDto)
            {
               //validação 
                if (string.IsNullOrWhiteSpace(dto.Name))
                    throw new Exception("Name is required");

                if (dto.Wage <= 0)
                    throw new Exception("wage must be greater then zero");

               // Mapeia o dto
                var employee = new Employee
                {
                    Name = dto.Name,
                    Position = dto.Position,
                    Wage = dto.Wage,
                    HiringDate = dto.HiringDate

                };
                employees.Add(employee);

            }

            await _repository.AddRangeAsync(employees);
        }

        public IEnumerable<Employee> FilterWord(string? wordKey,int? id,double? wage,DateTime? hiringDate)
        {
            var employee = _repository.GetAll();

            if (id.HasValue)
                employee = employee.Where(e => e.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(wordKey))
                employee = employee.Where(e => e.Position.Contains(wordKey, StringComparison.OrdinalIgnoreCase) ||
                e.Name.Contains(wordKey, StringComparison.OrdinalIgnoreCase));

            if (wage.HasValue)
                employee = employee.Where(e => e.Wage == wage.Value || e.Wage > wage.Value);

            if (hiringDate.HasValue)
                employee = employee.Where(e => e.HiringDate == hiringDate.Value.Date);
 
            return employee;
                
        }

        public IEnumerable<Employee> FilterMinWage(double minWage)
        {
            var employee = _repository.GetAll();

            return employee = employee.Where(e => e.Wage >= minWage);

        }
        public IEnumerable<Employee> FilterMaxWage(double maxWage)
        {
            var employee = _repository.GetAll();

            return employee = employee.Where(e => e.Wage <= maxWage);

        }

        public IEnumerable<Employee> FilterHiringDateMin(DateTime minHiringDate)
        {
            var employee = _repository.GetAll();

            return employee = employee.Where(e => e.HiringDate >=  minHiringDate);
        }
        public IEnumerable<Employee> FilterHiringDateMax(DateTime maxHiringDate)
        {
            var employee = _repository.GetAll();

            return employee = employee.Where(e => e.HiringDate <= maxHiringDate);
        }
        public IEnumerable<Employee> FilterPosition(string position)
        {
            var employee = _repository.GetAll();

            return employee = employee.Where(e => e.Position.Contains(position, StringComparison.OrdinalIgnoreCase));

        }
        public IEnumerable<Employee> FilterName(string name)
        {
            var employee = _repository.GetAll();

            return employee = employee.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }


        public IEnumerable<Employee> GetAll() 
        {
            return _repository.GetAll();
        }

    }
}
