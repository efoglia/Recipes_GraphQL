using Microsoft.EntityFrameworkCore;
using Recipes_GraphQL.Data;
using Recipes_GraphQL.Models;

namespace Recipes_GraphQL.Services
{
    public class RecipeService : IRecipeService
    {

        private readonly RecipesContext _dbContext;

        public RecipeService(IDbContextFactory<RecipesContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public List<Recipe> GetAllRecipes()
        {
            var recipes = _dbContext.Recipes;

            if (recipes == null)
            {
                return new List<Recipe>();
            }

            return recipes.ToList();
        }
    }
}
