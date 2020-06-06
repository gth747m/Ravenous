using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            GroceryList = new HashSet<GroceryList>();
            RecipeIngredient = new HashSet<RecipeIngredient>();
        }

        public int PkIngredient { get; set; }
        [Required, Display(Name = "Ingredient Name"), StringLength(64)]
        public string IngredientName { get; set; }
        [Display(Name = "Ingredient Type")]
        public int FkIngredientType { get; set; }

        [Display(Name = "Ingredient Type")]
        public virtual IngredientType IngredientType { get; set; }
        public virtual ICollection<GroceryList> GroceryList { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
