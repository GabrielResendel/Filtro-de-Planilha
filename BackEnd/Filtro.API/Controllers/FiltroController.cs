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
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("FilterAll")]
        public async Task<ActionResult<IEnumerable<Employee>>> FilterAll([FromQuery] string? wordKey, [FromQuery] int? id, [FromQuery] double? wage, [FromQuery] DateTime? hiringDate)
        {
            var result = await _service.FilterWord(wordKey, id, wage, hiringDate);
            return Ok(result);

        }

        [HttpGet("WageMin")]
        public async Task<ActionResult<IEnumerable<Employee>>> WageMin([FromQuery] double wageMin)
        {
            var result = await _service.FilterMinWage(wageMin);
            return Ok(result);
        }
        [HttpGet("WageMax")]
        public async Task<ActionResult<IEnumerable<Employee>>> WageMax([FromQuery] double wageMax)
        {
            var result = await _service.FilterMaxWage(wageMax);
            return Ok(result);
        }

        [HttpGet("DateMin")]
        public async Task<ActionResult<IEnumerable<Employee>>> DateMin([FromQuery] DateTime dateMin)
        {
            var result = await _service.FilterHiringDateMin(dateMin);
            return Ok(result);
        }

        [HttpGet("DateMax")]
        public async Task<ActionResult<IEnumerable<Employee>>> DateMax([FromQuery] DateTime dateMax)
        {
            var result = await _service.FilterHiringDateMax(dateMax);
            return Ok(result);
        }

        [HttpGet("Position")]
        public async Task<ActionResult<IEnumerable<Employee>>> Position([FromQuery] string position)
        {
            var result = await _service.FilterPosition(position);
            return Ok(result);
        }
        [HttpGet("Name")]
        public async Task<ActionResult<IEnumerable<Employee>>> Name([FromQuery] string name)
        {
            var result = await _service.FilterName(name);
            return Ok(result);
        }

    }
}