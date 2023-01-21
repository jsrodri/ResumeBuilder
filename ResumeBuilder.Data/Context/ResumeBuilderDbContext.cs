using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ResumeBuilder.Data.Context
{
    public class ResumeBuilderDbContext : DbContext
    {
        public ResumeBuilderDbContext(DbContextOptions<ResumeBuilderDbContext> options)
            : base(options) { }

        public DbSet<Resume> Resume { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<Skill> Skill { get; set; }


        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Contact>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Skill>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
        #endregion
    }

}