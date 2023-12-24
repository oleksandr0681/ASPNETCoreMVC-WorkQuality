using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Працівник")]
        public int EmployeeId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Employee? Employee { get; set; } // Зв'язок з таблицею Employees.

        [Display(Name = "Дата оцінювання"), DataType(DataType.Date)]
        public DateTime AssessDate { get; set; } = DateTime.Today;

        [Range(1, 5, 
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."), 
            Display(Name = "Технічні знання і навички")]
        public int? TechnicalKnowledgeScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."), 
            Display(Name = "Спроможність застосовувати знання")]
        public int? AbilityToApplyTechnicalKnowledgeScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Кількості та серйозності помилок")]
        public int? NumberAndSeverityOfErrorsScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Креативність рішень")]
        public int? CreativityOfSolutionsScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Відповідність роботи специфікаціям")]
        public int? ComplianceOfWorkWithRequirementsScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Продуктивність")]
        public int? ProductivityScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Командна робота")]
        public int? TeamworkScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Навички управління проектами")]
        public int? ProjectManagementSkillsScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Навчання та розвиток")]
        public int? TrainingAndDevelopmentScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."),
            Display(Name = "Внесок у загальні цілі компанії")]
        public int? ContributionToOverallGoalsScore { get; set; } = 5;

        [Range(1, 5,
            ErrorMessage = "Значення для {0} повинно бути між {1} і {2}."), 
            Display(Name = "Якість обслуговування клієнтів")]
        public int? QualityCustomerServiceScore { get; set; } = 5;

        [Display(Name = "Рейтинг")]
        public double? Rating { get; set; } = 0;
    }
}
