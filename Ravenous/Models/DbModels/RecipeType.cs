using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class RecipeType
    {
        public RecipeType()
        {
            Recipe = new HashSet<Recipe>();
        }

        public int PkRecipeType { get; set; }
        [Required, Display(Name = "Recipe Type"), StringLength(64)]
        public string RecipeTypeName { get; set; }

        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
