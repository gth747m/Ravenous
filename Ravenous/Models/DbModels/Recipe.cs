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
        [Required, DataType(DataType.Time),
            DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = @"{0:hh\:mm}"),
            Display(Name = "Prep Time")]
        public TimeSpan PrepTime { get; set; }
        [Required, DataType(DataType.Time),
            DisplayFormat(ApplyFormatInEditMode = true,
            DataFormatString = @"{0:hh\:mm}"),
            Display(Name = "Cook Time")]
        public TimeSpan CookTime { get; set; }
        [Display(Name = "Recipe Type")]
        public int FkRecipeType { get; set; }
        [Display(Name = "Rating"), Range(0, 10)]
        public int? Rating { get; set; }

        [Display(Name = "Recipe Type")]
        public virtual RecipeType RecipeType { get; set; }
        [Display(Name = "Recipe Steps")]
        public virtual ICollection<RecipeStep> RecipeStep { get; set; }
        [Display(Name = "Recipe Tags")]
        public virtual ICollection<RecipeTag> RecipeTag { get; set; }
    }
}
