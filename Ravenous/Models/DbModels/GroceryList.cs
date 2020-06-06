using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class GroceryList
    {
        public int PkGroceryList { get; set; }
        [Display(Name = "Ingredient")]
        public int FkIngredient { get; set; }
        [Required, Display(Name = "Amount")]
        public float IngredientAmount { get; set; }
        [Display(Name = "Measurement")]
        public int FkMeasurement { get; set; }

        [Display(Name = "Ingredient")]
        public virtual Ingredient Ingredient { get; set; }
        [Display(Name = "Measurement")]
        public virtual Measurement Measurement { get; set; }
    }
}
