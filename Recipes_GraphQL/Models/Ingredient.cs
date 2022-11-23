using System.ComponentModel.DataAnnotations;

namespace Recipes_GraphQL.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int WholeQty { get; set; } = 1;
        public int Numerator { get; set; } = 0;
        public int Denominator { get; set; } = 1;
        public string Measurement { get; set; } = string.Empty;
        public override string ToString() => Numerator == 0 ?
            $"{WholeQty} {Measurement} {Name}" :
            (WholeQty > 0 ?
                $"{WholeQty} {Numerator}/{Denominator} {Measurement} {Name}" :
                $"{Numerator}/{Denominator} {Measurement} {Name}");
    }
}
