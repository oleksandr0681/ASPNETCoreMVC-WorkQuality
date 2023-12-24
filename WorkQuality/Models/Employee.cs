using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    [Display(Name = "Працівник")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200), Display(Name = "Прізвище, ім'я, по батькові")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Посада")]
        public int JobId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Job? Job { get; set; } // Зв'язок з таблицею Jobs.

        [MaxLength(1000), Display(Name = "Характеристика")]
        public string? Description { get; set; } = string.Empty;

        [Display(Name = "Оцінювання")]
        public ICollection<Assessment>? Assessments { get; set; }
    }
}
