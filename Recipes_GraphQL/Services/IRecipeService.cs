using Recipes_GraphQL.Models;

namespace Recipes_GraphQL.Services
{
    public interface IRecipeService
    {
        List<Recipe> GetAllRecipes();
    }
}
