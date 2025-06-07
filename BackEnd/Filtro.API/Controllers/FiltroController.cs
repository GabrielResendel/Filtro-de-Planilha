using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filtro.API.Models;
using Filtro.API.Services;
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
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll() 
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("Filter")]
        public ActionResult<IEnumerable<Employee>> Filter([FromQuery] string wordKey)
        {
            var result = _service.FilterWord(wordKey);
            return Ok(result);

        }

    }
}