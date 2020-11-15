using System;
using ApplyNow.Core.Models;
using ApplyNow.Data.Configurations;
using ApplyNow.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace ApplyNow.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<Company> Companies { get; set;  }

        public DbSet<Announcement> Announcements { get; set; }



        public DbSet<Apply> Applys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new ResumeConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ApplyConfiguration());

            modelBuilder.ApplyConfiguration(new EducationSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new ExperinceSeed(new int[] { 1, 2 }));

            modelBuilder.ApplyConfiguration(new UserSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new ResumeSeed(new int[] { 1, 2 }));

            modelBuilder.ApplyConfiguration(new CompanySeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new AnnouncementSeed(new int[] { 1, 2 }));


        }
    }
}
