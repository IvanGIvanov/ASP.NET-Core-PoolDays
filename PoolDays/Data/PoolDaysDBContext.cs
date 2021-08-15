using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoolDays.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        public DbSet<Jacuzzi> Jacuzzis { get; set; }

        public DbSet<Comment> Comments { get; set; }

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

            base.OnModelCreating(builder);
        }
    }
}
