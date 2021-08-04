using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoolDays.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoolDays.Data
{
    public class PoolDaysDBContext : IdentityDbContext
    {
        public PoolDaysDBContext(DbContextOptions<PoolDaysDBContext> options)
            : base(options)
        {
        }

        public DbSet<Pool> Pools { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Employee> Employees { get; init; }

        public DbSet<Jacuzzi> Jacuzzies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Pool>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Pools)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Pool>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Pools)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Employee>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Jacuzzi>()
                .HasOne(j => j.Employee)
                .WithMany(e => e.Jacuzzies)
                .HasForeignKey(j => j.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
