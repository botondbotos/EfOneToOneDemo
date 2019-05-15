using EfOneToOneDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EfOneToOneDemo.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Address> Address { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseNpgsql("Server=localhost;Port=5432;Database=EfOneToOneDemo;Username=secret_user;Password=secret_pass;")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) }));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Address)
                .WithOne(a => a.Employee)
                .HasForeignKey<Address>(a => a.EmployeeId);
        }
    }
}