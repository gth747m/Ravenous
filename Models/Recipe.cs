
using System.Collections.Generic;

namespace Ravenous.Models
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set;}

    }
}
