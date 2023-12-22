using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }

        public int ExaminationId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Examination? Examination { get; set; } // Зв'язок з таблицею Examinations.

        public int CriterionId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Criterion? Criterion { get; set; } // Зв'язок з таблицею Criteria.

        [Range(1, 5)]
        public int QualityScore { get; set; } = 5;
    }
}
