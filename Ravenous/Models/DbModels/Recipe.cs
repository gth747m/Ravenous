using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeStep = new HashSet<RecipeStep>();
            RecipeTag = new HashSet<RecipeTag>();
        }

        public int PkRecipe { get; set; }
        [Required, Display(Name = "Recipe"), StringLength(128)]
        public string RecipeName { get; set; }
        [Required, Display(Name = "Prep Time")]
        public TimeSpan PrepTime { get; set; }
        [Required, Display(Name = "Cook Time")]
        public TimeSpan CookTime { get; set; }
        [Display(Name = "Recipe Type")]
        public int FkRecipeType { get; set; }
        [Display(Name = "Rating")]
        public int? Rating { get; set; }

        [Display(Name = "Recipe Type")]
        public virtual RecipeType RecipeType { get; set; }
        public virtual ICollection<RecipeStep> RecipeStep { get; set; }
        public virtual ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
