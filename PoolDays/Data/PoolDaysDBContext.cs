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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Pool>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Pools)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
