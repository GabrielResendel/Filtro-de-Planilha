using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filtro.API.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Position { get; set; } = default!;
        public double? Wage { get; set; }
        public DateTime HiringDate { get; set; }

    }
}