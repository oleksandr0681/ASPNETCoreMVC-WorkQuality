using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Employee? Employee { get; set; } // Зв'язок з таблицею Employees.

        [Display(Name = "Дата оцінювання"), DataType(DataType.Date)]
        public DateTime AssessmentDate { get; set; } = DateTime.Today;

        [Range(1, 5, 
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}.")]
        public int TechnicalKnowledgeScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}.")]
        public int AbilityToApplyTechnicalKnowledgeScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}.")]
        public int ProjectManagementSkillsScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}.")]
        public int QualityCustomerServiceScore { get; set; } = 5;

        public double Rating { get; set; }

        //public ICollection<Score>? Scores { get; set; }
    }
}
