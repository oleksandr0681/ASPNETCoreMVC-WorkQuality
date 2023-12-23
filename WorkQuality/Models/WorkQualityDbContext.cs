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

            //modelBuilder.Entity<Criterion>(entity => { entity.HasKey(k => k.Id); });
            //modelBuilder.Entity<Criterion>().HasData( 
            //    new Criterion { Id = 1, Name = "Технічні знання і навички" },
            //    new Criterion { Id = 2, Name = "Спроможність застосовувати знання" },
            //    new Criterion { Id = 3, Name = "Якість роботи" },
            //    new Criterion { Id = 4, Name = "Продуктивність" },
            //    new Criterion { Id = 5, Name = "Командна робота", 
            //        Description = "Командна робота та комунікативні навички." });
        }

        //public DbSet<Criterion> Criteria { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        //public DbSet<Score> Scores { get; set; }
    }
}
