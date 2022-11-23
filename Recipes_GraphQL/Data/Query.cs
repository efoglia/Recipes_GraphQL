using Recipes_GraphQL.Models;
using Recipes_GraphQL.Services;
using HotChocolate;

namespace Recipes_GraphQL.Data
{
    public class Query
    {
        private readonly IRecipeService _recipeService;
        public Query(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetAllRecipes();
        }
    }
}
