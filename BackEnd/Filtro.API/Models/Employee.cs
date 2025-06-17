using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtro.API.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public double? Wage { get; set; }
        public DateTime? HiringDate { get; set; }

    }
}