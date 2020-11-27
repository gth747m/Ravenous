using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ravenous.Models.DbModels
{
    public partial class RecipeStep
    {
        public int PkRecipeStep { get; set; }
        [Display(Name = "Recipe")]
        public int FkRecipe { get; set; }
        [Required, Display(Name = "Step")]
        public int RecipeStepNumber { get; set; }
        [Required, Display(Name = "Instruction"), StringLength(512)]
        public string RecipeStepInstruction { get; set; }

        [Display(Name = "Recipe")]
        public virtual Recipe Recipe { get; set; }
    }
}
