using AspFoodProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspFoodProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
               : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> Subcategories { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Competition> Events { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<AspFoodProject.Models.Registeration> Registeration { get; set; }


    }
}
