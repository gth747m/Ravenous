using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Ravenous.Models.DbModels
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<IngredientAssignment>();
            Instructions = new HashSet<Instruction>();
        }

        public int RecipeId { get; set; }
        [Required, Display(Name="Recipe")]
        public string Name { get; set; }
        [Required, Range(1.0, 5.0), Display(Name="Rating")]
        public int Rating { get; set; }
        [Required, Display(Name="Prep Time"), 
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime PrepTime { get; set; }
        [Required, Display(Name="Cook Time"),
            DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime CookTime { get; set; }

        public virtual ICollection<IngredientAssignment> RecipeIngredients { get; set;}
        public virtual ICollection<Instruction> Instructions { get; set; }
    }
}
