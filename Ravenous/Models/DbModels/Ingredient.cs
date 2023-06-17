using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipieIngredients = new HashSet<IngredientAssignment>();
        }

        public int IngredientId { get; set; }
        [Required, Display(Name="Ingredient")]
        public string Name { get; set; }

        public ICollection<IngredientAssignment> RecipieIngredients { get; set; }
    }
}