using Microsoft.EntityFrameworkCore;
using Tripz.Domain.Entities;
using Tripz.Infrastructure.Repositories;

namespace Tripz.Infrastructure.Data
{
    public class TripzDbContext : DbContext
    {
        public TripzDbContext(DbContextOptions<TripzDbContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.EmployeeId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.EmployeeName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Destination).IsRequired().HasMaxLength(200);
                entity.Property(e => e.EstimatedCost).HasPrecision(18, 2);
            });
        }
    }
}