using Microsoft.EntityFrameworkCore;
using MyProfile.Models;

namespace MyProfile.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Resume> resumes { get; set; }
        public DbSet<BasicInfo> BasicInfos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<ContactUs> ContactUss { get; set; }

        public DbSet<Other> Others { get; set; }

    }
}
