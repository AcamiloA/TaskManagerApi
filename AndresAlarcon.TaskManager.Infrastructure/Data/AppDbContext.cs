using AndresAlarcon.TaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AndresAlarcon.TaskManager.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Trace> Trace { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());           

            modelBuilder.Entity<Board>()
                       .HasOne(e => e.Creator)
                       .WithMany()
                       .HasForeignKey(e => e.CreatedBy)
                       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Board>()
                        .HasOne(e => e.Updater)
                        .WithMany()
                        .HasForeignKey(e => e.UpdatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trace>()
                        .HasOne(e => e.Board)
                        .WithMany()
                        .HasForeignKey(e => e.BoardId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trace>()
                        .HasOne(e => e.CurrentUser)
                        .WithMany()
                        .HasForeignKey(e => e.CurrentAssignedTo)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trace>()
                        .HasOne(e => e.LastUser)
                        .WithMany()
                        .HasForeignKey(e => e.LastAssignedTo)
                        .OnDelete(DeleteBehavior.Restrict);

        }
    }    
}
