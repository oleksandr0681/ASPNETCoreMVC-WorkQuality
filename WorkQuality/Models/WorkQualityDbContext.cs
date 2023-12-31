using Microsoft.EntityFrameworkCore;

namespace WorkQuality.Models
{
    public class WorkQualityDbContext : DbContext
    {
        public WorkQualityDbContext(DbContextOptions<WorkQualityDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>(entity => { entity.HasKey(k => k.Id); });
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Name = "Програміст",
                    NumberAndSeverityOfErrorsPriorityCoefficient = 2,
                    ComplianceOfWorkWithRequirementsPriorityCoefficient = 2,
                    ProjectManagementSkillsPriorityCoefficient = 0,
                    QualityCustomerServicePriorityCoefficient = 0
                },
                new Job
                {
                    Id = 2,
                    Name = "Дизайнер",
                    CreativityOfSolutionsPriorityCoefficient = 4,
                    ProjectManagementSkillsPriorityCoefficient = 0,
                    QualityCustomerServicePriorityCoefficient = 0
                });
        }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Assessment> Assessments { get; set; }
    }
}
