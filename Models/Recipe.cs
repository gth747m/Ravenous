
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int RecipeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Range(0.0, 5.0)]
        public int Rating { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set;}

    }
}
