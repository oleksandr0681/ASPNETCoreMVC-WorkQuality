using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    public class Examination
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Employee? Employee { get; set; } // Зв'язок з таблицею Employees.

        public DateTime? Date { get; set; } = DateTime.Today;

        public ICollection<Score>? Scores { get; set; }
    }
}
