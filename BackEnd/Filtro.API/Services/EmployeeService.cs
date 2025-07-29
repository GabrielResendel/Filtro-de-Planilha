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

        public async Task<IEnumerable<Employee>> FilterWord(string? wordKey,int? id,double? wage,DateTime? hiringDate)
        {
            var employee = await _repository.GetAllAsync();

            if (id.HasValue)

                employee.Where(e => e.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(wordKey))

               employee.Where(e => e.Position.Contains(wordKey, StringComparison.OrdinalIgnoreCase) ||
                e.Name.Contains(wordKey, StringComparison.OrdinalIgnoreCase));

            if (wage.HasValue)

                 employee.Where(e => e.Wage == wage.Value || e.Wage > wage.Value);

            if (hiringDate.HasValue)
               
                employee.Where(e => e.HiringDate == hiringDate.Value.Date);
 
            return employee;
                
        }

        public async Task<IEnumerable<Employee>> FilterMinWage(double minWage)
        {
            var employee = await _repository.GetAllAsync();

            return employee.Where(e => e.Wage >= minWage);

        }
        public async Task<IEnumerable<Employee>> FilterMaxWage(double maxWage)
        {
            var employee = await _repository.GetAllAsync();

            return employee.Where(e => e.Wage <= maxWage);

        }

        public async Task<IEnumerable<Employee>> FilterHiringDateMin(DateTime minHiringDate)
        {
            var employee = await _repository.GetAllAsync();

            return employee.Where(e => e.HiringDate >=  minHiringDate);
        }
        public async Task<IEnumerable<Employee>> FilterHiringDateMax(DateTime maxHiringDate)
        {
            var employee = await _repository.GetAllAsync();

            return employee.Where(e => e.HiringDate <= maxHiringDate);
        }
        public async Task<IEnumerable<Employee>> FilterPosition(string position)
        {
            var employee = await _repository.GetAllAsync();

            return employee.Where(e => e.Position.Contains(position, StringComparison.OrdinalIgnoreCase));

        }
        public async Task<IEnumerable<Employee>> FilterName(string name)
        {
            var employee = await _repository.GetAllAsync();

            return employee.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }


        public async Task<IEnumerable<Employee>> GetAllAsync() 
        {
            return await _repository.GetAllAsync();
        }

    }
}
