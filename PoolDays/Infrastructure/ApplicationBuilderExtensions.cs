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

                    var adminRole = new IdentityRole { Name = AdministatorRoleName };
                    var employeeRole = new IdentityRole { Name = EmployeeRoleName };
                    var buyerRole = new IdentityRole { Name = BuyerRoleName };

                    await roleManager.CreateAsync(adminRole);
                    await roleManager.CreateAsync(employeeRole);
                    await roleManager.CreateAsync(buyerRole);

                    const string adminPassword = "123123";


                    var adminUser = new User
                    {
                        Email = "admin@mail.bg",
                        UserName = "admin@mail.bg",
                        FirstName = "Admin",
                        LastName = "Admin",
                    };

                    var employeeUser = new User
                    {
                        Email = "employee@mail.bg",
                        UserName = "employee@mail.bg",
                        FirstName = "Employee",
                        LastName = "Employee",
                    };

                    await userManager.CreateAsync(adminUser, adminPassword);
                    await userManager.AddToRoleAsync(adminUser, adminRole.Name);

                    await userManager.CreateAsync(employeeUser, adminPassword);
                    await userManager.AddToRoleAsync(employeeUser, employeeRole.Name);
                })
                .GetAwaiter()
                .GetResult();

        }
    }
}
