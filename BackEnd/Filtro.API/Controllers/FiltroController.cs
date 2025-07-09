using Filtro.API.DTOS;
using Filtro.API.Models;
using Filtro.API.Services;
using Microsoft.AspNetCore.Mvc;
namespace Filtro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FiltroController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public FiltroController(IEmployeeService service)
        {
            _service = service;
        }


        [HttpPost("SaveJsonList")]
        public async Task<IActionResult> PostEmployee([FromBody] List<EmployeeDTO> employeesDto )
        {
            try
            {
                await _service.SaveEmployeesAsync(employeesDto);
                return Ok(new { message = "Employees saved successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
                         
        }

       
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("FilterAll")]
        public ActionResult<IEnumerable<Employee>> FilterAll([FromQuery] string? wordKey, [FromQuery] int? id, [FromQuery] double? wage, [FromQuery] DateTime? hiringDate)
        {
            var result = _service.FilterWord(wordKey, id, wage, hiringDate);
            return Ok(result);

        }

        [HttpGet("WageMin")]
        public ActionResult<IEnumerable<Employee>> WageMin([FromQuery] double wageMin)
        {
            var result = _service.FilterMinWage(wageMin);
            return Ok(result);
        }
        [HttpGet("WageMax")]
        public ActionResult<IEnumerable<Employee>> WageMax([FromQuery] double wageMax)
        {
            var result = _service.FilterMaxWage(wageMax);
            return Ok(result);
        }

        [HttpGet("DateMin")]
        public ActionResult<IEnumerable<Employee>> DateMin([FromQuery] DateTime dateMin)
        {
            var result = _service.FilterHiringDateMin(dateMin);
            return Ok(result);
        }

        [HttpGet("DateMax")]
        public ActionResult<IEnumerable<Employee>> DateMax([FromQuery] DateTime dateMax)
        {
            var result = _service.FilterHiringDateMax(dateMax);
            return Ok(result);
        }

        [HttpGet("Position")]
        public ActionResult<IEnumerable<Employee>> Position([FromQuery] string position)
        {
            var result = _service.FilterPosition(position);
            return Ok(result);
        }
        [HttpGet("Name")]
        public ActionResult<IEnumerable<Employee>> Name([FromQuery] string name)
        {
            var result = _service.FilterName(name);
            return Ok(result);
        }

    }
}