using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Recipes_GraphQL.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Step> Steps { get; set; } = new List<Step>();
        [UseSorting]
        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public override string ToString() => $"{Name}: {Description}";
    }
}
