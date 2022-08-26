using AspFoodProject.Data;
using AspFoodProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspFood.xUnitTestProject
{
    public static class DbContextMocker1
    {
        public static ApplicationDbContext GetApplicationDbContext(string databasename)
        {
            // Create a fresh service provider for the InMemory Database instance.
            var serviceProvider = new ServiceCollection()
                                  .AddEntityFrameworkInMemoryDatabase()
                                  .BuildServiceProvider();

            // Create a new options instance,
            // telling the context to use InMemory database and the new service provider.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databasename)
                            .UseInternalServiceProvider(serviceProvider)
                            .Options;

            // Create the instance of the DbContext (would be an InMemory database)
            // NOTE: It will use the Scema as defined in the Data and Models folders
            var dbContext = new ApplicationDbContext(options);

            // Add entities to the inmemory database
            dbContext.SeedData();

            return dbContext;
        }

        internal static readonly SubCategory[] TestData_Subcategories
            = {
                new SubCategory
                {
                    SubcategoryId = 1,
                    SubcategoryName = "BreakFast"
                },
                new SubCategory
                {
                     SubcategoryId = 1,
                    SubcategoryName = "Lunch"
                },
                new SubCategory
                {
                     SubcategoryId = 1,
                    SubcategoryName = "Dinner"
                }
            };

        /// <summary>
        ///     An extension Method for the DbContext object.
        /// </summary>
        /// <param name="context"></param>
        private static void SeedData(this ApplicationDbContext context)
        {
            context.Subcategories.AddRange(TestData_Subcategories);

            context.SaveChanges();
        }
    }
}
