using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class RecipeTag
    {
        public int PkRecipeTag { get; set; }
        [Display(Name = "Recipe")]
        public int FkRecipe { get; set; }
        [Display(Name = "Tag")]
        public int FkTag { get; set; }

        [Display(Name = "Recipe")]
        public virtual Recipe Recipe { get; set; }
        [Display(Name = "Tag")]
        public virtual Tag Tag { get; set; }
    }
}
