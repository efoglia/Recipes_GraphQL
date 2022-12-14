using Microsoft.EntityFrameworkCore;
using Recipes_GraphQL.Models;

namespace Recipes_GraphQL.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<Recipe>? Recipes { get; set; }

        public static async Task CheckAndSeedDatabaseAsync(RecipesContext context)
        {
            if (await context.Database.EnsureCreatedAsync())
            {
                var recipes = Seed.GetRecipes();
                if (context.Recipes!= null)
                {
                    context.Recipes.AddRange(recipes);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .OwnsMany(r => r.Ingredients);

            modelBuilder.Entity<Recipe>()
                .OwnsMany(r => r.Steps);

            base.OnModelCreating(modelBuilder);
        }
    }
}
