using AndresAlarcon.TaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AndresAlarcon.TaskManager.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Board { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Role>() 
                        .HasOne(e => e.Creator)       
                        .WithMany()                   
                        .HasForeignKey(e => e.CreatedBy) 
                        .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Role>()
                        .HasOne(e => e.Updater)      
                        .WithMany()                 
                        .HasForeignKey(e => e.UpdatedBy) 
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Priority>()
                        .HasOne(e => e.Creator)
                        .WithMany()
                        .HasForeignKey(e => e.CreatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Priority>()
                        .HasOne(e => e.Updater)
                        .WithMany()
                        .HasForeignKey(e => e.UpdatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
                        .HasOne(e => e.Creator)
                        .WithMany()
                        .HasForeignKey(e => e.CreatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
                        .HasOne(e => e.Updater)
                        .WithMany()
                        .HasForeignKey(e => e.UpdatedBy)
                        .OnDelete(DeleteBehavior.Restrict);

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
        }
    }    
}
