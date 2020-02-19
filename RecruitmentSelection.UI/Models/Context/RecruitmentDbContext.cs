using Microsoft.EntityFrameworkCore;

namespace RecruitmentSelection.UI.Models.Context
{
    public class RecruitmentDbContext : DbContext
    {
        public RecruitmentDbContext() { }

        public RecruitmentDbContext(DbContextOptions<RecruitmentDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Languages> Languages { get; set; }      
    }
}
