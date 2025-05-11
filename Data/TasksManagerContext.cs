using Microsoft.EntityFrameworkCore;
using todo_backend.Models;

namespace todo_backend.Data
{
    public class TasksManagerContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        public TasksManagerContext(DbContextOptions<TasksManagerContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);
        }
    }
}
