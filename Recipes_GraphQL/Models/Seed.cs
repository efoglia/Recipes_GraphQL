namespace Recipes_GraphQL.Models
{
    public class Seed
    {
        public static List<Recipe> GetRecipes()
        {
            List<Ingredient> ingredients = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Name = "Food"
                },
                new Ingredient()
                {
                    Name = "Love"
                }
            };
            List<Step> steps = new List<Step>()
            {
                new Step()
                {
                    Order = 1,
                    Instructions = "Gather ingredients"
                },
                new Step()
                {
                    Order = 2,
                    Instructions = "Cook recipe"
                }
            };
            Recipe someRecipe = new Recipe()
            {
                Name = "Regular Recipe",
                Description = "How to always cook a good meal",
                Steps = steps,
                Ingredients = ingredients
            };

            return new List<Recipe>() { someRecipe };
        }
    }
}
