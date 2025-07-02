using System.ComponentModel.DataAnnotations;

namespace Filtro.API.DTOS
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        [Range(0, 1000000)]
        public double Wage { get; set; }
        [DataType(DataType.Date)]
        public DateTime? HiringDate { get; set; }

    }
}
