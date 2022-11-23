using Recipes_GraphQL.Models;
using HotChocolate;

namespace Recipes_GraphQL.Data
{

    public class InvalidNameException : Exception
    {
        public InvalidNameException()
            : base($"The recipe name may not contain a link.")
        {
        }
    }

    public class Mutation
    {
        [Error(typeof(InvalidNameException))]
        public Recipe? UpdateRecipeName([Service] RecipesContext context, [ID] int id, string name)
        {
            if (name.Contains(".com"))
            {
                throw new InvalidNameException();
            }
            var recipe = context.Recipes?.FirstOrDefault(rec => rec.Id == id);

            if (recipe is null)
                return null;

            recipe.Name = name;
            context.SaveChanges();
            return recipe;
        }

        public Recipe? UpdateRecipeDescription([Service] RecipesContext context, [ID] int id, string description)
        {
            var recipe = context.Recipes?.FirstOrDefault(rec => rec.Id == id);

            if (recipe is null)
                return null;

            recipe.Description = description;
            context.SaveChanges();
            return recipe;
        }
    }
}
