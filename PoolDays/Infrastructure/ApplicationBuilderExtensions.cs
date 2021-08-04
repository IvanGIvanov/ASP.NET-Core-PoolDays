using PoolDays.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using PoolDays.Data.Models;

namespace PoolDays.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<PoolDaysDBContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(PoolDaysDBContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Oval"},
                new Category { Name = "Circle"},
                new Category { Name = "Rectange"},
                new Category { Name = "Eight"},
                new Category { Name = "Square"},
                new Category { Name = "Indoor"},
                new Category { Name = "Outdoor"},
            });

            data.SaveChanges();
        }
    }
}
