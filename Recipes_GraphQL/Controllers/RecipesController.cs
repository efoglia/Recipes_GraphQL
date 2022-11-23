using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipes_GraphQL.Data;
using Recipes_GraphQL.Models;
using Recipes_GraphQL.Services;

namespace Recipes_GraphQL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAll()
        {
            return Ok(_recipeService.GetAllRecipes());
        }
    }
}
