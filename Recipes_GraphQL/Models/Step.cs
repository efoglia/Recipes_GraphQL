using System.ComponentModel.DataAnnotations;

namespace Recipes_GraphQL.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; } = 0;
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
        public string Instructions { get; set; } = string.Empty;
        public override string ToString() => $"Step #{Order}";
    }
}
