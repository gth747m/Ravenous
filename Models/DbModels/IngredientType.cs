using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class IngredientType
    {
        public IngredientType()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int PkIngredientType { get; set; }
        [Required, Display(Name = "Ingredient Type")]
        public string IngredientTypeName { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
