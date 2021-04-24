using System.Collections.Generic;

namespace Ravenous.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipieIngredients = new HashSet<RecipeIngredient>();
        }

        public int IngredientId { get; set; }
        public string Name { get; set; }

        public ICollection<RecipeIngredient> RecipieIngredients { get; set; }
    }
}