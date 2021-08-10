using PoolDays.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using PoolDays.Data.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace PoolDays.Infrastructure
{
    using static WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var service = scopedServices.ServiceProvider;

            MigrateDatabase(service);

            SeedCategories(service);
            SeedAdministrator(service);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider service)
        {
            var data = service.GetRequiredService<PoolDaysDBContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<PoolDaysDBContext>();

            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Oval", Type = 1},
                new Category { Name = "Circle", Type = 1},
                new Category { Name = "Rectange", Type = 1},
                new Category { Name = "Eight", Type = 1},
                new Category { Name = "Square", Type = 1},
                new Category { Name = "Indoor", Type = 2},
                new Category { Name = "Outdoor", Type = 2},
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if(await roleManager.RoleExistsAsync(AdministatorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdministatorRoleName };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@mail.bg";
                    const string firstName = "Admin";
                    const string lastName = "Admin";
                    const string adminPassword = "123123";


                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FirstName = firstName,
                        LastName = lastName,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();

        }
    }
}
