using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Criterion
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public double? PriorityCoefficient { get; set; } = 1;
    }
}
