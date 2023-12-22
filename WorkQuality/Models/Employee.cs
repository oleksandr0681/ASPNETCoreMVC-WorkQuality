using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public int JobId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Job? Job { get; set; } // Зв'язок з таблицею Jobs.

        public ICollection<Examination>? Examinations { get; set; }
    }
}
