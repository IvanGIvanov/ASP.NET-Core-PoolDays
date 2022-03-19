using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoolDays.Data.Models;

namespace PoolDays.Data
{
    public class PoolDaysDBContext : IdentityDbContext<User>
    {
        public PoolDaysDBContext(DbContextOptions<PoolDaysDBContext> options)
            : base(options)
        {
        }

        public DbSet<Pool> Pools { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Pool>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Pools)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Comment>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pool>()
                .HasOne(j => j.Employee)
                .WithMany(e => e.Pools)
                .HasForeignKey(j => j.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasIndex(c => c.UserId)
                .IsUnique(false);
                
            base.OnModelCreating(builder);
        }
    }
}
