using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    [Index(nameof(Name), IsUnique = true), Display(Name = "Посада")]
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Display(Name = "Назва посади")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000), Display(Name = "Опис")]
        public string? Description { get; set; } = string.Empty;

        [Display(Name = "Коефіцієнт пріоритетності технічних знань")]
        public double TechnicalKnowledgePriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності спроможності застосовувати знання")]
        public double AbilityToApplyTechnicalKnowledgePriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності кількості та серйозності помилок")]
        public double NumberAndSeverityOfErrorsPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності креативності рішень")]
        public double CreativityOfSolutionsPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності відповідності роботи специфікаціям")]
        public double ComplianceOfWorkWithRequirementsPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності продуктивності")]
        public double ProductivityPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності командної роботи")]
        public double TeamworkPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності навичок управління проектами")]
        public double ProjectManagementSkillsPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності навчання та розвитку")]
        public double TrainingAndDevelopmentPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності внеску у загальні цілі")]
        public double ContributionToOverallGoalsPriorityCoefficient { get; set; } = 1;

        [Display(Name = "Коефіцієнт пріоритетності якості обслуговування клієнтів")]
        public double QualityCustomerServicePriorityCoefficient { get; set; } = 1;
    }
}
