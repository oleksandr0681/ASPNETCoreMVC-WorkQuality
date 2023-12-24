using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WorkQuality.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; } = string.Empty;

        public double TechnicalKnowledgePriorityCoefficient { get; set; } = 1;

        public double AbilityToApplyTechnicalKnowledgePriorityCoefficient { get; set; } = 1;

        public double ProjectManagementSkillsPriorityCoefficient { get; set; } = 1;

        public double QualityCustomerServicePriorityCoefficient { get; set; } = 1;
    }
}
