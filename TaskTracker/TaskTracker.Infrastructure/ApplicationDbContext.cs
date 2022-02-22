using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Entities;

namespace TaskTracker.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Uninitialized DbSet properties cause the compiler to emit warning. Read more here:
        // https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<TaskItem>().ToTable("TaskItem");


            modelBuilder.Entity<Project>()
                .Property(p => p.CreatedAt)
                .HasConversion<string>();
            modelBuilder.Entity<Project>()
                .Property(p => p.StartDate)
                .HasConversion<string>();
            modelBuilder.Entity<Project>()
                .Property(p => p.CompletionDate)
                .HasConversion<string>();

            modelBuilder.Entity<TaskItem>()
                .Property(p => p.CreatedAt)
                .HasConversion<string>();
            modelBuilder.Entity<TaskItem>()
                .Property(p => p.StartDate)
                .HasConversion<string>();
            modelBuilder.Entity<TaskItem>()
                .Property(p => p.CompletionDate)
                .HasConversion<string>();


            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.TasksItems)
                .HasForeignKey(t => t.ProjectId);
        }
    }
}
